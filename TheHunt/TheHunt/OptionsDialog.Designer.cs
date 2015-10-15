using System;

namespace TheHunt
{
    partial class OptionsDialog
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
            this.trackBarMasterVolume = new System.Windows.Forms.TrackBar();
            this.trackBarMusicVolume = new System.Windows.Forms.TrackBar();
            this.trackBarEffectsVolume = new System.Windows.Forms.TrackBar();
            this.buttonFullScreen = new System.Windows.Forms.Button();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMusicVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEffectsVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarMasterVolume
            // 
            this.trackBarMasterVolume.Location = new System.Drawing.Point(161, 10);
            this.trackBarMasterVolume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBarMasterVolume.Maximum = 100;
            this.trackBarMasterVolume.Name = "trackBarMasterVolume";
            this.trackBarMasterVolume.Size = new System.Drawing.Size(150, 45);
            this.trackBarMasterVolume.TabIndex = 18;
            int MasterValue = (int)Math.Ceiling(Properties.Sound.Default.master);
            this.trackBarMasterVolume.Value = MasterValue;
            this.trackBarMasterVolume.Scroll += new System.EventHandler(this.trackBarMasterVolume_Scroll);
            // 
            // trackBarMusicVolume
            // 
            this.trackBarMusicVolume.Location = new System.Drawing.Point(161, 60);
            this.trackBarMusicVolume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBarMusicVolume.Maximum = 100;
            this.trackBarMusicVolume.Name = "trackBarMusicVolume";
            this.trackBarMusicVolume.Size = new System.Drawing.Size(150, 45);
            this.trackBarMusicVolume.TabIndex = 18;
            int MusicValue = (int)Math.Ceiling(Properties.Sound.Default.music);
            this.trackBarMusicVolume.Value = MusicValue;
            this.trackBarMusicVolume.Scroll += new System.EventHandler(this.trackBarMusicVolume_Scroll);
            // 
            // trackBarEffectsVolume
            // 
            this.trackBarEffectsVolume.Location = new System.Drawing.Point(161, 110);
            this.trackBarEffectsVolume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBarEffectsVolume.Maximum = 100;
            this.trackBarEffectsVolume.Name = "trackBarEffectsVolume";
            this.trackBarEffectsVolume.Size = new System.Drawing.Size(150, 45);
            this.trackBarEffectsVolume.TabIndex = 18;
            int EffectValue = (int)Math.Ceiling(Properties.Sound.Default.effects);
            this.trackBarEffectsVolume.Value = EffectValue;
            this.trackBarEffectsVolume.Scroll += new System.EventHandler(this.trackBarEffectsVolume_Scroll);
            // 
            // buttonFullScreen
            // 
            this.buttonFullScreen.Location = new System.Drawing.Point(161, 161);
            this.buttonFullScreen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFullScreen.Name = "buttonFullScreen";
            this.buttonFullScreen.Size = new System.Drawing.Size(112, 24);
            this.buttonFullScreen.TabIndex = 3;
            this.buttonFullScreen.Text = "Full Screen: On";
            this.buttonFullScreen.UseVisualStyleBackColor = true;
            this.buttonFullScreen.Click += new System.EventHandler(this.buttonFullScreen_Click);
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.Location = new System.Drawing.Point(161, 190);
            this.buttonBackToMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(112, 24);
            this.buttonBackToMenu.TabIndex = 4;
            this.buttonBackToMenu.Text = "Back To Menu";
            this.buttonBackToMenu.UseVisualStyleBackColor = true;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click);
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 244);
            this.Controls.Add(this.buttonBackToMenu);
            this.Controls.Add(this.buttonFullScreen);
            this.Controls.Add(this.trackBarEffectsVolume);
            this.Controls.Add(this.trackBarMusicVolume);
            this.Controls.Add(this.trackBarMasterVolume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "OptionsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OptionsDialog";
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMusicVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEffectsVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        



        #endregion

        private System.Windows.Forms.TrackBar trackBarMasterVolume;
        private System.Windows.Forms.TrackBar trackBarMusicVolume;
        private System.Windows.Forms.TrackBar trackBarEffectsVolume;
        private System.Windows.Forms.Button buttonFullScreen;
        private System.Windows.Forms.Button buttonBackToMenu;
    }
}