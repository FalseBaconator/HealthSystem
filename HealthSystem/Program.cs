using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem
{
    internal class Program
    {

        static int health;
        static int maxHealth = 100;
        static int shield;
        static int maxShield = 100;
        static int lives;
        static int MaxLives = 99;
        static int lvl;
        static int maxLvl = 99;
        static int xp;
        static int xpToLvlUp = 100;

        static void Main(string[] args)
        {

        }

        static void Reset()
        {
            health = maxHealth;
            shield = maxShield;
            lives = 3;
            lvl = 1;
            xp = 0;
        }
    }
}
