using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClassLibrary
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Age { get; set; }
    }

    class Pokemon : Entity
    {
        public int DexNumber { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int SpcAttack { get; set; }
        public int SpcDefence { get; set; }
        public int Speed { get; set; }
        public string Description { get; set; }

        public Pokemon(int dexNum, int att, int def, int spcAtt, int spcDef, int speed, string des, string name,int health,int age)
        {
            DexNumber = dexNum;
            Attack = att;
            Defence = def;
            SpcAttack = spcAtt;
            SpcDefence = spcDef;
            Speed = speed;
            Description = des;
            Name = name;
            Health = health;
            Age = age;
        }
    }

    // pokedex class. this class simply contains a list of 24 pokemon for accessing to add to the team
    // as you wish.
    class Pokedex
    {
        public List<Pokemon> pokemonList { get; }

        //first 6
        readonly Pokemon bulbasaur = new Pokemon(001, 5, 4, 6, 4, 3, "A strange seed was planted on its back at birth. The plant sprouts and grows with this Pokémon.", "bulbasaur",10,0);
        readonly Pokemon ivysaur = new Pokemon(002, 10, 16, 12, 13, 11, "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.", "ivysaur",9,0);
        readonly Pokemon venusaur = new Pokemon(003, 25, 30, 28, 29, 19, "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.", "venusaur",11,0);
        readonly Pokemon charmander = new Pokemon(004,5,4,6,4,3, "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.", "charmander", 10,0);
        readonly Pokemon charmeleon = new Pokemon(005,12,14,13,15,14, "When it swings its burning tail, it elevates the temperature to unbearably high levels.", "charmeleon", 10,0);
        readonly Pokemon charizard = new Pokemon(006,12,14,13,15,13, "Spits fire that is hot enough to melt boulders. Known to cause forest fires unintentionally.", "charizard", 10,0);

        // second repeated 6
        readonly Pokemon squirtle = new Pokemon(007, 5, 4, 6, 4, 3, "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.", "squirtle", 10, 0);
        readonly Pokemon wartortle = new Pokemon(008, 10, 16, 12, 13, 11, "Often hides in water to stalk unwary prey. For swimming fast, it moves its ears to maintain balance.", "wartortle", 9, 0);
        readonly Pokemon blastoise = new Pokemon(009, 25, 30, 28, 29, 19, "A brutal Pokémon with pressurized water jets on its shell. They are used for high speed tackles.", "blastoise", 11, 0);
        readonly Pokemon caterpie = new Pokemon(010, 5, 4, 6, 4, 3, "	Its short feet are tipped with suction pads that enable it to tirelessly climb slopes and walls.", "caterpie", 10, 0);
        readonly Pokemon metapod = new Pokemon(011, 12, 14, 13, 15, 14, "This Pokémon is vulnerable to attack while its shell is soft, exposing its weak and tender body.", "metapod", 10, 0);
        readonly Pokemon butterfree = new Pokemon(012, 12, 14, 13, 15, 13, "In battle, it flaps its wings at high speed to release highly toxic dust into the air.", "butterfree", 10, 0);

        //thired 6
        readonly Pokemon weedle = new Pokemon(013, 5, 4, 6, 4, 3, "Often found in forests, eating leaves. It has a sharp venomous stinger on its head.", "", 10, 0);
        readonly Pokemon kakuna = new Pokemon(014, 10, 16, 12, 13, 11, "Almost incapable of moving, this Pokémon can only harden its shell to protect itself from predators.", "", 9, 0);
        readonly Pokemon beedrill = new Pokemon(015, 25, 30, 28, 29, 19, "Flies at high speed and attacks using its large venomous stingers on its forelegs and tail.", "", 11, 0);
        readonly Pokemon pidgey = new Pokemon(016, 5, 4, 6, 4, 3, "	A common sight in forests and woods. It flaps its wings at ground level to kick up blinding sand.", "", 10, 0);
        readonly Pokemon pidgeotto = new Pokemon(017, 12, 14, 13, 15, 14, "	Very protective of its sprawling territorial area, this Pokémon will fiercely peck at any intruder.", "", 10, 0);
        readonly Pokemon pidgeot = new Pokemon(018, 12, 14, 13, 15, 13, "When hunting, it skims the surface of water at high speed to pick off unwary prey such as Magikarp.", "", 10, 0);

        //forth 6
        readonly Pokemon ratata = new Pokemon(019, 5, 4, 6, 4, 3, "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.", "squirtle", 10, 0);
        readonly Pokemon raticate = new Pokemon(020, 10, 16, 12, 13, 11, "Often hides in water to stalk unwary prey. For swimming fast, it moves its ears to maintain balance.", "wartortle", 9, 0);
        readonly Pokemon spearow = new Pokemon(021, 25, 30, 28, 29, 19, "A brutal Pokémon with pressurized water jets on its shell. They are used for high speed tackles.", "blastoise", 11, 0);
        readonly Pokemon fearow = new Pokemon(022, 5, 4, 6, 4, 3, "	Its short feet are tipped with suction pads that enable it to tirelessly climb slopes and walls.", "caterpie", 10, 0);
        readonly Pokemon ekans = new Pokemon(023, 12, 14, 13, 15, 14, "This Pokémon is vulnerable to attack while its shell is soft, exposing its weak and tender body.", "metapod", 10, 0);
        readonly Pokemon arbok = new Pokemon(024, 12, 14, 13, 15, 13, "In battle, it flaps its wings at high speed to release highly toxic dust into the air.", "butterfree", 10, 0);

        public Pokedex()
        {
            pokemonList.Add(bulbasaur);
            pokemonList.Add(ivysaur);
            pokemonList.Add(venusaur);
            pokemonList.Add(charmander);
            pokemonList.Add(charmeleon);
            pokemonList.Add(charizard);
            pokemonList.Add(squirtle);
            pokemonList.Add(wartortle);
            pokemonList.Add(blastoise);
            pokemonList.Add(caterpie);
            pokemonList.Add(metapod);
            pokemonList.Add(butterfree);
            pokemonList.Add(weedle);
            pokemonList.Add(kakuna);
            pokemonList.Add(beedrill);
            pokemonList.Add(pidgey);
            pokemonList.Add(pidgeotto);
            pokemonList.Add(pidgeot);
            pokemonList.Add(ratata);
            pokemonList.Add(raticate);
            pokemonList.Add(spearow);
            pokemonList.Add(fearow);
            pokemonList.Add(ekans);
            pokemonList.Add(arbok);
        }
    }
}
