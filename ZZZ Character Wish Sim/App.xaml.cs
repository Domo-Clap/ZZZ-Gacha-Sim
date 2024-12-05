using System.Configuration;
using System.Data;
using System.Windows;

namespace ZZZ_Character_Wish_Sim
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            Application.Current.Properties["banner1RollsUntilA"] = 10;
            Application.Current.Properties["banner1RollsUntilS"] = 90;
            Application.Current.Properties["banner1RollCount"] = 0;
            Application.Current.Properties["banner1SoftPityCount"] = 0;

            Application.Current.Properties["banner2RollsUntilA"] = 10;
            Application.Current.Properties["banner2RollsUntilS"] = 90;
            Application.Current.Properties["banner2RollCount"] = 0;
            Application.Current.Properties["banner2SoftPityCount"] = 0;

            Application.Current.Properties["banner3RollsUntilA"] = 10;
            Application.Current.Properties["banner3RollsUntilS"] = 90;
            Application.Current.Properties["banner3RollCount"] = 0;
            Application.Current.Properties["banner3SoftPityCount"] = 0;

        }

    }

}
