using Newtonsoft.Json;
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
    public partial class RegistroPerfil : ContentPage
    {
        private int id;
        private static string UrlUsuario = "http://192.168.100.4/moviles/postPaciente.php?PK_USUARIO=";
        private readonly HttpClient client = new HttpClient();
        public RegistroPerfil(int pk)
        {
            InitializeComponent();
            id = pk;
            this.dpFechaNacimiento.MaximumDate=DateTime.Today;
            this.Title = "Perfil";
            estadoInicial(true);
            llenarPerfil();
        }

        private async void llenarPerfil()
        {
            
            var content = await client.GetStringAsync(UrlUsuario+id.ToString());

            var _postPaciente = JsonConvert.DeserializeObject<Proyecto_AppMoviles_.Model.PacienteModelo>(content);

            txtNombre.Text = _postPaciente.nombre ;
            txtApellido.Text = _postPaciente.apellido;
            txtIdentificacion.Text = _postPaciente.identificacion;
            
            //DateTime fecha=Convert.ToDateTime(_postPaciente.fechaNacimiento); //conversion directa

            dpFechaNacimiento.Date=Convert.ToDateTime(_postPaciente.fechaNacimiento);

            switch (_postPaciente.genero)
            {
                case "F":
                    pkrGenero.SelectedIndex = 0;
                    break;
                case "M":
                    pkrGenero.SelectedIndex = 1;
                    break;
                case "N":
                    pkrGenero.SelectedIndex = 2;
                    break;
                default:
                    pkrGenero.SelectedIndex = -1;
                    break;
            }
            txtDireccion.Text = _postPaciente.direccion;
            txtTelefono.Text = _postPaciente.telefono;
            txtAlergias.Text = _postPaciente.alergias;
            txtEFC.Text = _postPaciente.ec_s;

        }

        private void btnEditarPerfil_Clicked(object sender, EventArgs e)
        {
            llenarPerfil();
            estadoInicial(false);
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            estadoInicial(true);
            try
            {
                var content = await client.GetStringAsync(UrlUsuario + id.ToString());
                var _postPaciente = JsonConvert.DeserializeObject<Proyecto_AppMoviles_.Model.PacienteModelo>(content);

                if (_postPaciente.PK_Usuario==id)
                {
                    string cadena = "http://192.168.100.4/moviles/postPaciente.php?PK_USUARIO=" + id.ToString();
                    WebClient cliente = new WebClient();
                    var parametros = new System.Collections.Specialized.NameValueCollection();
                    parametros.Add("NOMBRE", txtNombre.Text);
                    parametros.Add("APELLIDO", txtApellido.Text);
                    parametros.Add("IDENTIFICACION", txtIdentificacion.Text);
                    parametros.Add("FECHANACIMIENTO", DateToString(dpFechaNacimiento.Date));
                    parametros.Add("DIRECCION", txtDireccion.Text);
                    parametros.Add("GENERO", Genero(pkrGenero.SelectedIndex).ToString());
                    parametros.Add("TELEFONO", txtTelefono.Text);
                    parametros.Add("ALERGIAS", txtAlergias.Text);
                    parametros.Add("EC_S", txtEFC.Text);

                    cadena += "&NOMBRE=" + txtNombre.Text;
                    cadena += "&APELLIDO=" + txtApellido.Text;
                    cadena += "&IDENTIFICACION=" + txtIdentificacion.Text;
                    cadena += "&FECHANACIMIENTO=" + DateToString(dpFechaNacimiento.Date);
                    cadena += "&DIRECCION=" + txtDireccion.Text;
                    cadena += "&GENERO=" + Genero(pkrGenero.SelectedIndex).ToString();
                    cadena += "&TELEFONO=" + txtTelefono.Text;
                    cadena += "&ALERGIAS=" + txtAlergias.Text;
                    cadena += "&EC_S=" + txtEFC.Text;

                    cliente.UploadValues(cadena, "PUT", parametros);
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
        }

        private string DateToString(DateTime fecha)
        {
            string conversionFecha = "";
            conversionFecha += fecha.Date.Year.ToString();
            conversionFecha += "-";
            conversionFecha += fecha.Date.Month.ToString();
            conversionFecha += "-";
            conversionFecha += fecha.Date.Day.ToString();

            return conversionFecha;
        }
        private char Genero(int genero)
        {
            char opcion = ' ';
            switch (genero)
            {
                case 0:
                    opcion = 'F';
                    break;
                case 1:
                    opcion = 'M';
                    break;
                case 2:
                    opcion = 'N';
                    break;
                default:
                    opcion = 'N';
                    break;
            }
            return opcion;
        }
        private void estadoInicial(bool estado)
        {
            txtNombre.IsEnabled = !estado;
            txtApellido.IsEnabled = !estado;
            txtIdentificacion.IsEnabled = !estado;
            dpFechaNacimiento.IsEnabled = !estado;
            pkrGenero.IsEnabled = !estado;
            txtDireccion.IsEnabled = !estado;
            txtTelefono.IsEnabled = !estado;
            txtAlergias.IsEnabled = !estado;
            txtEFC.IsEnabled = !estado;
            btnActualizar.IsVisible = !estado;
            btnEditarPerfil.IsVisible = estado;
        }
    }
}