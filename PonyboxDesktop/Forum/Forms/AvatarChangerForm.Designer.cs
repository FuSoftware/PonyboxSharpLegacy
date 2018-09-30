namespace PonyboxDesktop
{
    partial class AvatarChangerForm
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
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxTimestamp = new System.Windows.Forms.TextBox();
            this.textBoxToken = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.webBrowserMain = new System.Windows.Forms.WebBrowser();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Location = new System.Drawing.Point(3, 3);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(100, 20);
            this.textBoxUrl.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.textBoxUrl);
            this.flowLayoutPanel1.Controls.Add(this.textBoxTimestamp);
            this.flowLayoutPanel1.Controls.Add(this.textBoxToken);
            this.flowLayoutPanel1.Controls.Add(this.buttonStart);
            this.flowLayoutPanel1.Controls.Add(this.webBrowserMain);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(624, 441);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // textBoxTimestamp
            // 
            this.textBoxTimestamp.Location = new System.Drawing.Point(3, 29);
            this.textBoxTimestamp.Name = "textBoxTimestamp";
            this.textBoxTimestamp.Size = new System.Drawing.Size(100, 20);
            this.textBoxTimestamp.TabIndex = 1;
            // 
            // textBoxToken
            // 
            this.textBoxToken.Location = new System.Drawing.Point(3, 55);
            this.textBoxToken.Name = "textBoxToken";
            this.textBoxToken.Size = new System.Drawing.Size(100, 20);
            this.textBoxToken.TabIndex = 2;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(3, 81);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 3;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // webBrowserMain
            // 
            this.webBrowserMain.Location = new System.Drawing.Point(3, 110);
            this.webBrowserMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserMain.Name = "webBrowserMain";
            this.webBrowserMain.Size = new System.Drawing.Size(609, 319);
            this.webBrowserMain.TabIndex = 4;
            // 
            // AvatarChangerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AvatarChangerForm";
            this.Text = "AvatarChanger";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox textBoxTimestamp;
        private System.Windows.Forms.TextBox textBoxToken;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.WebBrowser webBrowserMain;
    }
}