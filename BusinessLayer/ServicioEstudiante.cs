using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ServicioEstudiante
    {

        public void Agregar(Estudiante item)
        {
            RepositorioEstudiante.Instancia.Estudiantes.Add(item);
        }

        public void Editar(int index,Estudiante item)
        {
            RepositorioEstudiante.Instancia.Estudiantes[index] = item;
        }

        public void Eliminar(int index)
        {
            RepositorioEstudiante.Instancia.Estudiantes.RemoveAt(index);
        }

        public Estudiante GetEstudiante(int index)
        {
            return RepositorioEstudiante.Instancia.Estudiantes[index];
        }

        public List<Estudiante> GetAll()
        {
            return RepositorioEstudiante.Instancia.Estudiantes;
        }
    }
}
