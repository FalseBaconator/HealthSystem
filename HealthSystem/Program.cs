using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem
{
    internal class Program
    {
        //Variables

        //HP
        static int health;
        static int prevHealth; //Previous health
        static int difHealth; //difference in health
        static int maxHealth = 100;

        //shield
        static int shield;
        static int prevShield;
        static int difShield;
        static int maxShield = 100;

        //lives
        static int lives;
        static int prevLives;
        static int difLives;
        static int maxLives = 99;
        static int defaultLives = 3;

        //levels
        static int lvl;
        static int prevLvl;
        static int difLvl;
        static int maxLvl = 99;
        static int defaultLvl = 1;

        //Experience
        static int xp;
        static int prevXP;
        static int difXP;
        static int xpToLvlUp = 100;
        static int defaultXP = 0;

        //written status
        static string status;

        //weaponry
        //current weapon and ammo
        static int weapon;
        static string weaponName;
        static int weaponDMG;
        static int ammo;
        static int prevAmmo;
        static int difAmmo;
        static int maxAmmo;

        //revolver stats
        static string weaponOneName = "Revolver";
        static int weaponOneMaxAmmo = 6;
        static int weaponOneDMG = 3;

        //shotgun stats
        static string weaponTwoName = "ShotGun";
        static int weaponTwoMaxAmmo = 2;
        static int weaponTwoDMG = 10;

        //rifle stats
        static string weaponThreeName = "Rifle";
        static int weaponThreeMaxAmmo = 10;
        static int weaponThreeDMG = 5;

        //default is revolver
        static int defaultWeapon = 0;
        static string defaultWeaponName = weaponOneName;
        static int defaultMaxAmmo = weaponOneMaxAmmo;
        static int defaultAmmo = defaultMaxAmmo;

        //input
        static string playerInput;

        //enemy
        static int eHealth;
        static int eMaxHealth;
        static int eDMG;

        //Items
        const string healName = "Health Pack";
        static int healCount;
        static int prevHealCount;
        static int difHealCount;
        static int healPower = 50;
        const string shieldName = "Shield Pack";
        static int shieldCount;
        static int prevShieldCount;
        static int difShieldCount;
        static int shieldPower = 50;

        //Methods

        static void Main(string[] args)
        {
            UnitTest();
        }

        static void Reset()
        {
            //set all stats to default
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

            //make sure that no difference is displayed in ShowHud;
            SetPrevs();
            SetDifs();

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("A RESET OCCURRED");
            Console.WriteLine();
        }

        static void DetermineStatus()
        {
            //changes status method to match health
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

            //shield
            Console.Write("Shield: " + shield.ToString());
            if(difShield > 0) //shield gained
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" +" + difShield.ToString());
                Console.ResetColor();
            }else if(difShield < 0) //shield lost
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" " + difShield.ToString());
                Console.ResetColor();
            }
            else //no change
            {
                Console.WriteLine();
            }

            //health
            Console.Write("Health: " + health.ToString());
            if (difHealth > 0) //health gained
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" +" + difHealth.ToString());
                Console.ResetColor();
            }
            else if (difHealth < 0) //health lost
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" " + difHealth.ToString());
                Console.ResetColor();
            }
            else //no change
            {
                Console.WriteLine();
            }

            //status
            Console.WriteLine("Status: " + status);

            //lives
            Console.Write("Lives: " + lives.ToString());
            if (difLives > 0) //lives gained
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" +" + difLives.ToString());
                Console.ResetColor();
            }
            else if (difLives < 0)//lives lost
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" " + difLives.ToString());
                Console.ResetColor();
            }
            else //no change
            {
                Console.WriteLine();
            }

            //level
            Console.Write("Level: " + lvl.ToString());
            if (difLvl > 0) //lvl gained
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" +" + difLvl.ToString());
                Console.ResetColor();
            }
            else if (difLvl < 0) //lvl lost | shoudln't really be possible
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" " + difLvl.ToString());
                Console.ResetColor();
            }
            else //no change
            {
                Console.WriteLine();
            }

            //XP
            Console.Write("XP: " + xp.ToString());
            if (difXP > 0) //xp gained
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" +" + difXP.ToString());
                Console.ResetColor();
            }
            else if (difXP < 0) //xp lost
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" " + difXP.ToString());
                Console.ResetColor();
            }
            else //no change
            {
                Console.WriteLine();
            }

            //weapon name
            Console.WriteLine("Weapon: " + weaponName);

            //ammo
            Console.Write("Ammo: " + ammo.ToString());
            if (difAmmo > 0) //ammo gained
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" +" + difAmmo.ToString());
                Console.ResetColor();
            }
            else if (difAmmo < 0) // ammo lost
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" " + difAmmo.ToString());
                Console.ResetColor();
            }
            else //no change
            {
                Console.WriteLine();
            }

            Console.WriteLine("-----------------------");
            Console.WriteLine();

            //Inventory

            Console.WriteLine("Inventory");

            //HealPacks
            Console.Write(healName + ": " + healCount);
            if (difHealCount > 0) //ammo gained
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" +" + difHealCount.ToString());
                Console.ResetColor();
            }
            else if (difHealCount < 0) // ammo lost
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" " + difHealCount.ToString());
                Console.ResetColor();
            }
            else //no change
            {
                Console.WriteLine();
            }

            //ShieldPacks
            Console.Write(shieldName + ": " + shieldCount);
            if (difShieldCount > 0) //ammo gained
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" +" + difShieldCount.ToString());
                Console.ResetColor();
            }
            else if (difShieldCount < 0) // ammo lost
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" " + difShieldCount.ToString());
                Console.ResetColor();
            }
            else //no change
            {
                Console.WriteLine();
            }

            Console.WriteLine("-----------------------");
            Console.WriteLine();

            Console.ReadKey(true);

        }

        static void TakeDMG(int DMG)
        {
            SetPrevs(); //save current stats
            Console.WriteLine("Player is taking " + DMG.ToString() + " damage");
            if(DMG >= 0) //error check
            {
                if(shield < DMG) //if will lose shield, or already lost shield
                {
                    DMG -= shield;  //shield removes some dmg
                    shield = 0;     //shield is 0
                    health -= DMG;  //remaining dmg goes to health
                    if (health <= 0)                                //
                    {                                               //
                        health = 0;                                 //if player dies 
                        Console.WriteLine("Player has died");       //
                        lives -= 1;                                 //
                        if (lives <= 0) //
                        {               //
                            GameOver(); //if 0 lives
                            return;     //
                        }               //
                        else                                            //
                        {                                               //
                            health = maxHealth;                         //respawn
                            shield = maxShield;                         //
                            Console.WriteLine("Player has respawned");  //
                        }                                               
                    }
                }
                else                //
                {                   //shield takes dmg but isn't 0 yet
                    shield -= DMG;  //
                }                   //

                DetermineStatus();

            }
            else                                                        //
            {                                                           //
                Console.WriteLine("ERROR: Can't deal negative damage"); //error
            }                                                           //

            SetDifs();//compare current stats to stats at the start of the method
        }

        static void GameOver()
        {
            SetDifs();//compare stats to stats at the beginning of TakeDMG()
            Console.WriteLine("GAME OVER!");
            status = "Permanently Dead";
        }

        static void Heal(int toHeal)
        {
            SetPrevs();//save current stats
            Console.WriteLine("Player gained " + toHeal.ToString() + " health");
            if (toHeal >= 0) //error check
            {
                health += toHeal;//heal
                if(health > maxHealth)  //
                {                       //
                    health = maxHealth; //range check
                }                       //

                DetermineStatus();
            }
            else                                                        //
            {                                                           //
                Console.WriteLine("ERROR: Can't heal negative health"); //error
            }                                                           //

            SetDifs(); //compare current stats to stats at beginning of method
        }

        static void RegenShield(int toRegen)
        {
            SetPrevs();//save current stats
            Console.WriteLine("Player gained " + toRegen.ToString() + " shield");
            if(toRegen >= 0)//error check
            {
                shield += toRegen;//regen
                if(shield > maxShield)  //
                {                       //
                    shield = maxShield; //range check
                }                       //
            }
            else                                                            //
            {                                                               //
                Console.WriteLine("ERROR: Can't regen negative shield");    //error
            }                                                               //

            SetDifs(); //compare current stats to stats at beginning of method
        }

        static void OneUp(int oneUps)
        {
            SetPrevs();//save current stats
            Console.WriteLine("Player gained " + oneUps.ToString() + " lives");
            if(oneUps >= 0)//error check
            {
                health = maxHealth; //
                shield = maxShield; //heal and add life
                lives += oneUps;    //
                DetermineStatus();  //
                if (lives >= maxLives)                              //
                {                                                   //
                    Console.WriteLine("Player is at max lives");    //range check
                    lives = maxLives;                               //
                }                                                   //
            }
            else                                                        //
            {                                                           //
                Console.WriteLine("ERROR: Can't give negative lives");  //error
            }                                                           //

            SetDifs();//compare current stats to stats at beginning of method
        }

        static void GainXP(int toGain)
        {
            SetPrevs();//save current stats
            Console.WriteLine("Player gained " + toGain + " XP");
            if(toGain >= 0)//error check
            {
                xp += toGain;//gain
                while(xp >= xpToLvlUp)                              //level up loop
                {                                                   //
                    xp -= xpToLvlUp;                                //  //
                    if(lvl < maxLvl)                                //  //  //range check
                    {                                               //  //level up once
                        Console.WriteLine("LEVEL UP!");             //  //
                        lvl += 1;                                   //  //
                    }                                               //  //
                    else                                            //      //
                    {                                               //      //
                        Console.WriteLine("Already at max level");  //      //range check
                    }                                               //      //
                }                                                   //
            }
            else                                                        //
            {                                                           //
                Console.WriteLine("ERROR: Can't give negative XP");     //error
            }                                                           //

            SetDifs();//compare current stats to stats at the start of the method
        }

        static void SwitchWeapon(int weap)
        {
            SetPrevs();//save current stats
            if(weapon == weap)                                                          //
            {                                                                           //
                Console.WriteLine("Player took the ammo from the new " + weaponName);   //if changing to current weapon
                ammo = maxAmmo;                                                         //
            }                                                                           //
            else
            {
                switch (weap)                                                   //switch weapon
                {                                                               //
                    case 0:                                                     //  //
                        weapon = weap;                                          //  //
                        weaponName = weaponOneName;                             //  //
                        maxAmmo = weaponOneMaxAmmo;                             //  //revolver
                        ammo = maxAmmo;                                         //  //
                        weaponDMG = weaponOneDMG;                               //  //
                        Console.WriteLine("Player picked up a " + weaponName);  //  //
                        break;                                                  //  //
                    case 1:                                                     //      //
                        weapon = weap;                                          //      //
                        weaponName = weaponTwoName;                             //      //
                        maxAmmo = weaponTwoMaxAmmo;                             //      //shotgun
                        ammo = maxAmmo;                                         //      //
                        weaponDMG = weaponTwoDMG;                               //      //
                        Console.WriteLine("Player picked up a " + weaponName);  //      //
                        break;                                                  //      //
                    case 2:                                                     //          //
                        weapon = weap;                                          //          //
                        weaponName = weaponThreeName;                           //          //
                        maxAmmo = weaponThreeMaxAmmo;                           //          //laser rifle
                        ammo = maxAmmo;                                         //          //
                        weaponDMG = weaponThreeDMG;                             //          //
                        Console.WriteLine("Player picked up a " + weaponName);  //          //
                        break;                                                  //          //
                    default:                                                    //  //
                        Console.WriteLine("Error: Not a valid weapon");         //  //error check
                        break;                                                  //  //
                }                                                               //
            }

            SetDifs(); //compare current stats to stats at start of method      
        }

        static void Fire(int times)
        {
            SetPrevs();//save current stats
            Console.WriteLine("firing " + times.ToString() + " times");
            if (times >= 0)//error check
            {
                while(times > 0 && ammo > 0)        //
                {                                   //
                    times--;                        //has ammmo
                    ammo--;                         //
                    Console.WriteLine("Bang!");     //
                }                                   //
                while (times > 0 && ammo <= 0)          //
                {                                       //
                    times--;                            //ammo'nt
                    ammo = 0;                           //
                    Console.WriteLine("Click");         //
                }                                       //
            }
            else                                                        //
            {                                                           //
                Console.WriteLine("Error: can't fire negative times");  //error
            }                                                           //

            SetDifs(); //compare current stats to stats at start of method
        }

        static void Reload()
        {
            SetPrevs();//save current stats
            ammo = maxAmmo;
            Console.WriteLine("Player reloaded");
            SetDifs(); //compare current stats to stats at start of method
        }

        static void SetPrevs()
        {
            //save the current stats
            prevShield = shield;
            prevHealth = health;
            prevLives = lives;
            prevLvl = lvl;
            prevXP = xp;
            prevAmmo = ammo;
            prevHealCount = healCount;
            prevShieldCount = shieldCount;
        }

        static void SetDifs()
        {
            //compare current stats to the stats held at the last SetPrevs()
            difShield = shield - prevShield;
            difHealth = health - prevHealth;
            difLives = lives - prevLives;
            difLvl = lvl - prevLvl;
            difXP = xp - prevXP;
            difAmmo = ammo - prevAmmo;
            difHealCount = healCount - prevHealCount;
            difShieldCount = shieldCount - prevShieldCount;
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
            TakeDMG(150);
            ShowHud();
            TakeDMG(100);
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

            //reload with revolver
            Reset();
            ShowHud();
            Fire(1);
            ShowHud();
            Reload();
            ShowHud();

            //reload more than one bullet for revolver
            Reset();
            ShowHud();
            Fire(4);
            ShowHud();
            Reload();
            ShowHud();

            //reload shotgun
            Reset();
            ShowHud();
            SwitchWeapon(1);
            ShowHud();
            Fire(1);
            ShowHud();
            Reload();
            ShowHud();

            //reload more shotgun
            Reset();
            ShowHud();
            SwitchWeapon(1);
            ShowHud();
            Fire(4);
            ShowHud();
            Reload();
            ShowHud();

            //Reload rifle
            Reset();
            ShowHud();
            SwitchWeapon(2);
            ShowHud();
            Fire(1);
            ShowHud();
            Reload();
            ShowHud();

            //Reload more rifle
            Reset();
            ShowHud();
            SwitchWeapon(2);
            ShowHud();
            Fire(7);
            ShowHud();
            Reload();
            ShowHud();
        }

        static void GetBattleInput()
        {
            Console.WriteLine("Do you want to 'attack', 'reload', 'use item' or 'run'?");
            playerInput = Console.ReadLine();
            switch (playerInput)
            {
                case "attack":
                    DealDMG(weaponDMG);
                    break;
                case "reload":
                    Reload();
                    break;
                case "use item":
                    Console.WriteLine("Which item? " + healName + " or " + shieldName);
                    UseItem(Console.ReadLine());
                    break;
                case "run":
                    break;
                default:
                    Console.WriteLine("Error: invalid command");
                    GetBattleInput();
                    break;
            }
            ShowHud();
        }

        static void DealDMG(int DMG)
        {
            eHealth -= DMG;
        }

        static void UseItem(string Item)
        {
            switch (Item)
            {
                case healName:
                    if (healCount > 0)
                    {
                        Heal(healPower);
                        healCount--;
                        if(healCount < 0)
                        {
                            healCount = 0;
                        }
                        else
                        {
                            Console.WriteLine("you don't have any");
                            GetBattleInput();
                        }
                    }
                    break;
                case shieldName:
                    if(shieldCount > 0)
                    {
                        RegenShield(shieldPower);
                        shieldCount--;
                        if(shieldCount < 0)
                        {
                            shieldCount = 0;
                        }
                        else
                        {
                            Console.WriteLine("you don't have any");
                            GetBattleInput();
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Error: Invalid item");
                    GetBattleInput();
                    break;
            }
        }

    }
}
