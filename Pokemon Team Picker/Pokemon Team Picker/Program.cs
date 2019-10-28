using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Team_Picker
{
    class Program
    {

        #region-class level variables-
        public static bool bigHeading;
        private static bool correctDetails;
        private static string userRoal;
        private static string username;
        #endregion

        static void Main(string[] args)
        {
            bigHeading = true;
            Title();
            do
            {
                string[] userDetaisl = RequestDetails();
                AssesDetails(userDetaisl);
                // create new user needs to be added if they fail as an option
                if (!correctDetails)
                {
                    Console.WriteLine("Invalid user login, please try again");
                }
            } while (!correctDetails);
            if (correctDetails)
            {
                AppBody();
            }
            
        }


        //pritns title for the app
        static void Title()
        {

            //use to repeat charaters.
            if (bigHeading)
            {
                Console.WriteLine(new string('*', 55));
                Console.WriteLine();
                Console.WriteLine("   *****  *****  *  *  ****  **   **  *****  **    *");
                Console.WriteLine("   *   *  *   *  * *   *     * * * *  *   *  * *   *");
                Console.WriteLine("  *****  *   *  **    ***   *  *  *  *   *  *  *  *");
                Console.WriteLine(" *      *   *  * *   *     *     *  *   *  *   * *");
                Console.WriteLine("*      *****  *  *  ****  *     *  *****  *    **");
                Console.WriteLine("                  TEAM MAKER");
                Console.WriteLine();
                Console.WriteLine(new string('*', 55));
            }
        }

        #region-login & authenticate methods-
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
            string fileLocation = System.AppContext.BaseDirectory;
            string fileName = "Passwords.txt";
            string fileDetails = GetFileLines(fileLocation + fileName);
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
                            username = splitIndividualDetails[0];
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
                }
            }
        }
        // used to get all the users stored in a text file.
        private static string GetFileLines(string fileLocation)
        {
            string lineIn;
            using (System.IO.StreamReader file =
            new System.IO.StreamReader(fileLocation, true))
            {
                lineIn = file.ReadToEnd();
            }
            return lineIn;
        }
        #endregion

        #region-appBody Methods-
        // used for displaying the body of the app with additions based on the users roal. admin will alow the ussrs to see more and proforem differernt operations.
        static void AppBody()
        {
            if (userRoal == "admin")
            {
                UserApp();
            }
            else if (userRoal == "user")
            {
                UserApp();
            }
        }

        static void AdminExtra()
        {

        }

        static void UserApp()
        {
            Console.WriteLine("Welcome to pokemon team maker");
            Console.WriteLine("Searching for teams created by you...");
            List<Pokemon> myPokemon = new List<Pokemon>();
            Pokedex myDex = new Pokedex();
            // search if any teams have been created by the user.
            // this is down to how the team is stored.

            string[] team = GetTeam(username);

            //needs t have
            #region-this is for if a team is present-
            foreach (Pokemon p in myDex.pokemonList)
            {
                foreach (var item in team)
                {
                    if (item == "" || item == null)
                    {
                        break;
                    }
                    if (p.DexNumber == Convert.ToInt32(item))
                    {
                        myPokemon.Add(p);

                        
                    }
                }
                
            }

            Console.WriteLine("Your current team is:");
            foreach (var item in myPokemon)
            {
                Console.WriteLine("|{0}|{1}|",item.DexNumber,item.Name);
            }
            #endregion
            Console.WriteLine("please enter one of the following options:");
            Console.WriteLine("1 for change team");
            Console.WriteLine("2 for replace a pokemon");
            Console.WriteLine("3 to save and exit");
            Console.WriteLine("4 to print team.");
            Console.WriteLine("EXIT to exit without saving");

            

            string input = Console.ReadLine();

            do
            {
                if (input == "1")
                {
                    DisplayPokemonTable(myDex.pokemonList);
                    Console.WriteLine();
                    Console.WriteLine("Please enter the numbers beside the pokemon you wish to add to the list with a space between each number:");
                    bool correctNumber = false;

                    do
                    {
                        string newTeam = Console.ReadLine();
                        string[] teamsplit = newTeam.Split(' ');
                        if (teamsplit.Length < 6)
                        {
                            Console.WriteLine("Not enough pokemon have been added. try again:");
                            correctNumber = false;
                        }
                        else if (teamsplit.Length > 6)
                        {
                            Console.WriteLine("to many pokemon have been added. please try again.");
                            correctNumber = false;
                        }
                        else
                        {
                            Console.WriteLine("Thank you. now writing team to memory.");
                            correctNumber = true;
                            team = teamsplit;
                        }
                    }
                    while (!correctNumber);

                    WriteTeamToMemory(team);

                }
                else if (input == "2")
                {
                    Console.WriteLine("Below is a list of your current team:");
                    foreach (var item in myPokemon)
                    {
                        Console.WriteLine("|{0}|{1}|", item.DexNumber, item.Name);
                    }

                    Console.WriteLine("please select which pokemon you wish to change.");
                    Console.WriteLine("enter between 1 - 6.");

                    int pokemonToChance = Convert.ToInt32(Console.ReadLine());

                    DisplayPokemonTable(myDex.pokemonList);
                    Console.WriteLine("please chooses a pokemon to add");
                    int chosePokemon = Convert.ToInt32( Console.ReadLine() );

                    Pokemon temp = GetPokemon(pokemonToChance,myDex,chosePokemon);

                    //Incompleat section the new number needs to be added to the list so the new team can be displayed.

                    //

                }
                else if (input == "3")
                {

                }
                else if (input == "4")
                {
                    foreach (Pokemon p in myDex.pokemonList)
                    {
                        foreach (var item in team)
                        {
                            if (item == "" || item == null)
                            {
                                break;
                            }
                            if (p.DexNumber == Convert.ToInt32(item))
                            {
                                myPokemon.Add(p);

                            }
                        }

                    }
                    Console.WriteLine("Your current team is:");
                    foreach (var item in myPokemon)
                    {
                        Console.WriteLine("|{0}|{1}|", item.DexNumber, item.Name);
                    }
                }
                else if (input.ToUpper() == "EXIT")
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Would you like to do anything else?");
                input = Console.ReadLine();
            } while (input.ToUpper() != "EXIT");
            

        }

        private static Pokemon GetPokemon(int singleInput, Pokedex myDex,int chosenPokemon)
        {
            List<Pokemon> templist = new List<Pokemon>();
            foreach (var item in myDex.pokemonList)
            {
                if (item.DexNumber == chosenPokemon)
                {

                    templist.Add( item );
                    break;
                }
            }

            return templist[0];
        }

        static void WriteTeamToMemory(string[] team)
        {
            string fileLocation = System.AppContext.BaseDirectory;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileLocation + username + "teams.txt"))
            {
                foreach (var item in team)
                {
                    file.Write(item + ",");
                }
                
            }
        }

        static void DisplayPokemonTable(List<Pokemon> pokemonList)
        {
            int count = 1;
            foreach (Pokemon item in pokemonList)
            {
                Console.Write("|{0}|{1}| ",item.DexNumber,item.Name);
                if (count % 6 == 0)
                {
                    Console.Write("\n");
                }
                count++;
            }
        }

        private static string[] GetTeam(string username)
        {
            // add try catch to stop when file dose not exist.
            string directory = System.AppContext.BaseDirectory;
            string teamIn = GetFileLines(directory + username + "teams.txt");
            return teamIn.Split(',');
        }
        #endregion
    }
}
