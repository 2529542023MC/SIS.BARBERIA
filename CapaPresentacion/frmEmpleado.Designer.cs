namespace CapaPresentacion
{
    partial class frmEmpleado
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
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInsertar_Click = new System.Windows.Forms.Button();
            this.eliminar_Click = new System.Windows.Forms.Button();
            this.btnModificar_Click = new System.Windows.Forms.Button();
            this.btnConectar_Click = new System.Windows.Forms.Button();
            this.textId_Consulta = new System.Windows.Forms.TextBox();
            this.btnDesactivar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(7, 7);
            this.dgvDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(745, 523);
            this.dgvDatos.TabIndex = 0;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(797, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ingrese el ID a Consultar";
            // 
            // btnInsertar_Click
            // 
            this.btnInsertar_Click.Location = new System.Drawing.Point(769, 226);
            this.btnInsertar_Click.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInsertar_Click.Name = "btnInsertar_Click";
            this.btnInsertar_Click.Size = new System.Drawing.Size(219, 68);
            this.btnInsertar_Click.TabIndex = 3;
            this.btnInsertar_Click.Text = "Insertar";
            this.btnInsertar_Click.UseVisualStyleBackColor = true;
            this.btnInsertar_Click.Click += new System.EventHandler(this.button1_Click);
            // 
            // eliminar_Click
            // 
            this.eliminar_Click.Location = new System.Drawing.Point(768, 442);
            this.eliminar_Click.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.eliminar_Click.Name = "eliminar_Click";
            this.eliminar_Click.Size = new System.Drawing.Size(219, 64);
            this.eliminar_Click.TabIndex = 4;
            this.eliminar_Click.Text = "Eliminar de Base de datos";
            this.eliminar_Click.UseVisualStyleBackColor = true;
            this.eliminar_Click.Click += new System.EventHandler(this.eliminar_Click_Click);
            // 
            // btnModificar_Click
            // 
            this.btnModificar_Click.Location = new System.Drawing.Point(768, 299);
            this.btnModificar_Click.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnModificar_Click.Name = "btnModificar_Click";
            this.btnModificar_Click.Size = new System.Drawing.Size(219, 62);
            this.btnModificar_Click.TabIndex = 5;
            this.btnModificar_Click.Text = "Modificar";
            this.btnModificar_Click.UseVisualStyleBackColor = true;
            this.btnModificar_Click.Click += new System.EventHandler(this.btnModificar_Click_Click);
            // 
            // btnConectar_Click
            // 
            this.btnConectar_Click.Location = new System.Drawing.Point(769, 86);
            this.btnConectar_Click.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConectar_Click.Name = "btnConectar_Click";
            this.btnConectar_Click.Size = new System.Drawing.Size(219, 66);
            this.btnConectar_Click.TabIndex = 6;
            this.btnConectar_Click.Text = "Consultar solo el ID ingresdado";
            this.btnConectar_Click.UseVisualStyleBackColor = true;
            this.btnConectar_Click.Click += new System.EventHandler(this.button4_Click);
            // 
            // textId_Consulta
            // 
            this.textId_Consulta.Location = new System.Drawing.Point(768, 30);
            this.textId_Consulta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textId_Consulta.Name = "textId_Consulta";
            this.textId_Consulta.Size = new System.Drawing.Size(219, 22);
            this.textId_Consulta.TabIndex = 7;
            // 
            // btnDesactivar
            // 
            this.btnDesactivar.Location = new System.Drawing.Point(768, 366);
            this.btnDesactivar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDesactivar.Name = "btnDesactivar";
            this.btnDesactivar.Size = new System.Drawing.Size(100, 70);
            this.btnDesactivar.TabIndex = 8;
            this.btnDesactivar.Text = "Desactivar";
            this.btnDesactivar.UseVisualStyleBackColor = true;
            this.btnDesactivar.Click += new System.EventHandler(this.btnDesactivar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textId_Consulta);
            this.groupBox1.Controls.Add(this.btnDesactivar);
            this.groupBox1.Controls.Add(this.btnConectar_Click);
            this.groupBox1.Controls.Add(this.dgvDatos);
            this.groupBox1.Controls.Add(this.btnInsertar_Click);
            this.groupBox1.Controls.Add(this.btnModificar_Click);
            this.groupBox1.Controls.Add(this.eliminar_Click);
            this.groupBox1.Location = new System.Drawing.Point(-3, -2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(1061, 569);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(768, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(196, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Seleccione la accion a Realizar";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(886, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 69);
            this.button1.TabIndex = 10;
            this.button1.Text = "Activar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // frmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 539);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEmpleado";
            this.Text = "EMPLEADO";
            this.Load += new System.EventHandler(this.frmEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInsertar_Click;
        private System.Windows.Forms.Button eliminar_Click;
        private System.Windows.Forms.Button btnModificar_Click;
        private System.Windows.Forms.Button btnConectar_Click;
        private System.Windows.Forms.TextBox textId_Consulta;
        private System.Windows.Forms.Button btnDesactivar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}