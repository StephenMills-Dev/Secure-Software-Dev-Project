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
        readonly Pokemon squirtle = new Pokemon(001, 5, 4, 6, 4, 3, "After birth, its back swells and hardens into a shell. Powerfully sprays foam from its mouth.", "squirtle", 10, 0);
        readonly Pokemon wartortle = new Pokemon(002, 10, 16, 12, 13, 11, "Often hides in water to stalk unwary prey. For swimming fast, it moves its ears to maintain balance.", "wartortle", 9, 0);
        readonly Pokemon blastoise = new Pokemon(003, 25, 30, 28, 29, 19, "A brutal Pokémon with pressurized water jets on its shell. They are used for high speed tackles.", "blastoise", 11, 0);
        readonly Pokemon caterpie = new Pokemon(004, 5, 4, 6, 4, 3, "	Its short feet are tipped with suction pads that enable it to tirelessly climb slopes and walls.", "caterpie", 10, 0);
        readonly Pokemon metapod = new Pokemon(005, 12, 14, 13, 15, 14, "This Pokémon is vulnerable to attack while its shell is soft, exposing its weak and tender body.", "metapod", 10, 0);
        readonly Pokemon butterfree = new Pokemon(006, 12, 14, 13, 15, 13, "In battle, it flaps its wings at high speed to release highly toxic dust into the air.", "butterfree", 10, 0);

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
        }
    }
}
