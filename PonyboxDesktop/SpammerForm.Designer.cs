namespace PonyboxDesktop
{
    partial class SpammerForm
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
            this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelStarted = new System.Windows.Forms.Label();
            this.buttonExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownCount
            // 
            this.numericUpDownCount.Location = new System.Drawing.Point(13, 13);
            this.numericUpDownCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownCount.Name = "numericUpDownCount";
            this.numericUpDownCount.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownCount.TabIndex = 0;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(13, 40);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelStarted
            // 
            this.labelStarted.AutoSize = true;
            this.labelStarted.Location = new System.Drawing.Point(13, 70);
            this.labelStarted.Name = "labelStarted";
            this.labelStarted.Size = new System.Drawing.Size(35, 13);
            this.labelStarted.TabIndex = 2;
            this.labelStarted.Text = "label1";
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(94, 39);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(75, 23);
            this.buttonExport.TabIndex = 3;
            this.buttonExport.Text = "Export";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // SpammerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.labelStarted);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.numericUpDownCount);
            this.Name = "SpammerForm";
            this.Text = "SpammerForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownCount;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelStarted;
        private System.Windows.Forms.Button buttonExport;
    }
}