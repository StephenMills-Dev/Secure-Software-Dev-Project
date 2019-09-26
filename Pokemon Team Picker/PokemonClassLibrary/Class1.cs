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
        public int dexNumber;
        public int attack;
        public int defence;
        public int spcAttack;
        public int spcDefence;
        public int speed;
    }

    public class Pokedex : Pokemon
    {

    }
}
