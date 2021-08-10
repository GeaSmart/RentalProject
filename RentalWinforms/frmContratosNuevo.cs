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
    public partial class frmContratosNuevo : Form
    {
        private readonly int id;

        public frmContratosNuevo()
        {
            InitializeComponent();
        }
        public frmContratosNuevo(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (id > 0)
            {
                Contrato miContrato = new Contrato()
                {
                    Id = id,
                    FechaInicio = this.dtpFechaInicio.Value,
                    FechaFin = this.dtpFechaFin.Value,
                    IsCombustible = this.chkCombustible.Checked,
                    IsTransporte = this.chkTransporte.Checked,
                    Observaciones = this.txtObservaciones.Text
                };

                //Reply oReply = new Reply();
                //RequestHelper o = new RequestHelper();
                //oReply = await o.Execute<Contrato>($"https://localhost:44329/api/contrato/{id}", RequestHelper.methodHttp.PUT, miContrato);
                //MessageBox.Show(oReply.StatusCode);

                
                Reply oReply = new Reply();
                ApiHelper o = new ApiHelper();
                oReply = await o.Execute<Contrato>($"https://localhost:44329/api/contrato/{id}", ApiHelper.methodHttp.PUT, miContrato);
                                
                MessageBox.Show(oReply.StatusCode);

            }
            else
            {
                Contrato miContrato = new Contrato()
                {
                    FechaInicio = this.dtpFechaInicio.Value,
                    FechaFin = this.dtpFechaFin.Value,
                    IsCombustible = this.chkCombustible.Checked,
                    IsTransporte = this.chkTransporte.Checked,
                    Observaciones = this.txtObservaciones.Text
                };

                var response = await ApiHelper.Post(miContrato);

                MessageBox.Show("Contrato guardado correctamente");
            }
            this.Close();
        }

        private async void frmContratosNuevo_Load(object sender, EventArgs e)
        {
            if (id > 0)
            {
                var response = await ApiHelper.Get(id);
                var objeto = JsonConvert.DeserializeObject<Contrato>(response);

                this.dtpFechaInicio.Value = objeto.FechaInicio;
                this.dtpFechaFin.Value = objeto.FechaFin;
                this.chkCombustible.Checked = objeto.IsCombustible;
                this.chkTransporte.Checked = objeto.IsTransporte;
                this.txtObservaciones.Text = objeto.Observaciones;

                this.btnGuardar.Text = "Actualizar";
            }
        }
    }
}
