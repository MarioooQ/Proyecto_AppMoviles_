using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_AppMoviles_
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaRegistro : ContentPage
    {
        Account account;
        //AccountStore store;
        public PaginaRegistro()
        {
            InitializeComponent();
            this.Title = "Registro";
            //store = AccountStore.Create();

        }

        private void btnIngresarGoogle_Clicked(object sender, EventArgs e)
        {
            string clientId = null;
            string redirectUri = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = AppConstant.Constants.iOSClientId;
                    redirectUri = AppConstant.Constants.iOSRedirectUrl;
                    break;

                case Device.Android:
                    clientId = AppConstant.Constants.AndroidClientId;
                    redirectUri = AppConstant.Constants.AndroidRedirectUrl;
                    break;
            }

            //account = store.FindAccountsForService(AppConstant.Constants.AppName).FirstOrDefault();

            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                AppConstant.Constants.Scope,
                new Uri(AppConstant.Constants.AuthorizeUrl),
                new Uri(redirectUri),
                new Uri(AppConstant.Constants.AccessTokenUrl),
                null,
                true);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);

        }

        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            User user = null;
            if (e.IsAuthenticated)
            {
                // If the user is authenticated, request their basic user data from Google
                // UserInfoUrl = https://www.googleapis.com/oauth2/v2/userinfo
                var request = new OAuth2Request("GET", new Uri(AppConstant.Constants.UserInfoUrl), null, e.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    // Deserialize the data and store it in the account store
                    // The users email address will be used to identify data in SimpleDB
                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<User>(userJson);
                }

                //await store.SaveAsync(account = e.Account, AppConstant.Constants.AppName);
                await DisplayAlert("Email address", user.Email, "OK");
            }
        }
        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }

        private async void btnRegistar_Clicked(object sender, EventArgs e)
        {
            if(txtContrasena.Text == txtConfirmar.Text)
            {
                string cadena = "http://192.168.100.4/moviles/postLogin.php";
                WebClient cliente = new WebClient();

                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("USUARIO", txtUsuario.Text);
                parametros.Add("CONTRASENA", txtContrasena.Text);

                cliente.UploadValues(cadena, "POST", parametros);

                await this.DisplayAlert("¡Usuario ingresado con exito!", "Inicie sesión con su nueva cuenta", "Aceptar");
                await this.Navigation.PopAsync();
            }
            else
            {
                await this.DisplayAlert("Error", "Las contraseñas no son iguales", "Aceptar");
                txtConfirmar.Text = null;
            }
        }
    }
}