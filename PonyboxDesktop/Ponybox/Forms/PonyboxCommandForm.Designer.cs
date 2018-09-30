namespace PonyboxDesktop
{
    partial class PonyboxCommandForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.numericKick = new System.Windows.Forms.NumericUpDown();
            this.buttonKick = new System.Windows.Forms.Button();
            this.textBoxChannel = new System.Windows.Forms.TextBox();
            this.buttonJoin = new System.Windows.Forms.Button();
            this.buttonLeave = new System.Windows.Forms.Button();
            this.buttonLock = new System.Windows.Forms.Button();
            this.buttonUnlock = new System.Windows.Forms.Button();
            this.buttonListBans = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.textBoxOlderMessages = new System.Windows.Forms.TextBox();
            this.numericUpDownOlderMessages = new System.Windows.Forms.NumericUpDown();
            this.buttonOlderMessages = new System.Windows.Forms.Button();
            this.buttonDeban = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericKick)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOlderMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.numericKick);
            this.flowLayoutPanel1.Controls.Add(this.buttonDeban);
            this.flowLayoutPanel1.Controls.Add(this.buttonKick);
            this.flowLayoutPanel1.Controls.Add(this.textBoxChannel);
            this.flowLayoutPanel1.Controls.Add(this.buttonJoin);
            this.flowLayoutPanel1.Controls.Add(this.buttonLeave);
            this.flowLayoutPanel1.Controls.Add(this.buttonLock);
            this.flowLayoutPanel1.Controls.Add(this.buttonUnlock);
            this.flowLayoutPanel1.Controls.Add(this.buttonListBans);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // numericKick
            // 
            this.numericKick.Location = new System.Drawing.Point(3, 3);
            this.numericKick.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericKick.Name = "numericKick";
            this.numericKick.Size = new System.Drawing.Size(120, 20);
            this.numericKick.TabIndex = 2;
            // 
            // buttonKick
            // 
            this.buttonKick.Location = new System.Drawing.Point(3, 58);
            this.buttonKick.Name = "buttonKick";
            this.buttonKick.Size = new System.Drawing.Size(75, 23);
            this.buttonKick.TabIndex = 1;
            this.buttonKick.Text = "Kick";
            this.buttonKick.UseVisualStyleBackColor = true;
            this.buttonKick.Click += new System.EventHandler(this.buttonKick_Click);
            // 
            // textBoxChannel
            // 
            this.textBoxChannel.Location = new System.Drawing.Point(3, 87);
            this.textBoxChannel.Name = "textBoxChannel";
            this.textBoxChannel.Size = new System.Drawing.Size(100, 20);
            this.textBoxChannel.TabIndex = 3;
            // 
            // buttonJoin
            // 
            this.buttonJoin.Location = new System.Drawing.Point(3, 113);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(75, 23);
            this.buttonJoin.TabIndex = 4;
            this.buttonJoin.Text = "Join";
            this.buttonJoin.UseVisualStyleBackColor = true;
            this.buttonJoin.Click += new System.EventHandler(this.buttonJoin_Click);
            // 
            // buttonLeave
            // 
            this.buttonLeave.Location = new System.Drawing.Point(3, 142);
            this.buttonLeave.Name = "buttonLeave";
            this.buttonLeave.Size = new System.Drawing.Size(75, 23);
            this.buttonLeave.TabIndex = 5;
            this.buttonLeave.Text = "Leave";
            this.buttonLeave.UseVisualStyleBackColor = true;
            this.buttonLeave.Click += new System.EventHandler(this.buttonLeave_Click);
            // 
            // buttonLock
            // 
            this.buttonLock.Location = new System.Drawing.Point(3, 171);
            this.buttonLock.Name = "buttonLock";
            this.buttonLock.Size = new System.Drawing.Size(75, 23);
            this.buttonLock.TabIndex = 7;
            this.buttonLock.Text = "Lock";
            this.buttonLock.UseVisualStyleBackColor = true;
            this.buttonLock.Click += new System.EventHandler(this.buttonLock_Click);
            // 
            // buttonUnlock
            // 
            this.buttonUnlock.Location = new System.Drawing.Point(3, 200);
            this.buttonUnlock.Name = "buttonUnlock";
            this.buttonUnlock.Size = new System.Drawing.Size(75, 23);
            this.buttonUnlock.TabIndex = 8;
            this.buttonUnlock.Text = "Unlock";
            this.buttonUnlock.UseVisualStyleBackColor = true;
            this.buttonUnlock.Click += new System.EventHandler(this.buttonUnlock_Click);
            // 
            // buttonListBans
            // 
            this.buttonListBans.Location = new System.Drawing.Point(3, 229);
            this.buttonListBans.Name = "buttonListBans";
            this.buttonListBans.Size = new System.Drawing.Size(75, 23);
            this.buttonListBans.TabIndex = 6;
            this.buttonListBans.Text = "List Bans";
            this.buttonListBans.UseVisualStyleBackColor = true;
            this.buttonListBans.Click += new System.EventHandler(this.buttonListBans_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.textBoxOlderMessages);
            this.flowLayoutPanel2.Controls.Add(this.numericUpDownOlderMessages);
            this.flowLayoutPanel2.Controls.Add(this.buttonOlderMessages);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 258);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(447, 100);
            this.flowLayoutPanel2.TabIndex = 9;
            // 
            // textBoxOlderMessages
            // 
            this.textBoxOlderMessages.Location = new System.Drawing.Point(3, 3);
            this.textBoxOlderMessages.Name = "textBoxOlderMessages";
            this.textBoxOlderMessages.Size = new System.Drawing.Size(100, 20);
            this.textBoxOlderMessages.TabIndex = 0;
            // 
            // numericUpDownOlderMessages
            // 
            this.numericUpDownOlderMessages.Location = new System.Drawing.Point(109, 3);
            this.numericUpDownOlderMessages.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownOlderMessages.Name = "numericUpDownOlderMessages";
            this.numericUpDownOlderMessages.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownOlderMessages.TabIndex = 1;
            // 
            // buttonOlderMessages
            // 
            this.buttonOlderMessages.Location = new System.Drawing.Point(235, 3);
            this.buttonOlderMessages.Name = "buttonOlderMessages";
            this.buttonOlderMessages.Size = new System.Drawing.Size(75, 23);
            this.buttonOlderMessages.TabIndex = 2;
            this.buttonOlderMessages.Text = "OlderMessages";
            this.buttonOlderMessages.UseVisualStyleBackColor = true;
            this.buttonOlderMessages.Click += new System.EventHandler(this.buttonOlderMessages_Click);
            // 
            // buttonDeban
            // 
            this.buttonDeban.Location = new System.Drawing.Point(3, 29);
            this.buttonDeban.Name = "buttonDeban";
            this.buttonDeban.Size = new System.Drawing.Size(75, 23);
            this.buttonDeban.TabIndex = 10;
            this.buttonDeban.Text = "Deban";
            this.buttonDeban.UseVisualStyleBackColor = true;
            this.buttonDeban.Click += new System.EventHandler(this.buttonDeban_Click);
            // 
            // PonyboxCommandForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "PonyboxCommandForm";
            this.Text = "PonyboxCommandForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericKick)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOlderMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.NumericUpDown numericKick;
        private System.Windows.Forms.Button buttonKick;
        private System.Windows.Forms.TextBox textBoxChannel;
        private System.Windows.Forms.Button buttonJoin;
        private System.Windows.Forms.Button buttonLeave;
        private System.Windows.Forms.Button buttonListBans;
        private System.Windows.Forms.Button buttonLock;
        private System.Windows.Forms.Button buttonUnlock;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TextBox textBoxOlderMessages;
        private System.Windows.Forms.NumericUpDown numericUpDownOlderMessages;
        private System.Windows.Forms.Button buttonOlderMessages;
        private System.Windows.Forms.Button buttonDeban;
    }
}