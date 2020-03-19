namespace CopiasSeguras
{
    partial class Form2
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cifra = new System.Windows.Forms.Button();
            this.SlecArchivoButton = new System.Windows.Forms.Button();
            this.ArchivoaCifrar = new System.Windows.Forms.TextBox();
            this.SelccionaArchivo = new System.Windows.Forms.Label();
            this.SeleccionaCifrado = new System.Windows.Forms.Label();
            this.Cifrar = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.descargar = new System.Windows.Forms.Button();
            this.SelecDescButton = new System.Windows.Forms.Button();
            this.rutaDesc = new System.Windows.Forms.TextBox();
            this.RutaDescarga = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.ArchivoRecuperar = new System.Windows.Forms.Label();
            this.RecuperarArchivo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 84);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cifra);
            this.panel1.Controls.Add(this.SlecArchivoButton);
            this.panel1.Controls.Add(this.ArchivoaCifrar);
            this.panel1.Controls.Add(this.SelccionaArchivo);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.SeleccionaCifrado);
            this.panel1.Controls.Add(this.Cifrar);
            this.panel1.Location = new System.Drawing.Point(435, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(353, 403);
            this.panel1.TabIndex = 1;
            // 
            // cifra
            // 
            this.cifra.Location = new System.Drawing.Point(91, 196);
            this.cifra.Name = "cifra";
            this.cifra.Size = new System.Drawing.Size(75, 23);
            this.cifra.TabIndex = 5;
            this.cifra.Text = "Cifrar";
            this.cifra.UseVisualStyleBackColor = true;
            this.cifra.Click += new System.EventHandler(this.cifra_Click);
            // 
            // SlecArchivoButton
            // 
            this.SlecArchivoButton.Location = new System.Drawing.Point(9, 196);
            this.SlecArchivoButton.Name = "SlecArchivoButton";
            this.SlecArchivoButton.Size = new System.Drawing.Size(75, 23);
            this.SlecArchivoButton.TabIndex = 4;
            this.SlecArchivoButton.Text = "Explorar Carpetas";
            this.SlecArchivoButton.UseVisualStyleBackColor = true;
            this.SlecArchivoButton.Click += new System.EventHandler(this.SlecArchivoButton_Click);
            // 
            // ArchivoaCifrar
            // 
            this.ArchivoaCifrar.Location = new System.Drawing.Point(9, 169);
            this.ArchivoaCifrar.Name = "ArchivoaCifrar";
            this.ArchivoaCifrar.Size = new System.Drawing.Size(306, 20);
            this.ArchivoaCifrar.TabIndex = 3;
            // 
            // SelccionaArchivo
            // 
            this.SelccionaArchivo.AutoSize = true;
            this.SelccionaArchivo.Location = new System.Drawing.Point(6, 153);
            this.SelccionaArchivo.Name = "SelccionaArchivo";
            this.SelccionaArchivo.Size = new System.Drawing.Size(104, 13);
            this.SelccionaArchivo.TabIndex = 2;
            this.SelccionaArchivo.Text = "Selcciona el Archivo";
            // 
            // SeleccionaCifrado
            // 
            this.SeleccionaCifrado.AutoSize = true;
            this.SeleccionaCifrado.Location = new System.Drawing.Point(6, 68);
            this.SeleccionaCifrado.Name = "SeleccionaCifrado";
            this.SeleccionaCifrado.Size = new System.Drawing.Size(127, 13);
            this.SeleccionaCifrado.TabIndex = 1;
            this.SeleccionaCifrado.Text = "Selecciona el tipo Cifrado";
            // 
            // Cifrar
            // 
            this.Cifrar.AutoSize = true;
            this.Cifrar.Location = new System.Drawing.Point(3, 17);
            this.Cifrar.Name = "Cifrar";
            this.Cifrar.Size = new System.Drawing.Size(31, 13);
            this.Cifrar.TabIndex = 0;
            this.Cifrar.Text = "Cifrar";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.descargar);
            this.panel2.Controls.Add(this.SelecDescButton);
            this.panel2.Controls.Add(this.rutaDesc);
            this.panel2.Controls.Add(this.RutaDescarga);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.ArchivoRecuperar);
            this.panel2.Controls.Add(this.RecuperarArchivo);
            this.panel2.Location = new System.Drawing.Point(12, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 403);
            this.panel2.TabIndex = 4;
            // 
            // descargar
            // 
            this.descargar.Location = new System.Drawing.Point(90, 191);
            this.descargar.Name = "descargar";
            this.descargar.Size = new System.Drawing.Size(75, 23);
            this.descargar.TabIndex = 5;
            this.descargar.Text = "Descargar";
            this.descargar.UseVisualStyleBackColor = true;
            // 
            // SelecDescButton
            // 
            this.SelecDescButton.Location = new System.Drawing.Point(9, 191);
            this.SelecDescButton.Name = "SelecDescButton";
            this.SelecDescButton.Size = new System.Drawing.Size(75, 23);
            this.SelecDescButton.TabIndex = 4;
            this.SelecDescButton.Text = "Explorar Carpetas";
            this.SelecDescButton.UseVisualStyleBackColor = true;
            this.SelecDescButton.Click += new System.EventHandler(this.SelecDescButton_Click);
            // 
            // rutaDesc
            // 
            this.rutaDesc.Location = new System.Drawing.Point(9, 165);
            this.rutaDesc.Name = "rutaDesc";
            this.rutaDesc.Size = new System.Drawing.Size(306, 20);
            this.rutaDesc.TabIndex = 3;
            // 
            // RutaDescarga
            // 
            this.RutaDescarga.AutoSize = true;
            this.RutaDescarga.Location = new System.Drawing.Point(6, 149);
            this.RutaDescarga.Name = "RutaDescarga";
            this.RutaDescarga.Size = new System.Drawing.Size(150, 13);
            this.RutaDescarga.TabIndex = 2;
            this.RutaDescarga.Text = "Selcciona la ruta de Descarga";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 80);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // ArchivoRecuperar
            // 
            this.ArchivoRecuperar.AutoSize = true;
            this.ArchivoRecuperar.Location = new System.Drawing.Point(6, 64);
            this.ArchivoRecuperar.Name = "ArchivoRecuperar";
            this.ArchivoRecuperar.Size = new System.Drawing.Size(110, 13);
            this.ArchivoRecuperar.TabIndex = 1;
            this.ArchivoRecuperar.Text = "Selecciona el Archivo";
            // 
            // RecuperarArchivo
            // 
            this.RecuperarArchivo.AutoSize = true;
            this.RecuperarArchivo.Location = new System.Drawing.Point(3, 13);
            this.RecuperarArchivo.Name = "RecuperarArchivo";
            this.RecuperarArchivo.Size = new System.Drawing.Size(96, 13);
            this.RecuperarArchivo.TabIndex = 0;
            this.RecuperarArchivo.Text = "Recuperar Archivo";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SelccionaArchivo;
        private System.Windows.Forms.Label SeleccionaCifrado;
        private System.Windows.Forms.Label Cifrar;
        private System.Windows.Forms.TextBox ArchivoaCifrar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox rutaDesc;
        private System.Windows.Forms.Label RutaDescarga;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label ArchivoRecuperar;
        private System.Windows.Forms.Label RecuperarArchivo;
        private System.Windows.Forms.Button SlecArchivoButton;
        private System.Windows.Forms.Button SelecDescButton;
        private System.Windows.Forms.Button cifra;
        private System.Windows.Forms.Button descargar;
    }
}