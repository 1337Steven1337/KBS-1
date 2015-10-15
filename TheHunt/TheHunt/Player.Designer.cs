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
            this.SuspendLayout();
            // 
            // Player
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Player";
            this.ResumeLayout(false);

        }

        private void pictureBoxOptionsButton_Click(object sender, EventArgs e)
        {
            toggleMenu();
        }

        private void buttonFullScreen_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonBackToMenu_Click(object sender, EventArgs e)
        {
            toggleOptions();
        }

        private void pictureBoxOptions_Click(object sender, EventArgs e)
        {
            toggleOptions();
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

        private void toggleOptions()
        {
            toggleMenu();
            if (!optionsEnabled)
            {
                panelOptions.Visible = true;
                optionsEnabled = true;
            }
            else
            {
                panelOptions.Visible = false;
                optionsEnabled = false;
            }
        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelMenu;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Label labelOptions;
        private System.Windows.Forms.TrackBar trackBarMasterVolume;
        private System.Windows.Forms.Button buttonBackToMenu;
        private System.Windows.Forms.Button buttonFullScreen;
        private System.Windows.Forms.Label labelSoundEffects;
        private System.Windows.Forms.Label labelMusicVolume;
        private System.Windows.Forms.Label labelMasterVolume;
        private System.Windows.Forms.TrackBar trackBarSoundEffects;
        private System.Windows.Forms.TrackBar trackBarMusicVolume;
        private System.Windows.Forms.PictureBox pictureBoxContinue;
        private System.Windows.Forms.PictureBox pictureBoxExitToMenu;
        private System.Windows.Forms.PictureBox pictureBoxOptions;
        private System.Windows.Forms.PictureBox pictureBoxExitToDesktop;
        private System.Windows.Forms.PictureBox pictureBoxOptionsButton;
    }
}