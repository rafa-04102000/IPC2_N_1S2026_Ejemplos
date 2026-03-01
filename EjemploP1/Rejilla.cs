using System;
using System.Diagnostics; // Necesario para Process.Start
using System.IO;          // Necesario para manejar Archivos

namespace EjemploP1;

public class Rejilla
{
    public Casilla Raiz;

    public int NumeroPeriodo;

    public int TamanoRejilla;

    public Rejilla(int numeroPeriodo, int tamanoRejilla)
    {
        NumeroPeriodo = numeroPeriodo;
        TamanoRejilla = tamanoRejilla;
        Raiz = null;
    }

    public void append(Casilla nuevaCasilla)
    {
        if (Raiz == null)
        {
            Raiz = nuevaCasilla;
        }
        else
        {
            Casilla? actual = Raiz;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevaCasilla;
            nuevaCasilla.Anterior = actual;
        }
    }

    // Print de la Rejilla
    public void printRejilla()
    {
        Casilla aux = Raiz;
        string cadena = "";

        for (int fila = 1; fila <= TamanoRejilla; fila++)
        {
            for (int columna = 1; columna <= TamanoRejilla; columna++)
            {
                if (columna == TamanoRejilla)
                {
                    cadena += $"{aux.Condicion}";
                    aux = aux.Siguiente;
                }
                else
                {
                    cadena += $"{aux.Condicion} ";
                    aux = aux.Siguiente;
                }
            }
            Console.WriteLine(cadena);
            cadena = "";
        }

    }


    public void graficarRejillaV1(string nombreTablero)
    {
        // Crear una carpeta
        string baseDir = AppContext.BaseDirectory;

        // Resultados dentro de esa carpeta
        string carpetaResultados = Path.Combine(baseDir, $"Resultados/{nombreTablero}");
        Directory.CreateDirectory(carpetaResultados);
        // si ya existe la carpeta no se hace nada, si no existe se crea

        // nombre sin extensión
        string nombreBase = $"Periodo_{NumeroPeriodo}";
        string dotPath = Path.Combine(carpetaResultados, $"{nombreBase}.dot");
        string pngPath = Path.Combine(carpetaResultados, $"{nombreBase}.png");
        // string nombreArchivo = $"Resultados/{nombreTablero}_Periodo_{NumeroPeriodo}";
        // Armare la cadena con el contendido de la grafica de graphviz, para luego escribirla en un archivo .dot y luego generar la imagen con graphviz

        Casilla? aux = Raiz;
        string cadena = """
                digraph G {
              // ===== FONDO GENERAL =====
                graph [
                    rankdir=LR,
                    bgcolor="#07131F",
                    pad="0.25",
                    fontname="Arial"
                ]

                node [fontname="Arial"]
                edge [color="#274457"]

                  // ===== PANEL PRINCIPAL =====
                subgraph cluster1 {
                    label="Rejilla"
                    labelloc="t"
                    fontsize=28
                    fontcolor="#EAF6FF"
                    style="rounded,filled"
                    color="#1F3A4C"
                    fillcolor="#0A1C2B"
                    penwidth=2

                    // ===== NODO MATRIZ =====
                    a0 [
                    shape=plain,
                    margin=0,
                    label=<
                        <TABLE border="0" cellborder="1" cellspacing="0" cellpadding="8" bgcolor="#0A1C2B" color="#1F3A4C">

        """;
        // Titulo dependiendo del numero de periodo
        if (NumeroPeriodo == 0)
        {
            cadena += $"""
                    <!-- ===== BARRA DE TÍTULO (tipo header) ===== -->
                    <TR>
                        <TD colspan="{TamanoRejilla}" bgcolor="#0D2436" color="#1F3A4C"  cellpadding="14">
                        <FONT color="white">PATRÓN INICIAL</FONT>
                        </TD>
                    </TR>
            """;
            cadena += "\n\n";
        }
        else
        {
            cadena += $"""
                    <!-- ===== BARRA DE TÍTULO (tipo header) ===== -->
                    <TR>
                        <TD colspan="{TamanoRejilla}" bgcolor="#0D2436" color="#1F3A4C"  cellpadding="14">
                        <FONT color="white">PERIODO {NumeroPeriodo}</FONT>
                        </TD>
                    </TR>
            """;
        }

        // Inicio del contenido de la tabla
        for (int fila = 1; fila <= TamanoRejilla; fila++)
        {
            cadena += "<TR>\n";
            for (int columna = 1; columna <= TamanoRejilla; columna++)
            {
                string colorCelda = aux.Condicion == 0 ? "#0B263A" : "#5FB9D4";
                cadena += $"<TD  bgcolor=\"{colorCelda}\">&nbsp;</TD>\n";
                aux = aux.Siguiente;
            }
            cadena += "</TR>\n\n";

            // fin del contenido de la tabla


        }
        cadena += """
                        </TABLE>
                        >
                    ]
                }
            }
        """;

        // creacion del archivo .dot con la cadena y luego generar la imagen con graphviz
        File.WriteAllText(dotPath, cadena);

        var startInfo = new ProcessStartInfo
        {
            FileName = "dot",
            // comillas por si hay espacios
            Arguments = $"-Tpng \"{dotPath}\" -o \"{pngPath}\"",
            UseShellExecute = false,
            RedirectStandardError = true,
            CreateNoWindow = true
        };

        using (var p = Process.Start(startInfo))
        {
            string err = p.StandardError.ReadToEnd();
            p.WaitForExit();

            if (p.ExitCode != 0 || !File.Exists(pngPath))
                throw new Exception($"Graphviz falló. ExitCode={p.ExitCode}\n{err}");
        }

        // Borro los .dot ya que no nos serviran
        if (File.Exists(dotPath))
        {
            File.Delete(dotPath);
        }
        // abrir con ruta absoluta
        Process.Start(new ProcessStartInfo(pngPath) { UseShellExecute = true });

    }

}
