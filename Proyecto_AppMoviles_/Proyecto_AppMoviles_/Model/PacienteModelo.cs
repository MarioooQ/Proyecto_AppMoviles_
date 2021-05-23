using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto_AppMoviles_.Model
{
    class PacienteModelo
    {
        public int PK_Paciente { get; set; }
        public int PK_Usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string identificacion { get; set; }
        public string fechaNacimiento { get; set; } //date
        public string direccion { get; set; }
        public string genero { get; set; } //char
        public string telefono { get; set; }
        public string alergias { get; set; }
        public string ec_s { get; set; }
    }
}
