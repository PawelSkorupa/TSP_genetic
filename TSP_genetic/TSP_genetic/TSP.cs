// C# implementation of the above approach
using System;
using System.Collections.Generic;
using System.Linq;
// Structure of a GNOME
// string defines the path traversed
// by the salesman while the fitness value
// of the path is stored in an integer
public struct Individual
{
    public string gnome;
    public int fitness;
}

public class TSP
{
    // Number of cities in TSP
    const int V = 5;
    // Names of the cities
    const string GENES = "ABCDE";
    // Starting Node Value
    const int START = 0;
    // Initial population size for the algorithm
    const int POP_SIZE = 10;

    // Function to return a random number
    // from start and end
    static int RandNum(int start, int end)
    {
        int r = end - start;
        int rnum = start + new Random().Next() % r;
        return rnum;
    }
    // Function to check if the character
    // has already occurred in the string
    static bool Repeat(string s, char ch)
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == ch)
                return true;
        }
        return false;
    }
    // Function to return a mutated GNOME
    // Mutated GNOME is a string
    // with a random interchange
    // of two genes to create variation in species
    static string MutatedGene(string gnome)
    {
        while (true)
        {
            int r = RandNum(1, V);
            int r1 = RandNum(1, V);
            if (r1 != r)
            {
                char[] arr = gnome.ToCharArray();
                char temp = arr[r];
                arr[r] = arr[r1];
                arr[r1] = temp;
                gnome = new string(arr);
                break;
            }
        }
        return gnome;
    }
    // Function to return a valid GNOME string
    // required to create the population
    static string CreateGnome()
    {
        string gnome = "0";
        while (true)
        {
            if (gnome.Length == V)
            {
                gnome += gnome[0];
                break;
            }
            int temp = RandNum(1, V);
            if (!Repeat(gnome, (char)(temp + 48)))
                gnome += (char)(temp + 48);
        }
        return gnome;
    }
    // Function to return the fitness value of a gnome.
    // The fitness value is the path length
    // of the path represented by the GNOME.
    static int CalFitness(string gnome)
    {
        int[,] map = new int[,] {
            { 0, 2, int.MaxValue, 12, 5 },
            { 2, 0, 4, 8, int.MaxValue },
            { int.MaxValue, 4, 0, 3, 3 },
            { 12, 8, 3, 0, 10 },
            { 5, int.MaxValue, 3, 10, 0 }
        };
        int f = 0;
        for (int i = 0; i < gnome.Length - 1; i++)
        {
            if (map[gnome[i] - 48, gnome[i + 1] - 48] == int.MaxValue)
                return int.MaxValue;
            f += map[gnome[i] - 48, gnome[i + 1] - 48];
        }
        return f;
    }
    // Function to return the updated value
    // of the cooling element
    static int CoolDown(int temp)
    {
        return (90 * temp) / 100;
    }
    // Comparator for GNOME struct.
    static bool LessThan(Individual t1, Individual t2)
    {
        return t1.fitness < t2.fitness;
    }


    // Utility function for TSP problem.
    static void TSPUtil(int[,] map)
    {
        // Generation Number
        int gen = 1;
        // Number of Gene Iterations
        int gen_thres = 5;

        List<Individual> population = new List<Individual>();
        Individual temp;

        // Populating the GNOME pool.
        for (int i = 0; i < POP_SIZE; i++)
        {
            temp.gnome = CreateGnome();
            temp.fitness = CalFitness(temp.gnome);
            population.Add(temp);
        }

        Console.WriteLine("\nInitial population: \nGNOME     FITNESS VALUE\n");
        foreach (Individual ind in population)
        {
            Console.WriteLine(ind.gnome + " " + ind.fitness);
        }
        Console.WriteLine();

        bool found = false;
        int temperature = 10000;

        // Iteration to perform
        // population crossing and gene mutation.
        while (temperature > 1000 && gen <= gen_thres)
        {
            population = population.OrderBy(x => x.fitness).ToList();
            Console.WriteLine("\nCurrent temp: " + temperature + "\n");
            List<Individual> new_population = new List<Individual>();

            for (int i = 0; i < POP_SIZE; i++)
            {
                Individual p1 = population[i];

                while (true)
                {
                    string new_g = MutatedGene(p1.gnome);
                    Individual new_gnome;
                    new_gnome.gnome = new_g;
                    new_gnome.fitness = CalFitness(new_gnome.gnome);

                    if (new_gnome.fitness <= population[i].fitness)
                    {
                        new_population.Add(new_gnome);
                        break;
                    }
                    else
                    {

                        // Accepting the rejected children at
                        // a possible probability above threshold.
                        float prob = (float)Math.Pow(2.7,
                                        -1 * ((float)(new_gnome.fitness
                                                - population[i].fitness)
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
            Console.WriteLine("Generation " + gen + " \nGNOME     FITNESS VALUE\n");

            foreach (Individual ind in population)
            {
                Console.WriteLine(ind.gnome + " " + ind.fitness);
            }
            gen++;
        }
    }

    //static void Main(string[] args)
    //{
    //    int[,] map = new int[,] { { 0, 2, int.MaxValue, 12, 5 },
    //                                  { 2, 0, 4, 8, int.MaxValue },
    //                                  { int.MaxValue, 4, 0, 3, 3 },
    //                                  { 12, 8, 3, 0, 10 },
    //                                  { 5, int.MaxValue, 3, 10, 0 } };

    //    TSPUtil(map);
    //}
}
