﻿namespace AdminIES
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
            this.btnCiclos = new System.Windows.Forms.Button();
            this.btnEstudiantes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCiclos
            // 
            this.btnCiclos.Location = new System.Drawing.Point(12, 12);
            this.btnCiclos.Name = "btnCiclos";
            this.btnCiclos.Size = new System.Drawing.Size(320, 318);
            this.btnCiclos.TabIndex = 0;
            this.btnCiclos.Text = "CICLOS";
            this.btnCiclos.UseVisualStyleBackColor = true;
            this.btnCiclos.Click += new System.EventHandler(this.btnCiclos_Click);
            // 
            // btnEstudiantes
            // 
            this.btnEstudiantes.Location = new System.Drawing.Point(350, 12);
            this.btnEstudiantes.Name = "btnEstudiantes";
            this.btnEstudiantes.Size = new System.Drawing.Size(336, 318);
            this.btnEstudiantes.TabIndex = 1;
            this.btnEstudiantes.Text = "ESTUDIANTES";
            this.btnEstudiantes.UseVisualStyleBackColor = true;
            this.btnEstudiantes.Click += new System.EventHandler(this.btnEstudiantes_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 342);
            this.Controls.Add(this.btnEstudiantes);
            this.Controls.Add(this.btnCiclos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCiclos;
        private System.Windows.Forms.Button btnEstudiantes;
    }
}

