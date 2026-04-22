using Backend.Repositories;

namespace Backend.Services
{
    public class ConsultaService
    {
        private readonly RepositorioTienda _repositorio;

        public ConsultaService(RepositorioTienda repositorio)
        {
            _repositorio = repositorio;
        }

        // Obtiene todos los clientes ordenados por NIT
        public object ObtenerTodosLosClientes()
        {
            return _repositorio.Clientes
                .OrderBy(c => c.NIT)
                .Select(c => new {
                    c.NIT,
                    c.Nombre,
                    SaldoFavor = c.SaldoAFavor
                })
                .ToList();
        }

        // Obtiene el estado de cuenta detallado de un cliente
        public object? ObtenerEstadoCuenta(string nit)
        {
            var cliente = _repositorio.Clientes.FirstOrDefault(c => c.NIT == nit);
            if (cliente == null) return null;

            // Mapeamos Facturas a formato de "Cargo"
            var cargos = _repositorio.Facturas
                .Where(f => f.NITCliente == nit)
                .Select(f => new {
                    f.Fecha,
                    Cargo = $"Q. {f.Valor:N2} (Fact. # {f.NumeroFactura})",
                    Abono = "",
                    FechaSort = f.Fecha // Para ordenar al final
                });

            // Mapeamos Pagos a formato de "Abono"
            var abonos = _repositorio.Pagos
                .Where(p => p.NITCliente == nit)
                .Select(p => new {
                    p.Fecha,
                    Cargo = "",
                    Abono = $"Q. {p.Valor:N2} (Banco {NombreBanco(p.CodigoBanco)})",
                    FechaSort = p.Fecha
                });

            // Unimos y ordenamos de más reciente a más antigua
            var historial = cargos.Concat(abonos)
            .OrderByDescending(t => t.FechaSort) // Primero por fecha (más reciente arriba)
            //.ThenBy(t => t.Abono)               // Luego, los que tienen Abono vacío (Cargos) van primero
            .Select(t => new {
                Fecha = t.Fecha.ToString("dd/MM/yyyy"),
                t.Cargo,
                t.Abono
            })
            .ToList();
            // aca junto las dos listas de objetos
            // las ordeno de forma descendente por fecha
            // selecciono solo las propiedades necesarias para la respuesta final
            // esto aparecerea ordenado de la fecha mas reciente a la mas antigua
            // entonces siempre se mostrara lo ultimo que se hizo
            // como el pago que seria el abono se mostrara arriba, y la factura que seria el cargo, se mostrara debajo

            return new
            {
                Cliente = $"{cliente.NIT} - {cliente.Nombre}",
                SaldoActual = $"Q. {cliente.SaldoAFavor:N2}",
                Transacciones = historial
            };
        }

        public object ObtenerIngresosPorBanco(int mes, int anio)
        {
            // 1. Definir la fecha límite (Fin del mes seleccionado)
            DateTime fechaFin = new DateTime(anio, mes, 1).AddMonths(1).AddDays(-1);
            // 2. Definir la fecha de inicio (3 meses atrás desde el inicio del mes seleccionado)
            DateTime fechaInicio = new DateTime(anio, mes, 1).AddMonths(-2);

            // 3. Filtrar pagos en ese rango de 3 meses
            var ingresosAgrupados = _repositorio.Pagos
                .Where(p => p.Fecha >= fechaInicio && p.Fecha <= fechaFin)
                .GroupBy(p => new {
                    p.CodigoBanco,
                    Mes = p.Fecha.Month,
                    Anio = p.Fecha.Year
                })
                .Select(grupo => {
                    var banco = _repositorio.Bancos.FirstOrDefault(b => b.Codigo == grupo.Key.CodigoBanco);
                    string nombreBanco = banco?.Nombre ?? $"Banco {grupo.Key.CodigoBanco}";

                    string nombreMes = new DateTime(grupo.Key.Anio, grupo.Key.Mes, 1)
                                        .ToString("MMMM", new System.Globalization.CultureInfo("es-GT"));

                    return new
                    {
                        Banco = nombreBanco,
                        Periodo = $"{nombreMes} {grupo.Key.Anio}",
                        Total = grupo.Sum(p => p.Valor),
                        FechaParaOrden = new DateTime(grupo.Key.Anio, grupo.Key.Mes, 1)
                    };
                })
                .OrderBy(res => res.FechaParaOrden)
                .ToList();

            return ingresosAgrupados;
        }

        public string NombreBanco(string codigo)
        {
            var banco = _repositorio.Bancos.FirstOrDefault(b => b.Codigo == codigo);
            return banco?.Nombre ?? codigo;
        }

    }
}
