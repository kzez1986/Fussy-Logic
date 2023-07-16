namespace Sterownik_rozmyty
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
            this.laZachmurzenie = new System.Windows.Forms.Label();
            this.laWilgotność = new System.Windows.Forms.Label();
            this.laGradient = new System.Windows.Forms.Label();
            this.trZachmurzenie = new System.Windows.Forms.TrackBar();
            this.trWilgotność = new System.Windows.Forms.TrackBar();
            this.trGradient = new System.Windows.Forms.TrackBar();
            this.teZachmurzenie = new System.Windows.Forms.TextBox();
            this.teWilgotność = new System.Windows.Forms.TextBox();
            this.teGradient = new System.Windows.Forms.TextBox();
            this.teIloczyn = new System.Windows.Forms.TextBox();
            this.buStart = new System.Windows.Forms.Button();
            this.laIloczyn = new System.Windows.Forms.Label();
            this.laStopieńAktywacji = new System.Windows.Forms.Label();
            this.teStopieńAktywacji = new System.Windows.Forms.TextBox();
            this.laStopieńBurza = new System.Windows.Forms.Label();
            this.teStopieńBurzy = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.trZachmurzenie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trWilgotność)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trGradient)).BeginInit();
            this.SuspendLayout();
            // 
            // laZachmurzenie
            // 
            this.laZachmurzenie.AutoSize = true;
            this.laZachmurzenie.Location = new System.Drawing.Point(9, 344);
            this.laZachmurzenie.Name = "laZachmurzenie";
            this.laZachmurzenie.Size = new System.Drawing.Size(77, 13);
            this.laZachmurzenie.TabIndex = 0;
            this.laZachmurzenie.Text = "Zachmurzenie:";
            // 
            // laWilgotność
            // 
            this.laWilgotność.AutoSize = true;
            this.laWilgotność.Location = new System.Drawing.Point(9, 381);
            this.laWilgotność.Name = "laWilgotność";
            this.laWilgotność.Size = new System.Drawing.Size(63, 13);
            this.laWilgotność.TabIndex = 1;
            this.laWilgotność.Text = "Wilgotność:";
            // 
            // laGradient
            // 
            this.laGradient.AutoSize = true;
            this.laGradient.Location = new System.Drawing.Point(9, 422);
            this.laGradient.Name = "laGradient";
            this.laGradient.Size = new System.Drawing.Size(94, 13);
            this.laGradient.TabIndex = 3;
            this.laGradient.Text = "Gradient ciśnienia:";
            // 
            // trZachmurzenie
            // 
            this.trZachmurzenie.Location = new System.Drawing.Point(109, 335);
            this.trZachmurzenie.Maximum = 160;
            this.trZachmurzenie.Name = "trZachmurzenie";
            this.trZachmurzenie.Size = new System.Drawing.Size(216, 45);
            this.trZachmurzenie.TabIndex = 4;
            this.trZachmurzenie.Scroll += new System.EventHandler(this.trZachmurzenie_Scroll);
            // 
            // trWilgotność
            // 
            this.trWilgotność.Location = new System.Drawing.Point(109, 372);
            this.trWilgotność.Maximum = 200;
            this.trWilgotność.Name = "trWilgotność";
            this.trWilgotność.Size = new System.Drawing.Size(216, 45);
            this.trWilgotność.TabIndex = 5;
            this.trWilgotność.Scroll += new System.EventHandler(this.trWilgotność_Scroll);
            // 
            // trGradient
            // 
            this.trGradient.Location = new System.Drawing.Point(109, 413);
            this.trGradient.Maximum = 160;
            this.trGradient.Name = "trGradient";
            this.trGradient.Size = new System.Drawing.Size(216, 45);
            this.trGradient.TabIndex = 7;
            this.trGradient.Scroll += new System.EventHandler(this.trGradient_Scroll);
            // 
            // teZachmurzenie
            // 
            this.teZachmurzenie.Location = new System.Drawing.Point(331, 337);
            this.teZachmurzenie.Name = "teZachmurzenie";
            this.teZachmurzenie.Size = new System.Drawing.Size(138, 20);
            this.teZachmurzenie.TabIndex = 8;
            // 
            // teWilgotność
            // 
            this.teWilgotność.Location = new System.Drawing.Point(331, 378);
            this.teWilgotność.Name = "teWilgotność";
            this.teWilgotność.Size = new System.Drawing.Size(138, 20);
            this.teWilgotność.TabIndex = 9;
            // 
            // teGradient
            // 
            this.teGradient.Location = new System.Drawing.Point(331, 419);
            this.teGradient.Name = "teGradient";
            this.teGradient.Size = new System.Drawing.Size(138, 20);
            this.teGradient.TabIndex = 11;
            // 
            // teIloczyn
            // 
            this.teIloczyn.Location = new System.Drawing.Point(251, 52);
            this.teIloczyn.Name = "teIloczyn";
            this.teIloczyn.Size = new System.Drawing.Size(100, 20);
            this.teIloczyn.TabIndex = 12;
            // 
            // buStart
            // 
            this.buStart.Location = new System.Drawing.Point(71, 234);
            this.buStart.Name = "buStart";
            this.buStart.Size = new System.Drawing.Size(75, 23);
            this.buStart.TabIndex = 13;
            this.buStart.Text = "START";
            this.buStart.UseVisualStyleBackColor = true;
            this.buStart.Click += new System.EventHandler(this.buStart_Click);
            // 
            // laIloczyn
            // 
            this.laIloczyn.AutoSize = true;
            this.laIloczyn.Location = new System.Drawing.Point(36, 55);
            this.laIloczyn.Name = "laIloczyn";
            this.laIloczyn.Size = new System.Drawing.Size(110, 13);
            this.laIloczyn.TabIndex = 14;
            this.laIloczyn.Text = "Iloczyn mnogościowy:";
            // 
            // laStopieńAktywacji
            // 
            this.laStopieńAktywacji.AutoSize = true;
            this.laStopieńAktywacji.Location = new System.Drawing.Point(36, 94);
            this.laStopieńAktywacji.Name = "laStopieńAktywacji";
            this.laStopieńAktywacji.Size = new System.Drawing.Size(129, 13);
            this.laStopieńAktywacji.TabIndex = 15;
            this.laStopieńAktywacji.Text = "Stopień aktywacji deszcz:";
            // 
            // teStopieńAktywacji
            // 
            this.teStopieńAktywacji.Location = new System.Drawing.Point(251, 94);
            this.teStopieńAktywacji.Name = "teStopieńAktywacji";
            this.teStopieńAktywacji.Size = new System.Drawing.Size(100, 20);
            this.teStopieńAktywacji.TabIndex = 16;
            // 
            // laStopieńBurza
            // 
            this.laStopieńBurza.AutoSize = true;
            this.laStopieńBurza.Location = new System.Drawing.Point(37, 133);
            this.laStopieńBurza.Name = "laStopieńBurza";
            this.laStopieńBurza.Size = new System.Drawing.Size(121, 13);
            this.laStopieńBurza.TabIndex = 17;
            this.laStopieńBurza.Text = "Stopień aktywacji burzy:";
            // 
            // teStopieńBurzy
            // 
            this.teStopieńBurzy.Location = new System.Drawing.Point(251, 133);
            this.teStopieńBurzy.Name = "teStopieńBurzy";
            this.teStopieńBurzy.Size = new System.Drawing.Size(100, 20);
            this.teStopieńBurzy.TabIndex = 18;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(145, 186);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 19;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(277, 186);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 449);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.teStopieńBurzy);
            this.Controls.Add(this.laStopieńBurza);
            this.Controls.Add(this.teStopieńAktywacji);
            this.Controls.Add(this.laStopieńAktywacji);
            this.Controls.Add(this.laIloczyn);
            this.Controls.Add(this.buStart);
            this.Controls.Add(this.teIloczyn);
            this.Controls.Add(this.teGradient);
            this.Controls.Add(this.teWilgotność);
            this.Controls.Add(this.teZachmurzenie);
            this.Controls.Add(this.trGradient);
            this.Controls.Add(this.trWilgotność);
            this.Controls.Add(this.trZachmurzenie);
            this.Controls.Add(this.laGradient);
            this.Controls.Add(this.laWilgotność);
            this.Controls.Add(this.laZachmurzenie);
            this.Name = "Form1";
            this.Text = "Czy będzie padać?";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trZachmurzenie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trWilgotność)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trGradient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label laZachmurzenie;
        private System.Windows.Forms.Label laWilgotność;
        private System.Windows.Forms.Label laGradient;
        private System.Windows.Forms.TrackBar trZachmurzenie;
        private System.Windows.Forms.TrackBar trWilgotność;
        private System.Windows.Forms.TrackBar trGradient;
        private System.Windows.Forms.TextBox teZachmurzenie;
        private System.Windows.Forms.TextBox teWilgotność;
        private System.Windows.Forms.TextBox teGradient;
        private System.Windows.Forms.TextBox teIloczyn;
        private System.Windows.Forms.Button buStart;
        private System.Windows.Forms.Label laIloczyn;
        private System.Windows.Forms.Label laStopieńAktywacji;
        private System.Windows.Forms.TextBox teStopieńAktywacji;
        private System.Windows.Forms.Label laStopieńBurza;
        private System.Windows.Forms.TextBox teStopieńBurzy;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
    }
}

