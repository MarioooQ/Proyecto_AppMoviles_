using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;


namespace Proyecto_AppMoviles_
{
    public class CommandTexto
    {
        public ICommand TapRecuperar { get; } = new Command(async () =>
        {
            //await App.Current.MainPage.DisplayAlert("", DateTime.Today.ToString(),"ok");
            await App.Current.MainPage.DisplayAlert("Texto presionado", "En desarrollo", "ok");
        });
        public ICommand TapRegistro { get; } = new Command(async () =>
        {
            
            await App.Current.MainPage.Navigation.PushAsync(new PaginaRegistro());
        });
    }
}
