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
using ZZZ_Character_Wish_Sim;

// --------------------------------------------------------------------------------------------------------------------------------
//LIMITED WEAPONS BANNER
//ONLY 3 STAR WEAPONS, 4 STAR WEAPONS, AND 5 STAR WEAPONS

// Page for the Standard banner
// Has different roll counts and reward possibilities

// --------------------------------------------------------------------------------------------------------------------------------

namespace ZZZ_Character_Wish_Sim.OtherPages
{
    /// <summary>
    /// Interaction logic for Banner2.xaml
    /// </summary>
    public partial class Banner2 : Page
    {

        // General varaibles used to track roll counts
        // Used when we want to determine if in soft pity or are confirmed for a 4/5 star reward
        int banner2RollCount;
        int banner2RollsUntilS;
        int banner2RollsUntilA;
        int banner2SoftPityCount;

        // DB class var
        private RewardDB rewardDB;


        // Page Initializer
        // Gets the env values for banner 1 roll counts. This is the way we keep track of banner specific roll counts when moving off the page.

        public Banner2()
        {
            InitializeComponent();

            banner2RollsUntilA = (int)(Application.Current.Properties["banner2RollsUntilA"] ?? 10);
            banner2RollsUntilS = (int)(Application.Current.Properties["banner2RollsUntilS"] ?? 90);
            banner2RollCount = (int)(Application.Current.Properties["banner2RollCount"] ?? 0);
            banner2SoftPityCount = (int)(Application.Current.Properties["banner2SoftPityCount"] ?? 0);

            banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
            banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

        }


        // --------------------------------------------------------------------------------------------------------------------------------
        // Updates our app/env vars to whatever the new value is after a roll occurs
        // --------------------------------------------------------------------------------------------------------------------------------

        private void UpdateRollCounts()
        {

            Application.Current.Properties["banner2RollsUntilA"] = banner2RollsUntilA;
            Application.Current.Properties["banner2RollsUntilS"] = banner2RollsUntilS;
            Application.Current.Properties["banner2RollCount"] = banner2RollCount;
            Application.Current.Properties["banner2SoftPityCount"] = banner2SoftPityCount;

        }


        // --------------------------------------------------------------------------------------------------------------------------------
        // Roll 1 function!
        // Gets 1 random choice from the db and opens a dialog window after the roll completes

        // IDEA: Could possibly delete the rollOnce function and pass in another var to the Roll10 function to make it roll a certain amount of times. Would save a lot of line space
        // --------------------------------------------------------------------------------------------------------------------------------

        public void RollOnceBanner2(object sender, MouseButtonEventArgs e)
        {

            rewardDB = new RewardDB();

            Random randNum = new Random();

            double rollChance = randNum.NextDouble();

            if (banner2RollsUntilA == 1)
            {

                var (result, rewardPath) = rewardDB.GetRandom4StarWeapon();

                MessageBox.Show($"You pulled a 4 Star Weapon: {result}, IMAGE: {rewardPath}");

                Console.WriteLine("You pulled a 4 Star");
                banner2RollCount += 1;

                banner2RollsUntilA = 10;
                banner2RollsUntilS -= 1;

                banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

            }

            else if (banner2RollsUntilS == 1)
            {

                var (result, rewardPath) = rewardDB.GetRandom5StarWeapon();

                MessageBox.Show($"You pulled a 5 Star Weapon: {result}, IMAGE: {rewardPath}");

                Console.WriteLine($"You pulled a 5 Star Weapon: {result}, IMAGE: {rewardPath}");
                banner2RollCount = 0;

                banner2RollsUntilA = 10;
                banner2RollsUntilS = 90;

                banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

            }


            else if (banner2RollCount < 75)
            {

                if (rollChance <= 0.006)
                {

                    var (result, rewardPath) = rewardDB.GetRandom5StarWeapon();

                    MessageBox.Show($"You pulled a 5 Star Weapon: {result}, IMAGE: {rewardPath}");

                    Console.WriteLine("You pulled a 5 Star");
                    banner2RollCount = 0;

                    banner2RollsUntilA = 10;
                    banner2RollsUntilS = 90;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                }

                else if (rollChance > 0.006 && rollChance <= 0.078)
                {

                    var (result, rewardPath) = rewardDB.GetRandom4StarWeapon();

                    MessageBox.Show($"You pulled a 4 Star Weapon: {result}, IMAGE: {rewardPath}");

                    Console.WriteLine("You pulled a 4 Star");
                    banner2RollCount += 1;

                    banner2RollsUntilA = 10;
                    banner2RollsUntilS -= 1;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                }

                else
                {


                    var (result, rewardPath) = rewardDB.GetRandom3Star();

                    MessageBox.Show($"You pulled a 3 Star. {result}");


                    Console.WriteLine("You pulled a 3 Star");
                    banner2RollCount += 1;

                    banner2RollsUntilA -= 1;
                    banner2RollsUntilS -= 1;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                }


            }



            else
            {

                banner2SoftPityCount = Math.Abs(74 - banner2RollCount);

                Console.WriteLine($"You are in soft pity currently! Your roll count is currently at: {banner2RollCount}");

                if (rollChance <= 0.006 + (banner2SoftPityCount + 10))
                {

                    var (result, rewardPath) = rewardDB.GetRandom5StarWeapon();

                    MessageBox.Show($"You pulled a 5 Star Weapon: {result}, IMAGE: {rewardPath}");

                    Console.WriteLine("You pulled a 5 Star");
                    banner2RollCount = 0;

                    banner2RollsUntilA = 10;
                    banner2RollsUntilS = 90;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";
                }

                else if (rollChance > 0.006 && rollChance <= 0.078)
                {

                    var (result, rewardPath) = rewardDB.GetRandom4StarWeapon();

                    MessageBox.Show($"You pulled a 4 Star Weapon: {result}, IMAGE: {rewardPath}");

                    Console.WriteLine("You pulled a 4 Star");
                    banner2RollCount += 1;

                    banner2RollsUntilA = 10;
                    banner2RollsUntilS -= 1;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                }

                else
                {

                    var (result, rewardPath) = rewardDB.GetRandom3Star();

                    MessageBox.Show($"You pulled a 3 Star. {result}");

                    Console.WriteLine("You pulled a 3 Star");
                    banner2RollCount += 1;

                    banner2RollsUntilA -= 1;
                    banner2RollsUntilS -= 1;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

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

        public void RollTenBanner2(object sender, MouseButtonEventArgs e)
        {

            rewardDB = new RewardDB();

            Random randNum = new Random();

            string[] rollResults = { "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll" };

            for (int i = 0; i < 10; i++)
            {

                double rollChance = randNum.NextDouble();

                if (banner2RollsUntilA == 1)
                {

                    var (result, rewardPath) = rewardDB.GetRandom4StarWeapon();
                    rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";


                    banner2RollCount += 1;

                    banner2RollsUntilA = 10;
                    banner2RollsUntilS -= 1;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                }

                else if (banner2RollsUntilS == 1)
                {

                    var (result, rewardPath) = rewardDB.GetRandom5StarWeapon();
                    rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                    banner2RollCount = 0;

                    banner2RollsUntilA = 10;
                    banner2RollsUntilS = 90;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                }


                else if (banner2RollCount < 75)
                {

                    if (rollChance <= 0.006)
                    {

                        var (result, rewardPath) = rewardDB.GetRandom5StarWeapon();
                        rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                        banner2RollCount = 0;

                        banner2RollsUntilA = 10;
                        banner2RollsUntilS = 90;
                        banner2RollsUntilS = 90;

                        banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                        banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                    }

                    else if (rollChance > 0.006 && rollChance <= 0.078)
                    {

                        var (result, rewardPath) = rewardDB.GetRandom4StarWeapon();
                        rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                        Console.WriteLine("You pulled a 4 Star");

                        banner2RollCount += 1;

                        banner2RollsUntilA = 10;
                        banner2RollsUntilS -= 1;

                        banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                        banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                    }

                    else
                    {

                        var (result, rewardPath) = rewardDB.GetRandom3Star();

                        Console.WriteLine("You pulled a 3 Star");

                        rollResults[i] = $"You pulled a 3 Star. {result}\n";

                        banner2RollCount += 1;

                        banner2RollsUntilA -= 1;
                        banner2RollsUntilS -= 1;

                        banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                        banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                    }


                }



                else
                {

                    banner2SoftPityCount = Math.Abs(74 - banner2RollCount);

                    Console.WriteLine($"You are in soft pity currently! Your roll count is currently at: {banner2RollCount}");

                    if (rollChance <= 0.006 + (banner2SoftPityCount + 10))
                    {

                        var (result, rewardPath) = rewardDB.GetRandom5StarWeapon();
                        rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                        banner2RollCount = 0;

                        banner2RollsUntilA = 10;
                        banner2RollsUntilS = 90;

                        banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                        banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";
                    }

                    else if (rollChance > 0.006 && rollChance <= 0.078)
                    {

                        

                        var (result, rewardPath) = rewardDB.GetRandom4StarWeapon();
                        rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                        banner2RollCount += 1;

                        banner2RollsUntilA = 10;
                        banner2RollsUntilS -= 1;

                        banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                        banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                    }

                    else
                    {

                        var (result, rewardPath) = rewardDB.GetRandom3Star();

                        Console.WriteLine("You pulled a 3 Star");

                        rollResults[i] = $"You pulled a 3 Star. {result}\n";

                        banner2RollCount += 1;

                        banner2RollsUntilA -= 1;
                        banner2RollsUntilS -= 1;

                        banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                        banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

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
