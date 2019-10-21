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

        readonly Pokemon bulbasaur = new Pokemon(001, 5, 4, 6, 4, 3, "A strange seed was planted on its back at birth. The plant sprouts and grows with this Pokémon.", "bulbasaur",10,0);
        readonly Pokemon ivysaur = new Pokemon(002, 10, 16, 12, 13, 11, "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.", "ivysaur",9,0);
        readonly Pokemon venusaur = new Pokemon(003, 25, 30, 28, 29, 19, "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.", "venusaur",11,0);
        readonly Pokemon charmander = new Pokemon();
        readonly Pokemon charmeleon = new Pokemon();
        readonly Pokemon charizard = new Pokemon();

        public Pokedex()
        {
            pokemonList.Add(bulbasaur);
            pokemonList.Add(ivysaur);
            pokemonList.Add(venusaur);
            pokemonList.Add(charmander);
            pokemonList.Add(charmeleon);
            pokemonList.Add(charizard);
        }
    }
}
