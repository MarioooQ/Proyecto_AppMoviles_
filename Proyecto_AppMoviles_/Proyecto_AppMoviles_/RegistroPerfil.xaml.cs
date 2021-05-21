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
    public partial class RegistroPerfil : ContentPage
    {
        public RegistroPerfil()
        {
            InitializeComponent();
            this.fechaNacimiento.MaximumDate=DateTime.Today;
            this.Title = "Perfil";
            txtNombre.IsEnabled = false;
            txtApellido.IsEnabled = false;
            txtIdentificacion.IsEnabled = false;
            fechaNacimiento.IsEnabled = false;
            pkrGenero.IsEnabled = false;
            txtDireccion.IsEnabled = false;
            txtTelefono.IsEnabled = false;
            txtAlergias.IsEnabled = false;
            txtEFC.IsEnabled = false;
            btnActualizar.IsVisible = false;
        }

        private void btnEditarPerfil_Clicked(object sender, EventArgs e)
        {
            txtNombre.IsEnabled = true;
            txtApellido.IsEnabled = true;
            txtIdentificacion.IsEnabled = true;
            fechaNacimiento.IsEnabled = true;
            pkrGenero.IsEnabled = true;
            txtDireccion.IsEnabled = true;
            txtTelefono.IsEnabled = true;
            txtAlergias.IsEnabled = true;
            txtEFC.IsEnabled = true;
            btnActualizar.IsVisible = true;
            btnEditarPerfil.IsVisible = false;

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            btnActualizar.IsVisible = false;
            btnEditarPerfil.IsVisible = true;
            txtNombre.IsEnabled = false;
            txtApellido.IsEnabled = false;
            txtIdentificacion.IsEnabled = false;
            fechaNacimiento.IsEnabled = false;
            pkrGenero.IsEnabled = false;
            txtDireccion.IsEnabled = false;
            txtTelefono.IsEnabled = false;
            txtAlergias.IsEnabled = false;
            txtEFC.IsEnabled = false;
        }
    }
    public class Genero
    {
        public string Name { get; set; }
    }
}