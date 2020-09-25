using System;

namespace Tarea2_AlejandroVenegas.Formularios
{
    partial class FormCategoriaProductos
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
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.codigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.descripción = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._id = new System.Windows.Forms.TextBox();
            this._nombre1 = new System.Windows.Forms.TextBox();
            this._apellido1 = new System.Windows.Forms.TextBox();
            this._apellido2 = new System.Windows.Forms.TextBox();
            this._cajaAsig = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(190, 143);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Agregar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Código:";
            // 
            // codigo
            // 
            this.codigo.Location = new System.Drawing.Point(121, 37);
            this.codigo.Name = "codigo";
            this.codigo.Size = new System.Drawing.Size(144, 20);
            this.codigo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Descripción:";
            // 
            // descripción
            // 
            this.descripción.Location = new System.Drawing.Point(121, 75);
            this.descripción.Name = "descripción";
            this.descripción.Size = new System.Drawing.Size(144, 20);
            this.descripción.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nueva categoría";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.descripción);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.codigo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 184);
            this.panel1.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Black", 8F);
            this.label12.Location = new System.Drawing.Point(466, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "Número de registros= ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Black", 10F);
            this.label8.Location = new System.Drawing.Point(387, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(284, 19);
            this.label8.TabIndex = 24;
            this.label8.Text = "Registro de categorías de productos";
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this._id);
            this.panel2.Controls.Add(this._nombre1);
            this.panel2.Controls.Add(this._apellido1);
            this.panel2.Controls.Add(this._apellido2);
            this.panel2.Controls.Add(this._cajaAsig);
            this.panel2.Location = new System.Drawing.Point(439, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(219, 222);
            this.panel2.TabIndex = 23;
            // 
            // _id
            // 
            this._id.Enabled = false;
            this._id.Font = new System.Drawing.Font("Arial Black", 8F);
            this._id.Location = new System.Drawing.Point(0, 0);
            this._id.Name = "_id";
            this._id.Size = new System.Drawing.Size(100, 23);
            this._id.TabIndex = 11;
            this._id.Text = "Código";
            // 
            // _nombre1
            // 
            this._nombre1.Enabled = false;
            this._nombre1.Font = new System.Drawing.Font("Arial Black", 8F);
            this._nombre1.Location = new System.Drawing.Point(0, 0);
            this._nombre1.Name = "_nombre1";
            this._nombre1.Size = new System.Drawing.Size(100, 23);
            this._nombre1.TabIndex = 11;
            this._nombre1.Text = "Nombre";
            // 
            // _apellido1
            // 
            this._apellido1.Enabled = false;
            this._apellido1.Font = new System.Drawing.Font("Arial Black", 8F);
            this._apellido1.Location = new System.Drawing.Point(0, 0);
            this._apellido1.Name = "_apellido1";
            this._apellido1.Size = new System.Drawing.Size(100, 23);
            this._apellido1.TabIndex = 11;
            this._apellido1.Text = "Apellido 1";
            // 
            // _apellido2
            // 
            this._apellido2.Enabled = false;
            this._apellido2.Font = new System.Drawing.Font("Arial Black", 8F);
            this._apellido2.Location = new System.Drawing.Point(0, 0);
            this._apellido2.Name = "_apellido2";
            this._apellido2.Size = new System.Drawing.Size(100, 23);
            this._apellido2.TabIndex = 11;
            this._apellido2.Text = "Apellido 2";
            // 
            // _cajaAsig
            // 
            this._cajaAsig.Enabled = false;
            this._cajaAsig.Font = new System.Drawing.Font("Arial Black", 8F);
            this._cajaAsig.Location = new System.Drawing.Point(0, 0);
            this._cajaAsig.Name = "_cajaAsig";
            this._cajaAsig.Size = new System.Drawing.Size(100, 23);
            this._cajaAsig.TabIndex = 11;
            this._cajaAsig.Text = "Caja Asignada";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(348, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "Listar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormCategoriaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(694, 329);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCategoriaProductos";
            this.Text = "Mantenimiento de categorías de productos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox codigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descripción;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox _id;
        private System.Windows.Forms.TextBox _nombre1;
        private System.Windows.Forms.TextBox _apellido1;
        private System.Windows.Forms.TextBox _apellido2;
        private System.Windows.Forms.TextBox _cajaAsig;
        private System.Windows.Forms.Button button1;
    }
}