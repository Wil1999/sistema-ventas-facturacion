using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_PUNTO_VENTAS.MODELO
{
    class UsuarioM
    {
        public int IdUsuario { get; set; }
        public string NombresApellidos { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Icono { get; set; }
        public string IconoNombre { get; set; }
        public string Correo { get; set; }
        public string Rol { get; set; }
    }
}
