namespace SiecNeuronowa
{
    partial class FormTworzSiecZLiczb
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
            this.EtykietaWprowadzLiczby = new System.Windows.Forms.Label();
            this.PoleWprowadzLiczby = new System.Windows.Forms.TextBox();
            this.ZatwierdzLiczby = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PoleMinWaga = new System.Windows.Forms.TextBox();
            this.PoleMaxWaga = new System.Windows.Forms.TextBox();
            this.ZatwierdzWagi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CofnijDoEkranPowitalny
            // 
            this.CofnijDoEkranPowitalny.Location = new System.Drawing.Point(663, 392);
            this.CofnijDoEkranPowitalny.Name = "CofnijDoEkranPowitalny";
            this.CofnijDoEkranPowitalny.Size = new System.Drawing.Size(125, 46);
            this.CofnijDoEkranPowitalny.TabIndex = 0;
            this.CofnijDoEkranPowitalny.Text = "Cofnij ->";
            this.CofnijDoEkranPowitalny.UseVisualStyleBackColor = true;
            this.CofnijDoEkranPowitalny.Click += new System.EventHandler(this.CofnijDoEkranPowitalny_Click);
            // 
            // EtykietaWprowadzLiczby
            // 
            this.EtykietaWprowadzLiczby.AutoSize = true;
            this.EtykietaWprowadzLiczby.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.EtykietaWprowadzLiczby.Location = new System.Drawing.Point(99, 102);
            this.EtykietaWprowadzLiczby.Name = "EtykietaWprowadzLiczby";
            this.EtykietaWprowadzLiczby.Size = new System.Drawing.Size(640, 16);
            this.EtykietaWprowadzLiczby.TabIndex = 1;
            this.EtykietaWprowadzLiczby.Text = "Wprowadź ilość węzłów na poszczególnych warstwach. Warstwy rozdzielaj spacją. Np." +
    " 2 2 1";
            this.EtykietaWprowadzLiczby.Visible = false;
            // 
            // PoleWprowadzLiczby
            // 
            this.PoleWprowadzLiczby.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PoleWprowadzLiczby.Location = new System.Drawing.Point(258, 121);
            this.PoleWprowadzLiczby.Name = "PoleWprowadzLiczby";
            this.PoleWprowadzLiczby.Size = new System.Drawing.Size(288, 20);
            this.PoleWprowadzLiczby.TabIndex = 2;
            this.PoleWprowadzLiczby.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PoleWprowadzLiczby.Visible = false;
            // 
            // ZatwierdzLiczby
            // 
            this.ZatwierdzLiczby.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ZatwierdzLiczby.Location = new System.Drawing.Point(258, 147);
            this.ZatwierdzLiczby.Name = "ZatwierdzLiczby";
            this.ZatwierdzLiczby.Size = new System.Drawing.Size(288, 23);
            this.ZatwierdzLiczby.TabIndex = 3;
            this.ZatwierdzLiczby.Text = "Potwierdź";
            this.ZatwierdzLiczby.UseVisualStyleBackColor = true;
            this.ZatwierdzLiczby.Visible = false;
            this.ZatwierdzLiczby.Click += new System.EventHandler(this.ZatwierdzLiczby_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(199, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(409, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "W pola poniżej wprowadź, z jakiego zakresu losować wagi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(255, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Minimum:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Maksimum:";
            // 
            // PoleMinWaga
            // 
            this.PoleMinWaga.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PoleMinWaga.Location = new System.Drawing.Point(312, 37);
            this.PoleMinWaga.Name = "PoleMinWaga";
            this.PoleMinWaga.Size = new System.Drawing.Size(70, 20);
            this.PoleMinWaga.TabIndex = 7;
            this.PoleMinWaga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PoleMaxWaga
            // 
            this.PoleMaxWaga.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PoleMaxWaga.Location = new System.Drawing.Point(476, 37);
            this.PoleMaxWaga.Name = "PoleMaxWaga";
            this.PoleMaxWaga.Size = new System.Drawing.Size(70, 20);
            this.PoleMaxWaga.TabIndex = 8;
            this.PoleMaxWaga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ZatwierdzWagi
            // 
            this.ZatwierdzWagi.Location = new System.Drawing.Point(258, 63);
            this.ZatwierdzWagi.Name = "ZatwierdzWagi";
            this.ZatwierdzWagi.Size = new System.Drawing.Size(288, 25);
            this.ZatwierdzWagi.TabIndex = 9;
            this.ZatwierdzWagi.Text = "Idź dalej";
            this.ZatwierdzWagi.UseVisualStyleBackColor = true;
            this.ZatwierdzWagi.Click += new System.EventHandler(this.ZatwierdzWagi_Click);
            // 
            // FormTworzSiecZLiczb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ZatwierdzWagi);
            this.Controls.Add(this.PoleMaxWaga);
            this.Controls.Add(this.PoleMinWaga);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ZatwierdzLiczby);
            this.Controls.Add(this.PoleWprowadzLiczby);
            this.Controls.Add(this.EtykietaWprowadzLiczby);
            this.Controls.Add(this.CofnijDoEkranPowitalny);
            this.Name = "FormTworzSiecZLiczb";
            this.Text = "Tworzenie sieci z zadanych liczb";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CofnijDoEkranPowitalny;
        private System.Windows.Forms.Label EtykietaWprowadzLiczby;
        private System.Windows.Forms.TextBox PoleWprowadzLiczby;
        private System.Windows.Forms.Button ZatwierdzLiczby;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PoleMinWaga;
        private System.Windows.Forms.TextBox PoleMaxWaga;
        private System.Windows.Forms.Button ZatwierdzWagi;
    }
}