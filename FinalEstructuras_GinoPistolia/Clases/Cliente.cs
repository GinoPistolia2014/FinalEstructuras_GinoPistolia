using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEstructuras_GinoPistolia.Clases
{
    public class Cliente
    {
        public string DNI {  get; set; }
        public string Nombre {  get; set; }
        public string Apellido {  get; set; }

        public Cliente Siguiente;

        public Cliente(string DNI, string Nombre, string Apellido)
        {
            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellido = Apellido;
        }
    }
}
