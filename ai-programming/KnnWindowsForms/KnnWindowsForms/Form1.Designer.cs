namespace KnnWindowsForms
{
    partial class Form1
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
            this.PrzyciskPlik = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.NapisAtrybuty = new System.Windows.Forms.Label();
            this.PoleAtrybuty = new System.Windows.Forms.TextBox();
            this.SpisAtrybutow = new System.Windows.Forms.TextBox();
            this.LiczbaAtrybutow = new System.Windows.Forms.Label();
            this.LiczbaMaksAtrybutow = new System.Windows.Forms.Label();
            this.NapisListaAtrybutow = new System.Windows.Forms.Label();
            this.NapisK = new System.Windows.Forms.Label();
            this.PoleK = new System.Windows.Forms.TextBox();
            this.BladK = new System.Windows.Forms.Label();
            this.BladAtrybuty = new System.Windows.Forms.Label();
            this.PoleWyboruMetryki = new System.Windows.Forms.ComboBox();
            this.NapisMetryka = new System.Windows.Forms.Label();
            this.PrzyciskKlasyfikuj = new System.Windows.Forms.Button();
            this.PoleWynik = new System.Windows.Forms.TextBox();
            this.NapisWynik = new System.Windows.Forms.Label();
            this.PrzyciskReset = new System.Windows.Forms.Button();
            this.CheckBoxNormalizacja = new System.Windows.Forms.CheckBox();
            this.PrzyciskDokladnosciKlasyfikacji = new System.Windows.Forms.Button();
            this.PoleDokladnoscKlasyfikacji = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PrzyciskPlik
            // 
            this.PrzyciskPlik.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.PrzyciskPlik.FlatAppearance.BorderSize = 2;
            this.PrzyciskPlik.Location = new System.Drawing.Point(578, 12);
            this.PrzyciskPlik.Name = "PrzyciskPlik";
            this.PrzyciskPlik.Size = new System.Drawing.Size(210, 23);
            this.PrzyciskPlik.TabIndex = 0;
            this.PrzyciskPlik.Text = "Importuj dane";
            this.PrzyciskPlik.UseVisualStyleBackColor = true;
            this.PrzyciskPlik.Click += new System.EventHandler(this.PrzyciskPlik_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "ofd1";
            // 
            // NapisAtrybuty
            // 
            this.NapisAtrybuty.AutoSize = true;
            this.NapisAtrybuty.Location = new System.Drawing.Point(172, 46);
            this.NapisAtrybuty.Name = "NapisAtrybuty";
            this.NapisAtrybuty.Size = new System.Drawing.Size(314, 13);
            this.NapisAtrybuty.TabIndex = 1;
            this.NapisAtrybuty.Text = "Poniżej wprowadzaj atrybuty każdorazowo zatwierdzając enterem";
            this.NapisAtrybuty.Visible = false;
            // 
            // PoleAtrybuty
            // 
            this.PoleAtrybuty.Location = new System.Drawing.Point(275, 62);
            this.PoleAtrybuty.Name = "PoleAtrybuty";
            this.PoleAtrybuty.Size = new System.Drawing.Size(98, 20);
            this.PoleAtrybuty.TabIndex = 2;
            this.PoleAtrybuty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleAtrybuty.Visible = false;
            this.PoleAtrybuty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PoleAtrybuty_KeyDown);
            // 
            // SpisAtrybutow
            // 
            this.SpisAtrybutow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SpisAtrybutow.Location = new System.Drawing.Point(578, 96);
            this.SpisAtrybutow.Multiline = true;
            this.SpisAtrybutow.Name = "SpisAtrybutow";
            this.SpisAtrybutow.Size = new System.Drawing.Size(210, 338);
            this.SpisAtrybutow.TabIndex = 3;
            this.SpisAtrybutow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SpisAtrybutow.Visible = false;
            // 
            // LiczbaAtrybutow
            // 
            this.LiczbaAtrybutow.Location = new System.Drawing.Point(0, 0);
            this.LiczbaAtrybutow.Name = "LiczbaAtrybutow";
            this.LiczbaAtrybutow.Size = new System.Drawing.Size(100, 23);
            this.LiczbaAtrybutow.TabIndex = 6;
            // 
            // LiczbaMaksAtrybutow
            // 
            this.LiczbaMaksAtrybutow.AutoSize = true;
            this.LiczbaMaksAtrybutow.Location = new System.Drawing.Point(597, 45);
            this.LiczbaMaksAtrybutow.Name = "LiczbaMaksAtrybutow";
            this.LiczbaMaksAtrybutow.Size = new System.Drawing.Size(152, 13);
            this.LiczbaMaksAtrybutow.TabIndex = 4;
            this.LiczbaMaksAtrybutow.Text = "Liczba atrybutów w próbkach: ";
            this.LiczbaMaksAtrybutow.Visible = false;
            // 
            // NapisListaAtrybutow
            // 
            this.NapisListaAtrybutow.AutoSize = true;
            this.NapisListaAtrybutow.Location = new System.Drawing.Point(597, 65);
            this.NapisListaAtrybutow.Name = "NapisListaAtrybutow";
            this.NapisListaAtrybutow.Size = new System.Drawing.Size(171, 26);
            this.NapisListaAtrybutow.TabIndex = 5;
            this.NapisListaAtrybutow.Text = "Poniżej znajdują się wprowadzone \r\natrybuty próbki testowej";
            this.NapisListaAtrybutow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NapisListaAtrybutow.Visible = false;
            // 
            // NapisK
            // 
            this.NapisK.AutoSize = true;
            this.NapisK.Location = new System.Drawing.Point(152, 88);
            this.NapisK.Name = "NapisK";
            this.NapisK.Size = new System.Drawing.Size(366, 13);
            this.NapisK.TabIndex = 7;
            this.NapisK.Text = "Podaj k (ilu sąsiadów brać pod uwagę) i zatwierdź enterem. Gdzie k: 0 < k < ";
            this.NapisK.Visible = false;
            // 
            // PoleK
            // 
            this.PoleK.Location = new System.Drawing.Point(273, 104);
            this.PoleK.Name = "PoleK";
            this.PoleK.Size = new System.Drawing.Size(100, 20);
            this.PoleK.TabIndex = 8;
            this.PoleK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleK.Visible = false;
            this.PoleK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PoleK_KeyDown);
            // 
            // BladK
            // 
            this.BladK.AutoSize = true;
            this.BladK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BladK.ForeColor = System.Drawing.Color.Red;
            this.BladK.Location = new System.Drawing.Point(379, 107);
            this.BladK.Name = "BladK";
            this.BladK.Size = new System.Drawing.Size(100, 13);
            this.BladK.TabIndex = 9;
            this.BladK.Text = "Błędna wartość!";
            this.BladK.Visible = false;
            // 
            // BladAtrybuty
            // 
            this.BladAtrybuty.AutoSize = true;
            this.BladAtrybuty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BladAtrybuty.ForeColor = System.Drawing.Color.Red;
            this.BladAtrybuty.Location = new System.Drawing.Point(379, 65);
            this.BladAtrybuty.Name = "BladAtrybuty";
            this.BladAtrybuty.Size = new System.Drawing.Size(100, 13);
            this.BladAtrybuty.TabIndex = 10;
            this.BladAtrybuty.Text = "Błędna wartość!";
            this.BladAtrybuty.Visible = false;
            // 
            // PoleWyboruMetryki
            // 
            this.PoleWyboruMetryki.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PoleWyboruMetryki.FormattingEnabled = true;
            this.PoleWyboruMetryki.Location = new System.Drawing.Point(261, 142);
            this.PoleWyboruMetryki.Name = "PoleWyboruMetryki";
            this.PoleWyboruMetryki.Size = new System.Drawing.Size(121, 21);
            this.PoleWyboruMetryki.TabIndex = 11;
            this.PoleWyboruMetryki.Visible = false;
            // 
            // NapisMetryka
            // 
            this.NapisMetryka.AutoSize = true;
            this.NapisMetryka.Location = new System.Drawing.Point(225, 126);
            this.NapisMetryka.Name = "NapisMetryka";
            this.NapisMetryka.Size = new System.Drawing.Size(206, 13);
            this.NapisMetryka.TabIndex = 12;
            this.NapisMetryka.Text = "Wybierz, z której metryki chcesz korzystać";
            this.NapisMetryka.Visible = false;
            // 
            // PrzyciskKlasyfikuj
            // 
            this.PrzyciskKlasyfikuj.Location = new System.Drawing.Point(261, 169);
            this.PrzyciskKlasyfikuj.Name = "PrzyciskKlasyfikuj";
            this.PrzyciskKlasyfikuj.Size = new System.Drawing.Size(121, 23);
            this.PrzyciskKlasyfikuj.TabIndex = 13;
            this.PrzyciskKlasyfikuj.Text = "Klasyfikuj próbkę";
            this.PrzyciskKlasyfikuj.UseVisualStyleBackColor = true;
            this.PrzyciskKlasyfikuj.Visible = false;
            this.PrzyciskKlasyfikuj.Click += new System.EventHandler(this.Klasyfikuj_Click);
            // 
            // PoleWynik
            // 
            this.PoleWynik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PoleWynik.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PoleWynik.Location = new System.Drawing.Point(155, 288);
            this.PoleWynik.Multiline = true;
            this.PoleWynik.Name = "PoleWynik";
            this.PoleWynik.Size = new System.Drawing.Size(363, 146);
            this.PoleWynik.TabIndex = 14;
            this.PoleWynik.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleWynik.Visible = false;
            // 
            // NapisWynik
            // 
            this.NapisWynik.AutoSize = true;
            this.NapisWynik.Location = new System.Drawing.Point(258, 272);
            this.NapisWynik.Name = "NapisWynik";
            this.NapisWynik.Size = new System.Drawing.Size(150, 13);
            this.NapisWynik.TabIndex = 15;
            this.NapisWynik.Text = "Próbka testowa po klasyfikacji";
            this.NapisWynik.Visible = false;
            // 
            // PrzyciskReset
            // 
            this.PrzyciskReset.Location = new System.Drawing.Point(12, 12);
            this.PrzyciskReset.Name = "PrzyciskReset";
            this.PrzyciskReset.Size = new System.Drawing.Size(113, 23);
            this.PrzyciskReset.TabIndex = 16;
            this.PrzyciskReset.Text = "Resetuj program";
            this.PrzyciskReset.UseCompatibleTextRendering = true;
            this.PrzyciskReset.UseVisualStyleBackColor = true;
            this.PrzyciskReset.Click += new System.EventHandler(this.PrzyciskResetuj_Click);
            // 
            // CheckBoxNormalizacja
            // 
            this.CheckBoxNormalizacja.AutoSize = true;
            this.CheckBoxNormalizacja.Location = new System.Drawing.Point(388, 144);
            this.CheckBoxNormalizacja.Name = "CheckBoxNormalizacja";
            this.CheckBoxNormalizacja.Size = new System.Drawing.Size(143, 17);
            this.CheckBoxNormalizacja.TabIndex = 17;
            this.CheckBoxNormalizacja.Text = "Czy normalizować dane?";
            this.CheckBoxNormalizacja.UseVisualStyleBackColor = true;
            this.CheckBoxNormalizacja.Visible = false;
            this.CheckBoxNormalizacja.CheckedChanged += new System.EventHandler(this.CheckBoxNormalizacja_CheckedChanged);
            // 
            // PrzyciskDokladnosciKlasyfikacji
            // 
            this.PrzyciskDokladnosciKlasyfikacji.Location = new System.Drawing.Point(232, 198);
            this.PrzyciskDokladnosciKlasyfikacji.Name = "PrzyciskDokladnosciKlasyfikacji";
            this.PrzyciskDokladnosciKlasyfikacji.Size = new System.Drawing.Size(199, 23);
            this.PrzyciskDokladnosciKlasyfikacji.TabIndex = 18;
            this.PrzyciskDokladnosciKlasyfikacji.Text = "Wylicz dokładność klasyfikacji";
            this.PrzyciskDokladnosciKlasyfikacji.UseVisualStyleBackColor = true;
            this.PrzyciskDokladnosciKlasyfikacji.Visible = false;
            this.PrzyciskDokladnosciKlasyfikacji.Click += new System.EventHandler(this.PrzyciskDokladnosciKlasyfikacji_Click);
            // 
            // PoleDokladnoscKlasyfikacji
            // 
            this.PoleDokladnoscKlasyfikacji.Location = new System.Drawing.Point(232, 227);
            this.PoleDokladnoscKlasyfikacji.Name = "PoleDokladnoscKlasyfikacji";
            this.PoleDokladnoscKlasyfikacji.Size = new System.Drawing.Size(199, 20);
            this.PoleDokladnoscKlasyfikacji.TabIndex = 19;
            this.PoleDokladnoscKlasyfikacji.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleDokladnoscKlasyfikacji.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 461);
            this.Controls.Add(this.PoleDokladnoscKlasyfikacji);
            this.Controls.Add(this.PrzyciskDokladnosciKlasyfikacji);
            this.Controls.Add(this.CheckBoxNormalizacja);
            this.Controls.Add(this.PrzyciskReset);
            this.Controls.Add(this.NapisWynik);
            this.Controls.Add(this.PoleWynik);
            this.Controls.Add(this.PrzyciskKlasyfikuj);
            this.Controls.Add(this.NapisMetryka);
            this.Controls.Add(this.PoleWyboruMetryki);
            this.Controls.Add(this.BladAtrybuty);
            this.Controls.Add(this.BladK);
            this.Controls.Add(this.PoleK);
            this.Controls.Add(this.NapisK);
            this.Controls.Add(this.NapisListaAtrybutow);
            this.Controls.Add(this.LiczbaMaksAtrybutow);
            this.Controls.Add(this.LiczbaAtrybutow);
            this.Controls.Add(this.SpisAtrybutow);
            this.Controls.Add(this.PoleAtrybuty);
            this.Controls.Add(this.NapisAtrybuty);
            this.Controls.Add(this.PrzyciskPlik);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrzyciskPlik;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Label NapisAtrybuty;
        private System.Windows.Forms.TextBox PoleAtrybuty;
        private System.Windows.Forms.TextBox SpisAtrybutow;
        private System.Windows.Forms.Label LiczbaAtrybutow;
        private System.Windows.Forms.Label LiczbaMaksAtrybutow;
        private System.Windows.Forms.Label NapisListaAtrybutow;
        private System.Windows.Forms.Label NapisK;
        private System.Windows.Forms.TextBox PoleK;
        private System.Windows.Forms.Label BladK;
        private System.Windows.Forms.Label BladAtrybuty;
        private System.Windows.Forms.ComboBox PoleWyboruMetryki;
        private System.Windows.Forms.Label NapisMetryka;
        private System.Windows.Forms.Button PrzyciskKlasyfikuj;
        private System.Windows.Forms.TextBox PoleWynik;
        private System.Windows.Forms.Label NapisWynik;
        private System.Windows.Forms.Button PrzyciskReset;
        private System.Windows.Forms.CheckBox CheckBoxNormalizacja;
        private System.Windows.Forms.Button PrzyciskDokladnosciKlasyfikacji;
        private System.Windows.Forms.TextBox PoleDokladnoscKlasyfikacji;
    }
}

