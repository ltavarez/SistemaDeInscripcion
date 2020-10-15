using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public sealed class RepositorioEstudiante
    {

        public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

        public static RepositorioEstudiante Instancia { get; } = new RepositorioEstudiante();

        private RepositorioEstudiante()
        {

        }



    }
}
