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

        static string DetermineStatus()
        {
            string status;

            if(health >= 0 && health <= 10)
            {
                status = "Go to a hospital";
            }else if(health <= 25)
            {
                status = "Probably crippled";
            }else if(health <= 50)
            {
                status = "Doing pretty poorly";
            }else if(health <= 75)
            {
                status = "You can probably walk that off right?";
            }else if(health < 100)
            {
                status = "Doing alright";
            }else if (health == 100)
            {
                status = "In perfect health";
            }
            else
            {
                status = "Something went wrong in DetermineStatus()";
            }

            return status;

        }

        static void ShowHud()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Shield: " + shield);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Status: " + DetermineStatus());
            Console.WriteLine("Lives: " + lives);
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.ReadKey(true);

        }

        static void TakeDMG(int DMG)
        {
            Console.WriteLine("Player is taking " + DMG.ToString() + " damage");
            if(shield < DMG)
            {
                DMG -= shield;
                shield = 0;
                health -= DMG;
                if (health <= 0)
                {
                    health = 0;
                    Console.WriteLine("Player has died");
                    lives -= 1;
                    if (lives <= 0)
                    {
                        GameOver();
                    }
                    else
                    {
                        health = maxHealth;
                        shield = maxShield;
                    }
                }
            }
            else
            {
                shield -= DMG;
            }
        }

        static void GameOver()
        {
            Console.WriteLine("GAME OVER!");
        }

    }
}
