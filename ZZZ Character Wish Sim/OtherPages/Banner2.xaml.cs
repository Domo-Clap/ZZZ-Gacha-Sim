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

namespace ZZZ_Character_Wish_Sim.OtherPages
{
    /// <summary>
    /// Interaction logic for Banner2.xaml
    /// </summary>
    public partial class Banner2 : Page
    {

        int banner2RollCount = 0;

        int banner2RollsUntilS = 90;
        int banner2RollsUntilA = 10;
        int banner2SoftPityCount = 0;

        private RewardDB rewardDB;

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

        private void UpdateRollCounts()
        {

            Application.Current.Properties["banner2RollsUntilA"] = banner2RollsUntilA;
            Application.Current.Properties["banner2RollsUntilS"] = banner2RollsUntilS;
            Application.Current.Properties["banner2RollCount"] = banner2RollCount;
            Application.Current.Properties["banner2SoftPityCount"] = banner2SoftPityCount;

        }


        public void RollOnceBanner2(object sender, MouseButtonEventArgs e)
        {

            rewardDB = new RewardDB();

            Random randNum = new Random();

            double rollChance = randNum.NextDouble();

            if (banner2RollsUntilA == 1)
            {

                MessageBox.Show("You pulled a 4 Star");

                Console.WriteLine("You pulled a 4 Star");
                banner2RollCount += 1;

                banner2RollsUntilA = 10;
                banner2RollsUntilS -= 1;

                banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

            }

            else if (banner2RollsUntilS == 1)
            {

                Console.WriteLine("You pulled a 5 Star");
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
                    MessageBox.Show("You pulled a 5 Star");

                    Console.WriteLine("You pulled a 5 Star");
                    banner2RollCount = 0;

                    banner2RollsUntilA = 10;
                    banner2RollsUntilS = 90;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                }

                else if (rollChance > 0.006 && rollChance <= 0.078)
                {
                    MessageBox.Show("You pulled a 4 Star");

                    Console.WriteLine("You pulled a 4 Star");
                    banner2RollCount += 1;

                    banner2RollsUntilA = 10;
                    banner2RollsUntilS -= 1;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                }

                else
                {


                    string result = rewardDB.GetRandom3Star();

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

                    MessageBox.Show("You pulled a 5 Star");

                    Console.WriteLine("You pulled a 5 Star");
                    banner2RollCount = 0;

                    banner2RollsUntilA = 10;
                    banner2RollsUntilS = 90;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";
                }

                else if (rollChance > 0.006 && rollChance <= 0.078)
                {

                    MessageBox.Show("You pulled a 4 Star");

                    Console.WriteLine("You pulled a 4 Star");
                    banner2RollCount += 1;

                    banner2RollsUntilA = 10;
                    banner2RollsUntilS -= 1;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                }

                else
                {

                    string result = rewardDB.GetRandom3Star();
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

                    Random weapOrChar = new Random();

                    if (weapOrChar.Next(1, 3) == 1)
                    {

                        string result = rewardDB.GetRandom4StarWeapon();
                        rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                    }

                    else
                    {

                        string result = rewardDB.GetRandom4StarCharacter();
                        rollResults[i] = $"You pulled a 4 Star Character {result}\n";

                    }

                    banner2RollCount += 1;

                    banner2RollsUntilA = 10;
                    banner2RollsUntilS -= 1;

                    banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                    banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                }

                else if (banner2RollsUntilS == 1)
                {

                    Random weapOrChar = new Random();

                    if (weapOrChar.Next(1, 3) == 1)
                    {

                        string result = rewardDB.GetRandom5StarWeapon();
                        rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                    }

                    else
                    {

                        string result = rewardDB.GetRandom5StarCharacter();
                        rollResults[i] = $"You pulled a 5 Star Character {result}\n";

                    }

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

                        Random weapOrChar = new Random();

                        if (weapOrChar.Next(1, 3) == 1)
                        {

                            string result = rewardDB.GetRandom5StarWeapon();
                            rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                        }

                        else
                        {

                            string result = rewardDB.GetRandom5StarCharacter();
                            rollResults[i] = $"You pulled a 5 Star Character {result}\n";

                        }

                        banner2RollCount = 0;

                        banner2RollsUntilA = 10;
                        banner2RollsUntilS = 90;
                        banner2RollsUntilS = 90;

                        banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                        banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                    }

                    else if (rollChance > 0.006 && rollChance <= 0.078)
                    {

                        Random weapOrChar = new Random();

                        if (weapOrChar.Next(1, 3) == 1)
                        {

                            string result = rewardDB.GetRandom4StarWeapon();
                            rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                        }

                        else
                        {

                            string result = rewardDB.GetRandom4StarCharacter();
                            rollResults[i] = $"You pulled a 4 Star Character {result}\n";

                        }

                        Console.WriteLine("You pulled a 4 Star");

                        banner2RollCount += 1;

                        banner2RollsUntilA = 10;
                        banner2RollsUntilS -= 1;

                        banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                        banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                    }

                    else
                    {

                        string result = rewardDB.GetRandom3Star();

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

                        Random weapOrChar = new Random();

                        if (weapOrChar.Next(1, 3) == 1)
                        {

                            string result = rewardDB.GetRandom5StarWeapon();
                            rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                        }

                        else
                        {

                            string result = rewardDB.GetRandom5StarCharacter();
                            rollResults[i] = $"You pulled a 5 Star Character {result}\n";

                        }

                        banner2RollCount = 0;

                        banner2RollsUntilA = 10;
                        banner2RollsUntilS = 90;

                        banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                        banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";
                    }

                    else if (rollChance > 0.006 && rollChance <= 0.078)
                    {

                        Random weapOrChar = new Random();

                        if (weapOrChar.Next(1, 3) == 1)
                        {

                            string result = rewardDB.GetRandom4StarWeapon();
                            rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                        }

                        else
                        {

                            string result = rewardDB.GetRandom4StarCharacter();
                            rollResults[i] = $"You pulled a 4 Star Character {result}\n";

                        }

                        banner2RollCount += 1;

                        banner2RollsUntilA = 10;
                        banner2RollsUntilS -= 1;

                        banner2aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner2RollsUntilA} Searches";
                        banner2sRankCounter.Text = $"S-Rank Signal guaranteed in {banner2RollsUntilS} Searches";

                    }

                    else
                    {

                        string result = rewardDB.GetRandom3Star();

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
