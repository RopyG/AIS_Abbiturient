
namespace AIS
{
    partial class HomeForm
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
            this.panelHome = new System.Windows.Forms.Panel();
            this.buttonReg = new System.Windows.Forms.Button();
            this.buttonSim = new System.Windows.Forms.Button();
            this.buttonDB = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelHome
            // 
            this.panelHome.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelHome.Location = new System.Drawing.Point(153, 29);
            this.panelHome.Name = "panelHome";
            this.panelHome.Size = new System.Drawing.Size(644, 416);
            this.panelHome.TabIndex = 0;
            // 
            // buttonReg
            // 
            this.buttonReg.Location = new System.Drawing.Point(12, 29);
            this.buttonReg.Name = "buttonReg";
            this.buttonReg.Size = new System.Drawing.Size(135, 99);
            this.buttonReg.TabIndex = 1;
            this.buttonReg.Text = "Регистрация";
            this.buttonReg.UseVisualStyleBackColor = true;
            this.buttonReg.Click += new System.EventHandler(this.buttonReg_Click);
            // 
            // buttonSim
            // 
            this.buttonSim.Location = new System.Drawing.Point(12, 170);
            this.buttonSim.Name = "buttonSim";
            this.buttonSim.Size = new System.Drawing.Size(135, 99);
            this.buttonSim.TabIndex = 2;
            this.buttonSim.Text = "Симуляция";
            this.buttonSim.UseVisualStyleBackColor = true;
            this.buttonSim.Click += new System.EventHandler(this.buttonSim_Click);
            // 
            // buttonDB
            // 
            this.buttonDB.Location = new System.Drawing.Point(12, 316);
            this.buttonDB.Name = "buttonDB";
            this.buttonDB.Size = new System.Drawing.Size(135, 99);
            this.buttonDB.TabIndex = 3;
            this.buttonDB.Text = "База данных аббитуриентов";
            this.buttonDB.UseVisualStyleBackColor = true;
            this.buttonDB.Click += new System.EventHandler(this.buttonDB_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Закрыть";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(639, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Свернуть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDB);
            this.Controls.Add(this.buttonSim);
            this.Controls.Add(this.buttonReg);
            this.Controls.Add(this.panelHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHome;
        private System.Windows.Forms.Button buttonReg;
        private System.Windows.Forms.Button buttonSim;
        private System.Windows.Forms.Button buttonDB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}