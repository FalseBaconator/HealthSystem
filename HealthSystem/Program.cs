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

        static int weapon;
        static string weaponName;
        static int ammo;
        static int maxAmmo;
        static string weaponOneName = "Revolver";
        static int weaponOneMaxAmmo = 6;
        static string weaponTwoName = "ShotGun";
        static int weaponTwoMaxAmmo = 2;
        static string weaponThreeName = "Laser Rifle";
        static int weaponThreeMaxAmmo = 10;
        static int defaultWeapon = 0;
        static string defaultWeaponName = weaponOneName;
        static int defaultMaxAmmo = weaponOneMaxAmmo;
        static int defaultAmmo = defaultMaxAmmo;



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
            weapon = defaultWeapon;
            weaponName = defaultWeaponName;
            ammo = defaultAmmo;
            maxAmmo = defaultMaxAmmo;

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
            Console.WriteLine("Weapon: " + weaponName);
            Console.WriteLine("Ammo: " + ammo.ToString());
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
                        return;
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
            status = "Permanently Dead";
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

        static void OneUp(int oneUps)
        {
            health = maxHealth;
            shield = maxShield;
            lives += oneUps;
            DetermineStatus();
            Console.WriteLine("Player gained " + oneUps.ToString() + " lives");
            if (lives >= maxLives)
            {
                Console.WriteLine("Player is at max lives");
                lives = maxLives;
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

        static void SwitchWeapon(int weap)
        {
            if(weapon == weap)
            {
                Console.WriteLine("Player took the ammo from the new " + weaponName);
                ammo = maxAmmo;
            }
            else
            {
                switch (weap)
                {
                    case 0:
                        weapon = weap;
                        weaponName = weaponOneName;
                        maxAmmo = weaponOneMaxAmmo;
                        ammo = maxAmmo;
                        Console.WriteLine("Player picked up a " + weaponName);
                        break;
                    case 1:
                        weapon = weap;
                        weaponName = weaponTwoName;
                        maxAmmo = weaponTwoMaxAmmo;
                        ammo = maxAmmo;
                        Console.WriteLine("Player picked up a " + weaponName);
                        break;
                    case 2:
                        weapon = weap;
                        weaponName = weaponThreeName;
                        maxAmmo = weaponThreeMaxAmmo;
                        ammo = maxAmmo;
                        Console.WriteLine("Player picked up a " + weaponName);
                        break;
                    default:
                        Console.WriteLine("Error: Not a valid weapon");
                        break;
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

            //take enough damage to die
            Reset();
            ShowHud();
            TakeDMG(250);
            ShowHud();

            //Die 3 times
            Reset();
            ShowHud();
            Console.WriteLine("DEBUG: Player is going to die enough times to get a game over");
            TakeDMG(200);
            ShowHud();
            TakeDMG(200);
            ShowHud();
            TakeDMG(200);
            ShowHud();

            //take damage and then get a life
            Reset();
            ShowHud();
            Console.WriteLine("DEBUG: Player is going to be damaged and then gain a life, healing them in the proccess");
            TakeDMG(150);
            ShowHud();
            OneUp(1);
            ShowHud();

            //gain more lives
            Reset();
            ShowHud();
            OneUp(3);
            ShowHud();

            //gain more than max lives
            Reset();
            ShowHud();
            OneUp(105);
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

            //switch to Revolver when already has revolver
            Reset();
            ShowHud();
            SwitchWeapon(0);
            ShowHud();

            //switch to shotgun
            Reset();
            ShowHud();
            SwitchWeapon(1);
            ShowHud();

            //switch to laser rifle
            Reset();
            ShowHud();
            SwitchWeapon(2);
            ShowHud();

            //switch to nonexistant weapon
            Reset();
            ShowHud();
            Console.WriteLine("DEBUG: Attempting to switch to a nonexistant weapon");
            SwitchWeapon(3);
            ShowHud();

            //switch to shotgun and back to revolver
            Reset();
            ShowHud();
            Console.WriteLine("DEBUG: switching to shotgun and back to revolver");
            SwitchWeapon(1);
            ShowHud();
            SwitchWeapon(0);
            ShowHud();

        }





    }
}
