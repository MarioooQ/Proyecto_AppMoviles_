using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_AppMoviles_.Model
{
    class HistoriaClinicaModelo
    {
        public int PK_HistoriaClinica { get; set; }
        public int PK_Cita { get; set; }
        public string tratamiento { get; set; }
        public string observaciones { get; set; }
    }
}
