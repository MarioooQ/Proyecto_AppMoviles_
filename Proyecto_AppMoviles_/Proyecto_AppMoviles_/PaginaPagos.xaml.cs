using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft;

namespace Proyecto_AppMoviles_
{
    public partial class PaginaPagos : ContentPage
    {
        private static string UrlPago = "http://192.168.100.4/moviles/postPago.php";
        private readonly HttpClient clientCita = new HttpClient();//Paciente porque busca en citas y envia el paciente
        string idCita;
        public PaginaPagos(string PK_Cita)
        {
            InitializeComponent();
            Title = "Pagos";
            idCita = PK_Cita;
        }

        private async void btnAgregarPago_Clicked(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await this.DisplayAlert("Error", "Camara no disponible", "Aceptar");
                return;
            }

            var pago =
            await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Pagos_CTLH",
                Name = "Pago-" + idCita,
                SaveToAlbum = true,
                CompressionQuality = 75,
                CustomPhotoSize=50,
                PhotoSize=Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight,
                MaxWidthHeight=800,
                DefaultCamera=Plugin.Media.Abstractions.CameraDevice.Rear
            });

            if (pago == null)
                return;

            imgPago.Source = ImageSource.FromStream(() =>
              {
                  var stream = pago.GetStream();
                  return stream;
              });

            try
            {
                //string cadena = "http://192.168.100.4/moviles/postCita.php?PK_CITA="+idCita+"&PAGO=";
                //WebClient cliente = new WebClient();

                //var parametros = new System.Collections.Specialized.NameValueCollection();
                //parametros.Add("PK_CITA", idCita);
                //parametros.Add("PAGO", GetBase64StringForImage(pago.Path));

                //await this.DisplayAlert("path", pago.Path, "Aceptar");
                //await this.DisplayAlert("transformacion", GetBase64StringForImage(pago.Path), "Aceptar");

                var stringContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("PK_CITA", idCita),
                    new KeyValuePair<string, string>("PAGO", GetBase64StringForImage(pago.Path)),
                });

                //cliente.UploadValues(cadena+GetBase64StringForImage(pago.Path), "PUT", parametros);*/

                /*await this.DisplayAlert("¡Usuario ingresado con exito!", "Inicie sesión con su nueva cuenta", "Aceptar");

                await this.Navigation.PopAsync();*/

                await clientCita.PostAsync(UrlPago, stringContent);
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("Error", ex.Message, "ok");
            }


        }
        protected static string GetBase64StringForImage(string imgPath)
        {
            byte[] imageBytes = System.IO.File.ReadAllBytes(imgPath);
            string base64String = Convert.ToBase64String(imageBytes);
            return base64String;
        }

        private async void btnSalir_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }


}