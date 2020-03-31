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
            this.panelCifrado = new System.Windows.Forms.Panel();
            this.botonEncriptar = new System.Windows.Forms.Button();
            this.SlecArchivoCif = new System.Windows.Forms.Button();
            this.ArchivoaCifrar = new System.Windows.Forms.TextBox();
            this.SelccionaArchivo = new System.Windows.Forms.Label();
            this.SeleccionaCifrado = new System.Windows.Forms.Label();
            this.EncriptarTitulo = new System.Windows.Forms.Label();
            this.panelDescarga = new System.Windows.Forms.Panel();
            this.descargar = new System.Windows.Forms.Button();
            this.SelecDescButton = new System.Windows.Forms.Button();
            this.rutaDesc = new System.Windows.Forms.TextBox();
            this.RutaDescarga = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.ArchivoRecuperar = new System.Windows.Forms.Label();
            this.RecuperarArchivo = new System.Windows.Forms.Label();
            this.botonMenuCifra = new System.Windows.Forms.Button();
            this.botonMenuDescifra = new System.Windows.Forms.Button();
            this.botonMenuDescarga = new System.Windows.Forms.Button();
            this.panelDesencriptado = new System.Windows.Forms.Panel();
            this.botonDesencriptar = new System.Windows.Forms.Button();
            this.SlecArchicvoDesc = new System.Windows.Forms.Button();
            this.ArchivoaDescifrar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DesencriptarTitulo = new System.Windows.Forms.Label();
            this.panelCifrado.SuspendLayout();
            this.panelDescarga.SuspendLayout();
            this.panelDesencriptado.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(9, 84);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // panelCifrado
            // 
            this.panelCifrado.Controls.Add(this.botonEncriptar);
            this.panelCifrado.Controls.Add(this.SlecArchivoCif);
            this.panelCifrado.Controls.Add(this.ArchivoaCifrar);
            this.panelCifrado.Controls.Add(this.SelccionaArchivo);
            this.panelCifrado.Controls.Add(this.comboBox1);
            this.panelCifrado.Controls.Add(this.SeleccionaCifrado);
            this.panelCifrado.Controls.Add(this.EncriptarTitulo);
            this.panelCifrado.Location = new System.Drawing.Point(491, 29);
            this.panelCifrado.Name = "panelCifrado";
            this.panelCifrado.Size = new System.Drawing.Size(356, 406);
            this.panelCifrado.TabIndex = 1;
            // 
            // botonEncriptar
            // 
            this.botonEncriptar.Location = new System.Drawing.Point(91, 196);
            this.botonEncriptar.Name = "botonEncriptar";
            this.botonEncriptar.Size = new System.Drawing.Size(75, 23);
            this.botonEncriptar.TabIndex = 5;
            this.botonEncriptar.Text = "Encriptar";
            this.botonEncriptar.UseVisualStyleBackColor = true;
            this.botonEncriptar.Click += new System.EventHandler(this.botonEncriptar_Click);
            // 
            // SlecArchivoCif
            // 
            this.SlecArchivoCif.Location = new System.Drawing.Point(9, 196);
            this.SlecArchivoCif.Name = "SlecArchivoCif";
            this.SlecArchivoCif.Size = new System.Drawing.Size(75, 23);
            this.SlecArchivoCif.TabIndex = 4;
            this.SlecArchivoCif.Text = "Explorar Carpetas";
            this.SlecArchivoCif.UseVisualStyleBackColor = true;
            this.SlecArchivoCif.Click += new System.EventHandler(this.SlecArchivoButton_Click);
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
            // EncriptarTitulo
            // 
            this.EncriptarTitulo.AutoSize = true;
            this.EncriptarTitulo.Location = new System.Drawing.Point(6, 17);
            this.EncriptarTitulo.Name = "EncriptarTitulo";
            this.EncriptarTitulo.Size = new System.Drawing.Size(49, 13);
            this.EncriptarTitulo.TabIndex = 0;
            this.EncriptarTitulo.Text = "Encriptar";
            // 
            // panelDescarga
            // 
            this.panelDescarga.Controls.Add(this.descargar);
            this.panelDescarga.Controls.Add(this.SelecDescButton);
            this.panelDescarga.Controls.Add(this.rutaDesc);
            this.panelDescarga.Controls.Add(this.RutaDescarga);
            this.panelDescarga.Controls.Add(this.comboBox2);
            this.panelDescarga.Controls.Add(this.ArchivoRecuperar);
            this.panelDescarga.Controls.Add(this.RecuperarArchivo);
            this.panelDescarga.Location = new System.Drawing.Point(853, 29);
            this.panelDescarga.Name = "panelDescarga";
            this.panelDescarga.Size = new System.Drawing.Size(356, 406);
            this.panelDescarga.TabIndex = 4;
            this.panelDescarga.Visible = false;
            // 
            // descargar
            // 
            this.descargar.Location = new System.Drawing.Point(90, 196);
            this.descargar.Name = "descargar";
            this.descargar.Size = new System.Drawing.Size(75, 23);
            this.descargar.TabIndex = 5;
            this.descargar.Text = "Descargar";
            this.descargar.UseVisualStyleBackColor = true;
            // 
            // SelecDescButton
            // 
            this.SelecDescButton.Location = new System.Drawing.Point(9, 196);
            this.SelecDescButton.Name = "SelecDescButton";
            this.SelecDescButton.Size = new System.Drawing.Size(75, 23);
            this.SelecDescButton.TabIndex = 4;
            this.SelecDescButton.Text = "Explorar Carpetas";
            this.SelecDescButton.UseVisualStyleBackColor = true;
            this.SelecDescButton.Click += new System.EventHandler(this.SelecDescButton_Click);
            // 
            // rutaDesc
            // 
            this.rutaDesc.Location = new System.Drawing.Point(9, 169);
            this.rutaDesc.Name = "rutaDesc";
            this.rutaDesc.Size = new System.Drawing.Size(306, 20);
            this.rutaDesc.TabIndex = 3;
            // 
            // RutaDescarga
            // 
            this.RutaDescarga.AutoSize = true;
            this.RutaDescarga.Location = new System.Drawing.Point(6, 153);
            this.RutaDescarga.Name = "RutaDescarga";
            this.RutaDescarga.Size = new System.Drawing.Size(150, 13);
            this.RutaDescarga.TabIndex = 2;
            this.RutaDescarga.Text = "Selcciona la ruta de Descarga";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(9, 84);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // ArchivoRecuperar
            // 
            this.ArchivoRecuperar.AutoSize = true;
            this.ArchivoRecuperar.Location = new System.Drawing.Point(6, 68);
            this.ArchivoRecuperar.Name = "ArchivoRecuperar";
            this.ArchivoRecuperar.Size = new System.Drawing.Size(110, 13);
            this.ArchivoRecuperar.TabIndex = 1;
            this.ArchivoRecuperar.Text = "Selecciona el Archivo";
            // 
            // RecuperarArchivo
            // 
            this.RecuperarArchivo.AutoSize = true;
            this.RecuperarArchivo.Location = new System.Drawing.Point(6, 17);
            this.RecuperarArchivo.Name = "RecuperarArchivo";
            this.RecuperarArchivo.Size = new System.Drawing.Size(96, 13);
            this.RecuperarArchivo.TabIndex = 0;
            this.RecuperarArchivo.Text = "Recuperar Archivo";
            // 
            // botonMenuCifra
            // 
            this.botonMenuCifra.Location = new System.Drawing.Point(13, 29);
            this.botonMenuCifra.Name = "botonMenuCifra";
            this.botonMenuCifra.Size = new System.Drawing.Size(75, 23);
            this.botonMenuCifra.TabIndex = 2;
            this.botonMenuCifra.Text = "Encriptado";
            this.botonMenuCifra.UseVisualStyleBackColor = true;
            this.botonMenuCifra.Click += new System.EventHandler(this.botonMenuCifra_Click);
            // 
            // botonMenuDescifra
            // 
            this.botonMenuDescifra.Location = new System.Drawing.Point(13, 59);
            this.botonMenuDescifra.Name = "botonMenuDescifra";
            this.botonMenuDescifra.Size = new System.Drawing.Size(75, 23);
            this.botonMenuDescifra.TabIndex = 3;
            this.botonMenuDescifra.Text = "Desencriptado";
            this.botonMenuDescifra.UseVisualStyleBackColor = true;
            this.botonMenuDescifra.Click += new System.EventHandler(this.botonMenuDescifra_Click);
            // 
            // botonMenuDescarga
            // 
            this.botonMenuDescarga.Location = new System.Drawing.Point(13, 93);
            this.botonMenuDescarga.Name = "botonMenuDescarga";
            this.botonMenuDescarga.Size = new System.Drawing.Size(75, 23);
            this.botonMenuDescarga.TabIndex = 4;
            this.botonMenuDescarga.Text = "Descargar Archivos";
            this.botonMenuDescarga.UseVisualStyleBackColor = true;
            this.botonMenuDescarga.Click += new System.EventHandler(this.botonMenuDescarga_Click);
            // 
            // panelDesencriptado
            // 
            this.panelDesencriptado.Controls.Add(this.botonDesencriptar);
            this.panelDesencriptado.Controls.Add(this.SlecArchicvoDesc);
            this.panelDesencriptado.Controls.Add(this.ArchivoaDescifrar);
            this.panelDesencriptado.Controls.Add(this.label1);
            this.panelDesencriptado.Controls.Add(this.comboBox3);
            this.panelDesencriptado.Controls.Add(this.label2);
            this.panelDesencriptado.Controls.Add(this.DesencriptarTitulo);
            this.panelDesencriptado.Location = new System.Drawing.Point(129, 29);
            this.panelDesencriptado.Name = "panelDesencriptado";
            this.panelDesencriptado.Size = new System.Drawing.Size(356, 406);
            this.panelDesencriptado.TabIndex = 6;
            this.panelDesencriptado.Visible = false;
            // 
            // botonDesencriptar
            // 
            this.botonDesencriptar.Location = new System.Drawing.Point(91, 196);
            this.botonDesencriptar.Name = "botonDesencriptar";
            this.botonDesencriptar.Size = new System.Drawing.Size(75, 23);
            this.botonDesencriptar.TabIndex = 5;
            this.botonDesencriptar.Text = "Desencriptar";
            this.botonDesencriptar.UseVisualStyleBackColor = true;
            this.botonDesencriptar.Click += new System.EventHandler(this.botonDesencriptar_Click);
            // 
            // SlecArchicvoDesc
            // 
            this.SlecArchicvoDesc.Location = new System.Drawing.Point(9, 196);
            this.SlecArchicvoDesc.Name = "SlecArchicvoDesc";
            this.SlecArchicvoDesc.Size = new System.Drawing.Size(75, 23);
            this.SlecArchicvoDesc.TabIndex = 4;
            this.SlecArchicvoDesc.Text = "Explorar Carpetas";
            this.SlecArchicvoDesc.UseVisualStyleBackColor = true;
            this.SlecArchicvoDesc.Click += new System.EventHandler(this.SlecArchicvoDesc_Click);
            // 
            // ArchivoaDescifrar
            // 
            this.ArchivoaDescifrar.Location = new System.Drawing.Point(9, 169);
            this.ArchivoaDescifrar.Name = "ArchivoaDescifrar";
            this.ArchivoaDescifrar.Size = new System.Drawing.Size(306, 20);
            this.ArchivoaDescifrar.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selcciona el Archivo";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(9, 84);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Selecciona el tipo Cifrado";
            // 
            // DesencriptarTitulo
            // 
            this.DesencriptarTitulo.AutoSize = true;
            this.DesencriptarTitulo.Location = new System.Drawing.Point(6, 17);
            this.DesencriptarTitulo.Name = "DesencriptarTitulo";
            this.DesencriptarTitulo.Size = new System.Drawing.Size(67, 13);
            this.DesencriptarTitulo.TabIndex = 0;
            this.DesencriptarTitulo.Text = "Desencriptar";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 450);
            this.Controls.Add(this.panelDesencriptado);
            this.Controls.Add(this.panelCifrado);
            this.Controls.Add(this.panelDescarga);
            this.Controls.Add(this.botonMenuDescarga);
            this.Controls.Add(this.botonMenuDescifra);
            this.Controls.Add(this.botonMenuCifra);
            this.Name = "Form2";
            this.Text = "Form2";
            this.panelCifrado.ResumeLayout(false);
            this.panelCifrado.PerformLayout();
            this.panelDescarga.ResumeLayout(false);
            this.panelDescarga.PerformLayout();
            this.panelDesencriptado.ResumeLayout(false);
            this.panelDesencriptado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panelCifrado;
        private System.Windows.Forms.Label SelccionaArchivo;
        private System.Windows.Forms.Label SeleccionaCifrado;
        private System.Windows.Forms.Label EncriptarTitulo;
        private System.Windows.Forms.TextBox ArchivoaCifrar;
        private System.Windows.Forms.Panel panelDescarga;
        private System.Windows.Forms.TextBox rutaDesc;
        private System.Windows.Forms.Label RutaDescarga;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label ArchivoRecuperar;
        private System.Windows.Forms.Label RecuperarArchivo;
        private System.Windows.Forms.Button SlecArchivoCif;
        private System.Windows.Forms.Button SelecDescButton;
        private System.Windows.Forms.Button botonEncriptar;
        private System.Windows.Forms.Button descargar;
        private System.Windows.Forms.Button botonMenuCifra;
        private System.Windows.Forms.Button botonMenuDescifra;
        private System.Windows.Forms.Button botonMenuDescarga;
        private System.Windows.Forms.Panel panelDesencriptado;
        private System.Windows.Forms.Button botonDesencriptar;
        private System.Windows.Forms.Button SlecArchicvoDesc;
        private System.Windows.Forms.TextBox ArchivoaDescifrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DesencriptarTitulo;
    }
}