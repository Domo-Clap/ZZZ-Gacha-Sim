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

namespace ZZZ_Character_Wish_Sim.OtherPages
{
    /// <summary>
    /// Interaction logic for Banner3.xaml
    /// </summary>
    public partial class Banner3 : Page
    {

        int banner3RollCount = 0;

        int banner3RollsUntilS = 90;
        int banner3RollsUntilA = 10;
        int banner3SoftPityCount = 0;

        private RewardDB rewardDB;

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

        private void UpdateRollCounts()
        {

            Application.Current.Properties["banner3RollsUntilA"] = banner3RollsUntilA;
            Application.Current.Properties["banner3RollsUntilS"] = banner3RollsUntilS;
            Application.Current.Properties["banner3RollCount"] = banner3RollCount;
            Application.Current.Properties["banner3SoftPityCount"] = banner3SoftPityCount;

        }


        public void RollOnceBanner3(object sender, MouseButtonEventArgs e)
        {

            rewardDB = new RewardDB();

            Random randNum = new Random();

            double rollChance = randNum.NextDouble();

            if (banner3RollsUntilA == 1)
            {

                MessageBox.Show("You pulled a 4 Star");

                Console.WriteLine("You pulled a 4 Star");
                banner3RollCount += 1;

                banner3RollsUntilA = 10;
                banner3RollsUntilS -= 1;

                banner3aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner3RollsUntilA} Searches";
                banner3sRankCounter.Text = $"S-Rank Signal guaranteed in {banner3RollsUntilS} Searches";

            }

            else if (banner3RollsUntilS == 1)
            {

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


                    string result = rewardDB.GetRandom3Star();

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

                    string result = rewardDB.GetRandom3Star();
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

                        string result = rewardDB.GetRandom4StarWeapon();
                        rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                    }

                    else
                    {

                        string result = rewardDB.GetRandom4StarCharacter();
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

                        string result = rewardDB.GetRandom5StarWeapon();
                        rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                    }

                    else
                    {

                        string result = rewardDB.GetRandom5StarCharacter();
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

                            string result = rewardDB.GetRandom5StarWeapon();
                            rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                        }

                        else
                        {

                            string result = rewardDB.GetRandom5StarCharacter();
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

                            string result = rewardDB.GetRandom4StarWeapon();
                            rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                        }

                        else
                        {

                            string result = rewardDB.GetRandom4StarCharacter();
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

                        string result = rewardDB.GetRandom3Star();

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

                            string result = rewardDB.GetRandom5StarWeapon();
                            rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                        }

                        else
                        {

                            string result = rewardDB.GetRandom5StarCharacter();
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

                            string result = rewardDB.GetRandom4StarWeapon();
                            rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                        }

                        else
                        {

                            string result = rewardDB.GetRandom4StarCharacter();
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

                        string result = rewardDB.GetRandom3Star();

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
