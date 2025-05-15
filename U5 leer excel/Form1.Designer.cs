namespace U5_leer_excel
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
            this.listViewLineas = new System.Windows.Forms.ListView();
            this.btnLeerArchivo = new System.Windows.Forms.Button();
            this.listViewArchivos = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listViewLineas
            // 
            this.listViewLineas.HideSelection = false;
            this.listViewLineas.Location = new System.Drawing.Point(631, 59);
            this.listViewLineas.Name = "listViewLineas";
            this.listViewLineas.Size = new System.Drawing.Size(354, 370);
            this.listViewLineas.TabIndex = 0;
            this.listViewLineas.UseCompatibleStateImageBehavior = false;
            // 
            // btnLeerArchivo
            // 
            this.btnLeerArchivo.Location = new System.Drawing.Point(58, 59);
            this.btnLeerArchivo.Name = "btnLeerArchivo";
            this.btnLeerArchivo.Size = new System.Drawing.Size(131, 61);
            this.btnLeerArchivo.TabIndex = 1;
            this.btnLeerArchivo.Text = "Leer Archivo";
            this.btnLeerArchivo.UseVisualStyleBackColor = true;
            this.btnLeerArchivo.Click += new System.EventHandler(this.btnLeerArchivo_Click_1);
            // 
            // listViewArchivos
            // 
            this.listViewArchivos.HideSelection = false;
            this.listViewArchivos.Location = new System.Drawing.Point(230, 59);
            this.listViewArchivos.Name = "listViewArchivos";
            this.listViewArchivos.Size = new System.Drawing.Size(354, 370);
            this.listViewArchivos.TabIndex = 2;
            this.listViewArchivos.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 450);
            this.Controls.Add(this.listViewArchivos);
            this.Controls.Add(this.btnLeerArchivo);
            this.Controls.Add(this.listViewLineas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewLineas;
        private System.Windows.Forms.Button btnLeerArchivo;
        private System.Windows.Forms.ListView listViewArchivos;
    }
}

