﻿namespace Tarea2_AlejandroVenegas.Formularios
{
    partial class FormProducto_Categoria
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Categoria = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._id = new System.Windows.Forms.TextBox();
            this._nombre1 = new System.Windows.Forms.TextBox();
            this._apellido1 = new System.Windows.Forms.TextBox();
            this._apellido2 = new System.Windows.Forms.TextBox();
            this._cajaAsig = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.Categoria);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 121);
            this.panel1.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(273, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Buscar producto por nombre de categoría";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nombre:";
            // 
            // Categoria
            // 
            this.Categoria.Location = new System.Drawing.Point(61, 55);
            this.Categoria.Name = "Categoria";
            this.Categoria.Size = new System.Drawing.Size(144, 20);
            this.Categoria.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(211, 53);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Black", 8F);
            this.label12.Location = new System.Drawing.Point(502, 46);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "Número de registros= ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 10F);
            this.label1.Location = new System.Drawing.Point(434, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 19);
            this.label1.TabIndex = 23;
            this.label1.Text = "Registro de productos por categoría";
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
            this.panel2.Location = new System.Drawing.Point(315, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 253);
            this.panel2.TabIndex = 22;
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
            // FormProducto_Categoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(845, 339);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProducto_Categoria";
            this.Text = "Búsqueda de productos por categoría";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Categoria;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox _id;
        private System.Windows.Forms.TextBox _nombre1;
        private System.Windows.Forms.TextBox _apellido1;
        private System.Windows.Forms.TextBox _apellido2;
        private System.Windows.Forms.TextBox _cajaAsig;
    }
}