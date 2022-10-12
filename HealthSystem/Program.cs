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
        static int maxLives = 99;
        static int defaultLives = 3;
        static int lvl;
        static int maxLvl = 99;
        static int defaultLvl = 1;
        static int xp;
        static int xpToLvlUp = 100;
        static int defaultXP = 0;
        static string status;

        static void Main(string[] args)
        {
            UnitTest();
        }

        static void Reset()
        {
            health = maxHealth;
            shield = maxShield;
            lives = defaultLives;
            lvl = defaultLvl;
            xp = defaultXP;

            DetermineStatus();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("RESET");
            Console.WriteLine();
        }

        static void DetermineStatus()
        {

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

        }

        static void ShowHud()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine("Shield: " + shield);
            Console.WriteLine("Health: " + health);
            Console.WriteLine("Status: " + status);
            Console.WriteLine("Lives: " + lives);
            Console.WriteLine("Level: " + lvl);
            Console.WriteLine("XP: " + xp);
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
            DetermineStatus();
        }

        static void GameOver()
        {
            Console.WriteLine("GAME OVER!");
        }

        static void Heal(int toHeal)
        {
            Console.WriteLine("Player gained " + toHeal.ToString() + " health");
            health += toHeal;
            if(health > maxHealth)
            {
                health = maxHealth;
            }
            DetermineStatus();
        }

        static void RegenShield(int toRegen)
        {
            Console.WriteLine("Player gained " + toRegen.ToString() + " shield");
            shield += toRegen;
            if(shield > maxShield)
            {
                shield = maxShield;
            }
        }

        static void GainXP(int toGain)
        {
            Console.WriteLine("Player gained " + toGain + " XP");
            xp += toGain;
            while(xp >= xpToLvlUp)
            {
                xp -= xpToLvlUp;
                if(lvl < maxLvl)
                {
                    Console.WriteLine("LEVEL UP!");
                    lvl += 1;
                }
                else
                {
                    Console.WriteLine("Already at max level");
                }
            }
        }

        static void UnitTest()
        {
            //take 50 dmg
            Reset();
            ShowHud();
            TakeDMG(50);
            ShowHud();

            //take 150 dmg
            Reset();
            ShowHud();
            TakeDMG(150);
            ShowHud();

            //take damage to show healing
            Reset();
            ShowHud();
            Console.WriteLine("DEBUG: Player is going to be damaged and then healed");
            TakeDMG(150);
            ShowHud();
            Heal(25);
            ShowHud();

            //take damage and then heal above max
            Reset();
            ShowHud();
            Console.WriteLine("DEBUG: Player is going to be damaged and then healed above their max");
            TakeDMG(150);
            ShowHud();
            Heal(150);
            ShowHud();

            //take damage and then regen shield
            Reset();
            ShowHud();
            Console.WriteLine("DEBUG: Player is going to be damaged and then regain shield");
            TakeDMG(50);
            ShowHud();
            RegenShield(25);
            ShowHud();

            //take damage and then regen shield above max
            Reset();
            ShowHud();
            Console.WriteLine("DEBUG: Player is going to be damaged and regain shield above their max");
            TakeDMG(50);
            ShowHud();
            RegenShield(75);
            ShowHud();

            //Gain XP
            Reset();
            ShowHud();
            GainXP(50);
            ShowHud();

            //Gain XP enough to lvl up
            Reset();
            ShowHud();
            GainXP(150);
            ShowHud();

            //Gain XP enough to lvl up multiple times
            Reset();
            ShowHud();
            Console.WriteLine("DEBUG: Player is going to gain enough XP to level up multiple times in one go");
            GainXP(350);
            ShowHud();

            //Gain XP enough to reach max lvl
            Reset();
            ShowHud();
            Console.WriteLine("DEBUG: Player is going to reach max lvl");
            GainXP(9950);
            ShowHud();



        }





    }
}
