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
        public PaginaRegistrarCita()
        {
            InitializeComponent();
            Title = "Registrar cita";

        }

        private void btnGuardarCita_Clicked(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {

        }
    }
}