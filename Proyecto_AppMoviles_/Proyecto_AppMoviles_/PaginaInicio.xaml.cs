using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_AppMoviles_
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicio : FlyoutPage
    {
        public PaginaInicio()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PaginaInicioFlyoutMenuItem;
            if (item == null)
                return;

            switch (item.Id)
            {
                case 0:
                    Detail = new NavigationPage(new PaginaInicioDetail());
                    break;
                case 1:
                    Detail = new NavigationPage(new RegistroPerfil());
                    break;
                case 2:
                    Detail = new NavigationPage(new PaginaCitas());
                    break;
                /*case 2:
                    Detail = new NavigationPage(new PaginaPagos(1));
                    break;*/
                case 3:
                    Detail = new NavigationPage(new PaginaContacto());
                    break;
                case 4:
                    await App.Current.MainPage.Navigation.PopToRootAsync(true);
                    break;
            }

            IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }
    }
}