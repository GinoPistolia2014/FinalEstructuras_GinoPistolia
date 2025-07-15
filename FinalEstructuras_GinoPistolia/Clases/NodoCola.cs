using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEstructuras_GinoPistolia.Clases
{
    public class NodoCola
    {
        public Cliente Cliente { get; set; }
        public NodoCola Siguiente { get; set; }

        public NodoCola(Cliente cliente)
        { 
            Cliente = cliente;
            Siguiente = null;
        }
    }
}
