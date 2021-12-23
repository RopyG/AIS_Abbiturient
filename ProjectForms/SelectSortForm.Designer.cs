
namespace AIS.ProjectForms
{
    partial class SelectSortForm
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
            this.allDirectionChBox = new System.Windows.Forms.CheckBox();
            this.progObCBo = new System.Windows.Forms.ComboBox();
            this.directionCBox = new System.Windows.Forms.ComboBox();
            this.progObLabel = new System.Windows.Forms.Label();
            this.directionLabel = new System.Windows.Forms.Label();
            this.allProgObChBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.enrollmentChBox = new System.Windows.Forms.CheckBox();
            this.abiturValueBox = new System.Windows.Forms.TextBox();
            this.abiturientsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // allDirectionChBox
            // 
            this.allDirectionChBox.AutoSize = true;
            this.allDirectionChBox.Enabled = false;
            this.allDirectionChBox.Location = new System.Drawing.Point(341, 191);
            this.allDirectionChBox.Name = "allDirectionChBox";
            this.allDirectionChBox.Size = new System.Drawing.Size(114, 17);
            this.allDirectionChBox.TabIndex = 1;
            this.allDirectionChBox.Text = "Все направления";
            this.allDirectionChBox.UseVisualStyleBackColor = true;
            this.allDirectionChBox.CheckedChanged += new System.EventHandler(this.allDirectionChBox_CheckedChanged);
            // 
            // progObCBo
            // 
            this.progObCBo.FormattingEnabled = true;
            this.progObCBo.Items.AddRange(new object[] {
            "Бакалавриат",
            "Магистратура",
            "Среднее профессиональное образование",
            "Аспирантура"});
            this.progObCBo.Location = new System.Drawing.Point(48, 136);
            this.progObCBo.Name = "progObCBo";
            this.progObCBo.Size = new System.Drawing.Size(188, 21);
            this.progObCBo.TabIndex = 2;
            this.progObCBo.SelectedIndexChanged += new System.EventHandler(this.progObCBo_SelectedIndexChanged);
            // 
            // directionCBox
            // 
            this.directionCBox.Enabled = false;
            this.directionCBox.FormattingEnabled = true;
            this.directionCBox.Location = new System.Drawing.Point(48, 187);
            this.directionCBox.Name = "directionCBox";
            this.directionCBox.Size = new System.Drawing.Size(287, 21);
            this.directionCBox.TabIndex = 3;
            this.directionCBox.SelectedIndexChanged += new System.EventHandler(this.directionCBox_SelectedIndexChanged);
            // 
            // progObLabel
            // 
            this.progObLabel.AutoSize = true;
            this.progObLabel.Location = new System.Drawing.Point(45, 120);
            this.progObLabel.Name = "progObLabel";
            this.progObLabel.Size = new System.Drawing.Size(118, 13);
            this.progObLabel.TabIndex = 4;
            this.progObLabel.Text = "Программа обучения:";
            // 
            // directionLabel
            // 
            this.directionLabel.AutoSize = true;
            this.directionLabel.Location = new System.Drawing.Point(45, 171);
            this.directionLabel.Name = "directionLabel";
            this.directionLabel.Size = new System.Drawing.Size(75, 13);
            this.directionLabel.TabIndex = 5;
            this.directionLabel.Text = "Направление";
            // 
            // allProgObChBox
            // 
            this.allProgObChBox.AutoSize = true;
            this.allProgObChBox.Location = new System.Drawing.Point(242, 140);
            this.allProgObChBox.Name = "allProgObChBox";
            this.allProgObChBox.Size = new System.Drawing.Size(156, 17);
            this.allProgObChBox.TabIndex = 6;
            this.allProgObChBox.Text = "Все программы обучения";
            this.allProgObChBox.UseVisualStyleBackColor = true;
            this.allProgObChBox.CheckedChanged += new System.EventHandler(this.allProgObChBox_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(443, 267);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 49);
            this.button1.TabIndex = 7;
            this.button1.Text = "Вывести";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // enrollmentChBox
            // 
            this.enrollmentChBox.AutoSize = true;
            this.enrollmentChBox.Location = new System.Drawing.Point(443, 39);
            this.enrollmentChBox.Name = "enrollmentChBox";
            this.enrollmentChBox.Size = new System.Drawing.Size(102, 17);
            this.enrollmentChBox.TabIndex = 8;
            this.enrollmentChBox.Text = "На зачисление";
            this.enrollmentChBox.UseVisualStyleBackColor = true;
            this.enrollmentChBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // abiturValueBox
            // 
            this.abiturValueBox.Enabled = false;
            this.abiturValueBox.Location = new System.Drawing.Point(443, 62);
            this.abiturValueBox.Name = "abiturValueBox";
            this.abiturValueBox.Size = new System.Drawing.Size(26, 20);
            this.abiturValueBox.TabIndex = 9;
            this.abiturValueBox.Text = "30";
            this.abiturValueBox.TextChanged += new System.EventHandler(this.adirueValueBox_TextChanged);
            this.abiturValueBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.adirueValueBox_KeyPress);
            // 
            // abiturientsLabel
            // 
            this.abiturientsLabel.AutoSize = true;
            this.abiturientsLabel.Enabled = false;
            this.abiturientsLabel.Location = new System.Drawing.Point(469, 65);
            this.abiturientsLabel.Name = "abiturientsLabel";
            this.abiturientsLabel.Size = new System.Drawing.Size(76, 13);
            this.abiturientsLabel.TabIndex = 10;
            this.abiturientsLabel.Text = "абитуриентов";
            this.abiturientsLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // SelectSortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 403);
            this.Controls.Add(this.abiturientsLabel);
            this.Controls.Add(this.abiturValueBox);
            this.Controls.Add(this.enrollmentChBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.allProgObChBox);
            this.Controls.Add(this.directionLabel);
            this.Controls.Add(this.progObLabel);
            this.Controls.Add(this.directionCBox);
            this.Controls.Add(this.progObCBo);
            this.Controls.Add(this.allDirectionChBox);
            this.Name = "SelectSortForm";
            this.Text = "SelectSortForm";
            this.Load += new System.EventHandler(this.SelectSortForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox allDirectionChBox;
        private System.Windows.Forms.ComboBox progObCBo;
        private System.Windows.Forms.ComboBox directionCBox;
        private System.Windows.Forms.Label progObLabel;
        private System.Windows.Forms.Label directionLabel;
        private System.Windows.Forms.CheckBox allProgObChBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox enrollmentChBox;
        private System.Windows.Forms.TextBox abiturValueBox;
        private System.Windows.Forms.Label abiturientsLabel;
    }
}