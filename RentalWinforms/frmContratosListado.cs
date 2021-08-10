using RentalWinforms.Entities;
using RentalWinforms.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentalWinforms
{
    public partial class frmContratosListado : Form
    {
        public frmContratosListado()
        {
            InitializeComponent();
        }

        private async void frmContratosListado_Load(object sender, EventArgs e)
        {
            //List<Contrato> listado = new List<Contrato>();
            //Reply oReply = new Reply();
            //ApiHelper o = new ApiHelper();
            //oReply = await o.Execute<List<Contrato>>("https://localhost:44329/api/contrato", ApiHelper.methodHttp.GET, listado);

            //this.dgvListadoContratos.DataSource = oReply.Data;
            //MessageBox.Show(oReply.StatusCode);

            List<Contrato> listado = new List<Contrato>();
            Reply oReply = new Reply();
            RequestHelper o = new RequestHelper();
            oReply = await o.Execute<List<Contrato>>("https://localhost:44329/api/contrato", RequestHelper.methodHttp.GET, listado);

            this.dgvListadoContratos.DataSource = oReply.Data;
            MessageBox.Show(oReply.StatusCode);
        }

        private void btnNuevoContrato_Click(object sender, EventArgs e)
        {
            frmContratosNuevo nuevo = new frmContratosNuevo();
            nuevo.ShowDialog();
        }

        private void dgvListadoContratos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = Convert.ToInt32(this.dgvListadoContratos.CurrentRow.Cells["id"].Value.ToString());
            frmContratosNuevo nuevo = new frmContratosNuevo(id);
            nuevo.ShowDialog();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var response = await ApiHelper.GetAll();
            var listado = JsonConvert.DeserializeObject<List<Contrato>>(response);

            this.dgvListadoContratos.DataSource = listado;
        }
    }
}
