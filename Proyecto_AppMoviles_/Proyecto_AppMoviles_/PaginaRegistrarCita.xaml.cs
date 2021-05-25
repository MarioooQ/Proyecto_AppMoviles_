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
    public partial class PaginaRegistrarCita : ContentPage
    {
        private int id;
        public PaginaRegistrarCita(int pk)
        {
            InitializeComponent();
            Title = "Registrar cita";
            id = pk;

        }

        private void btnGuardarCita_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }
}