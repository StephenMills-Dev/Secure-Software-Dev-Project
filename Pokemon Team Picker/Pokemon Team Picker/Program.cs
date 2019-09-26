using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Team_Picker
{
    class Program
    {
        public static bool bigHeading;
        static void Main(string[] args)
        {
            bigHeading = false;
            Title();
            string[] userDetaisl = RequestDetails();
        }
        //pritns title for the app
        static void Title()
        {
            /*
            *****  *****  *  *  ****  **   **  *****  **    *
            *   *  *   *  * *   *     * * * *  *   *  * *   *
            *****  *   *  **    ***   *  *  *  *   *  *  *  *
            *      *   *  * *   *     *     *  *   *  *   * *
            *      *****  *  *  ****  *     *  *****  *    **
             */

            //use to repeat charaters.
            if (bigHeading)
            {
                Console.WriteLine(new string('*', 50));
                Console.WriteLine();
                Console.WriteLine("*****  *****  *  *  ****  **   **  *****  **    *");
                Console.WriteLine("*   *  *   *  * *   *     * * * *  *   *  * *   *");
                Console.WriteLine("*****  *   *  **    ***   *  *  *  *   *  *  *  *");
                Console.WriteLine("*      *   *  * *   *     *     *  *   *  *   * *");
                Console.WriteLine("*      *****  *  *  ****  *     *  *****  *    **");
                Console.WriteLine();
                Console.WriteLine(new string('*', 50));
            }
            else
            {
                Console.WriteLine(new string('*', 50));
                Console.WriteLine();
                Console.WriteLine("               POKEMON TEAM MAKER");
                Console.WriteLine();
                Console.WriteLine(new string('*', 50));
            }
            Console.ReadLine();
        }
        //gets the sign in details
        static string[] RequestDetails()
        {
            Console.WriteLine("Please enter your Username");
            string username =  Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            return new string[] { username, password };
        }
        //Test Details agenst the array taken in.
        static void AssesDetails(string[] userInputs)
        {

        }
    
    }
}
