using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyecto_AppMoviles_
{
    public partial class MainPage : ContentPage
    {
        private static string Url = "http://192.168.100.4/moviles/postLogin.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Proyecto_AppMoviles_.Model.LoginModelo> _postLogin;
        public MainPage()
        {

            InitializeComponent();
            txtContrasena.Text = "";
            txtUsuario.Text = "";
            BindingContext = new CommandTexto();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            var content = await client.GetStringAsync(Url);
            List<Proyecto_AppMoviles_.Model.LoginModelo> posts = JsonConvert.DeserializeObject<List<Proyecto_AppMoviles_.Model.LoginModelo>>(content);
            _postLogin = new ObservableCollection<Proyecto_AppMoviles_.Model.LoginModelo>(posts);

            try
            {
                if (_postLogin.Any(i => i.usuario == txtUsuario.Text && i.contrasena == txtContrasena.Text)==true)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new PaginaInicio(_postLogin.Single(i => i.usuario == txtUsuario.Text).pk_usuario));
                }
                else
                {
                    await this.DisplayAlert("Error", "Usuario o contraseña incorrecta ", "ok");
                }
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("Error", "Error " + ex.Message, "ok");
            }
        }
    }
}
