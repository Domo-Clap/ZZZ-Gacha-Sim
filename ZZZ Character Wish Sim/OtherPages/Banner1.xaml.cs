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
    /// Interaction logic for Banner1.xaml
    /// </summary>
    public partial class Banner1 : Page
    {

        private int banner1RollCount;
        private int banner1RollsUntilS;
        private int banner1RollsUntilA;
        private int banner1SoftPityCount;

        private RewardDB rewardDB;

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

        private void UpdateRollCounts()
        {

            Application.Current.Properties["banner1RollsUntilA"] = banner1RollsUntilA;
            Application.Current.Properties["banner1RollsUntilS"] = banner1RollsUntilS;
            Application.Current.Properties["banner1RollCount"] = banner1RollCount;
            Application.Current.Properties["banner1SoftPityCount"] = banner1SoftPityCount;

        }


        public void RollOnceBanner1(object sender, MouseButtonEventArgs e)
        {

            rewardDB = new RewardDB();

            Random randNum = new Random();

            double rollChance = randNum.NextDouble();

            if (banner1RollsUntilA == 1)
            {

                MessageBox.Show("You pulled a 4 Star");

                Console.WriteLine("You pulled a 4 Star");
                banner1RollCount += 1;

                banner1RollsUntilA = 10;
                banner1RollsUntilS -= 1;

                banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

            }

            else if (banner1RollsUntilS == 1)
            {

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
                    MessageBox.Show("You pulled a 5 Star");

                    Console.WriteLine("You pulled a 5 Star");
                    banner1RollCount = 0;

                    banner1RollsUntilA = 10;
                    banner1RollsUntilS = 90;

                    banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                    banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                }

                else if (rollChance > 0.006 && rollChance <= 0.078)
                {
                    MessageBox.Show("You pulled a 4 Star");

                    Console.WriteLine("You pulled a 4 Star");
                    banner1RollCount += 1;

                    banner1RollsUntilA = 10;
                    banner1RollsUntilS -= 1;

                    banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                    banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                }

                else
                {


                    string result = rewardDB.GetRandom3Star();

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

                    MessageBox.Show("You pulled a 5 Star");

                    Console.WriteLine("You pulled a 5 Star");
                    banner1RollCount = 0;

                    banner1RollsUntilA = 10;
                    banner1RollsUntilS = 90;

                    banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                    banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";
                }

                else if (rollChance > 0.006 && rollChance <= 0.078)
                {

                    MessageBox.Show("You pulled a 4 Star");

                    Console.WriteLine("You pulled a 4 Star");
                    banner1RollCount += 1;

                    banner1RollsUntilA = 10;
                    banner1RollsUntilS -= 1;

                    banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                    banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                }

                else
                {

                    string result = rewardDB.GetRandom3Star();
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

                        string result = rewardDB.GetRandom4StarWeapon();
                        rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                    }

                    else
                    {

                        string result = rewardDB.GetRandom4StarCharacter();
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

                        string result = rewardDB.GetRandom5StarWeapon();
                        rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                    }

                    else
                    {

                        string result = rewardDB.GetRandom5StarCharacter();
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

                            string result = rewardDB.GetRandom5StarWeapon();
                            rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                        }

                        else
                        {

                            string result = rewardDB.GetRandom5StarCharacter();
                            rollResults[i] = $"You pulled a 5 Star Character {result}\n";

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

                            string result = rewardDB.GetRandom4StarWeapon();
                            rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                        }

                        else
                        {

                            string result = rewardDB.GetRandom4StarCharacter();
                            rollResults[i] = $"You pulled a 4 Star Character {result}\n";

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

                        string result = rewardDB.GetRandom3Star();

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

                            string result = rewardDB.GetRandom5StarWeapon();
                            rollResults[i] = $"You pulled a 5 Star Weapon {result}\n";

                        }

                        else
                        {

                            string result = rewardDB.GetRandom5StarCharacter();
                            rollResults[i] = $"You pulled a 5 Star Character {result}\n";

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

                            string result = rewardDB.GetRandom4StarWeapon();
                            rollResults[i] = $"You pulled a 4 Star Weapon {result}\n";

                        }

                        else
                        {

                            string result = rewardDB.GetRandom4StarCharacter();
                            rollResults[i] = $"You pulled a 4 Star Character {result}\n";

                        }

                        banner1RollCount += 1;

                        banner1RollsUntilA = 10;
                        banner1RollsUntilS -= 1;

                        banner1aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {banner1RollsUntilA} Searches";
                        banner1sRankCounter.Text = $"S-Rank Signal guaranteed in {banner1RollsUntilS} Searches";

                    }

                    else
                    {

                        string result = rewardDB.GetRandom3Star();

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
