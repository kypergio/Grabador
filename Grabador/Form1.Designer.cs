namespace Grabador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tbAlumnos = new System.Windows.Forms.TabPage();
            this.txtIdTarjetaAlumno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMatricula = new System.Windows.Forms.MaskedTextBox();
            this.txtNombreAlumno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellidoMaternoAlumno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtApellidoPaternoAlumno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmpleados = new System.Windows.Forms.TabPage();
            this.txtIdTarjetaEmpleado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIssemym = new System.Windows.Forms.MaskedTextBox();
            this.txtNombreEmpleado = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtApellidoMaternoEmpleado = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtApellidoPaternoEmpleado = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbConexion = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.ajustesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaCiclos = new System.Windows.Forms.ToolStripComboBox();
            this.tbMain.SuspendLayout();
            this.tbAlumnos.SuspendLayout();
            this.tbEmpleados.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tbAlumnos);
            this.tbMain.Controls.Add(this.tbEmpleados);
            this.tbMain.Location = new System.Drawing.Point(0, 0);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(331, 275);
            this.tbMain.TabIndex = 0;
            this.tbMain.SelectedIndexChanged += new System.EventHandler(this.@__CambiarTab);
            // 
            // tbAlumnos
            // 
            this.tbAlumnos.Controls.Add(this.txtIdTarjetaAlumno);
            this.tbAlumnos.Controls.Add(this.label5);
            this.tbAlumnos.Controls.Add(this.txtMatricula);
            this.tbAlumnos.Controls.Add(this.txtNombreAlumno);
            this.tbAlumnos.Controls.Add(this.label4);
            this.tbAlumnos.Controls.Add(this.txtApellidoMaternoAlumno);
            this.tbAlumnos.Controls.Add(this.label3);
            this.tbAlumnos.Controls.Add(this.txtApellidoPaternoAlumno);
            this.tbAlumnos.Controls.Add(this.label2);
            this.tbAlumnos.Controls.Add(this.label1);
            this.tbAlumnos.Location = new System.Drawing.Point(4, 22);
            this.tbAlumnos.Name = "tbAlumnos";
            this.tbAlumnos.Padding = new System.Windows.Forms.Padding(3);
            this.tbAlumnos.Size = new System.Drawing.Size(323, 249);
            this.tbAlumnos.TabIndex = 0;
            this.tbAlumnos.Text = "Alumnos";
            this.tbAlumnos.UseVisualStyleBackColor = true;
            // 
            // txtIdTarjetaAlumno
            // 
            this.txtIdTarjetaAlumno.Location = new System.Drawing.Point(96, 109);
            this.txtIdTarjetaAlumno.Name = "txtIdTarjetaAlumno";
            this.txtIdTarjetaAlumno.ReadOnly = true;
            this.txtIdTarjetaAlumno.Size = new System.Drawing.Size(219, 20);
            this.txtIdTarjetaAlumno.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "ID Tarjeta";
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(96, 5);
            this.txtMatricula.Mask = "99999999999";
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(219, 20);
            this.txtMatricula.TabIndex = 0;
            this.txtMatricula.KeyDown += new System.Windows.Forms.KeyEventHandler(this._PresionarTecla);
            // 
            // txtNombreAlumno
            // 
            this.txtNombreAlumno.Location = new System.Drawing.Point(96, 84);
            this.txtNombreAlumno.Name = "txtNombreAlumno";
            this.txtNombreAlumno.ReadOnly = true;
            this.txtNombreAlumno.Size = new System.Drawing.Size(219, 20);
            this.txtNombreAlumno.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombre(s)";
            // 
            // txtApellidoMaternoAlumno
            // 
            this.txtApellidoMaternoAlumno.Location = new System.Drawing.Point(96, 59);
            this.txtApellidoMaternoAlumno.Name = "txtApellidoMaternoAlumno";
            this.txtApellidoMaternoAlumno.ReadOnly = true;
            this.txtApellidoMaternoAlumno.Size = new System.Drawing.Size(219, 20);
            this.txtApellidoMaternoAlumno.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apellido Materno";
            // 
            // txtApellidoPaternoAlumno
            // 
            this.txtApellidoPaternoAlumno.Location = new System.Drawing.Point(96, 32);
            this.txtApellidoPaternoAlumno.Name = "txtApellidoPaternoAlumno";
            this.txtApellidoPaternoAlumno.ReadOnly = true;
            this.txtApellidoPaternoAlumno.Size = new System.Drawing.Size(219, 20);
            this.txtApellidoPaternoAlumno.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido Paterno";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Matrícula";
            // 
            // tbEmpleados
            // 
            this.tbEmpleados.Controls.Add(this.txtIdTarjetaEmpleado);
            this.tbEmpleados.Controls.Add(this.label6);
            this.tbEmpleados.Controls.Add(this.txtIssemym);
            this.tbEmpleados.Controls.Add(this.txtNombreEmpleado);
            this.tbEmpleados.Controls.Add(this.label7);
            this.tbEmpleados.Controls.Add(this.txtApellidoMaternoEmpleado);
            this.tbEmpleados.Controls.Add(this.label8);
            this.tbEmpleados.Controls.Add(this.txtApellidoPaternoEmpleado);
            this.tbEmpleados.Controls.Add(this.label9);
            this.tbEmpleados.Controls.Add(this.label10);
            this.tbEmpleados.Location = new System.Drawing.Point(4, 22);
            this.tbEmpleados.Name = "tbEmpleados";
            this.tbEmpleados.Padding = new System.Windows.Forms.Padding(3);
            this.tbEmpleados.Size = new System.Drawing.Size(323, 249);
            this.tbEmpleados.TabIndex = 1;
            this.tbEmpleados.Text = "Empleados";
            this.tbEmpleados.UseVisualStyleBackColor = true;
            // 
            // txtIdTarjetaEmpleado
            // 
            this.txtIdTarjetaEmpleado.Location = new System.Drawing.Point(96, 109);
            this.txtIdTarjetaEmpleado.Name = "txtIdTarjetaEmpleado";
            this.txtIdTarjetaEmpleado.ReadOnly = true;
            this.txtIdTarjetaEmpleado.Size = new System.Drawing.Size(219, 20);
            this.txtIdTarjetaEmpleado.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "ID Tarjeta";
            // 
            // txtIssemym
            // 
            this.txtIssemym.Location = new System.Drawing.Point(96, 5);
            this.txtIssemym.Mask = "99999999999";
            this.txtIssemym.Name = "txtIssemym";
            this.txtIssemym.Size = new System.Drawing.Size(219, 20);
            this.txtIssemym.TabIndex = 10;
            this.txtIssemym.KeyDown += new System.Windows.Forms.KeyEventHandler(this._PresionarTecla);
            // 
            // txtNombreEmpleado
            // 
            this.txtNombreEmpleado.Location = new System.Drawing.Point(96, 84);
            this.txtNombreEmpleado.Name = "txtNombreEmpleado";
            this.txtNombreEmpleado.ReadOnly = true;
            this.txtNombreEmpleado.Size = new System.Drawing.Size(219, 20);
            this.txtNombreEmpleado.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Nombre(s)";
            // 
            // txtApellidoMaternoEmpleado
            // 
            this.txtApellidoMaternoEmpleado.Location = new System.Drawing.Point(96, 59);
            this.txtApellidoMaternoEmpleado.Name = "txtApellidoMaternoEmpleado";
            this.txtApellidoMaternoEmpleado.ReadOnly = true;
            this.txtApellidoMaternoEmpleado.Size = new System.Drawing.Size(219, 20);
            this.txtApellidoMaternoEmpleado.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Apellido Materno";
            // 
            // txtApellidoPaternoEmpleado
            // 
            this.txtApellidoPaternoEmpleado.Location = new System.Drawing.Point(96, 32);
            this.txtApellidoPaternoEmpleado.Name = "txtApellidoPaternoEmpleado";
            this.txtApellidoPaternoEmpleado.ReadOnly = true;
            this.txtApellidoPaternoEmpleado.Size = new System.Drawing.Size(219, 20);
            this.txtApellidoPaternoEmpleado.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Apellido Paterno";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "ISSEMYM";
            // 
            // btnGrabar
            // 
            this.btnGrabar.Enabled = false;
            this.btnGrabar.Location = new System.Drawing.Point(2, 277);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 1;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.@__Grabar);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbConexion,
            this.lbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 308);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(331, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbConexion
            // 
            this.lbConexion.BackColor = System.Drawing.Color.Red;
            this.lbConexion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lbConexion.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.lbConexion.Name = "lbConexion";
            this.lbConexion.Size = new System.Drawing.Size(38, 17);
            this.lbConexion.Text = "COM10";
            // 
            // lbStatus
            // 
            this.lbStatus.BackColor = System.Drawing.Color.GreenYellow;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(150, 17);
            this.lbStatus.Text = "Puede comenzar a Grabar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(83, 277);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.@__CancelarGrabacion);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajustesToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(331, 24);
            this.menu.TabIndex = 4;
            this.menu.Text = "menuStrip1";
            // 
            // ajustesToolStripMenuItem
            // 
            this.ajustesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listaCiclos});
            this.ajustesToolStripMenuItem.Name = "ajustesToolStripMenuItem";
            this.ajustesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.ajustesToolStripMenuItem.Text = "Ajustes";
            // 
            // listaCiclos
            // 
            this.listaCiclos.Name = "listaCiclos";
            this.listaCiclos.Size = new System.Drawing.Size(121, 23);
            this.listaCiclos.Text = "Ciclo Escolar";
            this.listaCiclos.SelectedIndexChanged += new System.EventHandler(this.@__CambioCiclo);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 330);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.tbMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grabador de Credenciales Escolares";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.@__CerrandoFormulario);
            this.Load += new System.EventHandler(this.@__CargarFormulario);
            this.tbMain.ResumeLayout(false);
            this.tbAlumnos.ResumeLayout(false);
            this.tbAlumnos.PerformLayout();
            this.tbEmpleados.ResumeLayout(false);
            this.tbEmpleados.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tbAlumnos;
        private System.Windows.Forms.TabPage tbEmpleados;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellidoPaternoAlumno;
        private System.Windows.Forms.TextBox txtNombreAlumno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellidoMaternoAlumno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtMatricula;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbConexion;
        private System.Windows.Forms.TextBox txtIdTarjetaAlumno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIdTarjetaEmpleado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtIssemym;
        private System.Windows.Forms.TextBox txtNombreEmpleado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtApellidoMaternoEmpleado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtApellidoPaternoEmpleado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem ajustesToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox listaCiclos;
    }
}

