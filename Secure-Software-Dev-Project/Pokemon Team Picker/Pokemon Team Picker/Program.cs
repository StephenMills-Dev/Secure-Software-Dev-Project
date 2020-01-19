using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Team_Picker
{
    class Program
    {

        // removed methods
        // getFileLines();

        #region-class level variables-
        public static bool bigHeading;
        private static bool correctDetails;
        private static string userRoal;
        private static string username;
        private static Pokedex myDex = new Pokedex();
        private const string _PK = "S1XYL+2vo-9hC6G7Te$#FS>b;jR9H'";
        #endregion
        // changes made
        // * added create new user option, new users all get assigned the role of user.
        // * nulled the password input when done to prevent theft.
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
                    Console.WriteLine("Would you like to create new user?  Y or N");
                    string input = Console.ReadLine();
                    if (input == "Y")
                    {
                        
                        CreateNewUser(userDetaisl[0],userDetaisl[1]);
                    }
                }
                // nulling pasword after fail and success to prevent theft.
                userDetaisl[1] = null;
            } while (!correctDetails);
            if (correctDetails)
            {
                AppBody();
            }

        }
        
        // more efficiant reader created after submission 
        private static string[] CSVReading(string Directory,string username,string password)
        {
            // this opens the stream and closes it inside the statement.
            using (var reader = new StreamReader(Directory))
            {
                // we then test if info is present
                while (!reader.EndOfStream)
                {
                    // seperated the data
                    string line = reader.ReadLine();
                    string[] details = line.Split(',');

                    //perform encryption on user inputs to test agenst encrypted database data

                    if (details[0] != "" && details[0] != " ")
                    {
                        if (Cryptography.Decrypt(details[0], _PK) == username && Cryptography.Decrypt(details[1], _PK) == password)
                        {
                            correctDetails = true;
                            return details;
                        }
                    }
                    
                }
            }
            correctDetails = false;
            return null;
        }
        private static string[] CSVReading(string Directory, string username)
        {
            // this opens the stream and closes it inside the statement.
            using (var reader = new StreamReader(Directory))
            {
                // we then test if info is present
                while (!reader.EndOfStream)
                {
                    // seperated the data
                    string line = reader.ReadLine();
                    string[] details = line.Split(',');

                    if (details[0] == username)
                    {
                        return details;
                    }
                }
            }
            return null;
        }

        private static void CreateNewUser(string username,string password) 
        {
            string directory = System.AppContext.BaseDirectory + "UD.csv";
            string encryptUsername = Cryptography.Encrypt(username, _PK);
            string encryptPassword = Cryptography.Encrypt(password, _PK);
            string details = encryptUsername + "," + encryptPassword + "," + "User";
            List<string> lines = new List<string>();
            lines.Add(details);
            File.AppendAllLines(directory, lines);

            string teamDirectory = System.AppContext.BaseDirectory + "UT.csv";
            List<string> newTeam = new List<string>();
            string team = encryptUsername + ",1,1,1,1,1,1";
            newTeam.Add(team);
            File.AppendAllLines(teamDirectory, newTeam);
        }

        //print's title for the app
        static void Title()
        {
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
        static string[] RequestDetails()
        {
            Console.WriteLine("Please enter your Username");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password");
            string password = Console.ReadLine();
            return new string[] { username, password };
        }

        //Test Details agenst the array taken in.
        // changes made
        // * the directory has been shortened for faster use.
        // * the CSVReading asses the details passed in to check if true
        // * CSVReading also returns the users details or null
        // * if method tests if the user details is not null
        // * sets the pasword feild to null for cleanup of data
        static void AssesDetails(string[] userInputs)
        {
            // used to bring in all the user information at once
            string directory = System.AppContext.BaseDirectory + "UD.csv";

            string[] user = CSVReading(directory,userInputs[0],userInputs[1]);

            // set password to null to clear if the user stuff returns true.
            if (user != null)
            {
                user[1] = null;
                userInputs[1] = null;
                username = user[0];
                userRoal = user[2];
            }
        }
        #endregion

        #region-appBody Methods-
        // used for displaying the body of the app with additions based on the users roal. admin will alow the ussrs to see more and proforem differernt operations.
        static void AppBody()
        {
            if (userRoal == "Admin")
            {
                AdminExtra();
                UserApp();
            }
            else if (userRoal == "User")
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
            
            // search if any teams have been created by the user.
            // this is down to how the team is stored.

            string[] team = GetTeam(username);

            //needs t have
            #region-this is for if a team is present-
            foreach (Pokemon p in myDex.pokemonList)
            {
                foreach (var item in team)
                {
                    if (item == "" || item == null || item == username)
                    {
                        continue;
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
                    team = InputNumOne();
                }
                else if (input == "2")
                {
                    team = InputNumTwo(ref myPokemon,team);
                }
                else if (input == "3")
                {
                    InputNumThree(team);
                }
                else if (input == "4")
                {
                    InputNumFour(ref myPokemon,team);
                }
                else if (input.ToUpper() == "EXIT")
                {
                    Environment.Exit(0);
                }
                Console.WriteLine("Would you like to do anything else?");
                input = Console.ReadLine();
            } while (input.ToUpper() != "EXIT");
        }

        // methods now created rather than the code happening in the body section
        #region-InputNum Methods-
        private static string[] InputNumOne()
        {
            DisplayPokemonTable(myDex.pokemonList);
            Console.WriteLine();
            Console.WriteLine("Please enter the numbers beside the pokemon you wish to add to the list with a space between each number:");
            string[] team = new string[6];
            bool correctNumber = false;

            for (int i = 0; i < 6; i++)
            {
                do
                {
                    Console.WriteLine("Please Pick Pokemon Number {0}", i + 1);

                    string uInput = Console.ReadLine();
                    if (Convert.ToInt32(uInput) > 0 && Convert.ToInt32(uInput) < myDex.pokemonList.Count)
                    {
                        team[i] = uInput;
                        correctNumber = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input plaese Pick between 1 and {0}", myDex.pokemonList.Count);
                        correctNumber = false;
                    }
                }
                while (!correctNumber);
            }
            return team;
        }
        private static string[] InputNumTwo(ref List<Pokemon> myPokemon, string[] team)
        {
            Console.WriteLine("Below is a list of your current team:");
            InputNumFour(ref myPokemon,team);

            Console.WriteLine("please select which pokemon you wish to change.");
            Console.WriteLine("enter between 1 - 6.");

            int pokemonToChance = Convert.ToInt32(Console.ReadLine());


            DisplayPokemonTable(myDex.pokemonList);
            Console.WriteLine("please chooses a pokemon to add");
            int chosePokemon = Convert.ToInt32(Console.ReadLine());

            Pokemon temp = GetPokemon(pokemonToChance, myDex, chosePokemon);
            myPokemon[pokemonToChance] = temp;
            team[pokemonToChance] = myPokemon[pokemonToChance].DexNumber.ToString();
            return team;
        }
        private static void InputNumThree(string[] team)
        {
            WriteTeamToMemory(team);
        }
        private static void InputNumFour(ref List<Pokemon>myPokemon, string[] team)
        {
            Console.WriteLine("Your current team is:");
            myPokemon.Clear();
            foreach (var item in team)
            {
                if (item != username)
                {
                    myPokemon.Add(myDex.pokemonList[Convert.ToInt32(item)-1]);
                }
                

            }

            foreach (var item in myPokemon)
            {
                Console.WriteLine("|{0}|{1}|", item.DexNumber, item.Name);
            }
        }
        #endregion

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

        static void WriteTeamToMemory(string[] team) // changes this to just edit the line of the UT.csv ***************************************************************
        {
            string fileLocation = System.AppContext.BaseDirectory + "UT.csv";
            List<string> csv = new List<string>();
            using (var reader = new StreamReader(fileLocation))
            {
                
                // we then test if info is present
                while (!reader.EndOfStream)
                {
                    // seperated the data
                    string line = reader.ReadLine();
                    
                    string[] details = line.Split(',');


                    if (details[0] == username)
                    {
                        string myNewTeam = team[0] + "," + team[1] + "," + team[2] + "," + team[3] + "," + team[4] + "," + team[5];
                        line = details[0] + "," + myNewTeam;
                    }
                    csv.Add(line);
                }
            }

            using (var writer = new StreamWriter(fileLocation))
            {
                foreach (var item in csv)
                {
                    writer.WriteLine(item);
                }
            }

            Environment.Exit(0);
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

        // changes made
        // an overloaded VSVReading with only 2 paramiters searches in the UT(user teams) directory for the users team.
        // returns null if no team is found.
        private static string[] GetTeam(string username)
        {
            // add try catch to stop when file dose not exist.
            string directory = System.AppContext.BaseDirectory + "UT.csv";
            string[] myTeam = CSVReading(directory, username);
            if (myTeam != null)
            {
                return myTeam;
            }
            else return null;
            
        }
        #endregion
    }
}
