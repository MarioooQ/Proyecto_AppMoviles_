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
    public partial class PaginaCitas : ContentPage
    {
        private int idUsuario;
        private int idPaciente;
        Model.PacienteModelo _postPaciente;

        /*************Paciente*****************/
        private static string UrlUsuario = "http://192.168.100.4/moviles/postPaciente.php";
        private readonly HttpClient clientUsuario = new HttpClient();//Usuario porque busca en pacientes y envia el usuario
        private ObservableCollection<Proyecto_AppMoviles_.Model.PacienteModelo> _postPacientes;

        /*************Cita********************/
        private static string UrlPaciente = "http://192.168.100.4/moviles/postCita.php";
        private readonly HttpClient clientPaciente = new HttpClient();//Paciente porque busca en citas y envia el paciente
        private ObservableCollection<Proyecto_AppMoviles_.Model.CitaModelo> _postCitas;

        public PaginaCitas(int pk)
        {
            InitializeComponent();
            idUsuario = pk;
            VerificarPaciente();
            get();
        }

        private async void get()
        {
            var content = await clientPaciente.GetStringAsync(UrlPaciente);
            List<Proyecto_AppMoviles_.Model.CitaModelo> posts = JsonConvert.DeserializeObject<List<Proyecto_AppMoviles_.Model.CitaModelo>>(content);
            _postCitas = new ObservableCollection<Proyecto_AppMoviles_.Model.CitaModelo>(posts);
            lvPaginaCitas.ItemsSource = _postCitas.Where(i => i.PK_Paciente == 1);
        }

        private async void VerificarPaciente()
        {
            var content = await clientUsuario.GetStringAsync(UrlUsuario);
            List<Proyecto_AppMoviles_.Model.PacienteModelo> posts = JsonConvert.DeserializeObject<List<Proyecto_AppMoviles_.Model.PacienteModelo>>(content);
            _postPacientes = new ObservableCollection<Proyecto_AppMoviles_.Model.PacienteModelo>(posts);
            _postPaciente = posts.Single(i => i.PK_Usuario == idUsuario);
           
            if (_postPacientes.Any(i => i.PK_Usuario == idUsuario) == false)
            {
                    await this.DisplayAlert("Error", "Debe llenar su perfil de usuario", "Aceptar");
                    await this.Navigation.PushAsync(new RegistroPerfil(idUsuario));
            }
            else
            {
                if ((_postPaciente.nombre==" ") == true || (_postPaciente.identificacion== " ") == true || ((_postPaciente.telefono== " ")==true))
                {
                    await this.DisplayAlert("Error", "Debe acabar de llenar su perfil", "Aceptar");
                    await this.Navigation.PushAsync(new RegistroPerfil(idUsuario));
                }
            }
        }

        private async void btnAgendarCita_Clicked(object sender, EventArgs e)
        {
            VerificarPaciente();
            if ((_postPaciente.nombre == " ") == false || (_postPaciente.identificacion == " ") == false || ((_postPaciente.telefono == " ") == false))
            {
                idPaciente = _postPaciente.PK_Paciente;
                await App.Current.MainPage.Navigation.PushAsync(new PaginaRegistrarCita(idPaciente));
            }

        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private async void btnPagar_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PushAsync(new PaginaPagos(idPaciente));
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            string opcion = await App.Current.MainPage.DisplayPromptAsync("Eliminar", "¿Seguro desea eliminar su cita", "Aceptar", "Cancelar");

            if (opcion.Equals("Aceptar"))
            {

            }

        }
    }
}