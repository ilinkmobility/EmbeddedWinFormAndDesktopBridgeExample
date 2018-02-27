namespace Demo.WinFrom
{
    partial class CurrencyConverter
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.labelRate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Check Currency Rates against USD";
            // 
            // comboBoxTo
            // 
            this.comboBoxTo.FormattingEnabled = true;
            this.comboBoxTo.Items.AddRange(new object[] {
            "AUD-Australian Dollar",
            "BGN-Bulgarian Lev",
            "BRL-Brazilian Real",
            "CAD-Canadian Dollar",
            "CHF-Swiss Franc",
            "CNY-Chinese Yuan",
            "CZK-Czech Koruna",
            "DKK-Danish Krone",
            "EUR-Euro",
            "GBP-British Pound",
            "HKD-Hong Kong Dollar",
            "HRK-Croatian Kuna",
            "HUF-Hungarian Forint",
            "IDR-Indonesian Rupiah",
            "ILS-Israeli Shekel",
            "INR-Indian Rupee",
            "JPY-Japanese Yen",
            "KRW-Korean Won",
            "MXN-Mexican Peso",
            "MYR-Malaysian Ringgit",
            "NOK-Norwegian Krone",
            "NZD-New Zealand Dollar",
            "PHP-Philippine Peso",
            "PLN-Polish Zloty",
            "RON-Romanian Leu",
            "RUB-Russian Rouble",
            "SEK-Swedish Krona",
            "SGD-Singapore Dollar",
            "THB-Thai Baht",
            "TRY-Turkey Lira",
            "ZAR-South African Rand"});
            this.comboBoxTo.Location = new System.Drawing.Point(28, 101);
            this.comboBoxTo.Name = "comboBoxTo";
            this.comboBoxTo.Size = new System.Drawing.Size(319, 21);
            this.comboBoxTo.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Currency";
            // 
            // buttonConvert
            // 
            this.buttonConvert.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConvert.Location = new System.Drawing.Point(28, 138);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(319, 37);
            this.buttonConvert.TabIndex = 5;
            this.buttonConvert.Text = "Convert";
            this.buttonConvert.UseVisualStyleBackColor = false;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // labelRate
            // 
            this.labelRate.AutoSize = true;
            this.labelRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRate.ForeColor = System.Drawing.Color.Red;
            this.labelRate.Location = new System.Drawing.Point(24, 190);
            this.labelRate.Name = "labelRate";
            this.labelRate.Size = new System.Drawing.Size(93, 20);
            this.labelRate.TabIndex = 6;
            this.labelRate.Text = "Rate :  0.0";
            // 
            // CurrencyConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Controls.Add(this.labelRate);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.comboBoxTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CurrencyConverter";
            this.Size = new System.Drawing.Size(377, 235);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Label labelRate;
    }
}
