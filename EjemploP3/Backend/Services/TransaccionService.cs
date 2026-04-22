using Backend.Models;
using Backend.Repositories;
using System.Globalization;
using System.Text;
using System.Xml.Linq;
namespace Backend.Services
{
    public class TransaccionService
    {
        private readonly RepositorioTienda _repositorio;

        public TransaccionService(RepositorioTienda repositorio)
        {
            _repositorio = repositorio;
        }

        public string ProcesarTransacciones(string xmlContent)
        {
            XDocument doc = XDocument.Parse(xmlContent);

            // Contadores para el reporte
            int nuevasFacturas = 0, facturasDuplicadas = 0, facturasConError = 0;
            int nuevosPagos = 0, pagosDuplicados = 0, pagosConError = 0;

            // 1. PROCESAR FACTURAS
            var facturasXml = doc.Root?.Element("facturas")?.Elements("factura");
            if (facturasXml != null)
            {
                foreach (var fXml in facturasXml)
                {
                    try
                    {
                        string numero = fXml.Element("numeroFactura")?.Value ?? "";
                        string nit = fXml.Element("NITcliente")?.Value ?? "";
                        string fechaStr = fXml.Element("fecha")?.Value ?? "";
                        decimal valor = decimal.Parse(fXml.Element("valor")?.Value ?? "0");

                        // Validaciones de Error
                        bool clienteExiste = _repositorio.Clientes.Any(c => c.NIT == nit);
                        bool fechaValida = DateTime.TryParseExact(fechaStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha);

                        if (!clienteExiste || !fechaValida || valor < 0)
                        {
                            facturasConError++;
                            continue;
                        }

                        // Validación de Duplicados
                        //bool esDuplicada = _repositorio.Facturas.Any(f => f.NumeroFactura == numero && f.NITCliente == nit && f.Fecha == fecha && f.Valor == valor);
                        //if (esDuplicada)
                        //{
                        //    facturasDuplicadas++;
                        //    continue;
                        //}
                        // con el NumeroFactura debería ser suficiente para identificar una factura, no necesito validar todos los campos
                        // Validación de Duplicados (Mejorada)
                        bool esDuplicada = _repositorio.Facturas.Any(f => f.NumeroFactura == numero);
                        if (esDuplicada)
                        {
                            facturasDuplicadas++;
                            continue;
                        }

                        // Registro de Factura Nueva
                        _repositorio.Facturas.Add(new Factura
                        {
                            NumeroFactura = numero,
                            NITCliente = nit,
                            Fecha = fecha,
                            Valor = valor,
                            SaldoPendiente = valor,
                            Pagada = false
                        });
                        nuevasFacturas++;
                    }
                    catch { facturasConError++; }
                }
            }

            // 2. PROCESAR PAGOS Y LOGICA DE ABONOS
            var pagosXml = doc.Root?.Element("pagos")?.Elements("pago");
            if (pagosXml != null)
            {
                foreach (var pXml in pagosXml)
                {
                    try
                    {
                        string codBanco = pXml.Element("codigoBanco")?.Value ?? "";
                        string nit = pXml.Element("NITcliente")?.Value ?? "";
                        string fechaStr = pXml.Element("fecha")?.Value ?? "";
                        decimal montoPago = decimal.Parse(pXml.Element("valor")?.Value ?? "0");

                        // Validaciones de Error
                        var cliente = _repositorio.Clientes.FirstOrDefault(c => c.NIT == nit);
                        bool bancoExiste = _repositorio.Bancos.Any(b => b.Codigo == codBanco);
                        bool fechaValida = DateTime.TryParseExact(fechaStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fechaPago);

                        if (cliente == null || !bancoExiste || !fechaValida || montoPago < 0)
                        {
                            pagosConError++;
                            continue;
                        }

                        // Validación de Duplicados
                        bool esDuplicado = _repositorio.Pagos.Any(p => p.NITCliente == nit && p.Fecha == fechaPago && p.Valor == montoPago);
                        if (esDuplicado)
                        {
                            pagosDuplicados++;
                            continue;
                        }

                        // --- LOGICA DE ABONO A FACTURAS ---
                        decimal remanente = cliente.SaldoAFavor + montoPago;
                        // El remanente es el dinero del pago que va viajando
                        // de factura en factura hasta agotarse o convertirse en saldo a favor
                        // debo limpiar el saldo a favor del cliente porque se va a usar para pagar facturas
                        cliente.SaldoAFavor = 0;
                        // si vuelve a sobrar se lo vuelo a añadir como saldo a favor

                        // Buscamos facturas no pagadas del cliente, ordenadas por fecha (más antigua primero)
                        var facturasPendientes = _repositorio.Facturas
                            .Where(f => f.NITCliente == nit && !f.Pagada)
                            .OrderBy(f => f.Fecha)
                            .ToList();

                        foreach (var factura in facturasPendientes)
                        {
                            if (remanente <= 0) break;

                            if (remanente >= factura.SaldoPendiente)
                            {
                                remanente -= factura.SaldoPendiente;
                                factura.SaldoPendiente = 0;
                                factura.Pagada = true;
                            }
                            else
                            {
                                factura.SaldoPendiente -= remanente;
                                remanente = 0;
                            }
                        }

                        // Si sobra dinero después de pagar facturas, va al Saldo a Favor
                        if (remanente > 0)
                        {
                            cliente.SaldoAFavor += remanente;
                        }

                        // Registrar el pago
                        _repositorio.Pagos.Add(new Pago
                        {
                            CodigoBanco = codBanco,
                            NITCliente = nit,
                            Fecha = fechaPago,
                            Valor = montoPago
                        });
                        nuevosPagos++;
                    }
                    catch { pagosConError++; }
                }
            }

            // 3. GENERAR XML DE RESPUESTA
            XDocument respuestaXML = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("transacciones",
                    new XElement("facturas",
                        new XElement("nuevasFacturas", nuevasFacturas),
                        new XElement("facturasDuplicadas", facturasDuplicadas),
                        new XElement("facturasConError", facturasConError)
                    ),
                    new XElement("pagos",
                        new XElement("nuevosPagos", nuevosPagos),
                        new XElement("pagosDuplicados", pagosDuplicados),
                        new XElement("pagosConError", pagosConError)
                    )
                )
            );

            string declaracion = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n";
            return declaracion + respuestaXML.ToString();
        }
    }
}
