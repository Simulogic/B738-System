namespace B738_System
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.XPConnectButton = new System.Windows.Forms.Button();
            this.MSFSConnectButton = new System.Windows.Forms.Button();
            this.DisconnectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(159, 104);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // XPConnectButton
            // 
            this.XPConnectButton.Location = new System.Drawing.Point(274, 94);
            this.XPConnectButton.Name = "XPConnectButton";
            this.XPConnectButton.Size = new System.Drawing.Size(117, 23);
            this.XPConnectButton.TabIndex = 1;
            this.XPConnectButton.Text = "Connect to XPlane";
            this.XPConnectButton.UseVisualStyleBackColor = true;
            this.XPConnectButton.Click += new System.EventHandler(this.ConnectXP_Button);
            // 
            // MSFSConnectButton
            // 
            this.MSFSConnectButton.Location = new System.Drawing.Point(397, 94);
            this.MSFSConnectButton.Name = "MSFSConnectButton";
            this.MSFSConnectButton.Size = new System.Drawing.Size(117, 23);
            this.MSFSConnectButton.TabIndex = 2;
            this.MSFSConnectButton.Text = "Connect to MSFS";
            this.MSFSConnectButton.UseVisualStyleBackColor = true;
            this.MSFSConnectButton.Click += new System.EventHandler(this.ConnectMSFS_Button);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Location = new System.Drawing.Point(335, 398);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(117, 23);
            this.DisconnectButton.TabIndex = 3;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.UseVisualStyleBackColor = true;
            this.DisconnectButton.Visible = false;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DisconnectButton);
            this.Controls.Add(this.MSFSConnectButton);
            this.Controls.Add(this.XPConnectButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button XPConnectButton;
        private System.Windows.Forms.Button MSFSConnectButton;
        private System.Windows.Forms.Button DisconnectButton;
    }
}