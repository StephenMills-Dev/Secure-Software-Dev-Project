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
        public static bool correctDetails;
        public static string userRoal;
        static void Main(string[] args)
        {
            bigHeading = false;
            Title();
            do
            {
                string[] userDetaisl = RequestDetails();
                AssesDetails(userDetaisl);
                if (!correctDetails)
                {
                    Console.WriteLine("Invalid user login, please try again");
                }
            } while (!correctDetails);
            
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
        }
        //gets the sign in details
        static string[] RequestDetails()
        {
            Console.WriteLine("Please enter your Username");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            return new string[] { username, password };
        }
        //Test Details agenst the array taken in.
        static void AssesDetails(string[] userInputs)
        {
            bool correctPassword = false;
            bool correctUsername = false;

            // used to bring in all the user information at once
            string fileDetails = GetFileLines();
            string[] sepDetails;

            // separates it based on the . at the end just to get an array of each users dtails
            if (fileDetails != "" || fileDetails != null)
            {
                sepDetails = fileDetails.Split('.');

                // test the users inputs agenst the file details
                foreach (var user in sepDetails)
                {
                    //further seperate the individual details for testing
                    string[] splitIndividualDetails = user.Split(',');

                    //loop to test agenst inputs
                    for (int i = 0; i < splitIndividualDetails.Length -1; i++)
                    {
                        // tests the username
                        if (userInputs[i].ToString() == splitIndividualDetails[i].ToString() && i == 0)
                        {
                            correctUsername = true;
                        }
                        // tests the password
                        if (userInputs[i].ToString() == splitIndividualDetails[i].ToString() && i == 1)
                        {
                            correctPassword = true;
                        }

                        //breaks if both are true so that the program knows the exit if it has found the correct details
                        if (correctPassword && correctUsername)
                        {
                            userRoal = splitIndividualDetails[2];
                            Console.WriteLine(userRoal);
                            break;
                        }
                    }
                    if (correctPassword && correctUsername)
                    {
                        break;
                    }
                }

                if (!correctPassword || !correctUsername)
                {
                    correctDetails = false;
                }
                else if (correctPassword && correctUsername)
                {
                    correctDetails = true;
                    Console.ReadLine();
                }
            }
        }

        public static string GetFileLines()
        {
            string lineIn;
            using (System.IO.StreamReader file =
            new System.IO.StreamReader(@"C:\Users\Shirley\Source\Repos\Secure-Software-Dev-Project\Pokemon Team Picker\passwords.txt", true))
            {
                lineIn = file.ReadToEnd();
            }
            return lineIn;
        }

        static void AppBody()
        {
            if (userRoal == "admin")
            {

            }
            else if (userRoal == "user")
            {

            }
        }

        static void AdminExtra()
        {

        }

        static void UserApp()
        {

        }
    }
}
