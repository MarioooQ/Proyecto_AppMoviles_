using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_AppMoviles_.Model
{
    class CitaModelo
    {
        public int PK_Cita;
        public int PK_Paciente;
        public string fechaCita; //datetime
        public string razon;
        public string pago; //blob
        public bool estado;
    }
}
