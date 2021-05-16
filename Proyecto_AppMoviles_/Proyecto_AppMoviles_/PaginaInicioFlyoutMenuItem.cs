using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_AppMoviles_
{
    public class PaginaInicioFlyoutMenuItem
    {
        public PaginaInicioFlyoutMenuItem()
        {
            TargetType = typeof(PaginaInicioFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}