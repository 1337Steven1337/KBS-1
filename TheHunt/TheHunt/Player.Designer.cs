using System;

namespace TheHunt
{
    partial class Player
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Boolean optionsEnabled = false;
        private Boolean menuEnabled = false;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelMenu = new System.Windows.Forms.Label();
            this.pictureBoxContinue = new System.Windows.Forms.PictureBox();
            this.pictureBoxExitToMenu = new System.Windows.Forms.PictureBox();
            this.pictureBoxOptions = new System.Windows.Forms.PictureBox();
            this.pictureBoxExitToDesktop = new System.Windows.Forms.PictureBox();
            this.pictureBoxOptionsButton = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContinue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToDesktop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptionsButton)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.labelMenu);
            this.panel1.Controls.Add(this.pictureBoxContinue);
            this.panel1.Controls.Add(this.pictureBoxExitToMenu);
            this.panel1.Controls.Add(this.pictureBoxOptions);
            this.panel1.Controls.Add(this.pictureBoxExitToDesktop);
            this.panel1.Location = new System.Drawing.Point(193, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 448);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // labelMenu
            // 
            this.labelMenu.AutoSize = true;
            this.labelMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.2F, System.Drawing.FontStyle.Bold);
            this.labelMenu.Location = new System.Drawing.Point(100, 3);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(187, 70);
            this.labelMenu.TabIndex = 0;
            this.labelMenu.Text = "Menu";
            // 
            // pictureBoxContinue
            // 
            this.pictureBoxContinue.Image = global::TheHunt.Properties.Resources.Continuebutton;
            this.pictureBoxContinue.Location = new System.Drawing.Point(9, 73);
            this.pictureBoxContinue.Name = "pictureBoxContinue";
            this.pictureBoxContinue.Size = new System.Drawing.Size(391, 87);
            this.pictureBoxContinue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxContinue.TabIndex = 3;
            this.pictureBoxContinue.TabStop = false;
            this.pictureBoxContinue.Click += new System.EventHandler(this.pictureBoxContinue_Click);
            // 
            // pictureBoxExitToMenu
            // 
            this.pictureBoxExitToMenu.Image = global::TheHunt.Properties.Resources.ExitToMenuButton;
            this.pictureBoxExitToMenu.Location = new System.Drawing.Point(9, 260);
            this.pictureBoxExitToMenu.Name = "pictureBoxExitToMenu";
            this.pictureBoxExitToMenu.Size = new System.Drawing.Size(391, 87);
            this.pictureBoxExitToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExitToMenu.TabIndex = 4;
            this.pictureBoxExitToMenu.TabStop = false;
            this.pictureBoxExitToMenu.Click += new System.EventHandler(this.pictureBoxExitToMain_Click);
            // 
            // pictureBoxOptions
            // 
            this.pictureBoxOptions.Image = global::TheHunt.Properties.Resources.optionsBtn;
            this.pictureBoxOptions.Location = new System.Drawing.Point(9, 166);
            this.pictureBoxOptions.Name = "pictureBoxOptions";
            this.pictureBoxOptions.Size = new System.Drawing.Size(391, 87);
            this.pictureBoxOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOptions.TabIndex = 5;
            this.pictureBoxOptions.TabStop = false;
            this.pictureBoxOptions.Click += new System.EventHandler(this.pictureBoxOptions_Click);
            // 
            // pictureBoxExitToDesktop
            // 
            this.pictureBoxExitToDesktop.Image = global::TheHunt.Properties.Resources.ExitToDesktopButton;
            this.pictureBoxExitToDesktop.Location = new System.Drawing.Point(9, 355);
            this.pictureBoxExitToDesktop.Name = "pictureBoxExitToDesktop";
            this.pictureBoxExitToDesktop.Size = new System.Drawing.Size(391, 87);
            this.pictureBoxExitToDesktop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExitToDesktop.TabIndex = 6;
            this.pictureBoxExitToDesktop.TabStop = false;
            this.pictureBoxExitToDesktop.Click += new System.EventHandler(this.pictureBoxExitToDesktop_Click);
            // 
            // pictureBoxOptionsButton
            // 
            this.pictureBoxOptionsButton.Image = global::TheHunt.Properties.Resources.options;
            this.pictureBoxOptionsButton.Location = new System.Drawing.Point(727, 696);
            this.pictureBoxOptionsButton.Name = "pictureBoxOptionsButton";
            this.pictureBoxOptionsButton.Size = new System.Drawing.Size(55, 56);
            this.pictureBoxOptionsButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOptionsButton.TabIndex = 3;
            this.pictureBoxOptionsButton.TabStop = false;
            this.pictureBoxOptionsButton.Click += new System.EventHandler(this.pictureBoxOptionsButton_Click);
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.pictureBoxOptionsButton);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Player";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map";
            this.Load += new System.EventHandler(this.Map_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Map_OnKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Map_OnKeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContinue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToDesktop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptionsButton)).EndInit();
            this.ResumeLayout(false);

        }

        private void pictureBoxOptionsButton_Click(object sender, EventArgs e)
        {
            toggleMenu();
            
        }

        private void pictureBoxOptions_Click(object sender, EventArgs e)
        {
            this.Options();
        }

        private void toggleMenu()
        {
            if (!menuEnabled)
            {
                pictureBoxOptionsButton.Visible = false;
                panel1.Visible = true;
                menuEnabled = true;
            }
            else
            {
                if(optionsEnabled == true)
                {
                    pictureBoxOptionsButton.Visible = true;
                }
                
                panel1.Visible = false;
                menuEnabled = false;
            }
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelMenu;
        private System.Windows.Forms.PictureBox pictureBoxContinue;
        private System.Windows.Forms.PictureBox pictureBoxExitToMenu;
        private System.Windows.Forms.PictureBox pictureBoxOptions;
        private System.Windows.Forms.PictureBox pictureBoxExitToDesktop;
        private System.Windows.Forms.PictureBox pictureBoxOptionsButton;
    }
}