using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_AppMoviles_.Model
{
    class CitaModelo
    {
        private int PK_cita;
        private int PK_paciente;
        private string fechaCita; //datetime
        private string pago; //blob
        bool estado;
    }
}
