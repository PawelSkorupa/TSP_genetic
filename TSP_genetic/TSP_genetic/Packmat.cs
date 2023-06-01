using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TSP_genetic
{
    public class Packmat
    {
        public string PackmatNumber { get; set; }
        public List<Tuple<string, float>> Connections { get; set; }

        // Konstruktor
        public Packmat(string packmatNumber)
        {
            PackmatNumber = packmatNumber;
            Connections = new List<Tuple<string, float>>();
        }

        public Packmat()
        {
            PackmatNumber = "";
            Connections = new List<Tuple<string, float>>();
        }

        // Metoda do wczytywania danych z pliku
        public static List<Packmat> LoadPackmatsFromFile(string filePath)
        {
            List<Packmat> Packmats = new List<Packmat>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');

                    if (parts.Length == 3)
                    {
                        string packmatNumber1 = parts[0];
                        string packmatNumber2 = parts[1];
                        float distance = float.Parse(parts[2]);

                        // Dodanie pierwszego Packmatu
                        Packmat Packmat1 = Packmats.Find(p => p.PackmatNumber == packmatNumber1);
                        if (Packmat1 == null)
                        {
                            Packmat1 = new Packmat(packmatNumber1);
                            Packmats.Add(Packmat1);
                        }

                        // Dodanie drugiego Packmatu
                        Packmat Packmat2 = Packmats.Find(p => p.PackmatNumber == packmatNumber2);
                        if (Packmat2 == null)
                        {
                            Packmat2 = new Packmat(packmatNumber2);
                            Packmats.Add(Packmat2);
                        }

                        // Dodanie połączenia
                        Packmat1.Connections.Add(new Tuple<string, float>(packmatNumber2, distance));
                        Packmat2.Connections.Add(new Tuple<string, float>(packmatNumber1, distance));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wystąpił błąd podczas wczytywania pliku: " + ex.Message);
            }

            return Packmats;
        }
    }

}
