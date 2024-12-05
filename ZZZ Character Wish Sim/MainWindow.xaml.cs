using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Data.Sqlite;
using ZZZ_Character_Wish_Sim.OtherPages;

namespace ZZZ_Character_Wish_Sim
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int rollCount = 0;

        int rollsUntilS = 90;
        int rollsUntilA = 10;
        int softPityCount = 0;

        private RewardDB rewardDB;


        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new Banner1());
            SetActiveBannerButton(bBtn1);

            rewardDB = new RewardDB();
            rewardDB.createDB();


        }

        public void NavigateToBanner1(object sender, MouseButtonEventArgs e)
        {

            MainFrame.Navigate(new Banner1());
            SetActiveBannerButton(bBtn1);

        }

        public void NavigateToBanner2(object sender, MouseButtonEventArgs e)
        {

            MainFrame.Navigate(new Banner2());
            SetActiveBannerButton(bBtn2);

        }

        public void NavigateToBanner3(object sender, MouseButtonEventArgs e)
        {

            MainFrame.Navigate(new Banner3());
            SetActiveBannerButton(bBtn3);

        }

        public void SetImageSource(Image imageControl, string imagePath)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.EndInit();

            imageControl.Source = bitmap;
        }


        public void SetActiveBannerButton(Image activeBTN)
        {

            Image[] btns = { bBtn1, bBtn2, bBtn3 };

            string[] activeImagePaths =
            {

                "C:\\Users\\Dominic\\source\\repos\\ZZZ Character Wish Sim\\Resources\\Images\\banner1buttonactive.png",
                "C:\\Users\\Dominic\\source\\repos\\ZZZ Character Wish Sim\\Resources\\Images\\banner2buttonactive.png",
                "C:\\Users\\Dominic\\source\\repos\\ZZZ Character Wish Sim\\Resources\\Images\\banner3buttonactive.png"

            };

            string[] notActiveImagePaths =
            {

                "C:\\Users\\Dominic\\source\\repos\\ZZZ Character Wish Sim\\Resources\\Images\\banner1button.png",
                "C:\\Users\\Dominic\\source\\repos\\ZZZ Character Wish Sim\\Resources\\Images\\banner2button.png",
                "C:\\Users\\Dominic\\source\\repos\\ZZZ Character Wish Sim\\Resources\\Images\\banner3button.png"

            };


            for (int i = 0; i < btns.Length; i++)
            { 

                if (btns[i] == activeBTN)
                {

                    SetImageSource(btns[i], activeImagePaths[i]);

                }
                else
                {

                    SetImageSource(btns[i], notActiveImagePaths[i]);

                }


            }
        }


        /*
        public void RollOnce(object sender, MouseButtonEventArgs e) {

            rewardDB = new RewardDB();

            Random randNum = new Random();

            double rollChance = randNum.NextDouble();

            if (rollsUntilA == 1)
            {

                MessageBox.Show("You pulled a 4 Star");

                Console.WriteLine("You pulled a 4 Star");
                rollCount += 1;

                rollsUntilA = 10;
                rollsUntilS -= 1;

                aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

            }

            else if (rollsUntilS == 1)
            {

                Console.WriteLine("You pulled a 5 Star");
                rollCount = 0;

                rollsUntilA = 10;
                rollsUntilS = 90;

                aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

            }


            else if (rollCount < 75)
            {

                if (rollChance <= 0.006)
                {
                    MessageBox.Show("You pulled a 5 Star");

                    Console.WriteLine("You pulled a 5 Star");
                    rollCount = 0;

                    rollsUntilA = 10;
                    rollsUntilS = 90;

                    aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                    sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

                }

                else if (rollChance > 0.006 && rollChance <= 0.078)
                {
                    MessageBox.Show("You pulled a 4 Star");

                    Console.WriteLine("You pulled a 4 Star");
                    rollCount += 1;

                    rollsUntilA = 10;
                    rollsUntilS -= 1;

                    aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                    sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

                }

                else
                {
                    

                    string result = rewardDB.GetRandom3Star();

                    MessageBox.Show($"You pulled a 3 Star. {result}");


                    Console.WriteLine("You pulled a 3 Star");
                    rollCount += 1;

                    rollsUntilA -= 1;
                    rollsUntilS -= 1;

                    aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                    sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

                }


            }

            

            else
            {

                softPityCount = Math.Abs(74 - rollCount);




                Console.WriteLine($"You are in soft pity currently! Your roll count is currently at: {rollCount}");

                if (rollChance <= 0.006 + (softPityCount + 10))
                {

                    MessageBox.Show("You pulled a 5 Star");

                    Console.WriteLine("You pulled a 5 Star");
                    rollCount = 0;

                    rollsUntilA = 10;
                    rollsUntilS = 90;

                    aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                    sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";
                }

                else if (rollChance > 0.006 && rollChance <= 0.078)
                {

                    MessageBox.Show("You pulled a 4 Star");

                    Console.WriteLine("You pulled a 4 Star");
                    rollCount += 1;

                    rollsUntilA = 10;
                    rollsUntilS -= 1;

                    aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                    sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

                }

                else
                {

                    string result = rewardDB.GetRandom3Star();
                    MessageBox.Show($"You pulled a 3 Star. {result}");

                    Console.WriteLine("You pulled a 3 Star");
                    rollCount += 1;

                    rollsUntilA -= 1;
                    rollsUntilS -= 1;

                    aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                    sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

                }


            }

            

        
        }

        public void RollTen(object sender, MouseButtonEventArgs e) {

            rewardDB = new RewardDB();

            Random randNum = new Random();

            string[] rollResults = {"No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll", "No Roll" };

            for (int i = 0; i < 10; i++)
            {

                double rollChance = randNum.NextDouble();

                if (rollsUntilA == 1)
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

                    rollCount += 1;

                    rollsUntilA = 10;
                    rollsUntilS -= 1;

                    aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                    sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

                }

                else if (rollsUntilS == 1)
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

                    rollCount = 0;

                    rollsUntilA = 10;
                    rollsUntilS = 90;

                    aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                    sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

                }


                else if (rollCount < 75)
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

                        rollCount = 0;

                        rollsUntilA = 10;
                        rollsUntilS = 90;

                        aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                        sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

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

                        rollCount += 1;

                        rollsUntilA = 10;
                        rollsUntilS -= 1;

                        aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                        sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

                    }

                    else
                    {

                        string result = rewardDB.GetRandom3Star();

                        Console.WriteLine("You pulled a 3 Star");

                        rollResults[i] = $"You pulled a 3 Star. {result}\n";

                        rollCount += 1;

                        rollsUntilA -= 1;
                        rollsUntilS -= 1;

                        aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                        sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

                    }


                }

                

                else
                {

                    softPityCount = Math.Abs(74 - rollCount);

                    Console.WriteLine($"You are in soft pity currently! Your roll count is currently at: {rollCount}");

                    if (rollChance <= 0.006 + (softPityCount + 10))
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

                        rollCount = 0;

                        rollsUntilA = 10;
                        rollsUntilS = 90;

                        aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                        sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";
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

                        rollCount += 1;

                        rollsUntilA = 10;
                        rollsUntilS -= 1;

                        aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                        sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

                    }

                    else
                    {

                        string result = rewardDB.GetRandom3Star();

                        Console.WriteLine("You pulled a 3 Star");

                        rollResults[i] = $"You pulled a 3 Star. {result}\n";

                        rollCount += 1;

                        rollsUntilA -= 1;
                        rollsUntilS -= 1;

                        aRankCounter.Text = $"A-Rank or higher Signal guarnteed in {rollsUntilA} Searches";
                        sRankCounter.Text = $"S-Rank Signal guaranteed in {rollsUntilS} Searches";

                    }


                }

                for (int j = 0; j < rollResults.Length; j++)
                {

                    Console.WriteLine($"rollResults[{j}] = {rollResults[j]}");

                }


            }

            MessageBox.Show($"Here are the roll results:\n {string.Join("\n\n", rollResults)}");


        }
        */
    }
}