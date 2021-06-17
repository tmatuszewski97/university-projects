namespace SiecNeuronowa
{
    partial class FormTworzSiecZPliku
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
            this.CofnijDoEkranPowitalny = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.WyborPliku = new System.Windows.Forms.OpenFileDialog();
            this.PrzyciskSzukajPliku = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CofnijDoEkranPowitalny
            // 
            this.CofnijDoEkranPowitalny.Location = new System.Drawing.Point(663, 392);
            this.CofnijDoEkranPowitalny.Name = "CofnijDoEkranPowitalny";
            this.CofnijDoEkranPowitalny.Size = new System.Drawing.Size(125, 46);
            this.CofnijDoEkranPowitalny.TabIndex = 1;
            this.CofnijDoEkranPowitalny.Text = "Cofnij ->";
            this.CofnijDoEkranPowitalny.UseVisualStyleBackColor = true;
            this.CofnijDoEkranPowitalny.Click += new System.EventHandler(this.CofnijDoEkranPowitalny_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(209, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(417, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wybierz plik .txt na którego podstawie chcesz stworzyć sieć";
            // 
            // WyborPliku
            // 
            this.WyborPliku.FileName = "wagi.txt";
            // 
            // PrzyciskSzukajPliku
            // 
            this.PrzyciskSzukajPliku.Location = new System.Drawing.Point(212, 28);
            this.PrzyciskSzukajPliku.Name = "PrzyciskSzukajPliku";
            this.PrzyciskSzukajPliku.Size = new System.Drawing.Size(414, 32);
            this.PrzyciskSzukajPliku.TabIndex = 3;
            this.PrzyciskSzukajPliku.Text = "Szukaj pliku";
            this.PrzyciskSzukajPliku.UseVisualStyleBackColor = true;
            this.PrzyciskSzukajPliku.Click += new System.EventHandler(this.PrzyciskSzukajPliku_Click);
            // 
            // FormTworzSiecZPliku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PrzyciskSzukajPliku);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CofnijDoEkranPowitalny);
            this.Name = "FormTworzSiecZPliku";
            this.Text = "Tworzenie sieci na podstawie pliku";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CofnijDoEkranPowitalny;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog WyborPliku;
        private System.Windows.Forms.Button PrzyciskSzukajPliku;
    }
}