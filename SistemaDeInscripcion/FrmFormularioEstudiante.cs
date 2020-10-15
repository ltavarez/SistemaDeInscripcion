using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace SistemaDeInscripcion
{
    public partial class FrmFormularioEstudiante : Form
    {

        private readonly ServicioEstudiante servicio;

        public int? indexEstudiante;
        public FrmFormularioEstudiante()
        {
            servicio = new ServicioEstudiante();
            InitializeComponent();
        }

        private void FrmFormularioEstudiante_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmListadoEstudiantes newForm = FrmListadoEstudiantes.Instancia;
            newForm.Show();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            Estudiante estudiante = new Estudiante()
            {
                Nombre = TxtNombre.Text,
                Apellido = TxtApellido.Text,
                MateriaFavorita = TxtMateriaFavorita.Text
            };

            if (indexEstudiante != null)
            {
                servicio.Editar(indexEstudiante.Value,estudiante);
            }
            else
            {
                servicio.Agregar(estudiante);
            }

            
            MessageBox.Show("Se ha guardado correctamente", "Notificacion");
            this.Close();
        }

        private void FrmFormularioEstudiante_Load(object sender, EventArgs e)
        {
            if (indexEstudiante != null)
            {
                Estudiante estudianteAEditar = servicio.GetEstudiante(indexEstudiante.Value);
                TxtNombre.Text = estudianteAEditar.Nombre;
                TxtApellido.Text = estudianteAEditar.Apellido;
                TxtMateriaFavorita.Text = estudianteAEditar.MateriaFavorita;
            }

        }


        private void CloseForm()
        {
        
            this.Close();
        }

      
    }
}
