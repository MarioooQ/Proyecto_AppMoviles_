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
    public partial class PaginaCitas : ContentPage
    {
        public PaginaCitas()
        {
            InitializeComponent();
        }

        private void btnAgendarCita_Clicked(object sender, EventArgs e)
        {

        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void btnPagar_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new PaginaPagos(1));
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            string opcion= await App.Current.MainPage.DisplayPromptAsync("Eliminar", "¿Seguro desea eliminar su cita", "Aceptar", "Cancelar");
            
            if (opcion.Equals("Aceptar"))
            {

            }

        }
    }
}