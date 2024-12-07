using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// --------------------------------------------------------------------------------------------------------------------------------
//LIMITED CHARACTER BANNER
//ONLY 3 STAR WEAPONS, 4 STAR WEAPONS AND CHARACTERS, AND 5 STAR CHARACTERS

// Page for the Limited Character banner
// Has different roll counts and reward possibilities

//Initial page you see when the app is launched
// --------------------------------------------------------------------------------------------------------------------------------

namespace ZZZ_Character_Wish_Sim.OtherPages
{


    public partial class Banner1 : Page
    {

        // General varaibles used to track roll counts
        // Used when we want to determine if in soft pity or are confirmed for a 4/5 star reward
        private int banner1RollCount;
        private int banner1RollsUntilS;
        private int banner1RollsUntilA;
        private int banner1SoftPityCount;

        // DB class var
        private RewardDB rewardDB;


        // Page Initializer
        // Gets the env values for banner 1 roll counts. This is the way we keep track of banner specific roll counts when moving off the page.

        public Banner1()
        {
            InitializeComponent();

            banner1RollsUntilA = (int)(Application.Current.Properties["banner1RollsUntilA"] ?? 10);
            banner1RollsUntilS = (int)(Application.Current.Properties["banner1RollsUntilS"] ?? 90);
            banner1RollCount = (int)(Application.Current.Properties["banner1RollCount"] ?? 0);
            banner1SoftPityCount = (int)(Application.Current.Properties["banner1SoftPityCount"] ?? 0);

            banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
            banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

        }

        // --------------------------------------------------------------------------------------------------------------------------------
        // Updates our app/env vars to whatever the new value is after a roll occurs
        // --------------------------------------------------------------------------------------------------------------------------------

        private void UpdateRollCounts()
        {

            Application.Current.Properties["banner1RollsUntilA"] = banner1RollsUntilA;
            Application.Current.Properties["banner1RollsUntilS"] = banner1RollsUntilS;
            Application.Current.Properties["banner1RollCount"] = banner1RollCount;
            Application.Current.Properties["banner1SoftPityCount"] = banner1SoftPityCount;

        }




        // --------------------------------------------------------------------------------------------------------------------------------
        // Roll 1 function!
        // Gets 1 random choice from the db and opens a dialog window after the roll completes

        // IDEA: Could possibly delete the rollOnce function and pass in another var to the Roll10 function to make it roll a certain amount of times. Would save a lot of line space
        // --------------------------------------------------------------------------------------------------------------------------------

        public void RollOnceBanner1(object sender, MouseButtonEventArgs e)
        {
            string result, rewardPath;

            rewardDB = new RewardDB();

            Random randNum = new Random();

            double rollChance = randNum.NextDouble();

            if (banner1RollsUntilA == 1)
            {

                Random weapOrChar = new Random();

                if (weapOrChar.Next(1, 3) == 1)
                {

                    (result, rewardPath) = rewardDB.GetRandom4StarWeapon();

                }

                else
                {

                    (result, rewardPath) = rewardDB.GetRandom4StarCharacter();

                }

                MessageBox.Show($"You pulled a 4 Star {result}");

                Console.WriteLine("You pulled a 4 Star");
                banner1RollCount += 1;

                banner1RollsUntilA = 10;
                banner1RollsUntilS -= 1;

                banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

            }

            else if (banner1RollsUntilS == 1)
            {

                Random weapOrChar = new Random();

                if (weapOrChar.Next(1, 3) == 1)
                {

                    (result, rewardPath) = rewardDB.GetRandom5StarWeapon();

                }

                else
                {

                    (result, rewardPath) = rewardDB.GetRandom5StarCharacter();

                }

                MessageBox.Show($"You pulled a 5 Star {result}");


                Console.WriteLine("You pulled a 5 Star");
                banner1RollCount = 0;

                banner1RollsUntilA = 10;
                banner1RollsUntilS = 90;

                banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

            }


            else if (banner1RollCount < 75)
            {

                if (rollChance <= 0.006)
                {

                    Random weapOrChar = new Random();

                    if (weapOrChar.Next(1, 3) == 1)
                    {

                        (result, rewardPath) = rewardDB.GetRandom5StarWeapon();

                    }

                    else
                    {

                        (result, rewardPath) = rewardDB.GetRandom5StarCharacter();

                    }

                    MessageBox.Show($"You pulled a 5 Star {result}");

                    Console.WriteLine("You pulled a 5 Star");
                    banner1RollCount = 0;

                    banner1RollsUntilA = 10;
                    banner1RollsUntilS = 90;

                    banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                    banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                }

                else if (rollChance > 0.006 && rollChance <= 0.078)
                {
                    Random weapOrChar = new Random();

                    if (weapOrChar.Next(1, 3) == 1)
                    {

                        (result, rewardPath) = rewardDB.GetRandom4StarWeapon();

                    }

                    else
                    {

                        (result, rewardPath) = rewardDB.GetRandom4StarCharacter();

                    }

                    MessageBox.Show($"You pulled a 4 Star {result}");

                    Console.WriteLine("You pulled a 4 Star");
                    banner1RollCount += 1;

                    banner1RollsUntilA = 10;
                    banner1RollsUntilS -= 1;

                    banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                    banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                }

                else
                {


                    (result, rewardPath) = rewardDB.GetRandom3Star();

                    MessageBox.Show($"You pulled a 3 Star. {result}");


                    Console.WriteLine("You pulled a 3 Star");
                    banner1RollCount += 1;

                    banner1RollsUntilA -= 1;
                    banner1RollsUntilS -= 1;

                    banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                    banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                }


            }



            else
            {

                banner1SoftPityCount = Math.Abs(74 - banner1RollCount);




                Console.WriteLine($"You are in soft pity currently! Your roll count is currently at: {banner1RollCount}");

                if (rollChance <= 0.006 + (banner1SoftPityCount + 10))
                {

                    Random weapOrChar = new Random();

                    if (weapOrChar.Next(1, 3) == 1)
                    {

                        (result, rewardPath) = rewardDB.GetRandom5StarWeapon();

                    }

                    else
                    {

                        (result, rewardPath) = rewardDB.GetRandom5StarCharacter();

                    }

                    MessageBox.Show($"You pulled a 5 Star {result}");

                    Console.WriteLine("You pulled a 5 Star");
                    banner1RollCount = 0;

                    banner1RollsUntilA = 10;
                    banner1RollsUntilS = 90;

                    banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                    banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";
                }

                else if (rollChance > 0.006 && rollChance <= 0.078)
                {

                    Random weapOrChar = new Random();

                    if (weapOrChar.Next(1, 3) == 1)
                    {

                        (result, rewardPath) = rewardDB.GetRandom4StarWeapon();

                    }

                    else
                    {

                        (result, rewardPath) = rewardDB.GetRandom4StarCharacter();

                    }

                    MessageBox.Show($"You pulled a 4 Star {result}");

                    Console.WriteLine("You pulled a 4 Star");
                    banner1RollCount += 1;

                    banner1RollsUntilA = 10;
                    banner1RollsUntilS -= 1;

                    banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                    banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                }

                else
                {

                    (result, rewardPath) = rewardDB.GetRandom3Star();
                    MessageBox.Show($"You pulled a 3 Star. {result}");

                    Console.WriteLine("You pulled a 3 Star");
                    banner1RollCount += 1;

                    banner1RollsUntilA -= 1;
                    banner1RollsUntilS -= 1;

                    banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                    banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                }


            }

            UpdateRollCounts();

        }


        // --------------------------------------------------------------------------------------------------------------------------------
        // Roll 10 function!
        // Gets 10 random choices from the db and stores them in a list
        // Opens a dialog window after all 10 rolls complete

        // IDEA: Could possibly delete the rollOnce function and pass in another var to this function to make it roll a certain amount of times. Would save a lot of line space
        // --------------------------------------------------------------------------------------------------------------------------------

        public void RollTenBanner1(object sender, MouseButtonEventArgs e)
        {

            rewardDB = new RewardDB();

            Random randNum = new Random();

            string[] rollResults = { "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll" };

            for (int i = 0; i < 10; i++)
            {

                double rollChance = randNum.NextDouble();

                if (banner1RollsUntilA == 1)
                {

                    Random weapOrChar = new Random();

                    if (weapOrChar.Next(1, 3) == 1)
                    {

                        var(result, rewardPath) = rewardDB.GetRandom4StarWeapon();
                        rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                    }

                    else
                    {

                        var (result, rewardPath) = rewardDB.GetRandom4StarCharacter();
                        rollResults[i] = $"You pulled a 4 Star Character {result}\n";

                    }

                    banner1RollCount += 1;

                    banner1RollsUntilA = 10;
                    banner1RollsUntilS -= 1;

                    banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                    banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                }

                else if (banner1RollsUntilS == 1)
                {

                    Random weapOrChar = new Random();

                    if (weapOrChar.Next(1, 3) == 1)
                    {

                        var(result, rewardPath) = rewardDB.GetRandom5StarWeapon();
                        rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                    }

                    else
                    {

                        var (result, rewardPath) = rewardDB.GetRandom5StarCharacter();
                        rollResults[i] = $"You pulled a 5 Star Character {result}\n";

                    }

                    banner1RollCount = 0;

                    banner1RollsUntilA = 10;
                    banner1RollsUntilS = 90;

                    banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                    banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                }


                else if (banner1RollCount < 75)
                {

                    if (rollChance <= 0.006)
                    {

                        Random weapOrChar = new Random();

                        if (weapOrChar.Next(1, 3) == 1)
                        {

                            var(result, rewardPath) = rewardDB.GetRandom5StarWeapon();
                            rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                        }

                        else
                        {

                            var (result, rewardPath) = rewardDB.GetRandom5StarCharacter();
                            rollResults[i] = $"You pulled a 5 Star Character {result}\nIMG PATH: {rewardPath}\n";

                        }

                        banner1RollCount = 0;

                        banner1RollsUntilA = 10;
                        banner1RollsUntilS = 90;

                        banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                        banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                    }

                    else if (rollChance > 0.006 && rollChance <= 0.078)
                    {

                        Random weapOrChar = new Random();

                        if (weapOrChar.Next(1, 3) == 1)
                        {

                            var(result, rewardPath) = rewardDB.GetRandom4StarWeapon();
                            rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                        }

                        else
                        {

                            var (result, rewardPath) = rewardDB.GetRandom4StarCharacter();
                            rollResults[i] = $"You pulled a 4 Star Character {result}\nIMG PATH: {rewardPath}\n";

                        }

                        Console.WriteLine("You pulled a 4 Star");

                        banner1RollCount += 1;

                        banner1RollsUntilA = 10;
                        banner1RollsUntilS -= 1;

                        banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                        banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                    }

                    else
                    {

                        var(result, rewardPath) = rewardDB.GetRandom3Star();

                        Console.WriteLine("You pulled a 3 Star");

                        rollResults[i] = $"You pulled a 3 Star. {result}\n";

                        banner1RollCount += 1;

                        banner1RollsUntilA -= 1;
                        banner1RollsUntilS -= 1;

                        banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                        banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                    }


                }



                else
                {

                    banner1SoftPityCount = Math.Abs(74 - banner1RollCount);

                    Console.WriteLine($"You are in soft pity currently! Your roll count is currently at: {banner1RollCount}");

                    if (rollChance <= 0.006 + (banner1SoftPityCount + 10))
                    {

                        Random weapOrChar = new Random();

                        if (weapOrChar.Next(1, 3) == 1)
                        {

                            var(result, rewardPath) = rewardDB.GetRandom5StarWeapon();
                            rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                        }

                        else
                        {

                            var (result, rewardPath) = rewardDB.GetRandom5StarCharacter();
                            rollResults[i] = $"You pulled a 5 Star Character {result}\n IMG PATH: {rewardPath}\n";

                        }

                        banner1RollCount = 0;

                        banner1RollsUntilA = 10;
                        banner1RollsUntilS = 90;

                        banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                        banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";
                    }

                    else if (rollChance > 0.006 && rollChance <= 0.078)
                    {

                        Random weapOrChar = new Random();

                        if (weapOrChar.Next(1, 3) == 1)
                        {

                            var(result, rewardPath) = rewardDB.GetRandom4StarWeapon();
                            rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                        }

                        else
                        {

                            var (result, rewardPath) = rewardDB.GetRandom4StarCharacter();
                            rollResults[i] = $"You pulled a 4 Star Character {result}\n IMG PATH: {rewardPath}\n";

                        }

                        banner1RollCount += 1;

                        banner1RollsUntilA = 10;
                        banner1RollsUntilS -= 1;

                        banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                        banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                    }

                    else
                    {

                        var(result, rewardPath) = rewardDB.GetRandom3Star();

                        Console.WriteLine("You pulled a 3 Star");

                        rollResults[i] = $"You pulled a 3 Star. {result}\n";

                        banner1RollCount += 1;

                        banner1RollsUntilA -= 1;
                        banner1RollsUntilS -= 1;

                        banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                        banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                    }


                }

                for (int j = 0; j < rollResults.Length; j++)
                {

                    Console.WriteLine($"rollResults[{j}] = {rollResults[j]}");

                }


            }

            MessageBox.Show($"Here are the roll results:\n {string.Join("\n\n", rollResults)}");

            UpdateRollCounts();

        }



    }
    
}
