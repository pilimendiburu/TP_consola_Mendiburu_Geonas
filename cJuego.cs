using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP_consola_Mendiburu_Geonas
{
    class cJuego
    {
        int cant_tableros_a_generar;//a hacer
        int cant_tab_generados;//ya hechos
        cTablero matriz_alfil;
        Amenazas casillas_amenazadas;
        cTablero pos_piezas;
        Amenazas cant_amenazasxCasillas;
        public Pieza[] arrayPiezas;

        public void GenerarTableros()
        {
            cant_tab_generados = 0;
            //poner matrices en 0
            while (cant_tab_generados < cant_tableros_a_generar)//-> necesito completar n tableros
            {
                pos_piezas = new cTablero();
                casillas_amenazadas = new Amenazas();
                cant_amenazasxCasillas = new Amenazas();
                //---------------------------------------------------------
                //TORRE1
                arrayPiezas[2].pos.EleccionAlAzar();
                casillas_amenazadas.AmenazasMovimientoTorre(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[2], true);
                pos_piezas.tablero[arrayPiezas[2].pos.fila, arrayPiezas[2].pos.columna] = (int)arrayPiezas[2].tipoPieza;
                /*Console.WriteLine("\nPosicion piezas:");
                pos_piezas.ImprimirTablero();*/
                //casillas_amenazadas.ImprimirTablero();
                //cant_amenazasxCasillas.ImprimirTablero();
                //TORRE 2:
                cPosicion aux = new cPosicion();
                aux = arrayPiezas[2].pos;//le cambie pq sino nunca entraba al while
                while (pos_piezas.tablero[aux.fila, aux.columna] != 0 && aux.fila == arrayPiezas[2].pos.fila && arrayPiezas[2].pos.columna == aux.columna)
                {
                    aux.EleccionAlAzar();
                }
                arrayPiezas[3].pos = aux;

                if (pos_piezas.tablero[aux.fila, aux.columna] == 0)
                {
                    pos_piezas.tablero[aux.fila, aux.columna] = 5;//torre2
                                                                  //COMPLETO POSICIONES AMENAZADAS CON EL CABALLO DESDE POSICION PROPUESTA
                    casillas_amenazadas.AmenazasMovimientoTorre(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[3], true);
                }
                /*Console.WriteLine("\nPosicion piezas:");
                pos_piezas.ImprimirTablero();*/
                //casillas_amenazadas.ImprimirTablero();
                //cant_amenazasxCasillas.ImprimirTablero();

                //ALFIL 1
                while (pos_piezas.tablero[aux.fila, aux.columna] != 0 || matriz_alfil.tablero[aux.fila, aux.columna] != 1)//condicion para ver si se puede mover el alfil{
                {
                    aux.EleccionAlAzar();
                }
                pos_piezas.tablero[aux.fila, aux.columna] = 6;//alfil 1
                arrayPiezas[4].pos = aux;
                casillas_amenazadas.AmenazasMovimientoAlfil(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[4], true);
                /*Console.WriteLine("\nPosicion piezas:");
                pos_piezas.ImprimirTablero();*/
                //casillas_amenazadas.ImprimirTablero();
                //cant_amenazasxCasillas.ImprimirTablero();
                //ALFIL 2
                while (pos_piezas.tablero[aux.fila, aux.columna] != 0 && matriz_alfil.tablero[aux.fila, aux.columna] != 2)//condicion para ver si se puede mover el alfil{
                {
                    aux.EleccionAlAzar();
                }
                pos_piezas.tablero[aux.fila, aux.columna] = 7;//alfil 2
                arrayPiezas[5].pos = aux;
                casillas_amenazadas.AmenazasMovimientoAlfil(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[5], true);
               /* Console.WriteLine("\nPosicion piezas:");
                pos_piezas.ImprimirTablero();*/
                //casillas_amenazadas.ImprimirTablero();
                //cant_amenazasxCasillas.ImprimirTablero();
                //REINA

                while (pos_piezas.tablero[aux.fila, aux.columna] != 0
                    || (casillas_amenazadas.tablero[aux.fila, aux.columna] == 6 ||
                    casillas_amenazadas.tablero[aux.fila, aux.columna] == 2) && ((aux.columna == arrayPiezas[2].pos.columna ||
                    aux.fila == arrayPiezas[2].pos.fila) || (aux.columna == arrayPiezas[3].pos.columna ||
                    aux.fila == arrayPiezas[3].pos.fila)))
                {
                    aux.EleccionAlAzar();
                }


                if (pos_piezas.tablero[aux.fila, aux.columna] == 0)
                {
                    pos_piezas.tablero[aux.fila, aux.columna] = 8;//Reina
                    arrayPiezas[6].pos = aux;
                    casillas_amenazadas.AmenazasMovimientoReina(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[6], true);
                }
                //pos_piezas.ImprimirTablero();
                //casillas_amenazadas.ImprimirTablero();
                //cant_amenazasxCasillas.ImprimirTablero();
                //busco primer posición vacia ->pongo caballo
                arrayPiezas[0].pos = cant_amenazasxCasillas.BuscarPosicionLibre();
                if (arrayPiezas[0].pos.fila == -1 && arrayPiezas[0].pos.fila == -1)
                {
                    cant_tab_generados++;
                    Console.WriteLine("\nTengo tablero numero:" + cant_tab_generados);
                    cant_amenazasxCasillas.ImprimirTablero();
                    pos_piezas.ImprimirTablero();
                   

                }
                else
                {
                    //cPosicion paux = new cPosicion();//creo una posicion nueva que va a estar inicializada en -
                    pos_piezas.tablero[arrayPiezas[0].pos.fila, arrayPiezas[0].pos.columna] = 2;//caballo
                                                                                                //Lleno matriz con posiciones que amenazan

                    //COMPLETO POSICIONES AMENAZADAS CON EL CABALLO DESDE POSICION PROPUESTA
                    //...
                    //COMPLETO MATRIZ cant_amenazas_casillas CON 1 EN LAS POSICIONES DONDE AMENAZA CABALLO

                    casillas_amenazadas.AmenazasMovimientoCaballos(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[0], true);
                    //busco segunda->otro caballo
                    //pos_piezas.ImprimirTablero();
                    //casillas_amenazadas.ImprimirTablero();
                    //cant_amenazasxCasillas.ImprimirTablero();
                    arrayPiezas[1].pos = cant_amenazasxCasillas.BuscarPosicionLibre();
                    if (arrayPiezas[1].pos.fila == -1 && arrayPiezas[1].pos.fila == -1)
                    {
                        cant_tab_generados++;
                        Console.WriteLine("\nTengo tablero numero:" + cant_tab_generados);
                        cant_amenazasxCasillas.ImprimirTablero();
                        pos_piezas.ImprimirTablero();

                    }
                    else
                    {

                        //catch (Exception ex)
                        //{
                        //    Console.WriteLine(ex.Message);
                        //    // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}
                        pos_piezas.tablero[arrayPiezas[1].pos.fila, arrayPiezas[1].pos.columna] = 3;//caballo2
                                                                                                    //COMPLETO POSICIONES AMENAZADAS CON EL CABALLO DESDE POSICION PROPUESTA
                                                                                                    // ...
                                                                                                    //COMPLETO MATRIZ cant_amenazas_casillas CON 1 EN LAS POSICIONES DONDE AMENAZA CABALLO
                        casillas_amenazadas.AmenazasMovimientoCaballos(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[1], true);
                       /* pos_piezas.ImprimirTablero();
                        casillas_amenazadas.ImprimirTablero();
                        cant_amenazasxCasillas.ImprimirTablero();*/
                        //busco tercera->rey
                        //REY -> me fijo si no hay ninguna pieza o si esta el alfil -> puedo superponer
                        arrayPiezas[7].pos = cant_amenazasxCasillas.BuscarPosicionLibre();
                        if (arrayPiezas[7].pos.fila == -1 && arrayPiezas[7].pos.fila == -1)
                        {
                            cant_tab_generados++;
                            Console.WriteLine("\nTengo tablero numero:" + cant_tab_generados);
                            cant_amenazasxCasillas.ImprimirTablero();
                            pos_piezas.ImprimirTablero();

                        }
                        else
                        {
                            pos_piezas.tablero[arrayPiezas[7].pos.fila, arrayPiezas[7].pos.columna] = 9;
                            casillas_amenazadas.AmenazasMovimientoRey(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas[7], true);
                            /*pos_piezas.ImprimirTablero();
                            casillas_amenazadas.ImprimirTablero();
                            cant_amenazasxCasillas.ImprimirTablero();*/
                            //UNA VEZ QUE TENGO COMPLETA MATRICES
                            cPosicion pos_sin_Amenazas = new cPosicion();
                            int contador = 0, cca = 0;
                            while (contador < 5)
                            {
                                //1) Nos fijamos si la matriz propuesta (aleatoriamente) -> si esta toda amenazada corto el while
                                //-> tenemos un tablero
                                for (int i = 0; i < 8; i++)
                                {
                                    for (int j = 0; j < 8; j++)
                                    {
                                        if (casillas_amenazadas.tablero[i, j] == 0)
                                        {
                                            pos_sin_Amenazas.fila = i;
                                            pos_sin_Amenazas.columna = j;//en un futuro capaz hacer un struct posición           que tenga columna y fila
                                                                         //ya significa que no encontro una solucion
                                            cant_amenazasxCasillas.casillas_no_amenazadas = cca + 1;
                                        }
                                    }
                                }
                                //fijarme si esta completo

                                if (cant_amenazasxCasillas.casillas_no_amenazadas == 0)
                                {// si matriz amenazada completa que termine el while
                                    cant_tab_generados++;
                                    Console.WriteLine("\nTengo tablero numero:" + cant_tab_generados);
                                    pos_piezas.ImprimirTablero();
                                    pos_piezas.ImprimirTablero();

                                    //tengo tablero
                                }
                                else
                                {

                                    //Si no esta del todo amenazado tengo que empezar a mover piezas hasta tener una solucion
                                    //-----------------------------------------------------------------------------------------
                                    //Llegue a chequear hasta acá!

                                    //MUEVO PIEZA DONDE HAY MAYOR CANTIDAD DE AMENAZAS -> me fijo con matriz cant_amenazas 
                                    //muevo 1 pieza por 2/3 casillas no amenazadas -> lo intento 3 veces si no funca empieza de nuevo

                                    for (int i = 0; i < 8; i++)
                                    {
                                        for (int j = 0; j < 8; j++)
                                        {
                                            if ((int)cant_amenazasxCasillas.tablero[i, j] > cant_amenazasxCasillas.max_amenazas)
                                            {
                                                cant_amenazasxCasillas.max_amenazas = (int)cant_amenazasxCasillas.tablero[i, j];
                                                casillas_amenazadas.pos_max_amenazas.fila = i;
                                                casillas_amenazadas.pos_max_amenazas.columna = j;
                                            }

                                        }
                                    }
                                    //si cuanas casillas libres->rip
                                    //ya tengo posicion con mi maximo-> movemos pieza posicionada en lugar de mas amenazas
                                    int max = casillas_amenazadas.tablero[casillas_amenazadas.pos_max_amenazas.fila, casillas_amenazadas.pos_max_amenazas.columna];
                                    cPosicion posicion_vacia = new cPosicion();
                                    posicion_vacia = pos_piezas.LiberarPieza(max);
                                    arrayPiezas[max - 2].pos = casillas_amenazadas.BuscarPosicionLibre();
                                    pos_piezas.tablero[arrayPiezas[max - 2].pos.fila, arrayPiezas[max - 2].pos.columna] = (int)arrayPiezas[max - 2].tipoPieza;
                                    if (arrayPiezas[max - 2].pos.fila == -1 && arrayPiezas[max - 2].pos.columna == -1)
                                    {
                                        cant_tab_generados++;
                                        Console.WriteLine("\nTengo tablero numero:" + cant_tab_generados);
                                        casillas_amenazadas.ImprimirTablero();
                                        pos_piezas.ImprimirTablero();
                                    }
                                    else
                                    {
                                        pos_piezas.tablero[arrayPiezas[max - 2].pos.fila, arrayPiezas[max - 2].pos.columna] = (int)arrayPiezas[max - 2].tipoPieza;
                                        casillas_amenazadas.BuscarYdesamenazar_porPieza(cant_amenazasxCasillas.tablero, arrayPiezas[max - 2], pos_piezas.tablero);
                                        casillas_amenazadas.AmenazarTablero(cant_amenazasxCasillas.tablero, pos_piezas.tablero, arrayPiezas, true);

                                        //-------------------------------------------------------
                                        cca = 0;
                                        for (int k = 0; k < 8; k++)
                                        {
                                            for (int l = 0; l < 8; l++)
                                            {
                                                if (casillas_amenazadas.tablero[k, l] == 0)
                                                {
                                                    cPosicion posSinAmenaza = new cPosicion();
                                                    posSinAmenaza.fila = k;
                                                    posSinAmenaza.columna = l;//en un futuro capaz hacer un struct posición           que tenga columna y fila
                                                                              //ya significa que no encontro una solucion
                                                    casillas_amenazadas.casillas_no_amenazadas = cca + 1;
                                                }
                                            }
                                        }
                                        //fijarme si esta completo
                                    }
                                    if (casillas_amenazadas.casillas_no_amenazadas == 0)
                                    {//si matriz amenazada completa que termine el while
                                        cant_tab_generados++;
                                        Console.WriteLine("\nTengo tablero numero:" + cant_tab_generados);
                                        pos_piezas.ImprimirTablero();
                                        pos_piezas.ImprimirTablero();


                                    }
                                    else
                                    {                                    //HAGO NUEVOS MOVIMIENTOS DE PIEZAS

                                        contador++;//si no llegamos a obtener un tablero despues de repetir proceso 3 veces-> empezamos de 0

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }//termina el while

        public cJuego()
        {
            cant_tableros_a_generar = 10;//inicializo 10 pa que funque
            cant_tab_generados = 0;
            matriz_alfil = new cTablero();
            casillas_amenazadas = new Amenazas();
            pos_piezas = new cTablero();
            cant_amenazasxCasillas = new Amenazas();
            arrayPiezas = new Pieza[8];//yo recibiria una por parametro

        }
        public void InicializarTableroAlfil()
        {
            int cont = 0;
            for (int i = 0; i < matriz_alfil.tablero.GetLength(0); i++)
            {
                for (int j = 0; j < matriz_alfil.tablero.GetLength(1); j++)
                {
                    if (cont % 2 == 0 || cont == 0)
                    {
                        matriz_alfil.tablero[i, j] = 1;
                    }
                    else
                    {
                        matriz_alfil.tablero[i, j] = 2;
                    }
                    cont++;
                }
            }
        }
    }
} 


