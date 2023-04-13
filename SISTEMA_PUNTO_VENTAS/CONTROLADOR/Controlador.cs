using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SISTEMA_PUNTO_VENTAS.CONTROLADOR
{
    class Controlador
    {
        //Funcion para validar Email
        public bool ValidacionEmail(string sMail) {
            return Regex.IsMatch(sMail,@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$");
        }

        //Funcion para aceptar solo numeros
        public void SoloNumeros(TextBox cajaTexto, KeyPressEventArgs e) {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else {
                e.Handled = true;
            }
        }
    }
}
