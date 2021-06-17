namespace AlgorytmGenetyczny
{
    partial class EkranPowitalny
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
            this.label1 = new System.Windows.Forms.Label();
            this.PrzyciskZadanie1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(29, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(759, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wybierz, które podzadanie z zadania trzeciego wykonać?\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PrzyciskZadanie1
            // 
            this.PrzyciskZadanie1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PrzyciskZadanie1.Location = new System.Drawing.Point(264, 183);
            this.PrzyciskZadanie1.Name = "PrzyciskZadanie1";
            this.PrzyciskZadanie1.Size = new System.Drawing.Size(279, 73);
            this.PrzyciskZadanie1.TabIndex = 1;
            this.PrzyciskZadanie1.Text = "Zadanie 1\r\n\"Zmutowany dywanik\"\r\n";
            this.PrzyciskZadanie1.UseVisualStyleBackColor = true;
            this.PrzyciskZadanie1.Click += new System.EventHandler(this.PrzyciskZadanie1_Click);
            // 
            // EkranPowitalny
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PrzyciskZadanie1);
            this.Controls.Add(this.label1);
            this.Name = "EkranPowitalny";
            this.Text = "Ekran powitalny";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PrzyciskZadanie1;
    }
}

