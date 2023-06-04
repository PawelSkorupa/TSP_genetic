using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace TSP_genetic
{
    public struct Individual
    {
        public List<string> gnome;
        public double routeLength; // route length
    }
    public class Packmat
    {
        public List<string> allPackmatNumbers { get; private set; } // list of all packmats
        public List<string> routePackmatNumbers { get; set; } // list of packmats selected for route
        public double[,] connectionMatrix { get; private set; } 

        public int routePointsQuantity  { get; set; } // quantity of packats in a route
        public int popSize { get; set; }
        public int gen_thres { get; set; }

    public Packmat()
        {
            allPackmatNumbers = new List<string>();
            connectionMatrix = null;
        }

        public string LoadConnectionsFromFile(string filePath)
        {
            try
            {
                // Loading allPackmatNumbers
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] data = line.Split(';');
                    string packmat1 = data[0];
                    string packmat2 = data[1];
                    double distance = double.Parse(data[2]);

                    if (!allPackmatNumbers.Contains(packmat1))
                    {
                        allPackmatNumbers.Add(packmat1);
                    }
                    if (!allPackmatNumbers.Contains(packmat2))
                    {
                        allPackmatNumbers.Add(packmat2);
                    }
                }
                //Creating connection matrix
                connectionMatrix = new double[allPackmatNumbers.Count, allPackmatNumbers.Count];
                for (int i = 0; i < connectionMatrix.GetLength(0); i++)
                {
                    for (int j = 0; j < connectionMatrix.GetLength(1); j++)
                    {
                        connectionMatrix[i, j] = double.PositiveInfinity;
                    }
                }

                foreach (string line in lines)
                {
                    string[] data = line.Split(';');
                    string packmat1 = data[0];
                    string packmat2 = data[1];
                    double distance = double.Parse(data[2]);

                    int index1 = allPackmatNumbers.IndexOf(packmat1);
                    int index2 = allPackmatNumbers.IndexOf(packmat2);

                    if (index1 != -1 && index2 != -1)
                    {
                        connectionMatrix[index1, index2] = distance;
                        connectionMatrix[index2, index1] = distance;
                    }
                    else
                    {
                        // Connection doesn't exist in matrix
                        // double.MaxValue is placed
                        if (index1 == -1)
                        {
                            connectionMatrix[index2, index2] = double.MaxValue;
                        }
                        if (index2 == -1)
                        {
                            connectionMatrix[index1, index1] = double.MaxValue;
                        }
                    }
                }

                return "Connections loaded successfully.";
            }
            catch (Exception e)
            {
                return "An error occurred while loading connections: " + e.Message;
            }
        }

        static int RandNum(int start, int end)
        {
            int r = end - start;
            int rnum = start + new Random().Next() % r;
            return rnum;
        }
        //Gene mutation
        static List<string> MutatedGene(List<string> gnome)
        {
            while (true)
            {
                int r = RandNum(1, gnome.Count-1);
                int r1 = RandNum(1, gnome.Count-1);
                if (r1 != r)
                {
                    string temp = gnome[r];
                    gnome[r] = gnome[r1];
                    gnome[r1] = temp;
                    break;
                }
            }
            return gnome;
        }
        //Creating initial gnome
        // Swaps two values in gnome, ensures first and last element is our starting point (start and end point should be the same)
        static List<string> CreateGnome(List<string> packmatRoute) 
        {
            List<string> genomeList = new List<string>();
            genomeList.Add(packmatRoute.First());
            while (genomeList.Count < packmatRoute.Count-1)
            {
                int temp = RandNum(1, packmatRoute.Count-1);

                if (!genomeList.Contains(packmatRoute[temp]))
                {
                    genomeList.Add(packmatRoute[temp]);
                }
            }
            genomeList.Add(packmatRoute.Last());
            return genomeList;
        }
        private double CalFitness(List<string> genome, double[,] distanceMatrix)
        {
            double fitness = 0;
            int numCities = genome.Count;

            for (int i = 0; i < numCities - 1; i++)
            {
                string packmat1 = genome[i];
                string packmat2 = genome[i + 1];

                int index1 = allPackmatNumbers.IndexOf(packmat1);
                int index2 = allPackmatNumbers.IndexOf(packmat2);

                if (index1 != -1 && index2 != -1)
                {
                    double distance = distanceMatrix[index1, index2];
                    fitness += distance;
                }
            }
            return fitness;
        }
        static int CoolDown(int temp)
        {
            return (90 * temp) / 100;
        }
        public StringBuilder TSPUtil(double[,] map)
        {
            StringBuilder sb = new StringBuilder();
            // Generation Number
            int gen = 1;

            List<Individual> population = new List<Individual>();
            Individual temp;
            routePackmatNumbers.Add(routePackmatNumbers[0]);


            // Populating the GNOME pool.
            for (int i = 0; i < popSize; i++)
            {
                temp.gnome = CreateGnome(routePackmatNumbers); //Creates first gnome
                temp.routeLength = CalFitness(temp.gnome, connectionMatrix);
                population.Add(temp);
            }

            sb.Append("\nInitial population: \nGNOME     FITNESS VALUE\n");
            sb.Append(Environment.NewLine);
            foreach (Individual ind in population)
            {
                foreach(string p in ind.gnome)
                {
                    sb.Append(p + " ");
                }
                sb.Append(ind.routeLength.ToString("0.00") + " ");
                sb.Append(Environment.NewLine);
            }
            sb.Append(Environment.NewLine);

            bool found = false;
            int temperature = 10000;

            // Iteration to perform
            // population crossing and gene mutation.
            while (temperature > 1000 && gen <= gen_thres)
            {
                population = population.OrderBy(x => x.routeLength).ToList();
                sb.Append("\nCurrent temp: " + temperature + "\n");
                sb.Append(Environment.NewLine);
                List<Individual> new_population = new List<Individual>();

                for (int i = 0; i < popSize; i++)
                {
                    Individual p1 = population[i];

                    while (true)
                    {
                        List<string> new_g = MutatedGene(p1.gnome);
                        Individual new_gnome;
                        new_gnome.gnome = new_g;
                        new_gnome.routeLength = CalFitness(new_gnome.gnome, connectionMatrix);

                        if (new_gnome.routeLength <= population[i].routeLength)
                        {
                            new_population.Add(new_gnome);
                            break;
                        }
                        else
                        {

                            // Accepting the rejected children at
                            // a possible probability above threshold.
                            float prob = (float)Math.Pow(2.7,
                                            -1 * ((float)(new_gnome.routeLength
                                                    - population[i].routeLength)
                                                / temperature));
                            if (prob > 0.5)
                            {
                                new_population.Add(new_gnome);
                                break;
                            }
                        }
                    }
                }

                temperature = CoolDown(temperature);
                population = new_population;

                sb.Append("Generation " + gen + " \nGNOME     FITNESS VALUE\n");
                sb.Append(Environment.NewLine);
                foreach (Individual ind in population)
                {
                    foreach(string p in ind.gnome)
                    {
                        sb.Append(p + " ");
                    }
                    sb.Append(ind.routeLength.ToString("0.00") + " ");
                    sb.Append(Environment.NewLine);
                }
                gen++;
                sb.Append(Environment.NewLine);
            }
            if (routePackmatNumbers.Count > 0)
            {
                routePackmatNumbers.RemoveAt(routePackmatNumbers.Count - 1);
            }
            return sb;
        }
    }

}
