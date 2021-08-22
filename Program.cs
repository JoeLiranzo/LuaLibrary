using LuaEntity;
using System;
using System.Collections.Generic;

namespace LuaLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird bird = new Bird();
            Ammo ammo = new Ammo();
            Random random = new Random();

            ammo = LuaCode.GetTable<Ammo>("AMMO", "PoisonBomb", true);

            float damage = 500f;

            float dmg_result;
            float DAMAGE_MIN_PERCENT = (float)LuaCode.GetLuaGlobal("EXTRAPOLATE_MIN_PERCENT").Number;
            float DAMAGE_MAX_PERCENT = (float)LuaCode.GetLuaGlobal("EXTRAPOLATE_MAX_PERCENT").Number;

            var bullets = new Dictionary<BombType, int>();

            //bullets.Add((BombType)currentAmmo, LuaLibrary.LuaCode.ExecuteLuaFunction("GetAmmoBulletsByLevel", Enum.GetName(typeof(BombType), currentAmmo), GameController.GameCurrentLevel.ToString()).Integer);

             //shipLoads = new List<Shipload>();

            var shipLoads = LuaCode.ExecuteLuaFunctionList<Shipload>("GetShipLoads");

            foreach (var shipLoad in shipLoads)
            {
                //bullets.Add(shipLoad.bombType, shipLoad.amount);
                Console.WriteLine(shipLoad);
            }

            //for (int i = 0; i < 10; i++)
            //{
            //    dmg_result = random.Next((int)(damage * DAMAGE_MIN_PERCENT), (int)(damage * (DAMAGE_MAX_PERCENT)));//UnityEngine.Random.Range(damage*DAMAGE_MIN_PERCENT, damage*DAMAGE_MAX_PERCENT);
            //    Console.WriteLine(dmg_result);
            //}

            //ammo.effects.Add(Effects.poison, new Ammo.AmmoEffect());

            //AMMO.
            //foreach (var effect in ammo.effects)
            //{
            //    //Console.WriteLine(effect.Key + " " + effect.Value);
            //}

            //bird = LuaCode.GetTable<Bird>("BIRDS", "SimpleBird");
            //Console.WriteLine("Bird Health: " + bird.health);
            //Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
