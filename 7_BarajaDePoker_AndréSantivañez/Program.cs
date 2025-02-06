using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _7_BarajaDePoker_AndréSantivañez
{
    class Carta
    {
        public string Palo { get; set; }
        public string Valor { get; set; }

        // El constructor
        public Carta(string palo, string valor)
        {
            Palo = palo;
            Valor = valor;
        }
        public void MostrarCarta()
        {
            Console.WriteLine($"{Valor} de {Palo}");
        }
    }
    class Baraja
    {
        private List<Carta> cartas;
        public Baraja()
        {
            string[] palos = { "Corazones", "Diamantes", "Tréboles", "Picas" };
            string[] valores = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

            cartas = new List<Carta>();

            foreach (string palo in palos)
            {
                foreach (string valor in valores)
                {
                    cartas.Add(new Carta(palo, valor));
                }
            }
        }
        public void Barajar()
        {
            Random rng = new Random();
            for (int i = 0; i < cartas.Count; i++)
            {
                int j = rng.Next(cartas.Count);
                (cartas[i], cartas[j]) = (cartas[j], cartas[i]);
            }
            Console.Clear();
            Console.WriteLine("Baraja mezclada correctamente. Roba una carta:");
        }
        public Carta RobarCarta()
        {
            if (cartas.Count > 0)
            {
                Carta cartaRobada = cartas[0];
                cartas.RemoveAt(0);
                return cartaRobada;
            }
            Console.WriteLine("No quedan cartas en el mazo.");
            return null;
        }
    }
    class Program
    {
        static void Main()
        {
            Baraja baraja = new Baraja();
            List<Carta> mano = new List<Carta>();
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\nMenú");
                Console.WriteLine("1. Barajar la baraja");
                Console.WriteLine("2. Robar una carta");
                Console.WriteLine("3. Mostrar mi mano");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Seleccione una opcion: ");

                string opcion = Console.ReadLine();

                switch(opcion)
                {
                    case "1":
                        Console.Clear();
                        baraja.Barajar();
                        break;
                    case "2":
                        Console.Clear();
                        if (mano.Count < 7)
                        {
                            Carta nuevaCarta = baraja.RobarCarta();
                            if (nuevaCarta != null)
                            {
                                mano.Add(nuevaCarta);
                                Console.WriteLine($"Has robado: {nuevaCarta.Valor} de {nuevaCarta.Palo}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Tu mano ya tiene 7 cartas, no puedes más.Espabila hombre, que la avaricia rompe el saco.");
                        }
                        break;
                    case "3":
                        Console.Clear();
                        MostrarMano(mano);
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opción no válida, intenta de nuevo.");
                        break;
                }
            }
        }
        static void MostrarMano(List<Carta> mano)
        {
            Console.WriteLine("Tu mano actual:");
            if (mano.Count == 0)
            {
                Console.WriteLine("No tienes cartas en tu mano, no ves que no tienes ni una??");
            }
            else
            {
                foreach (Carta carta in mano)
                {
                    carta.MostrarCarta();
                }
            }
        }

    }
}
