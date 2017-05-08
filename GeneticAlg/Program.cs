using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlg
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] population = new int[,] { { -5, -3, -2, 0 }, { -1, -2, 1, 0 } };


            for (int stage = 0; stage < 4; stage++)
            {
                double maxZ = 0;
                int maxZIndex = 0;
                double minZ = 1;
                int minZIndex = 0;
                double[] allZ = new double[4];
                for (int i = 0; i < population.GetLength(0); i++)
                {
                    allZ[i] = Z(population[0, i], population[1, i]);
                    Console.WriteLine("Z" + i + " = " + allZ[i]);
                    if (allZ[i] > maxZ)
                    {
                        maxZ = allZ[i];
                        maxZIndex = i;
                    }
                    if (allZ[i] < minZ)
                    {
                        minZ = allZ[i];
                        minZIndex = i;
                    }
                }
                double sumZ = 0;
                foreach (double d in allZ)
                {
                    sumZ += d;
                }
                Console.WriteLine(sumZ + "\n");

                population = delete(population, allZ);

                population = mix(population);
            }
        }
        public static int[,] mix(int[,] population)
        {
            int[,] newPopulation = new int[2, 4];
            newPopulation[0, 0] = population[0, 1];
            newPopulation[1, 0] = population[1, 0];
            newPopulation[0, 1] = population[0, 2];
            newPopulation[1, 1] = population[1, 0];
            newPopulation[0, 2] = population[0, 0];
            newPopulation[1, 2] = population[1, 1];
            newPopulation[0, 3] = population[0, 0];
            newPopulation[1, 3] = population[1, 2];
            return newPopulation;
        }

        public static int[,] delete(int[,] population, double[] allZ)
        {

            double[] sortedArray = allZ;
            bool isSwaped = false;
            for (int i = sortedArray.Length - 1; i >= 0; i--)
            {
                isSwaped = false;
                for (int j = 0; j < i; j++)
                {
                    if (sortedArray[j] < sortedArray[j + 1])
                    {
                        double temp = sortedArray[j];
                        sortedArray[j] = sortedArray[j + 1];
                        sortedArray[j + 1] = temp;

                        int atemp = population[0, j];
                        int btemp = population[1, j];
                        population[0, j] = population[0, j + 1];
                        population[1, j] = population[1, j + 1];
                        population[0, j + 1] = atemp;
                        population[1, j + 1] = btemp;
                        isSwaped = true;
                    }
                }
                if (!isSwaped)
                {
                    break;
                }
            }
            int[,] smallpopulation = new int[2, 3];
            for (int i = 0; i < smallpopulation.GetLength(0); i++)
            {
                smallpopulation[0, i] = population[0, i];
                smallpopulation[1, i] = population[1, i];
            }

            return smallpopulation;

        }
        public static double Z(double x, double y)
        {
            return (x - 3 * y + 2) / (2 * x * x + y * y + 1);
        }

    }
}



