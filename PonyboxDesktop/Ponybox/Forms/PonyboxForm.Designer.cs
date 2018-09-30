namespace PonyboxDesktop
{
    partial class PonyboxForm
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxPM = new System.Windows.Forms.TextBox();
            this.tabControlChannels = new System.Windows.Forms.TabControl();
            this.contextMenuStripChannels = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.joinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuStripChannels.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tabControlChannels, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 441);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxMessage, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonOK, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxPM, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 404);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(618, 34);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMessage.Location = new System.Drawing.Point(103, 3);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(462, 20);
            this.textBoxMessage.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOK.Location = new System.Drawing.Point(571, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(44, 28);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBoxPM
            // 
            this.textBoxPM.Location = new System.Drawing.Point(3, 3);
            this.textBoxPM.Name = "textBoxPM";
            this.textBoxPM.Size = new System.Drawing.Size(94, 20);
            this.textBoxPM.TabIndex = 3;
            // 
            // tabControlChannels
            // 
            this.tabControlChannels.ContextMenuStrip = this.contextMenuStripChannels;
            this.tabControlChannels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlChannels.Location = new System.Drawing.Point(3, 3);
            this.tabControlChannels.Name = "tabControlChannels";
            this.tabControlChannels.SelectedIndex = 0;
            this.tabControlChannels.Size = new System.Drawing.Size(618, 395);
            this.tabControlChannels.TabIndex = 2;
            this.tabControlChannels.SelectedIndexChanged += new System.EventHandler(this.tabControlChannels_SelectedIndexChanged);
            // 
            // contextMenuStripChannels
            // 
            this.contextMenuStripChannels.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joinToolStripMenuItem,
            this.leaveToolStripMenuItem});
            this.contextMenuStripChannels.Name = "contextMenuStripChannels";
            this.contextMenuStripChannels.Size = new System.Drawing.Size(105, 48);
            // 
            // joinToolStripMenuItem
            // 
            this.joinToolStripMenuItem.Name = "joinToolStripMenuItem";
            this.joinToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.joinToolStripMenuItem.Text = "Join";
            // 
            // leaveToolStripMenuItem
            // 
            this.leaveToolStripMenuItem.Name = "leaveToolStripMenuItem";
            this.leaveToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.leaveToolStripMenuItem.Text = "Leave";
            this.leaveToolStripMenuItem.Click += new System.EventHandler(this.leaveToolStripMenuItem_Click);
            // 
            // PonyboxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PonyboxForm";
            this.Text = "PonyboxForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.contextMenuStripChannels.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxPM;
        private System.Windows.Forms.TabControl tabControlChannels;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripChannels;
        private System.Windows.Forms.ToolStripMenuItem joinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaveToolStripMenuItem;
    }
}