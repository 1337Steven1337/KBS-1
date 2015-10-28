﻿using System;

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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelHeader = new System.Windows.Forms.Label();
            this.labelMaster = new System.Windows.Forms.Label();
            this.labelMusic = new System.Windows.Forms.Label();
            this.labelEffects = new System.Windows.Forms.Label();
            this.displayEnemyInfo = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMusicVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEffectsVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarMasterVolume
            // 
            this.trackBarMasterVolume.AutoSize = false;
            this.trackBarMasterVolume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarMasterVolume.Location = new System.Drawing.Point(123, 57);
            this.trackBarMasterVolume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBarMasterVolume.Maximum = 100;
            this.trackBarMasterVolume.Name = "trackBarMasterVolume";
            this.trackBarMasterVolume.Size = new System.Drawing.Size(150, 46);
            this.trackBarMasterVolume.TabIndex = 18;
            this.trackBarMasterVolume.Value = 100;
            this.trackBarMasterVolume.Scroll += new System.EventHandler(this.trackBarMasterVolume_Scroll);
            // 
            // trackBarMusicVolume
            // 
            this.trackBarMusicVolume.AutoSize = false;
            this.trackBarMusicVolume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarMusicVolume.Location = new System.Drawing.Point(123, 114);
            this.trackBarMusicVolume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBarMusicVolume.Maximum = 100;
            this.trackBarMusicVolume.Name = "trackBarMusicVolume";
            this.trackBarMusicVolume.Size = new System.Drawing.Size(150, 46);
            this.trackBarMusicVolume.TabIndex = 18;
            this.trackBarMusicVolume.Value = 100;
            this.trackBarMusicVolume.Scroll += new System.EventHandler(this.trackBarMusicVolume_Scroll);
            // 
            // trackBarEffectsVolume
            // 
            this.trackBarEffectsVolume.AutoSize = false;
            this.trackBarEffectsVolume.Cursor = System.Windows.Forms.Cursors.Hand;
            this.trackBarEffectsVolume.Location = new System.Drawing.Point(123, 171);
            this.trackBarEffectsVolume.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trackBarEffectsVolume.Maximum = 100;
            this.trackBarEffectsVolume.Name = "trackBarEffectsVolume";
            this.trackBarEffectsVolume.Size = new System.Drawing.Size(150, 46);
            this.trackBarEffectsVolume.TabIndex = 18;
            this.trackBarEffectsVolume.Value = 100;
            this.trackBarEffectsVolume.Scroll += new System.EventHandler(this.trackBarEffectsVolume_Scroll);
            // 
            // buttonFullScreen
            // 
            this.buttonFullScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFullScreen.Location = new System.Drawing.Point(9, 318);
            this.buttonFullScreen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFullScreen.Name = "buttonFullScreen";
            this.buttonFullScreen.Size = new System.Drawing.Size(150, 41);
            this.buttonFullScreen.TabIndex = 3;
            this.buttonFullScreen.Text = "Full Screen: On";
            this.buttonFullScreen.UseVisualStyleBackColor = true;
            this.buttonFullScreen.Click += new System.EventHandler(this.buttonFullScreen_Click);
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackToMenu.Location = new System.Drawing.Point(164, 318);
            this.buttonBackToMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(150, 41);
            this.buttonBackToMenu.TabIndex = 4;
            this.buttonBackToMenu.Text = "Back To Menu";
            this.buttonBackToMenu.UseVisualStyleBackColor = true;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TheHunt.Properties.Resources.uitleg;
            this.pictureBox1.Location = new System.Drawing.Point(316, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.Location = new System.Drawing.Point(9, 7);
            this.labelHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(135, 37);
            this.labelHeader.TabIndex = 20;
            this.labelHeader.Text = "Options";
            // 
            // labelMaster
            // 
            this.labelMaster.AutoSize = true;
            this.labelMaster.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaster.Location = new System.Drawing.Point(13, 57);
            this.labelMaster.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMaster.Name = "labelMaster";
            this.labelMaster.Size = new System.Drawing.Size(125, 17);
            this.labelMaster.TabIndex = 21;
            this.labelMaster.Text = "Master Volume: ";
            // 
            // labelMusic
            // 
            this.labelMusic.AutoSize = true;
            this.labelMusic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMusic.Location = new System.Drawing.Point(13, 114);
            this.labelMusic.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelMusic.Name = "labelMusic";
            this.labelMusic.Size = new System.Drawing.Size(117, 17);
            this.labelMusic.TabIndex = 22;
            this.labelMusic.Text = "Music Volume: ";
            // 
            // labelEffects
            // 
            this.labelEffects.AutoSize = true;
            this.labelEffects.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEffects.Location = new System.Drawing.Point(13, 171);
            this.labelEffects.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEffects.Name = "labelEffects";
            this.labelEffects.Size = new System.Drawing.Size(126, 17);
            this.labelEffects.TabIndex = 23;
            this.labelEffects.Text = "Effects Volume: ";
            // 
            // displayEnemyInfo
            // 
            this.displayEnemyInfo.AutoSize = true;
            this.displayEnemyInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayEnemyInfo.Location = new System.Drawing.Point(12, 211);
            this.displayEnemyInfo.Name = "displayEnemyInfo";
            this.displayEnemyInfo.Size = new System.Drawing.Size(280, 21);
            this.displayEnemyInfo.TabIndex = 24;
            this.displayEnemyInfo.Text = "Display info of the closest enemies";
            this.displayEnemyInfo.UseVisualStyleBackColor = true;
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(736, 368);
            this.Controls.Add(this.displayEnemyInfo);
            this.Controls.Add(this.labelEffects);
            this.Controls.Add(this.labelMusic);
            this.Controls.Add(this.labelMaster);
            this.Controls.Add(this.labelHeader);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonBackToMenu);
            this.Controls.Add(this.buttonFullScreen);
            this.Controls.Add(this.trackBarEffectsVolume);
            this.Controls.Add(this.trackBarMusicVolume);
            this.Controls.Add(this.trackBarMasterVolume);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "OptionsDialog";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OptionsDialog";
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMasterVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarMusicVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEffectsVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        





        #endregion

        private System.Windows.Forms.TrackBar trackBarMasterVolume;
        private System.Windows.Forms.TrackBar trackBarMusicVolume;
        private System.Windows.Forms.TrackBar trackBarEffectsVolume;
        private System.Windows.Forms.Button buttonFullScreen;
        private System.Windows.Forms.Button buttonBackToMenu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelHeader;
        private System.Windows.Forms.Label labelMaster;
        private System.Windows.Forms.Label labelMusic;
        private System.Windows.Forms.Label labelEffects;
        private System.Windows.Forms.CheckBox displayEnemyInfo;
    }
}