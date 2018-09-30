namespace PonyboxDesktop
{
    partial class LoggerForm
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
            this.textBoxChannel = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonJoin = new System.Windows.Forms.Button();
            this.buttonLeave = new System.Windows.Forms.Button();
            this.listViewChannels = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxChannel
            // 
            this.textBoxChannel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxChannel.Location = new System.Drawing.Point(3, 3);
            this.textBoxChannel.Name = "textBoxChannel";
            this.textBoxChannel.Size = new System.Drawing.Size(100, 20);
            this.textBoxChannel.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.textBoxChannel);
            this.flowLayoutPanel1.Controls.Add(this.buttonJoin);
            this.flowLayoutPanel1.Controls.Add(this.buttonLeave);
            this.flowLayoutPanel1.Controls.Add(this.listViewChannels);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(284, 261);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // buttonJoin
            // 
            this.buttonJoin.Location = new System.Drawing.Point(3, 29);
            this.buttonJoin.Name = "buttonJoin";
            this.buttonJoin.Size = new System.Drawing.Size(75, 23);
            this.buttonJoin.TabIndex = 1;
            this.buttonJoin.Text = "Join";
            this.buttonJoin.UseVisualStyleBackColor = true;
            this.buttonJoin.Click += new System.EventHandler(this.buttonJoin_Click);
            // 
            // buttonLeave
            // 
            this.buttonLeave.Location = new System.Drawing.Point(3, 58);
            this.buttonLeave.Name = "buttonLeave";
            this.buttonLeave.Size = new System.Drawing.Size(75, 23);
            this.buttonLeave.TabIndex = 2;
            this.buttonLeave.Text = "Leave";
            this.buttonLeave.UseVisualStyleBackColor = true;
            this.buttonLeave.Click += new System.EventHandler(this.buttonLeave_Click);
            // 
            // listViewChannels
            // 
            this.listViewChannels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name});
            this.listViewChannels.Location = new System.Drawing.Point(3, 87);
            this.listViewChannels.Name = "listViewChannels";
            this.listViewChannels.Size = new System.Drawing.Size(269, 162);
            this.listViewChannels.TabIndex = 3;
            this.listViewChannels.UseCompatibleStateImageBehavior = false;
            this.listViewChannels.View = System.Windows.Forms.View.Details;
            // 
            // Name
            // 
            this.Name.Width = 248;
            // 
            // LoggerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.flowLayoutPanel1);
            //this.Name = "LoggerForm";
            this.Text = "LoggerForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxChannel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonJoin;
        private System.Windows.Forms.Button buttonLeave;
        private System.Windows.Forms.ListView listViewChannels;
        private System.Windows.Forms.ColumnHeader Name;
    }
}