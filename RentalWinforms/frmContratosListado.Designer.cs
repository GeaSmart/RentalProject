
namespace Mach
{
    partial class frmContratosListado
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvListadoContratos = new System.Windows.Forms.DataGridView();
            this.btnNuevoContrato = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoContratos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(357, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(491, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "A continuación se muestra la lista de todos los contratos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvListadoContratos);
            this.groupBox1.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(33, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1231, 711);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Listado";
            // 
            // dgvListadoContratos
            // 
            this.dgvListadoContratos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoContratos.Location = new System.Drawing.Point(36, 46);
            this.dgvListadoContratos.Name = "dgvListadoContratos";
            this.dgvListadoContratos.RowHeadersWidth = 51;
            this.dgvListadoContratos.RowTemplate.Height = 24;
            this.dgvListadoContratos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoContratos.Size = new System.Drawing.Size(1146, 625);
            this.dgvListadoContratos.TabIndex = 0;
            this.dgvListadoContratos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadoContratos_CellContentDoubleClick);
            // 
            // btnNuevoContrato
            // 
            this.btnNuevoContrato.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoContrato.Location = new System.Drawing.Point(33, 818);
            this.btnNuevoContrato.Name = "btnNuevoContrato";
            this.btnNuevoContrato.Size = new System.Drawing.Size(246, 40);
            this.btnNuevoContrato.TabIndex = 2;
            this.btnNuevoContrato.Text = "Crear nuevo contrato";
            this.btnNuevoContrato.UseVisualStyleBackColor = true;
            this.btnNuevoContrato.Click += new System.EventHandler(this.btnNuevoContrato_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(1116, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmContratosListado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1332, 880);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNuevoContrato);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmContratosListado";
            this.Text = "Listado de Contratos";
            this.Load += new System.EventHandler(this.frmContratosListado_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoContratos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvListadoContratos;
        private System.Windows.Forms.Button btnNuevoContrato;
        private System.Windows.Forms.Button button1;
    }
}