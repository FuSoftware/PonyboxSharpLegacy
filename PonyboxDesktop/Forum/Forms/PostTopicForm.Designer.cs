namespace PonyboxDesktop.Forum.Forms
{
    partial class PostTopicForm
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
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxSubject = new System.Windows.Forms.TextBox();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.numericUpDownSection = new System.Windows.Forms.NumericUpDown();
            this.buttonSend = new System.Windows.Forms.Button();
            this.webBrowserMain = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSection)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(13, 13);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(100, 20);
            this.textBoxUsername.TabIndex = 0;
            this.textBoxUsername.Text = "Username";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(119, 13);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // textBoxSubject
            // 
            this.textBoxSubject.Location = new System.Drawing.Point(13, 39);
            this.textBoxSubject.Name = "textBoxSubject";
            this.textBoxSubject.Size = new System.Drawing.Size(100, 20);
            this.textBoxSubject.TabIndex = 2;
            this.textBoxSubject.Text = "Subject";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(119, 39);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(100, 20);
            this.textBoxMessage.TabIndex = 3;
            this.textBoxMessage.Text = "Test";
            // 
            // numericUpDownSection
            // 
            this.numericUpDownSection.Location = new System.Drawing.Point(13, 65);
            this.numericUpDownSection.Name = "numericUpDownSection";
            this.numericUpDownSection.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownSection.TabIndex = 4;
            this.numericUpDownSection.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(144, 65);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(75, 23);
            this.buttonSend.TabIndex = 5;
            this.buttonSend.Text = "Send";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // webBrowserMain
            // 
            this.webBrowserMain.Location = new System.Drawing.Point(13, 92);
            this.webBrowserMain.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserMain.Name = "webBrowserMain";
            this.webBrowserMain.Size = new System.Drawing.Size(759, 457);
            this.webBrowserMain.TabIndex = 6;
            // 
            // PostTopicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.webBrowserMain);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.numericUpDownSection);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.textBoxSubject);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Name = "PostTopicForm";
            this.Text = "PostTopicForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxSubject;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.NumericUpDown numericUpDownSection;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.WebBrowser webBrowserMain;
    }
}