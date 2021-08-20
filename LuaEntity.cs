using MoonSharp.Interpreter;
using System.Collections;
using System.Collections.Generic;

namespace LuaEntity
{
    public class Bird
    {
        public int health { get; set; }
        public int rarity { get; set; }
        public float speed { get; set; }
    }

    public class Ammo
    {
        public int damage { get; set; }
        public int area { get; set; }
        public int rarity { get; set; }
        public int speed { get; set; }

        public class AmmoEffect
        {
            public float dps { get; set; }
            public float slow { get; set; }
            public float duration { get; set; }
        }

        public Dictionary<Effects, AmmoEffect> effects { get; set; }
        //public Dictionary<Effects, Dictionary<string, int>> effects { get; set; }
    }
}

