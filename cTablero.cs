﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//using cPosicion;//como incluimos clase?

namespace TP_consola_Mendiburu_Geonas

{
    public class cTablero
    {
        public int[,] tablero = new int[8, 8];

        //metodos:
        
        public void LiberarPieza(Pieza pieza) {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((int)pieza.tipoPieza == tablero[i,j])
                        tablero[i,j] = 0;
                }
            }
        }
        public cTablero()
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = 0;
                }
            }
        }
        public void ImprimirTablero()
        {
            Console.WriteLine("Tablero\n");
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Console.Write(" " + tablero[r, c]);

                }
                Console.WriteLine();
            }

        }

    }
}
