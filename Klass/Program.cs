using System;

namespace Klass
{
    class Program
    {
        static void Main(string[] args)                     // Calculates the grade of the pig carcass based on lean meat content and allocates it according to customer specifications.
        {
            int fat, meat, weight;

            try { 
            Console.Write("Enter fat thickness: ");                             // Input fat tissue thickness
            fat = Convert.ToInt32(Console.ReadLine());              
            Console.Write("Enter meat thickness: ");                            // Input meat thickness
            meat = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter weight: ");                                    // Input weight.
            weight = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Carcass grade: " + LeanPercentage(fat, meat));   // Displays grade of pig carcass on the SEUROP scale
                Console.WriteLine(PigClass(LeanPercentage(fat, meat), weight));     // Allocates the pig carcass according to customer specifications (weight/grade).
            } 
            catch (Exception e) { 
                Console.WriteLine(e.Message);
            }
        }
        static char LeanPercentage(double num1, double num2)
        {
            double lean;
            char grade;

            // Calculates the lean percentage
            lean = (65.93356 - 0.17759 * num1 + 0.00579 * num2 - 52.54737 * num1 / num2);         

            // Sets the grade letter based on lean percentage.
            if (lean >= 60) { 
                grade = 'S';
            }
            else if (lean < 60 && lean >= 55) { 
                grade = 'E';
            }
            else if (lean < 55 && lean >= 50) { 
                grade = 'U';
            }
            else if (lean < 50 && lean >= 45) { 
                grade = 'R';
            }
            else if (lean < 45 && lean >= 40) { 
                grade = 'O';
            }
            else { 
                grade = 'P';
            }

            return grade;
        }

        static string PigClass(char a, int b)
        {
            // KS pigs S grade, weight 110 - 100. 
            // Kunde1 S,E grade, weight 100 - 90. 
            // Rest LVF.
            
            string kunde;

            if (a == 'S' && b <= 110 && b >= 100) { 
                kunde = "KS";
            }
            else if (a == 'S' || a == 'E' && b < 100 && b >= 90) { 
                kunde = "Kunde1";
            }
            else { 
                kunde = "LVF";
            }
            return kunde;
        }
    }
}
