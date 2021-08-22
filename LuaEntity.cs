using MoonSharp.Interpreter;
using System.Collections;
using System.Collections.Generic;

public enum BombType { Bomb, IceBomb, PoisonBomb, TeleBomb, Inferno, MegaBomb }

public struct KeyVal<TKey, TVal>
{
    public TKey Key { get; set; }
    public TVal Value { get; set; }
    public KeyVal(TKey key, TVal val) { this.Key = key; this.Value = val; }
    public void Set(TKey key, TVal val) { this.Key = key; this.Value = val; }
    public KeyVal<TKey, TVal> Get() { return this; }
}

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

    public class Shipload
    {
        public BombType bombType {get; set;}

        public int amount {get;set;}
    }
}

