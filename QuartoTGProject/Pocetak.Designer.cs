namespace QuartoTGProject
{
    partial class Pocetak
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
            this.btn_prvi = new System.Windows.Forms.Button();
            this.btn_drugi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dobro dosli!";
            // 
            // btn_prvi
            // 
            this.btn_prvi.Location = new System.Drawing.Point(33, 92);
            this.btn_prvi.Name = "btn_prvi";
            this.btn_prvi.Size = new System.Drawing.Size(122, 40);
            this.btn_prvi.TabIndex = 1;
            this.btn_prvi.Text = "Igram prvi!";
            this.btn_prvi.UseVisualStyleBackColor = true;
            this.btn_prvi.Click += new System.EventHandler(this.btn_prvi_Click);
            // 
            // btn_drugi
            // 
            this.btn_drugi.Location = new System.Drawing.Point(202, 92);
            this.btn_drugi.Name = "btn_drugi";
            this.btn_drugi.Size = new System.Drawing.Size(119, 40);
            this.btn_drugi.TabIndex = 2;
            this.btn_drugi.Text = "Igram drugi!";
            this.btn_drugi.UseVisualStyleBackColor = true;
            this.btn_drugi.Click += new System.EventHandler(this.btn_drugi_Click);
            // 
            // Pocetak
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 156);
            this.Controls.Add(this.btn_drugi);
            this.Controls.Add(this.btn_prvi);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(388, 195);
            this.MinimumSize = new System.Drawing.Size(388, 195);
            this.Name = "Pocetak";
            this.Text = "Pocetak";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_prvi;
        private System.Windows.Forms.Button btn_drugi;
    }
}