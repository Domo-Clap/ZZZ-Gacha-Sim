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
//STANDARD CHARACTER BANNER
//ALL REWARDS


// Page for the Standard banner
// Has different roll counts and reward possibilities
// --------------------------------------------------------------------------------------------------------------------------------

namespace ZZZ_Character_Wish_Sim.OtherPages
{

    public partial class Banner3 : Page
    {

        // General varaibles used to track roll counts
        // Used when we want to determine if in soft pity or are confirmed for a 4/5 star reward
        int banner3RollCount;

        int banner3RollsUntilS;
        int banner3RollsUntilA;
        int banner3SoftPityCount;

        // DB class var
        private RewardDB rewardDB;


        // Page Initializer
        // Gets the env values for banner 1 roll counts. This is the way we keep track of banner specific roll counts when moving off the page.

        public Banner3()
        {
            InitializeComponent();

            banner3RollsUntilA = (int)(Application.Current.Properties["banner3RollsUntilA"] ?? 10);
            banner3RollsUntilS = (int)(Application.Current.Properties["banner3RollsUntilS"] ?? 90);
            banner3RollCount = (int)(Application.Current.Properties["banner3RollCount"] ?? 0);
            banner3SoftPityCount = (int)(Application.Current.Properties["banner3SoftPityCount"] ?? 0);

            banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
            banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";
        }


        // --------------------------------------------------------------------------------------------------------------------------------
        // Updates our app/env vars to whatever the new value is after a roll occurs
        // --------------------------------------------------------------------------------------------------------------------------------

        private void UpdateRollCounts()
        {

            Application.Current.Properties["banner3RollsUntilA"] = banner3RollsUntilA;
            Application.Current.Properties["banner3RollsUntilS"] = banner3RollsUntilS;
            Application.Current.Properties["banner3RollCount"] = banner3RollCount;
            Application.Current.Properties["banner3SoftPityCount"] = banner3SoftPityCount;

        }


        // --------------------------------------------------------------------------------------------------------------------------------
        // Roll 1 function!
        // Gets 1 random choice from the db and opens a dialog window after the roll completes


        // IDEA: Could possibly delete the rollOnce function and pass in another var to the Roll10 function to make it roll a certain amount of times. Would save a lot of line space
        // --------------------------------------------------------------------------------------------------------------------------------

        public void RollOnceBanner3(object sender, MouseButtonEventArgs e)
        {

            string result, rewardPath;

            rewardDB = new RewardDB();

            Random randNum = new Random();

            double rollChance = randNum.NextDouble();

            if (banner3RollsUntilA == 1)
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
                banner3RollCount += 1;

                banner3RollsUntilA = 10;
                banner3RollsUntilS -= 1;

                banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

            }

            else if (banner3RollsUntilS == 1)
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
                banner3RollCount = 0;

                banner3RollsUntilA = 10;
                banner3RollsUntilS = 90;

                banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

            }


            else if (banner3RollCount < 75)
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
                    banner3RollCount = 0;

                    banner3RollsUntilA = 10;
                    banner3RollsUntilS = 90;

                    banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                    banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

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
                    banner3RollCount += 1;

                    banner3RollsUntilA = 10;
                    banner3RollsUntilS -= 1;

                    banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                    banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

                }

                else
                {


                    (result, rewardPath) = rewardDB.GetRandom3Star();

                    MessageBox.Show($"You pulled a 3 Star. {result}");


                    Console.WriteLine("You pulled a 3 Star");
                    banner3RollCount += 1;

                    banner3RollsUntilA -= 1;
                    banner3RollsUntilS -= 1;

                    banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                    banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

                }


            }



            else
            {

                banner3SoftPityCount = Math.Abs(74 - banner3RollCount);

                Console.WriteLine($"You are in soft pity currently! Your roll count is currently at: {banner3RollCount}");

                if (rollChance <= 0.006 + (banner3SoftPityCount + 10))
                {

                    MessageBox.Show("You pulled a 5 Star");

                    Console.WriteLine("You pulled a 5 Star");
                    banner3RollCount = 0;

                    banner3RollsUntilA = 10;
                    banner3RollsUntilS = 90;

                    banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                    banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";
                }

                else if (rollChance > 0.006 && rollChance <= 0.078)
                {

                    MessageBox.Show("You pulled a 4 Star");

                    Console.WriteLine("You pulled a 4 Star");
                    banner3RollCount += 1;

                    banner3RollsUntilA = 10;
                    banner3RollsUntilS -= 1;

                    banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                    banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

                }

                else
                {

                    (result, rewardPath) = rewardDB.GetRandom3Star();
                    MessageBox.Show($"You pulled a 3 Star. {result}");

                    Console.WriteLine("You pulled a 3 Star");
                    banner3RollCount += 1;

                    banner3RollsUntilA -= 1;
                    banner3RollsUntilS -= 1;

                    banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                    banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

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

        public void RollTenBanner3(object sender, MouseButtonEventArgs e)
        {

            rewardDB = new RewardDB();

            Random randNum = new Random();

            string[] rollResults = { "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll" };

            for (int i = 0; i < 10; i++)
            {

                double rollChance = randNum.NextDouble();

                if (banner3RollsUntilA == 1)
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

                    banner3RollCount += 1;

                    banner3RollsUntilA = 10;
                    banner3RollsUntilS -= 1;

                    banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                    banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

                }

                else if (banner3RollsUntilS == 1)
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

                    banner3RollCount = 0;

                    banner3RollsUntilA = 10;
                    banner3RollsUntilS = 90;

                    banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                    banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

                }


                else if (banner3RollCount < 75)
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
                            rollResults[i] = $"You pulled a 5 Star Character {result}\n";

                        }

                        banner3RollCount = 0;

                        banner3RollsUntilA = 10;
                        banner3RollsUntilS = 90;

                        banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                        banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

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
                            rollResults[i] = $"You pulled a 4 Star Character {result}\n";

                        }

                        Console.WriteLine("You pulled a 4 Star");

                        banner3RollCount += 1;

                        banner3RollsUntilA = 10;
                        banner3RollsUntilS -= 1;

                        banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                        banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

                    }

                    else
                    {

                        var(result, rewardPath) = rewardDB.GetRandom3Star();

                        Console.WriteLine("You pulled a 3 Star");

                        rollResults[i] = $"You pulled a 3 Star. {result}\n";

                        banner3RollCount += 1;

                        banner3RollsUntilA -= 1;
                        banner3RollsUntilS -= 1;

                        banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                        banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

                    }


                }



                else
                {

                    banner3SoftPityCount = Math.Abs(74 - banner3RollCount);

                    Console.WriteLine($"You are in soft pity currently! Your roll count is currently at: {banner3RollCount}");

                    if (rollChance <= 0.006 + (banner3SoftPityCount + 10))
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

                        banner3RollCount = 0;

                        banner3RollsUntilA = 10;
                        banner3RollsUntilS = 90;

                        banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                        banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";
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
                            rollResults[i] = $"You pulled a 4 Star Character {result}\n";

                        }

                        banner3RollCount += 1;

                        banner3RollsUntilA = 10;
                        banner3RollsUntilS -= 1;

                        banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                        banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

                    }

                    else
                    {

                        var(result, rewardPath) = rewardDB.GetRandom3Star();

                        Console.WriteLine("You pulled a 3 Star");

                        rollResults[i] = $"You pulled a 3 Star. {result}\n";

                        banner3RollCount += 1;

                        banner3RollsUntilA -= 1;
                        banner3RollsUntilS -= 1;

                        banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                        banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

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
