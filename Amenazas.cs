using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TP_consola_Mendiburu_Geonas
{
    public class Amenazas : cTablero//HERENCIA
    {
        public int casillas_no_amenazadas;
        public cPosicion pos_max_amenazas;
        public int max_amenazas;
        public Amenazas()
        {
            casillas_no_amenazadas = 0;
            pos_max_amenazas = new cPosicion();
            max_amenazas = (int)tablero[0, 0];
        }
        public void AmenazasMovimientoCaballos(int[,] Amz_x_Cas, int[,] pos_piezas, Pieza pieza, bool sumar) //necesito poner el numero por eso{ 
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == pieza.pos.fila)
                        break;
                    if((i==(pieza.pos.fila+2)&&pieza.pos.columna+1==j)||(i==(pieza.pos.fila-2)&&(pieza.pos.columna+1)==j))
                    {
                        if (sumar)
                        {
                            tablero[i,j] = (int)pieza.tipoPieza;
                            Amz_x_Cas[i,j]++;
                        }
                        else
                            Amz_x_Cas[i, j]--;
                    }
                    if ((pieza.pos.fila+2==i&&j==pieza.pos.columna-1)||(pieza.pos.fila-2==i&&j==pieza.pos.columna-1))
                    {

                        if (sumar)
                        {
                            tablero[i, j] = (int)pieza.tipoPieza;
                            Amz_x_Cas[i, j]++;
                        }
                        else
                            Amz_x_Cas[i, j]--;
                    }
                    if ((pieza.pos.fila+1==i&&j==pieza.pos.columna+2)||(pieza.pos.fila-1==i&&j==pieza.pos.columna+2))
                    {
                        if (sumar)
                        {
                            tablero[i,j] = (int)pieza.tipoPieza;
                            Amz_x_Cas[i,j]++;
                        }
                        else
                            Amz_x_Cas[i, pieza.pos.columna]--;
                    }
                    if ((pieza.pos.fila+1==i&&j==pieza.pos.columna-2)||(pieza.pos.fila-1==i&&j==pieza.pos.columna-2))
                    {
                        if (sumar)
                        {
                            tablero[i, j] = (int)pieza.tipoPieza;
                            Amz_x_Cas[i, j]++;
                        }
                        else
                            Amz_x_Cas[i,j]--;
                    }
                    
                }
            }
            tablero[pieza.pos.fila, pieza.pos.columna] = (int)pieza.tipoPieza;
            Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] = Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] + 1;
        }
        public void AmenazasMovimientoTorre(int[,] Amz_x_Cas, int[,] pos_piezas, Pieza pieza, bool sumar)
        {
            for (int i = 0; i < 8; i++)
            {
                if (i == pieza.pos.fila)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (sumar)
                        {
                            tablero[i, j] = (int)pieza.tipoPieza;//completo matriz con amenazas con nro correspondiente
                            Amz_x_Cas[i, j]= Amz_x_Cas[i, j] + 1;//completo matriz con cant ataques sumando 1
                        }
                        else
                        {
                            Amz_x_Cas[i, j] = Amz_x_Cas[j, i] - 1;
                        }
                    }
                    
                }
            }
            for (int i = 0; i < 8; i++)
            {
                if (i == pieza.pos.columna)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (sumar)
                        {
                            tablero[j, i] = (int)pieza.tipoPieza;//completo matriz con amenazas con nro correspondiente
                            Amz_x_Cas[j, i] = Amz_x_Cas[j, i] + 1;//completo matriz con cant ataques sumando 1
                        }
                        else
                        {
                            Amz_x_Cas[j, i] = Amz_x_Cas[j, i] - 1;
                        }
                    }
                }
            }
            //complete dos veces la matriz con 1 en la posicion propuesta
            Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] -= 1;
        }
        public void AmenazasMovimientoAlfil(int[,] Amz_x_Cas, int[,] pos_piezas, Pieza pieza, bool sumar)
        {
           
            int i = pieza.pos.fila;
            int j = pieza.pos.columna;
            if (sumar)
            {
                while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
                {
                    Amz_x_Cas[i, j] += 1;
                    tablero[i, j] = (int)pieza.tipoPieza;
                    
                    i++;
                    j++;
                }
                i = pieza.pos.fila;
                j = pieza.pos.columna;
                while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
                {
                    Amz_x_Cas[i, j] += 1;
                    tablero[i, j] = (int)pieza.tipoPieza;
                    
                    i--;
                    j--;
                }
                Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] -= 1;
                i = pieza.pos.fila;
                j = pieza.pos.columna;
                while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
                {
                    Amz_x_Cas[i, j] += 1;
                    tablero[i, j] = (int)pieza.tipoPieza;
                    
                    i++;
                    j--;
                }
                Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] -= 1;
                i = pieza.pos.fila;
                j = pieza.pos.columna;
                while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
                {
                    Amz_x_Cas[i, j] += 1;
                    tablero[i, j] = (int)pieza.tipoPieza;
                   
                    i--;
                    j++;
                }
                Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] -= 1;
            }
            else
            {
                while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
                {
                    Amz_x_Cas[i,j]-= 1;                   
                  
                    i++;
                    j++;
                }
                i = pieza.pos.fila;
                j = pieza.pos.columna;
                while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
                {
                    Amz_x_Cas[i,j] -= 1;
                   
                    i--;
                    j--;
                }
                Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] += 1;
                i = pieza.pos.fila;
                j = pieza.pos.columna;
                while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
                {
                    Amz_x_Cas[i, j] -= 1;                   
                    
                    i++;
                    j--;
                }
                Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] += 1;
                i = pieza.pos.fila;
                j = pieza.pos.columna;
                while ((i >= 0 && j >= 0) && (i <= 7 && j <= 7))
                {
                    Amz_x_Cas[i, j] -= 1;                    
                    
                    i--;
                    j++;
                }
                Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] += 1;
            }
        }
        public void AmenazasMovimientoReina(int[,] Amz_x_Cas, int[,] pos_piezas, Pieza pieza, bool sumar)
        {
            AmenazasMovimientoAlfil(Amz_x_Cas, pos_piezas, pieza, sumar);
            AmenazasMovimientoTorre(Amz_x_Cas, pos_piezas, pieza, sumar);
            Amz_x_Cas[pieza.pos.fila, pieza.pos.columna] += 1; 
        }

        public void AmenazasMovimientoRey(int[,] Amz_x_Cas, int[,] pos_piezas, Pieza pieza, bool sumar)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (pieza.pos.fila == i)
                    {
                        if (pieza.pos.columna - 1 == j || j == pieza.pos.columna + 1)
                        {
                            if (sumar)
                            {
                                tablero[i, j] = (int)pieza.tipoPieza;//pongo en REY
                                Amz_x_Cas[i, j]++;
                            }
                            else
                                Amz_x_Cas[i, j]--;
                        }
                    }
                    if (pieza.pos.columna == j)
                    {
                        if (pieza.pos.fila - 1 == i || i == pieza.pos.fila + 1)
                        {
                            if (sumar)
                            {
                                tablero[i, j] = (int)pieza.tipoPieza;//pongo en REY
                                Amz_x_Cas[i, j]++;
                            }
                            else
                                Amz_x_Cas[i, j]--;
                        }
                    }
                    if (i == pieza.pos.fila + 1 || i == pieza.pos.fila - 1)
                    {
                        if (j == pieza.pos.columna + 1 || j == pieza.pos.columna - 1)
                        {
                            if (sumar)
                            {
                                tablero[i, j] = (int)pieza.tipoPieza;//pongo en REY
                                Amz_x_Cas[i, j]++;
                            }
                            else
                                Amz_x_Cas[i, j]--;
                        }
                    }
                }

            }
        }
        public void BuscarYdesamenazar_porPieza(int[,] Amz_x_Cas, Pieza pieza, int[,] pos_piezas)
        {
            cPosicion pos = new cPosicion();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((int)pieza.tipoPieza == pos_piezas[i, j])
                    {
                        pos.fila = i;
                        pos.columna = j;
                    }
                }
            }
            switch (pieza.tipoPieza)
            {
                case e_Pieza.CABALLO1:
                    AmenazasMovimientoCaballos(Amz_x_Cas, pos_piezas, pieza, false);
                    break;
                case e_Pieza.CABALLO2:
                    AmenazasMovimientoCaballos(Amz_x_Cas, pos_piezas, pieza, false);
                    break;
                case e_Pieza.TORRE1:
                    AmenazasMovimientoTorre(Amz_x_Cas, pos_piezas, pieza, false);
                    break;
                case e_Pieza.TORRE2:
                    AmenazasMovimientoTorre(Amz_x_Cas, pos_piezas, pieza, false);
                    break;
                case e_Pieza.ALFIL1:
                    AmenazasMovimientoAlfil(Amz_x_Cas, pos_piezas, pieza, false);
                    break;
                case e_Pieza.ALFIL2:
                    AmenazasMovimientoAlfil(Amz_x_Cas, pos_piezas, pieza, false);
                    break;
                case e_Pieza.REINA:
                    AmenazasMovimientoReina(Amz_x_Cas, pos_piezas, pieza, false);
                    break;
                case e_Pieza.REY:
                    AmenazasMovimientoRey(Amz_x_Cas, pos_piezas, pieza, false);
                    break;
                default:
                    break;
            }



        }

    }
}
