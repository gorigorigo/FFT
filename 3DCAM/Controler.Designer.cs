namespace _3DCAM
{
    partial class Controler
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
            this.button_DrawGnuplot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_DrawGnuplot
            // 
            this.button_DrawGnuplot.Location = new System.Drawing.Point(409, 134);
            this.button_DrawGnuplot.Name = "button_DrawGnuplot";
            this.button_DrawGnuplot.Size = new System.Drawing.Size(183, 119);
            this.button_DrawGnuplot.TabIndex = 0;
            this.button_DrawGnuplot.Text = "button1";
            this.button_DrawGnuplot.UseVisualStyleBackColor = true;
            this.button_DrawGnuplot.Click += new System.EventHandler(this.button_DrawGnuplot_Click);
            // 
            // Controler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_DrawGnuplot);
            this.Name = "Controler";
            this.Text = "Controler";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_DrawGnuplot;
    }
}