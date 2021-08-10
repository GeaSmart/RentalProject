using Mach.Entities;
using Mach.Shared;
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

namespace Mach
{
    public partial class frmContratosTest : Form
    {
        public frmContratosTest()
        {
            InitializeComponent();
        }

        private async void frmContratos_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Contrato miContrato = new Contrato()
            {
                FechaInicio = new DateTime(2020, 1, 1),
                FechaFin = new DateTime(2020, 02, 02),
                IsCombustible = true,
                IsTransporte = true,
                Observaciones = "ninguna observacion"
            };

            var response = await ApiHelper.Post(miContrato);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Contrato miContrato = new Contrato()
            {
                Id = 1002,
                FechaInicio = new DateTime(2020, 1, 1),
                FechaFin = new DateTime(2020, 02, 02),
                IsCombustible = true,
                IsTransporte = true,
                Observaciones = "alguna observacion"
            };

            var response = await ApiHelper.Put(1002, miContrato);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var response = await ApiHelper.Delete(1002);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var response = await ApiHelper.GetAll();
            this.textBox1.Text = ApiHelper.BeautifyJson(response);
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var response = await ApiHelper.Get(1);
            this.textBox1.Text = ApiHelper.BeautifyJson(response);
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var response = await ApiHelper.GetAll();
            var listado = JsonConvert.DeserializeObject<List<Contrato>>(response);

            this.dataGridView1.DataSource = listado;

        }
    }
}
