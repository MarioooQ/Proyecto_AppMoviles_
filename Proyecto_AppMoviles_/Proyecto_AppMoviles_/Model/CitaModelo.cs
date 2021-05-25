using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_AppMoviles_.Model
{
    class CitaModelo
    {
        public int PK_Cita { get; set; }
        public int PK_Paciente { get; set; }
        public string fechaCita { get; set; } //datetime
        public string razon { get; set; }
        public string pago { get; set; } //blob
        public int estado { get; set; }
    }
}
