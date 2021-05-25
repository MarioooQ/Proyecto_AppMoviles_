using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_AppMoviles_
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaRegistrarCita : ContentPage
    {
        private int idPaciente;

        public PaginaRegistrarCita(int pk)
        {
            InitializeComponent();
            Title = "Registrar cita";
            idPaciente = pk;
            dpFechaCita.MinimumDate = DateTime.Now;

        }

        private async void btnGuardarCita_Clicked(object sender, EventArgs e)
        {
            string cadena = "http://192.168.100.4/moviles/postCita.php";
            WebClient cliente = new WebClient();
            
            var parametros = new System.Collections.Specialized.NameValueCollection();

            parametros.Add("PK_PACIENTE", idPaciente.ToString());
            parametros.Add("FECHACITA", DateTimeToString(dpFechaCita.Date)+" "+pkHoraCita.SelectedItem+":00");
            parametros.Add("RAZON", txtRazon.Text);

            cliente.UploadValues(cadena, "POST", parametros);
            await this.Navigation.PopAsync();
        }

        private string DateTimeToString(DateTime fecha)
        {
            string conversionFecha = "";
            conversionFecha += fecha.Date.Year.ToString();
            conversionFecha += "-";
            conversionFecha += fecha.Date.Month.ToString();
            conversionFecha += "-";
            conversionFecha += fecha.Date.Day.ToString();

            return conversionFecha;
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }
}