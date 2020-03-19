namespace CopiasSeguras
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.usuarioInicio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.passInicio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.iniciar = new System.Windows.Forms.Button();
            this.registro = new System.Windows.Forms.Button();
            this.panelInicio = new System.Windows.Forms.Panel();
            this.panelRegistro = new System.Windows.Forms.Panel();
            this.registrar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.passReg2 = new System.Windows.Forms.TextBox();
            this.passReg1 = new System.Windows.Forms.TextBox();
            this.nombreRegistro = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelInicio.SuspendLayout();
            this.panelRegistro.SuspendLayout();
            this.SuspendLayout();
            // 
            // usuarioInicio
            // 
            this.usuarioInicio.Location = new System.Drawing.Point(10, 48);
            this.usuarioInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.usuarioInicio.Name = "usuarioInicio";
            this.usuarioInicio.Size = new System.Drawing.Size(157, 20);
            this.usuarioInicio.TabIndex = 2;
            this.usuarioInicio.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario";
            // 
            // passInicio
            // 
            this.passInicio.Location = new System.Drawing.Point(10, 100);
            this.passInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passInicio.Name = "passInicio";
            this.passInicio.PasswordChar = '*';
            this.passInicio.Size = new System.Drawing.Size(157, 20);
            this.passInicio.TabIndex = 4;
            this.passInicio.Tag = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña";
            // 
            // iniciar
            // 
            this.iniciar.Location = new System.Drawing.Point(10, 136);
            this.iniciar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.iniciar.Name = "iniciar";
            this.iniciar.Size = new System.Drawing.Size(56, 19);
            this.iniciar.TabIndex = 6;
            this.iniciar.Text = "Iniciar";
            this.iniciar.UseVisualStyleBackColor = true;
            this.iniciar.Click += new System.EventHandler(this.iniciar_Click);
            // 
            // registro
            // 
            this.registro.Location = new System.Drawing.Point(10, 159);
            this.registro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registro.Name = "registro";
            this.registro.Size = new System.Drawing.Size(56, 19);
            this.registro.TabIndex = 7;
            this.registro.Text = "Registro";
            this.registro.UseVisualStyleBackColor = true;
            this.registro.Click += new System.EventHandler(this.button2_Click);
            // 
            // panelInicio
            // 
            this.panelInicio.Controls.Add(this.registro);
            this.panelInicio.Controls.Add(this.iniciar);
            this.panelInicio.Controls.Add(this.label2);
            this.panelInicio.Controls.Add(this.passInicio);
            this.panelInicio.Controls.Add(this.label1);
            this.panelInicio.Controls.Add(this.usuarioInicio);
            this.panelInicio.Location = new System.Drawing.Point(20, 60);
            this.panelInicio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelInicio.Name = "panelInicio";
            this.panelInicio.Size = new System.Drawing.Size(184, 194);
            this.panelInicio.TabIndex = 8;
            // 
            // panelRegistro
            // 
            this.panelRegistro.Controls.Add(this.registrar);
            this.panelRegistro.Controls.Add(this.label5);
            this.panelRegistro.Controls.Add(this.passReg2);
            this.panelRegistro.Controls.Add(this.passReg1);
            this.panelRegistro.Controls.Add(this.nombreRegistro);
            this.panelRegistro.Controls.Add(this.label4);
            this.panelRegistro.Controls.Add(this.label3);
            this.panelRegistro.Location = new System.Drawing.Point(20, 63);
            this.panelRegistro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelRegistro.Name = "panelRegistro";
            this.panelRegistro.Size = new System.Drawing.Size(184, 201);
            this.panelRegistro.TabIndex = 9;
            this.panelRegistro.Visible = false;
            // 
            // registrar
            // 
            this.registrar.Location = new System.Drawing.Point(10, 165);
            this.registrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.registrar.Name = "registrar";
            this.registrar.Size = new System.Drawing.Size(58, 19);
            this.registrar.TabIndex = 6;
            this.registrar.Text = "Registrar";
            this.registrar.UseVisualStyleBackColor = true;
            this.registrar.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 104);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Contraseña";
            // 
            // passReg2
            // 
            this.passReg2.Location = new System.Drawing.Point(13, 142);
            this.passReg2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passReg2.Name = "passReg2";
            this.passReg2.Size = new System.Drawing.Size(98, 20);
            this.passReg2.TabIndex = 4;
            // 
            // passReg1
            // 
            this.passReg1.Location = new System.Drawing.Point(13, 119);
            this.passReg1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.passReg1.Name = "passReg1";
            this.passReg1.Size = new System.Drawing.Size(98, 20);
            this.passReg1.TabIndex = 3;
            // 
            // nombreRegistro
            // 
            this.nombreRegistro.Location = new System.Drawing.Point(15, 43);
            this.nombreRegistro.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nombreRegistro.Name = "nombreRegistro";
            this.nombreRegistro.Size = new System.Drawing.Size(98, 20);
            this.nombreRegistro.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nombre de usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Registro";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 326);
            this.Controls.Add(this.panelInicio);
            this.Controls.Add(this.panelRegistro);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Copias Seguras";
            this.panelInicio.ResumeLayout(false);
            this.panelInicio.PerformLayout();
            this.panelRegistro.ResumeLayout(false);
            this.panelRegistro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox usuarioInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox passInicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button iniciar;
        private System.Windows.Forms.Button registro;
        private System.Windows.Forms.Panel panelInicio;
        private System.Windows.Forms.Panel panelRegistro;
        private System.Windows.Forms.Button registrar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox passReg2;
        private System.Windows.Forms.TextBox passReg1;
        private System.Windows.Forms.TextBox nombreRegistro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}

