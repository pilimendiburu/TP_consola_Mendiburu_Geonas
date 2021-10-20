using System;

namespace TP_consola_Mendiburu_Geonas
{
    class Program
    {
        static void Main(string[] args)
        {
            cJuego partida = new cJuego();
            partida.InicializarTableroAlfil();
            partida.arrayPiezas = CrearPiezas();
            partida.GenerarTableros();
            Console.ReadKey();
        }
        static Pieza[] CrearPiezas()
        {
            Pieza[] piezas = new Pieza[8];
            for (int i = 0; i < 8; i++)
            {
                piezas[i] = new Pieza((e_Pieza)i + 2);
            }
            return piezas;
        }
    }
}
