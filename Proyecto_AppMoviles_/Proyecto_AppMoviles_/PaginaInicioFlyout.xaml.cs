using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto_AppMoviles_
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicioFlyout : ContentPage
    {
        public ListView ListView;

        public PaginaInicioFlyout()
        {
            InitializeComponent();
            BindingContext = new PaginaInicioFlyoutViewModel();
            
            lblUsuario.Text = "";
            ListView = MenuItemsListView;
        }

        class PaginaInicioFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<PaginaInicioFlyoutMenuItem> MenuItems { get; set; }

            public PaginaInicioFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<PaginaInicioFlyoutMenuItem>(new[]
                {
                    new PaginaInicioFlyoutMenuItem {Id=0, Title="Inicio"},
                    new PaginaInicioFlyoutMenuItem { Id = 1, Title = "Perfil" },
                    new PaginaInicioFlyoutMenuItem { Id = 2, Title = "Citas" },
                    //new PaginaInicioFlyoutMenuItem { Id = 2, Title = "Pagos" },
                    new PaginaInicioFlyoutMenuItem { Id = 3, Title = "Contacto" },
                    new PaginaInicioFlyoutMenuItem { Id = 4, Title = "Cerrar sesión" }
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}