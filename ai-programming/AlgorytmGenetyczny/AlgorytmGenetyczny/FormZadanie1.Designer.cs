namespace AlgorytmGenetyczny
{
    partial class FormZadanie1
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
            this.PrzyciskEkranPowitalny = new System.Windows.Forms.Button();
            this.PoleListaOsobnikow = new System.Windows.Forms.TextBox();
            this.PoleWynikowe = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PoleParametry = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PoleMinZmiennosc = new System.Windows.Forms.TextBox();
            this.PoleMaxZmiennosc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PoleChromNaPar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.PoleIleOsobnikow = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PoleRozmiarTurnieju = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PoleIleIteracji = new System.Windows.Forms.TextBox();
            this.PrzyciskWywolajAlgorytm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PrzyciskEkranPowitalny
            // 
            this.PrzyciskEkranPowitalny.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PrzyciskEkranPowitalny.Location = new System.Drawing.Point(671, 393);
            this.PrzyciskEkranPowitalny.Name = "PrzyciskEkranPowitalny";
            this.PrzyciskEkranPowitalny.Size = new System.Drawing.Size(117, 45);
            this.PrzyciskEkranPowitalny.TabIndex = 0;
            this.PrzyciskEkranPowitalny.Text = "Wróć do ekranu startowego";
            this.PrzyciskEkranPowitalny.UseVisualStyleBackColor = true;
            this.PrzyciskEkranPowitalny.Click += new System.EventHandler(this.PrzyciskEkranPowitalny_Click);
            // 
            // PoleListaOsobnikow
            // 
            this.PoleListaOsobnikow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PoleListaOsobnikow.Location = new System.Drawing.Point(596, 12);
            this.PoleListaOsobnikow.Multiline = true;
            this.PoleListaOsobnikow.Name = "PoleListaOsobnikow";
            this.PoleListaOsobnikow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PoleListaOsobnikow.Size = new System.Drawing.Size(192, 375);
            this.PoleListaOsobnikow.TabIndex = 1;
            this.PoleListaOsobnikow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PoleWynikowe
            // 
            this.PoleWynikowe.Location = new System.Drawing.Point(398, 12);
            this.PoleWynikowe.Multiline = true;
            this.PoleWynikowe.Name = "PoleWynikowe";
            this.PoleWynikowe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PoleWynikowe.Size = new System.Drawing.Size(192, 375);
            this.PoleWynikowe.TabIndex = 2;
            this.PoleWynikowe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wprowadź dane niezbędne do wywołania algorytmu:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PoleParametry
            // 
            this.PoleParametry.Enabled = false;
            this.PoleParametry.Location = new System.Drawing.Point(16, 59);
            this.PoleParametry.Name = "PoleParametry";
            this.PoleParametry.Size = new System.Drawing.Size(92, 20);
            this.PoleParametry.TabIndex = 4;
            this.PoleParametry.Text = "2";
            this.PoleParametry.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleParametry.TextChanged += new System.EventHandler(this.PoleParametry_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ile parametrów?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(13, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dopuszczalny przedział zmienności:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(13, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Min:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PoleMinZmiennosc
            // 
            this.PoleMinZmiennosc.Location = new System.Drawing.Point(50, 122);
            this.PoleMinZmiennosc.Name = "PoleMinZmiennosc";
            this.PoleMinZmiennosc.Size = new System.Drawing.Size(92, 20);
            this.PoleMinZmiennosc.TabIndex = 8;
            this.PoleMinZmiennosc.Text = "0";
            this.PoleMinZmiennosc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleMinZmiennosc.TextChanged += new System.EventHandler(this.PoleMinZmiennosc_TextChanged);
            // 
            // PoleMaxZmiennosc
            // 
            this.PoleMaxZmiennosc.Location = new System.Drawing.Point(50, 149);
            this.PoleMaxZmiennosc.Name = "PoleMaxZmiennosc";
            this.PoleMaxZmiennosc.Size = new System.Drawing.Size(92, 20);
            this.PoleMaxZmiennosc.TabIndex = 9;
            this.PoleMaxZmiennosc.Text = "100";
            this.PoleMaxZmiennosc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleMaxZmiennosc.TextChanged += new System.EventHandler(this.PoleMaxZmiennosc_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(13, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Max:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(12, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Ile chromosomów na parametr? (Minimum 3)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PoleChromNaPar
            // 
            this.PoleChromNaPar.Location = new System.Drawing.Point(15, 208);
            this.PoleChromNaPar.Name = "PoleChromNaPar";
            this.PoleChromNaPar.Size = new System.Drawing.Size(92, 20);
            this.PoleChromNaPar.TabIndex = 12;
            this.PoleChromNaPar.Text = "3";
            this.PoleChromNaPar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleChromNaPar.TextChanged += new System.EventHandler(this.PoleChromNaPar_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(12, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(238, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ile osobników? (Minimum 9 i nieparzysta)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PoleIleOsobnikow
            // 
            this.PoleIleOsobnikow.Location = new System.Drawing.Point(15, 264);
            this.PoleIleOsobnikow.Name = "PoleIleOsobnikow";
            this.PoleIleOsobnikow.Size = new System.Drawing.Size(92, 20);
            this.PoleIleOsobnikow.TabIndex = 14;
            this.PoleIleOsobnikow.Text = "17";
            this.PoleIleOsobnikow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleIleOsobnikow.TextChanged += new System.EventHandler(this.PoleIleOsobnikow_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(12, 299);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(373, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Rozmiar turnieju: (Minimum 1 i mniejsza niż 1/5 ilości osobników)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PoleRozmiarTurnieju
            // 
            this.PoleRozmiarTurnieju.Location = new System.Drawing.Point(14, 315);
            this.PoleRozmiarTurnieju.Name = "PoleRozmiarTurnieju";
            this.PoleRozmiarTurnieju.Size = new System.Drawing.Size(94, 20);
            this.PoleRozmiarTurnieju.TabIndex = 16;
            this.PoleRozmiarTurnieju.Text = "3";
            this.PoleRozmiarTurnieju.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleRozmiarTurnieju.TextChanged += new System.EventHandler(this.PoleRozmiarTurnieju_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(12, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(202, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Ile iteracji wykonać? (Minimum 20)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PoleIleIteracji
            // 
            this.PoleIleIteracji.Location = new System.Drawing.Point(15, 367);
            this.PoleIleIteracji.Name = "PoleIleIteracji";
            this.PoleIleIteracji.Size = new System.Drawing.Size(94, 20);
            this.PoleIleIteracji.TabIndex = 18;
            this.PoleIleIteracji.Text = "20";
            this.PoleIleIteracji.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleIleIteracji.TextChanged += new System.EventHandler(this.PoleIleIteracji_TextChanged);
            // 
            // PrzyciskWywolajAlgorytm
            // 
            this.PrzyciskWywolajAlgorytm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PrzyciskWywolajAlgorytm.Location = new System.Drawing.Point(15, 393);
            this.PrzyciskWywolajAlgorytm.Name = "PrzyciskWywolajAlgorytm";
            this.PrzyciskWywolajAlgorytm.Size = new System.Drawing.Size(368, 40);
            this.PrzyciskWywolajAlgorytm.TabIndex = 19;
            this.PrzyciskWywolajAlgorytm.Text = "Wywołaj algorytm";
            this.PrzyciskWywolajAlgorytm.UseVisualStyleBackColor = true;
            this.PrzyciskWywolajAlgorytm.Click += new System.EventHandler(this.PrzyciskWywolajAlgorytm_Click);
            // 
            // FormZadanie1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PrzyciskWywolajAlgorytm);
            this.Controls.Add(this.PoleIleIteracji);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PoleRozmiarTurnieju);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PoleIleOsobnikow);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PoleChromNaPar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PoleMaxZmiennosc);
            this.Controls.Add(this.PoleMinZmiennosc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PoleParametry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PoleWynikowe);
            this.Controls.Add(this.PoleListaOsobnikow);
            this.Controls.Add(this.PrzyciskEkranPowitalny);
            this.Name = "FormZadanie1";
            this.Text = "FormZadanie1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrzyciskEkranPowitalny;
        private System.Windows.Forms.TextBox PoleListaOsobnikow;
        private System.Windows.Forms.TextBox PoleWynikowe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PoleParametry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PoleMinZmiennosc;
        private System.Windows.Forms.TextBox PoleMaxZmiennosc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PoleChromNaPar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PoleIleOsobnikow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PoleRozmiarTurnieju;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox PoleIleIteracji;
        private System.Windows.Forms.Button PrzyciskWywolajAlgorytm;
    }
}