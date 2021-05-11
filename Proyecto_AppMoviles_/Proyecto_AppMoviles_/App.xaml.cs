using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_AppMoviles_
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Image logo = new Image { Source = "logocentordeterapia.jpg" };

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
