using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyecto_AppMoviles_
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {

            InitializeComponent();
            BindingContext = new CommandTexto();
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {

        }

}
}
