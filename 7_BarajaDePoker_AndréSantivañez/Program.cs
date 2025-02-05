using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_BarajaDePoker_AndréSantivañez
{
    class Carta
    {
        public string Palo { get; set; }
        public string Valor { get; set; }

        // El constructor
        public Carta(string Palo, string Valor)
        {
            Palo = palo;
            Valor = valor;
        }
        public void MostrarCarta()
        {
            Console.WriteLine($"{Valor} de {Palo})");
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
            for (int i = 0; cartas.Count; i++)
            {
                int j = rng.Next(cartas.Count);
                (cartas[i], cartas[j]) = (cartas[j], cartas[i]);
            }
            Console.Clear();
            Console.WriteLine("Baraja mezclada correctamente. Roba una carta:");
        }
    }
}
