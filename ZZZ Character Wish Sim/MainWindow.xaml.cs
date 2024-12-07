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


// --------------------------------------------------------------------------------------------------------------------------------

// Main app interface that opens upon app run
// Uses a frame that controls which page shows up
// Holds the side panel buttons that map to each different page

// --------------------------------------------------------------------------------------------------------------------------------

namespace ZZZ_Character_Wish_Sim
{
   

    public partial class MainWindow : Window
    {

        private RewardDB rewardDB;

        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new Banner1());
            SetActiveBannerButton(bBtn1);

            rewardDB = new RewardDB();
            rewardDB.createDB();


        }

        // --------------------------------------------------------------------------------------------------------------------------------
        // Callbacks used to navigate to specific banner pages
        // Change the active banner buttons when chaning banners
        // --------------------------------------------------------------------------------------------------------------------------------

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
    }
}