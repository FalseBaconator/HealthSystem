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
            Console.WriteLine("A RESET OCCURRED");
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
                status = "You can probably walk that off, right?";
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
            if(DMG >= 0)
            {
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
                            Console.WriteLine("Player has respawned");
                        }
                    }
                }
                else
                {
                    shield -= DMG;
                }
                DetermineStatus();
            }
            else
            {
                Console.WriteLine("ERROR: Can't deal negative damage");
            }
            
        }

        static void GameOver()
        {
            Console.WriteLine("GAME OVER!");
            status = "Permanently Dead";
        }

        static void Heal(int toHeal)
        {
            Console.WriteLine("Player gained " + toHeal.ToString() + " health");
            if (toHeal >= 0)
            {
                health += toHeal;
                if(health > maxHealth)
                {
                    health = maxHealth;
                }
                DetermineStatus();
            }
            else
            {
                Console.WriteLine("ERROR: Can't heal negative health");
            }
            
        }

        static void RegenShield(int toRegen)
        {
            Console.WriteLine("Player gained " + toRegen.ToString() + " shield");
            if(toRegen >= 0)
            {
                shield += toRegen;
                if(shield > maxShield)
                {
                    shield = maxShield;
                }
            }
            else
            {
                Console.WriteLine("ERROR: Can't regen negative shield");
            }
        }

        static void OneUp(int oneUps)
        {
            Console.WriteLine("Player gained " + oneUps.ToString() + " lives");
            if(oneUps >= 0)
            {
                health = maxHealth;
                shield = maxShield;
                lives += oneUps;
                DetermineStatus();
                if (lives >= maxLives)
                {
                    Console.WriteLine("Player is at max lives");
                    lives = maxLives;
                }
            }
            else
            {
                Console.WriteLine("ERROR: Can't give negative lives");
            }
        }

        static void GainXP(int toGain)
        {
            Console.WriteLine("Player gained " + toGain + " XP");
            if(toGain >= 0)
            {
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
            else
            {
                Console.WriteLine("ERROR: Can't give negative XP");
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

        static void Fire(int times)
        {
            Console.WriteLine("firing " + times.ToString() + " times");
            if (times >= 0)
            {
                while(times > 0 && ammo > 0)
                {
                    times--;
                    ammo--;
                    Console.WriteLine("Bang!");
                }
                while (times > 0 && ammo <= 0)
                {
                    ammo = 0;
                    Console.WriteLine("Click");
                }
            }
            else
            {
                Console.WriteLine("Error: can't fire negative times");
            }
        }

        static void Reload()
        {
            ammo = maxAmmo;
            Console.WriteLine("Player reloaded");
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

            //take negative dmg
            Reset();
            ShowHud();
            TakeDMG(-50);
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

            //heal negative
            Reset();
            ShowHud();
            Heal(-50);
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

            //Regen negative shield
            Reset();
            ShowHud();
            RegenShield(-50);
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

            //gain negative lives
            Reset();
            ShowHud();
            OneUp(-1);
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

            //Gain negative XP
            Reset();
            ShowHud();
            GainXP(-50);
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

            //switch to shotgun and back to revolver
            Reset();
            ShowHud();
            Console.WriteLine("DEBUG: switching to shotgun and back to revolver");
            SwitchWeapon(1);
            ShowHud();
            SwitchWeapon(0);
            ShowHud();

            //switch to nonexistant weapon
            Reset();
            ShowHud();
            Console.WriteLine("DEBUG: Attempting to switch to a nonexistant weapon");
            SwitchWeapon(3);
            ShowHud();

            //fire with revolver
            Reset();
            ShowHud();
            Fire(1);
            ShowHud();

            //fire 10 times with revolver
            Reset();
            ShowHud();
            Fire(10);
            ShowHud();

            //fire negative times with revolver
            Reset();
            ShowHud();
            Fire(-10);
            ShowHud();

            //fire with ShotGun
            Reset();
            ShowHud();
            SwitchWeapon(1);
            ShowHud();
            Fire(1);
            ShowHud();

            //fire 5 times with shotgun
            Reset();
            ShowHud();
            SwitchWeapon(1);
            ShowHud();
            Fire(5);
            ShowHud();

            //fire negative times with shotgun
            Reset();
            ShowHud();
            SwitchWeapon(1);
            ShowHud();
            Fire(-5);
            ShowHud();

            //fire with laser rifle
            Reset();
            ShowHud();
            SwitchWeapon(2);
            ShowHud();
            Fire(1);
            ShowHud();

            //fire 15 times with laser
            Reset();
            ShowHud();
            SwitchWeapon(2);
            ShowHud();
            Fire(15);
            ShowHud();

            //fire negative times with laser
            Reset();
            ShowHud();
            SwitchWeapon(2);
            ShowHud();
            Fire(-1);
            ShowHud();


        }





    }
}
