using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_AppMoviles_
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicio : FlyoutPage
    {
        private int id;

        public PaginaInicio(int pk)
        {
            InitializeComponent();
            id = pk;
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
                    Detail = new NavigationPage(new PaginaInicioDetail()); //inicio
                    break;
                case 1:
                    Detail = new NavigationPage(new RegistroPerfil(id)); //perfil
                    break;
                case 2:
                    Detail = new NavigationPage(new PaginaCitas(id)); //citas
                    break;
                /*case 2:
                    Detail = new NavigationPage(new PaginaPagos(1));
                    break;*/
                case 3:
                    Detail = new NavigationPage(new PaginaContacto()); //contacto
                    break;
                case 4:
                    await App.Current.MainPage.Navigation.PopToRootAsync(true); //Cerrar sesión
                    break;
            }

            IsPresented = false;

            FlyoutPage.ListView.SelectedItem = null;
        }

    }
}