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
            this.pictureBoxExitToMenu = new System.Windows.Forms.PictureBox();
            this.pictureBoxExitToDesktop = new System.Windows.Forms.PictureBox();
            this.labelMenu = new System.Windows.Forms.Label();
            this.pictureBoxOptions = new System.Windows.Forms.PictureBox();
            this.pictureBoxContinue = new System.Windows.Forms.PictureBox();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.labelOptions = new System.Windows.Forms.Label();
            this.trackBarMasterVolume = new System.Windows.Forms.TrackBar();
            this.trackBarMusicVolume = new System.Windows.Forms.TrackBar();
            this.trackBarSoundEffects = new System.Windows.Forms.TrackBar();
            this.labelMasterVolume = new System.Windows.Forms.Label();
            this.labelMusicVolume = new System.Windows.Forms.Label();
            this.labelSoundEffects = new System.Windows.Forms.Label();
            this.buttonFullScreen = new System.Windows.Forms.Button();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.pictureBoxOptionsButton = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToDesktop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContinue)).BeginInit();
            this.panelOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMusicVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSoundEffects)).BeginInit();
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
            // pictureBoxExitToMenu
            // 
            this.pictureBoxExitToMenu.Image = global::TheHunt.Properties.Resources.ExitToMenuButton;
            this.pictureBoxExitToMenu.Location = new System.Drawing.Point(9, 260);
            this.pictureBoxExitToMenu.Name = "pictureBoxExitToMenu";
            this.pictureBoxExitToMenu.Size = new System.Drawing.Size(391, 87);
            this.pictureBoxExitToMenu.TabIndex = 4;
            this.pictureBoxExitToMenu.TabStop = false;
            this.pictureBoxExitToMenu.Click += new System.EventHandler(this.pictureBoxExitToMain_Click);
            // 
            // pictureBoxExitToDesktop
            // 
            this.pictureBoxExitToDesktop.Image = global::TheHunt.Properties.Resources.ExitToDesktopButton;
            this.pictureBoxExitToDesktop.Location = new System.Drawing.Point(9, 355);
            this.pictureBoxExitToDesktop.Name = "pictureBoxExitToDesktop";
            this.pictureBoxExitToDesktop.Size = new System.Drawing.Size(391, 87);
            this.pictureBoxExitToDesktop.TabIndex = 6;
            this.pictureBoxExitToDesktop.TabStop = false;
            this.pictureBoxExitToDesktop.Click += new System.EventHandler(this.pictureBoxExitToDesktop_Click);
            // 
            // labelMenu
            // 
            this.labelMenu.AutoSize = true;
            this.labelMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.2F, System.Drawing.FontStyle.Bold);
            this.labelMenu.Location = new System.Drawing.Point(125, 0);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(187, 70);
            this.labelMenu.TabIndex = 0;
            this.labelMenu.Text = "Menu";
            // 
            // pictureBoxOptions
            // 
            this.pictureBoxOptions.Image = global::TheHunt.Properties.Resources.optionsBtn;
            this.pictureBoxOptions.Location = new System.Drawing.Point(9, 166);
            this.pictureBoxOptions.Name = "pictureBoxOptions";
            this.pictureBoxOptions.Size = new System.Drawing.Size(391, 87);
            this.pictureBoxOptions.TabIndex = 5;
            this.pictureBoxOptions.TabStop = false;
            this.pictureBoxOptions.Click += new System.EventHandler(this.pictureBoxOptions_Click);
            // 
            // pictureBoxContinue
            // 
            this.pictureBoxContinue.Image = global::TheHunt.Properties.Resources.Continuebutton;
            this.pictureBoxContinue.Location = new System.Drawing.Point(9, 73);
            this.pictureBoxContinue.Name = "pictureBoxContinue";
            this.pictureBoxContinue.Size = new System.Drawing.Size(391, 87);
            this.pictureBoxContinue.TabIndex = 3;
            this.pictureBoxContinue.TabStop = false;
            this.pictureBoxContinue.Click += new System.EventHandler(this.pictureBoxContinue_Click);
            // 
            // panelOptions
            // 
            this.panelOptions.Controls.Add(this.labelOptions);
            this.panelOptions.Controls.Add(this.trackBarMasterVolume);
            this.panelOptions.Controls.Add(this.trackBarMusicVolume);
            this.panelOptions.Controls.Add(this.trackBarSoundEffects);
            this.panelOptions.Controls.Add(this.labelMasterVolume);
            this.panelOptions.Controls.Add(this.labelMusicVolume);
            this.panelOptions.Controls.Add(this.labelSoundEffects);
            this.panelOptions.Controls.Add(this.buttonFullScreen);
            this.panelOptions.Controls.Add(this.buttonBackToMenu);
            this.panelOptions.Location = new System.Drawing.Point(139, 112);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(507, 317);
            this.panelOptions.TabIndex = 2;
            this.panelOptions.Visible = false;
            // 
            // labelOptions
            // 
            this.labelOptions.AutoSize = true;
            this.labelOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.2F, System.Drawing.FontStyle.Bold);
            this.labelOptions.Location = new System.Drawing.Point(16, 14);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(248, 70);
            this.labelOptions.TabIndex = 0;
            this.labelOptions.Text = "Options";
            // 
            // trackBarMasterVolume
            // 
            this.trackBarMasterVolume.Location = new System.Drawing.Point(296, 93);
            this.trackBarMasterVolume.Maximum = 100;
            this.trackBarMasterVolume.Name = "trackBarMasterVolume";
            this.trackBarMasterVolume.Size = new System.Drawing.Size(200, 56);
            this.trackBarMasterVolume.TabIndex = 1;
            // 
            // trackBarMusicVolume
            // 
            this.trackBarMusicVolume.Location = new System.Drawing.Point(296, 155);
            this.trackBarMusicVolume.Maximum = 100;
            this.trackBarMusicVolume.Name = "trackBarMusicVolume";
            this.trackBarMusicVolume.Size = new System.Drawing.Size(200, 56);
            this.trackBarMusicVolume.TabIndex = 2;
            // 
            // trackBarSoundEffects
            // 
            this.trackBarSoundEffects.Location = new System.Drawing.Point(296, 217);
            this.trackBarSoundEffects.Maximum = 100;
            this.trackBarSoundEffects.Name = "trackBarSoundEffects";
            this.trackBarSoundEffects.Size = new System.Drawing.Size(200, 56);
            this.trackBarSoundEffects.TabIndex = 3;
            // 
            // labelMasterVolume
            // 
            this.labelMasterVolume.AutoSize = true;
            this.labelMasterVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelMasterVolume.Location = new System.Drawing.Point(22, 93);
            this.labelMasterVolume.Name = "labelMasterVolume";
            this.labelMasterVolume.Size = new System.Drawing.Size(203, 31);
            this.labelMasterVolume.TabIndex = 4;
            this.labelMasterVolume.Text = "Master Volume:";
            // 
            // labelMusicVolume
            // 
            this.labelMusicVolume.AutoSize = true;
            this.labelMusicVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelMusicVolume.Location = new System.Drawing.Point(19, 155);
            this.labelMusicVolume.Name = "labelMusicVolume";
            this.labelMusicVolume.Size = new System.Drawing.Size(191, 31);
            this.labelMusicVolume.TabIndex = 5;
            this.labelMusicVolume.Text = "Music Volume:";
            // 
            // labelSoundEffects
            // 
            this.labelSoundEffects.AutoSize = true;
            this.labelSoundEffects.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelSoundEffects.Location = new System.Drawing.Point(19, 217);
            this.labelSoundEffects.Name = "labelSoundEffects";
            this.labelSoundEffects.Size = new System.Drawing.Size(205, 31);
            this.labelSoundEffects.TabIndex = 6;
            this.labelSoundEffects.Text = "Effects Volume:";
            // 
            // buttonFullScreen
            // 
            this.buttonFullScreen.Location = new System.Drawing.Point(25, 264);
            this.buttonFullScreen.Name = "buttonFullScreen";
            this.buttonFullScreen.Size = new System.Drawing.Size(150, 40);
            this.buttonFullScreen.TabIndex = 7;
            this.buttonFullScreen.Text = "Full Screen: Off";
            this.buttonFullScreen.UseVisualStyleBackColor = true;
            this.buttonFullScreen.Click += new System.EventHandler(this.buttonFullScreen_Click);
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.Location = new System.Drawing.Point(194, 264);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(150, 40);
            this.buttonBackToMenu.TabIndex = 8;
            this.buttonBackToMenu.Text = "Back To Menu";
            this.buttonBackToMenu.UseVisualStyleBackColor = true;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click);
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
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.panel1);
            this.Name = "Player";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map";
            this.Load += new System.EventHandler(this.Map_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Map_OnKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Map_OnKeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToDesktop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContinue)).EndInit();
            this.panelOptions.ResumeLayout(false);
            this.panelOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMusicVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSoundEffects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptionsButton)).EndInit();
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