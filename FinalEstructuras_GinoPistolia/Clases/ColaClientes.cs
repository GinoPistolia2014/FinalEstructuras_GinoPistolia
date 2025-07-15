using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalEstructuras_GinoPistolia.Clases
{
    public class ColaClientes
    {
        public NodoCola Inicio;
        public NodoCola Fin;

        public ColaClientes()
        {
            Inicio = null;
            Fin = null;
        }
        public void Agregar(string DNI, string Nombre, string Apellido)
        {
            Cliente cliente = new Cliente(DNI, Nombre, Apellido);
            NodoCola nuevo = new NodoCola(cliente);
            if (Fin == null)
            {
                Inicio = nuevo;
                Fin = nuevo;
            }
            else 
            {
                Fin.Siguiente = nuevo;
                Fin = nuevo;
            }
        }

        public void Eliminar()
        {
            if(Inicio != null)
            {
                Inicio = Inicio.Siguiente;
                if (Inicio == null) Fin = null;
            }
        }
        public List<Cliente> devolverRegistros()
        {
            List<Cliente> lista = new List<Cliente>();
            NodoCola aux = Inicio;
            while (aux != null)
            {
                lista.Add(aux.Cliente);
                aux = aux.Siguiente;
            }
            return lista;
        }
        public void Vaciar()
        {
            Inicio = null;
            Fin = null;
        }
    }
}
