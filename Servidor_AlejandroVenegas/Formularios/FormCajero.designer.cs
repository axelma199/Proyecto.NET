using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tarea2_AlejandroVenegas.Formularios
{
    partial class FormCajero
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
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this._id = new System.Windows.Forms.TextBox();
            this._nombre1 = new System.Windows.Forms.TextBox();
            this._apellido1 = new System.Windows.Forms.TextBox();
            this._apellido2 = new System.Windows.Forms.TextBox();
            this._cajaAsig = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IdAprobar = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cajaAsig = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Black", 10F);
            this.label7.Location = new System.Drawing.Point(491, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Registro de cajeros";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Listar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Black", 9F);
            this.label10.Location = new System.Drawing.Point(491, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Número de registros= ";
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
            this.panel2.Location = new System.Drawing.Point(12, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(623, 222);
            this.panel2.TabIndex = 16;
            // 
            // _id
            // 
            this._id.Enabled = false;
            this._id.Font = new System.Drawing.Font("Arial Black", 8F);
            this._id.Location = new System.Drawing.Point(0, 0);
            this._id.Name = "_id";
            this._id.Size = new System.Drawing.Size(100, 23);
            this._id.TabIndex = 11;
            this._id.Text = "Identificación";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Black", 10F);
            this.label8.Location = new System.Drawing.Point(196, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(240, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "Registro de cajeros aprobados";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 23);
            this.label11.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Black", 8F);
            this.label12.Location = new System.Drawing.Point(231, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 15);
            this.label12.TabIndex = 18;
            this.label12.Text = "Número de registros= ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(355, 365);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "Aprobar cajero con identificación:";
            // 
            // IdAprobar
            // 
            this.IdAprobar.Location = new System.Drawing.Point(526, 365);
            this.IdAprobar.Name = "IdAprobar";
            this.IdAprobar.Size = new System.Drawing.Size(100, 20);
            this.IdAprobar.TabIndex = 20;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(632, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 21;
            this.button2.Text = "Aprobar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Location = new System.Drawing.Point(12, 437);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(623, 243);
            this.panel1.TabIndex = 17;
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("Arial Black", 8F);
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 11;
            this.textBox1.Text = "Identificación";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Arial Black", 8F);
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 11;
            this.textBox2.Text = "Nombre";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("Arial Black", 8F);
            this.textBox3.Location = new System.Drawing.Point(0, 0);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "Apellido 1";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Font = new System.Drawing.Font("Arial Black", 8F);
            this.textBox4.Location = new System.Drawing.Point(0, 0);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 23);
            this.textBox4.TabIndex = 11;
            this.textBox4.Text = "Apellido 2";
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Font = new System.Drawing.Font("Arial Black", 8F);
            this.textBox5.Location = new System.Drawing.Point(0, 0);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 23);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "Caja Asignada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Black", 8F);
            this.label3.Location = new System.Drawing.Point(140, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 15);
            this.label3.TabIndex = 26;
            this.label3.Text = "Número de registros= ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Black", 10F);
            this.label4.Location = new System.Drawing.Point(88, 362);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 19);
            this.label4.TabIndex = 25;
            this.label4.Text = "Registro de cajeros sin aprobar";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 313);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "Listar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(355, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Asignar caja número:";
            // 
            // cajaAsig
            // 
            this.cajaAsig.Location = new System.Drawing.Point(526, 400);
            this.cajaAsig.Name = "cajaAsig";
            this.cajaAsig.Size = new System.Drawing.Size(100, 20);
            this.cajaAsig.TabIndex = 28;
            // 
            // FormCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(732, 692);
            this.Controls.Add(this.cajaAsig);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.IdAprobar);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCajero";
            this.Text = "Mantenimiento de cajeros";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private Panel panel2;
        private TextBox _id;
        private TextBox _nombre1;
        private TextBox _apellido1;
        private TextBox _apellido2;
        private TextBox _cajaAsig;
        private Label label8;
        private Label label11;
        private Label label12;
        private Label label1;
        private TextBox IdAprobar;
        private Button button2;
        private Panel panel1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label3;
        private Label label4;
        private Button button3;
        private Label label5;
        private TextBox cajaAsig;
    }
}