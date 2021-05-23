using Newtonsoft.Json;
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
    public partial class RegistroPerfil : ContentPage
    {
        private int id;
        private static string UrlUsuario = "http://192.168.100.4/moviles/postPaciente.php?PK_USUARIO=";
        private readonly HttpClient client = new HttpClient();
        public RegistroPerfil(int pk)
        {
            InitializeComponent();
            id = pk;
            this.fechaNacimiento.MaximumDate=DateTime.Today;
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
            
            DateTime fecha=Convert.ToDateTime(_postPaciente.fechaNacimiento);

            fechaNacimiento.Date=Convert.ToDateTime(_postPaciente.fechaNacimiento);

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

        private void estadoInicial(bool estado)
        {
            txtNombre.IsEnabled = !estado;
            txtApellido.IsEnabled = !estado;
            txtIdentificacion.IsEnabled = !estado;
            fechaNacimiento.IsEnabled = !estado;
            pkrGenero.IsEnabled = !estado;
            txtDireccion.IsEnabled = !estado;
            txtTelefono.IsEnabled = !estado;
            txtAlergias.IsEnabled = !estado;
            txtEFC.IsEnabled = !estado;
            btnActualizar.IsVisible = !estado;
            btnEditarPerfil.IsVisible = estado;
        }
        private void btnEditarPerfil_Clicked(object sender, EventArgs e)
        {
            llenarPerfil();
            estadoInicial(false);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            estadoInicial(true);
        }
    }
}