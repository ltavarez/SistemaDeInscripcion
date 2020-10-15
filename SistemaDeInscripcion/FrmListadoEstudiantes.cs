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
    public sealed partial class FrmListadoEstudiantes : Form
    {

        public static FrmListadoEstudiantes Instancia { get; } = new FrmListadoEstudiantes();

        private readonly ServicioEstudiante servicio;

        private FrmListadoEstudiantes()
        {
            servicio = new ServicioEstudiante();
            InitializeComponent();
        }


        #region Events

        private void BtnAgregarEstudiante_Click(object sender, EventArgs e)
        {
            FrmFormularioEstudiante newForm = new FrmFormularioEstudiante();
            newForm.Show();
            this.Hide();
        }

        private void FrmListadoEstudiantes_Load(object sender, EventArgs e)
        {
            LoadEstudiantes();
        }

        private void FrmListadoEstudiantes_VisibleChanged(object sender, EventArgs e)
        {
            LoadEstudiantes();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int index = LboxEstudiantes.SelectedIndex;

            if (index < 0)
            {
                MessageBox.Show("Debe seleccionar un estudiante", "Notificacion");
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("Esta seguro que deseas eliminar a este estudiante",
                    "Notificacion", MessageBoxButtons.OKCancel);

                if (respuesta == DialogResult.OK)
                {
                    servicio.Eliminar(index);
                    LoadEstudiantes();
                }

            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            int index = LboxEstudiantes.SelectedIndex;

            if (index < 0)
            {
                MessageBox.Show("Debe seleccionar un estudiante", "Notificacion");
            }
            else
            {
                FrmFormularioEstudiante newForm = new FrmFormularioEstudiante();
                newForm.indexEstudiante = index;
                newForm.Show();
                this.Hide();
            }

        }

        #endregion

        #region Methods


        private void LoadEstudiantes()
        {
            LboxEstudiantes.BeginUpdate();

            LboxEstudiantes.Items.Clear();

            var estudiantes = servicio.GetAll();

            foreach (Estudiante item in estudiantes)
            {
                LboxEstudiantes.Items.Add(item.Datos);
            }

            LboxEstudiantes.EndUpdate();
        }
#endregion

    }
}
