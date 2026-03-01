using System;

namespace EjemploP1;

public class ListaPeriodos
{
    Periodo? Raiz;

    Rejilla? PatronInicial;

    public ListaPeriodos(Rejilla patronInicial)
    {
        PatronInicial = patronInicial;
        Raiz = null;
    }

    public void append(Periodo nuevoPeriodo)
    {
        if (Raiz == null)
        {
            Raiz = nuevoPeriodo;
        }
        else
        {
            Periodo? actual = Raiz;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            nuevoPeriodo.Anterior = actual;
            actual.Siguiente = nuevoPeriodo;
        }
    }


    public void realizarPeriodos(string nombreTablero, int numeroPeriodos)
    {
        PatronInicial.graficarRejillaV1(nombreTablero);

        if (Raiz == null)
        {
            Raiz = new Periodo(PatronInicial);
        }

        int numeroDePeriodo = 1;

        int tamano_matriz = PatronInicial.TamanoRejilla;

        // auxiliar, para ir cambiando patrones
        Rejilla nodoAux = PatronInicial;

        while (true)
        {
            // este auxiliar recorrela las caillas de la rejilla
            Casilla? nodoAux2 = nodoAux.Raiz;

            // nueva Rejilla para el nuevo periodo
            Rejilla nuevaRejilla = new Rejilla(numeroDePeriodo, tamano_matriz);

            // de igual forma tendra una matriz de m x m
            // evaluaremos la nueva matriz, con los valores de la matriz anterior

            for (int fila_evaluar = 1; fila_evaluar <= tamano_matriz; fila_evaluar++)
            {
                for (int columna_evaluar = 1; columna_evaluar <= tamano_matriz; columna_evaluar++)
                {
                    // veo la condicion actual de la casilla 0 o 1
                    int condicionCasilla = nodoAux2.Condicion;

                    // mnado, tamano de la matriz, posicion en la que estoy evaluando fila y columna, y la rejilla actual para evaluar las vecinas
                    int cantidadVecinasEn1 = verificarVecinas(tamano_matriz, fila_evaluar, columna_evaluar, nodoAux);

                    if (condicionCasilla == 1)
                    {
                        // Si la casilla actual es 1 y alrededor tiene 0 vecinas en 1 ⇒ pasa a 0.
                        if (cantidadVecinasEn1 == 0)
                        {
                            nuevaRejilla.append(new Casilla(fila_evaluar, columna_evaluar, 0));
                        }
                        else
                        {
                            nuevaRejilla.append(new Casilla(fila_evaluar, columna_evaluar, 1));
                        }
                    }
                    else if (condicionCasilla == 0)
                    {
                        // Si la casilla actual es 0 y tiene 2 o más vecinas en 1 ⇒ pasa a 1. 
                        if (cantidadVecinasEn1 >= 2)
                        {
                            nuevaRejilla.append(new Casilla(fila_evaluar, columna_evaluar, 1));
                        }
                        else
                        {
                            nuevaRejilla.append(new Casilla(fila_evaluar, columna_evaluar, 0));
                        }
                    }
                    // En cualquier otro caso ⇒ se mantiene.

                    // pasamos a la siguiente casilla
                    nodoAux2 = nodoAux2.Siguiente;
                }
            }

            // grafico la nueva rejilla
            nuevaRejilla.graficarRejillaV1(nombreTablero);

            // agrego el nuevo periodo a la lista de periodos
            Periodo nuevoPeriodo = new Periodo(nuevaRejilla);
            this.append(nuevoPeriodo);

            // aca harian ellos la verificacion de si el patron ya se repitio

            if (numeroDePeriodo == numeroPeriodos)
            {
                break;
            }
            numeroDePeriodo++;

            // cambio la rejilla anterior por la nueva rejilla, para seguir evaluando los siguientes periodos
            nodoAux = nuevaRejilla;
        }
    }


    public int verificarVecinas(int tamano_matriz, int fila_evaluar, int columna_evaluar, Rejilla rejilaActual)
    {
        // Si la casilla actual es 0 y tiene 2 o más vecinas en 1 ⇒ pasa a 1.
        // Si la casilla actual es 1 y alrededor tiene 0 vecinas en 1 ⇒ pasa a 0.
        // En cualquier otro caso ⇒ se mantiene.

        // auxiliar para ir recorriendo las casillas de la rejilla actual
        Casilla? nodoAux = rejilaActual.Raiz;

        // este valor retornaremos, sera la cantidad de vecinas en 1 que tiene la casilla que estamos evaluando
        int cantidadVecinasEn1 = 0;

        // si estoy en la fila 2 y columna 2, entonces tengo 8 vecinas
        // si estoy en la fila 1 y columna 1, entonces tengo 3 vecinas, aca en la validacion pues vere si existe esa fila y columna, para no salir de la matriz
        // en si todas las casillas en las esquinas o bordes, tendran esa validacion para no salir de la matriz
        // evaluo 8 posiciones, que son las vecinas, si estan en los bordes o esquinas, cuando evalue la fila y columna no existira por lo cual solo me quedaran las vecinas que si existen, y asi sucesivamente para cada casilla

        for (int fila = 1; fila <= tamano_matriz; fila++)
        {
            for (int columna = 1; columna <= tamano_matriz; columna++)
            // estos dos for son solo para iterar en el auxiliar, para ir cambiando al siguiente nodo, hasta llegar a la casilla que estoy evaluando, y asi evaluar sus vecinas
            {
                // celda de la esquina superior izquierda
                if (nodoAux.Fila == (fila_evaluar - 1) && nodoAux.Columna == (columna_evaluar - 1))
                {
                    if (nodoAux.Condicion == 1)
                    {
                        cantidadVecinasEn1++;
                    }
                }
                // celda izquierda
                else if (nodoAux.Fila == (fila_evaluar - 1) && nodoAux.Columna == columna_evaluar)
                {
                    if (nodoAux.Condicion == 1)
                    {
                        cantidadVecinasEn1++;
                    }
                }
                // celda inferiosr izquierda
                else if (nodoAux.Fila == (fila_evaluar - 1) && nodoAux.Columna == (columna_evaluar + 1))
                {
                    if (nodoAux.Condicion == 1)
                    {
                        cantidadVecinasEn1++;
                    }
                }
                // celda central superior
                else if (nodoAux.Fila == fila_evaluar && nodoAux.Columna == (columna_evaluar - 1))
                {
                    if (nodoAux.Condicion == 1)
                    {
                        cantidadVecinasEn1++;
                    }
                }
                // celda central inferior
                else if (nodoAux.Fila == fila_evaluar && nodoAux.Columna == (columna_evaluar + 1))
                {
                    if (nodoAux.Condicion == 1)
                    {
                        cantidadVecinasEn1++;
                    }
                }
                // celda de la esquina superior derecha
                else if (nodoAux.Fila == (fila_evaluar + 1) && nodoAux.Columna == (columna_evaluar - 1))
                {
                    if (nodoAux.Condicion == 1)
                    {
                        cantidadVecinasEn1++;
                    }
                }
                // celda derecha
                else if (nodoAux.Fila == (fila_evaluar + 1) && nodoAux.Columna == columna_evaluar)
                {
                    if (nodoAux.Condicion == 1)
                    {
                        cantidadVecinasEn1++;
                    }
                }
                // celda de la esquina inferior derecha
                else if (nodoAux.Fila == (fila_evaluar + 1) && nodoAux.Columna == (columna_evaluar + 1))
                {
                    if (nodoAux.Condicion == 1)
                    {
                        cantidadVecinasEn1++;
                    }
                }
                nodoAux = nodoAux.Siguiente;
            }
        }
        return cantidadVecinasEn1;
    }
}