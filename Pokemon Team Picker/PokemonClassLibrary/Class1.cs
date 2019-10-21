using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClassLibrary
{
    public class Entity
    {
        public string name;
        public string health;
        public int age;
    }

    public class Pokemon : Entity
    {
        public int dexNumber { get; set; }
        public int attack { get; set; }
        public int defence { get; set; }
        public int spcAttack { get; set; }
        public int spcDefence { get; set; }
        public int speed { get; set; }
        public string description { get; set; }

        public Pokemon(int dexNum, int att, int def, int spcAtt, int spcDef, int speed, string des)
        {
            dexNumber = dexNum;
            attack = att;
            defence = def;
            spcAttack = spcAtt;
            spcDefence = spcDef;
            this.speed = speed;
            description = des;
        }
    }

    public class Pokedex 
    {

        private Pokemon bulbasaur = new Pokemon(001, 5,4,6, 4, 3, "A strange seed was planted on its back at birth. The plant sprouts and grows with this Pokémon.");
        Pokemon ivysaur = new Pokemon(002, 10, 16, 12, 13, 11, "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.");
        Pokemon venusaur = new Pokemon(003, 25, 30, 28, 29, 19, "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.");

        List<Pokemon> pokemonList = new List<Pokemon>() {  };
        

    }
}
