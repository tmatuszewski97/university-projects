namespace SiecNeuronowa
{
    partial class FormObliczenia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormObliczenia));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ZapiszWagi = new System.Windows.Forms.Button();
            this.WczytajWagi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.WyborPlikuWczytaj = new System.Windows.Forms.OpenFileDialog();
            this.PoleDane = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.WyborPlikuZapisz = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.PoleBeta = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PoleKrokUczenia = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.PoleLiczbaEpok = new System.Windows.Forms.TextBox();
            this.PrzyciskUczSiec = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PoleWejscia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.PrzyciskWyliczWynik = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.PoleBeta2 = new System.Windows.Forms.TextBox();
            this.WczytajProbki = new System.Windows.Forms.Button();
            this.WyborProbekWczytaj = new System.Windows.Forms.OpenFileDialog();
            this.label11 = new System.Windows.Forms.Label();
            this.PoleWeWy = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.PoleMaxBlad = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ustal potrzebne parametry:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ZapiszWagi);
            this.panel1.Controls.Add(this.WczytajWagi);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(641, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(147, 120);
            this.panel1.TabIndex = 1;
            // 
            // ZapiszWagi
            // 
            this.ZapiszWagi.Location = new System.Drawing.Point(3, 31);
            this.ZapiszWagi.Name = "ZapiszWagi";
            this.ZapiszWagi.Size = new System.Drawing.Size(139, 38);
            this.ZapiszWagi.TabIndex = 2;
            this.ZapiszWagi.Text = "Zapisz wagi do pliku";
            this.ZapiszWagi.UseVisualStyleBackColor = true;
            this.ZapiszWagi.Click += new System.EventHandler(this.ZapiszWagi_Click);
            // 
            // WczytajWagi
            // 
            this.WczytajWagi.Location = new System.Drawing.Point(3, 75);
            this.WczytajWagi.Name = "WczytajWagi";
            this.WczytajWagi.Size = new System.Drawing.Size(139, 38);
            this.WczytajWagi.TabIndex = 2;
            this.WczytajWagi.Text = "Wczytaj wagi z pliku";
            this.WczytajWagi.UseVisualStyleBackColor = true;
            this.WczytajWagi.Click += new System.EventHandler(this.WczytajWagi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Możesz również skorzystać \r\nz poniższych przycisków";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WyborPlikuWczytaj
            // 
            this.WyborPlikuWczytaj.FileName = "wagi.txt";
            // 
            // PoleDane
            // 
            this.PoleDane.Location = new System.Drawing.Point(369, 40);
            this.PoleDane.Multiline = true;
            this.PoleDane.Name = "PoleDane";
            this.PoleDane.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PoleDane.Size = new System.Drawing.Size(266, 398);
            this.PoleDane.TabIndex = 2;
            this.PoleDane.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(417, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Okno podglądu całej sieci";
            // 
            // WyborPlikuZapisz
            // 
            this.WyborPlikuZapisz.FileName = "wagi.txt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Parametr uczenia (beta):";
            // 
            // PoleBeta
            // 
            this.PoleBeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PoleBeta.Location = new System.Drawing.Point(171, 38);
            this.PoleBeta.Name = "PoleBeta";
            this.PoleBeta.Size = new System.Drawing.Size(79, 20);
            this.PoleBeta.TabIndex = 5;
            this.PoleBeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleBeta.TextChanged += new System.EventHandler(this.PoleBeta_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(12, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Krok uczący (μ):";
            // 
            // PoleKrokUczenia
            // 
            this.PoleKrokUczenia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PoleKrokUczenia.Location = new System.Drawing.Point(171, 64);
            this.PoleKrokUczenia.Name = "PoleKrokUczenia";
            this.PoleKrokUczenia.Size = new System.Drawing.Size(79, 20);
            this.PoleKrokUczenia.TabIndex = 7;
            this.PoleKrokUczenia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleKrokUczenia.TextChanged += new System.EventHandler(this.PoleKrokUczenia_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(12, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Liczba epok:";
            // 
            // PoleLiczbaEpok
            // 
            this.PoleLiczbaEpok.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PoleLiczbaEpok.Location = new System.Drawing.Point(171, 90);
            this.PoleLiczbaEpok.Name = "PoleLiczbaEpok";
            this.PoleLiczbaEpok.Size = new System.Drawing.Size(79, 20);
            this.PoleLiczbaEpok.TabIndex = 9;
            this.PoleLiczbaEpok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleLiczbaEpok.TextChanged += new System.EventHandler(this.PoleLiczbaEpok_TextChanged);
            // 
            // PrzyciskUczSiec
            // 
            this.PrzyciskUczSiec.Enabled = false;
            this.PrzyciskUczSiec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PrzyciskUczSiec.Location = new System.Drawing.Point(15, 184);
            this.PrzyciskUczSiec.Name = "PrzyciskUczSiec";
            this.PrzyciskUczSiec.Size = new System.Drawing.Size(235, 35);
            this.PrzyciskUczSiec.TabIndex = 10;
            this.PrzyciskUczSiec.Text = "Ucz sieć na podstawie parametrów";
            this.PrzyciskUczSiec.UseVisualStyleBackColor = true;
            this.PrzyciskUczSiec.Click += new System.EventHandler(this.PrzyciskUczSiec_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(22, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(211, 112);
            this.label7.TabIndex = 11;
            this.label7.Text = resources.GetString("label7.Text");
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(12, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 12;
            this.label8.Text = "Wejścia:";
            // 
            // PoleWejscia
            // 
            this.PoleWejscia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PoleWejscia.Location = new System.Drawing.Point(78, 363);
            this.PoleWejscia.Name = "PoleWejscia";
            this.PoleWejscia.Size = new System.Drawing.Size(172, 20);
            this.PoleWejscia.TabIndex = 13;
            this.PoleWejscia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleWejscia.TextChanged += new System.EventHandler(this.PoleWejscia_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(64, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 26);
            this.label9.TabIndex = 14;
            this.label9.Text = "Ilość wejść musi zgadzać się z tą \r\nzadeklarowaną wcześniej!";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PrzyciskWyliczWynik
            // 
            this.PrzyciskWyliczWynik.Enabled = false;
            this.PrzyciskWyliczWynik.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PrzyciskWyliczWynik.Location = new System.Drawing.Point(15, 415);
            this.PrzyciskWyliczWynik.Name = "PrzyciskWyliczWynik";
            this.PrzyciskWyliczWynik.Size = new System.Drawing.Size(235, 23);
            this.PrzyciskWyliczWynik.TabIndex = 15;
            this.PrzyciskWyliczWynik.Text = "Wylicz wyniki";
            this.PrzyciskWyliczWynik.UseVisualStyleBackColor = true;
            this.PrzyciskWyliczWynik.Click += new System.EventHandler(this.PrzyciskWyliczWynik_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(12, 338);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "Parametr uczenia (beta):";
            // 
            // PoleBeta2
            // 
            this.PoleBeta2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PoleBeta2.Location = new System.Drawing.Point(171, 337);
            this.PoleBeta2.Name = "PoleBeta2";
            this.PoleBeta2.Size = new System.Drawing.Size(79, 20);
            this.PoleBeta2.TabIndex = 17;
            this.PoleBeta2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleBeta2.TextChanged += new System.EventHandler(this.PoleBeta2_TextChanged);
            // 
            // WczytajProbki
            // 
            this.WczytajProbki.Location = new System.Drawing.Point(15, 120);
            this.WczytajProbki.Name = "WczytajProbki";
            this.WczytajProbki.Size = new System.Drawing.Size(235, 23);
            this.WczytajProbki.TabIndex = 18;
            this.WczytajProbki.Text = "Wczytaj próbki uczące";
            this.WczytajProbki.UseVisualStyleBackColor = true;
            this.WczytajProbki.Click += new System.EventHandler(this.WczytajProbki_Click);
            // 
            // WyborProbekWczytaj
            // 
            this.WyborProbekWczytaj.FileName = "probkiTestowe.txt";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(644, 149);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Okno podglądu we/wy";
            // 
            // PoleWeWy
            // 
            this.PoleWeWy.Location = new System.Drawing.Point(641, 172);
            this.PoleWeWy.Multiline = true;
            this.PoleWeWy.Name = "PoleWeWy";
            this.PoleWeWy.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PoleWeWy.Size = new System.Drawing.Size(147, 266);
            this.PoleWeWy.TabIndex = 20;
            this.PoleWeWy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(12, 146);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(145, 32);
            this.label12.TabIndex = 21;
            this.label12.Text = "Do jakiego max błędu \r\ndokonywać wyliczeń?";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PoleMaxBlad
            // 
            this.PoleMaxBlad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PoleMaxBlad.Location = new System.Drawing.Point(171, 148);
            this.PoleMaxBlad.Name = "PoleMaxBlad";
            this.PoleMaxBlad.Size = new System.Drawing.Size(79, 20);
            this.PoleMaxBlad.TabIndex = 22;
            this.PoleMaxBlad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleMaxBlad.TextChanged += new System.EventHandler(this.PoleMaxBlad_TextChanged);
            // 
            // FormObliczenia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PoleMaxBlad);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.PoleWeWy);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.WczytajProbki);
            this.Controls.Add(this.PoleBeta2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.PrzyciskWyliczWynik);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.PoleWejscia);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PrzyciskUczSiec);
            this.Controls.Add(this.PoleLiczbaEpok);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PoleKrokUczenia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PoleBeta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PoleDane);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "FormObliczenia";
            this.Text = "Operacje na sieci";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ZapiszWagi;
        private System.Windows.Forms.Button WczytajWagi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog WyborPlikuWczytaj;
        private System.Windows.Forms.TextBox PoleDane;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog WyborPlikuZapisz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PoleBeta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PoleKrokUczenia;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PoleLiczbaEpok;
        private System.Windows.Forms.Button PrzyciskUczSiec;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PoleWejscia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button PrzyciskWyliczWynik;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PoleBeta2;
        private System.Windows.Forms.Button WczytajProbki;
        private System.Windows.Forms.OpenFileDialog WyborProbekWczytaj;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox PoleWeWy;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox PoleMaxBlad;
    }
}