using System;
using System.Drawing;
using System.Windows.Forms;

namespace TheHunt
{
    partial class form_startscreen
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
            this.PlayBtn = new System.Windows.Forms.PictureBox();
            this.CreateLvlBtn = new System.Windows.Forms.PictureBox();
            this.HighscoreBtn = new System.Windows.Forms.PictureBox();
            this.optionBtn = new System.Windows.Forms.PictureBox();
            this.exitBtn = new System.Windows.Forms.PictureBox();
            this.buttonFuSc = new System.Windows.Forms.Button();
            this.labelOptionsHeader = new System.Windows.Forms.Label();
            this.MasterTrackBar = new System.Windows.Forms.TrackBar();
            this.optionPanel = new System.Windows.Forms.Panel();
            this.uitlegPictureBox = new System.Windows.Forms.PictureBox();
            this.EffectsTrackbar = new System.Windows.Forms.TrackBar();
            this.MusicTrackBar = new System.Windows.Forms.TrackBar();
            this.EffectsVolumeLabel = new System.Windows.Forms.Label();
            this.MusicVolumeLabel = new System.Windows.Forms.Label();
            this.MasterVolumeLabel = new System.Windows.Forms.Label();
            this.backBtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PlayBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateLvlBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighscoreBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterTrackBar)).BeginInit();
            this.optionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uitlegPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffectsTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayBtn
            // 
            this.PlayBtn.BackColor = System.Drawing.Color.Transparent;
            this.PlayBtn.Image = global::TheHunt.Properties.Resources.playBtn;
            this.PlayBtn.Location = new System.Drawing.Point(448, 52);
            this.PlayBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(614, 150);
            this.PlayBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PlayBtn.TabIndex = 5;
            this.PlayBtn.TabStop = false;
            this.PlayBtn.Click += new System.EventHandler(this.btn_PlayGame);
            // 
            // CreateLvlBtn
            // 
            this.CreateLvlBtn.BackColor = System.Drawing.Color.Transparent;
            this.CreateLvlBtn.Image = global::TheHunt.Properties.Resources.crlvBtn;
            this.CreateLvlBtn.Location = new System.Drawing.Point(448, 212);
            this.CreateLvlBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateLvlBtn.Name = "CreateLvlBtn";
            this.CreateLvlBtn.Size = new System.Drawing.Size(614, 150);
            this.CreateLvlBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CreateLvlBtn.TabIndex = 6;
            this.CreateLvlBtn.TabStop = false;
            this.CreateLvlBtn.Click += new System.EventHandler(this.openDesigner);
            // 
            // HighscoreBtn
            // 
            this.HighscoreBtn.BackColor = System.Drawing.Color.Transparent;
            this.HighscoreBtn.Image = global::TheHunt.Properties.Resources.highscores;
            this.HighscoreBtn.Location = new System.Drawing.Point(448, 370);
            this.HighscoreBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HighscoreBtn.Name = "HighscoreBtn";
            this.HighscoreBtn.Size = new System.Drawing.Size(614, 152);
            this.HighscoreBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.HighscoreBtn.TabIndex = 7;
            this.HighscoreBtn.TabStop = false;
            this.HighscoreBtn.Click += new System.EventHandler(this.speelKlikGeluid);
            // 
            // optionBtn
            // 
            this.optionBtn.BackColor = System.Drawing.Color.Transparent;
            this.optionBtn.Image = global::TheHunt.Properties.Resources.optionsBtn;
            this.optionBtn.Location = new System.Drawing.Point(448, 532);
            this.optionBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(614, 150);
            this.optionBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.optionBtn.TabIndex = 8;
            this.optionBtn.TabStop = false;
            this.optionBtn.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.Image = global::TheHunt.Properties.Resources.exitBtn;
            this.exitBtn.Location = new System.Drawing.Point(448, 690);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(614, 146);
            this.exitBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.exitBtn.TabIndex = 9;
            this.exitBtn.TabStop = false;
            this.exitBtn.Click += new System.EventHandler(this.Afsluiten);
            // 
            // buttonFuSc
            // 
            this.buttonFuSc.AutoSize = true;
            this.buttonFuSc.Location = new System.Drawing.Point(81, 412);
            this.buttonFuSc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonFuSc.Name = "buttonFuSc";
            this.buttonFuSc.Size = new System.Drawing.Size(169, 50);
            this.buttonFuSc.TabIndex = 13;
            this.buttonFuSc.Text = "Full Screen: Off";
            this.buttonFuSc.UseVisualStyleBackColor = true;
            this.buttonFuSc.Visible = false;
            this.buttonFuSc.Click += new System.EventHandler(this.buttonFuSc_Click);
            // 
            // labelOptionsHeader
            // 
            this.labelOptionsHeader.AutoSize = true;
            this.labelOptionsHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelOptionsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.2F, System.Drawing.FontStyle.Bold);
            this.labelOptionsHeader.ForeColor = System.Drawing.Color.White;
            this.labelOptionsHeader.Location = new System.Drawing.Point(25, 18);
            this.labelOptionsHeader.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelOptionsHeader.Name = "labelOptionsHeader";
            this.labelOptionsHeader.Size = new System.Drawing.Size(296, 83);
            this.labelOptionsHeader.TabIndex = 17;
            this.labelOptionsHeader.Text = "Options";
            this.labelOptionsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelOptionsHeader.Visible = false;
            // 
            // MasterTrackBar
            // 
            this.MasterTrackBar.Location = new System.Drawing.Point(268, 166);
            this.MasterTrackBar.Margin = new System.Windows.Forms.Padding(2);
            this.MasterTrackBar.Maximum = 100;
            this.MasterTrackBar.Name = "MasterTrackBar";
            this.MasterTrackBar.Size = new System.Drawing.Size(225, 69);
            this.MasterTrackBar.TabIndex = 18;
            this.MasterTrackBar.Value = 10;
            this.MasterTrackBar.Visible = false;
            this.MasterTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // optionPanel
            // 
            this.optionPanel.Controls.Add(this.uitlegPictureBox);
            this.optionPanel.Controls.Add(this.EffectsTrackbar);
            this.optionPanel.Controls.Add(this.MusicTrackBar);
            this.optionPanel.Controls.Add(this.EffectsVolumeLabel);
            this.optionPanel.Controls.Add(this.MusicVolumeLabel);
            this.optionPanel.Controls.Add(this.MasterVolumeLabel);
            this.optionPanel.Controls.Add(this.labelOptionsHeader);
            this.optionPanel.Controls.Add(this.MasterTrackBar);
            this.optionPanel.Controls.Add(this.buttonFuSc);
            this.optionPanel.Location = new System.Drawing.Point(902, 318);
            this.optionPanel.Margin = new System.Windows.Forms.Padding(2);
            this.optionPanel.Name = "optionPanel";
            this.optionPanel.Size = new System.Drawing.Size(973, 504);
            this.optionPanel.TabIndex = 19;
            this.optionPanel.Visible = false;
            this.optionPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // uitlegPictureBox
            // 
            this.uitlegPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.uitlegPictureBox.Location = new System.Drawing.Point(577, 108);
            this.uitlegPictureBox.Name = "uitlegPictureBox";
            this.uitlegPictureBox.Size = new System.Drawing.Size(341, 354);
            this.uitlegPictureBox.TabIndex = 24;
            this.uitlegPictureBox.TabStop = false;
            this.uitlegPictureBox.Visible = false;
            // 
            // EffectsTrackbar
            // 
            this.EffectsTrackbar.Location = new System.Drawing.Point(268, 287);
            this.EffectsTrackbar.Margin = new System.Windows.Forms.Padding(2);
            this.EffectsTrackbar.Maximum = 100;
            this.EffectsTrackbar.Name = "EffectsTrackbar";
            this.EffectsTrackbar.Size = new System.Drawing.Size(225, 69);
            this.EffectsTrackbar.TabIndex = 23;
            this.EffectsTrackbar.Value = 50;
            this.EffectsTrackbar.Visible = false;
            this.EffectsTrackbar.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // MusicTrackBar
            // 
            this.MusicTrackBar.Location = new System.Drawing.Point(268, 226);
            this.MusicTrackBar.Margin = new System.Windows.Forms.Padding(2);
            this.MusicTrackBar.Maximum = 100;
            this.MusicTrackBar.Name = "MusicTrackBar";
            this.MusicTrackBar.Size = new System.Drawing.Size(225, 69);
            this.MusicTrackBar.TabIndex = 22;
            this.MusicTrackBar.Value = 50;
            this.MusicTrackBar.Visible = false;
            this.MusicTrackBar.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // EffectsVolumeLabel
            // 
            this.EffectsVolumeLabel.AutoSize = true;
            this.EffectsVolumeLabel.BackColor = System.Drawing.Color.Transparent;
            this.EffectsVolumeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.EffectsVolumeLabel.ForeColor = System.Drawing.Color.White;
            this.EffectsVolumeLabel.Location = new System.Drawing.Point(18, 298);
            this.EffectsVolumeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EffectsVolumeLabel.Name = "EffectsVolumeLabel";
            this.EffectsVolumeLabel.Size = new System.Drawing.Size(232, 37);
            this.EffectsVolumeLabel.TabIndex = 21;
            this.EffectsVolumeLabel.Text = "Effects Volume";
            // 
            // MusicVolumeLabel
            // 
            this.MusicVolumeLabel.AutoSize = true;
            this.MusicVolumeLabel.BackColor = System.Drawing.Color.Transparent;
            this.MusicVolumeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.MusicVolumeLabel.ForeColor = System.Drawing.Color.White;
            this.MusicVolumeLabel.Location = new System.Drawing.Point(18, 226);
            this.MusicVolumeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MusicVolumeLabel.Name = "MusicVolumeLabel";
            this.MusicVolumeLabel.Size = new System.Drawing.Size(227, 37);
            this.MusicVolumeLabel.TabIndex = 20;
            this.MusicVolumeLabel.Text = "Music Volume:";
            // 
            // MasterVolumeLabel
            // 
            this.MasterVolumeLabel.AutoSize = true;
            this.MasterVolumeLabel.BackColor = System.Drawing.Color.Transparent;
            this.MasterVolumeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.MasterVolumeLabel.ForeColor = System.Drawing.Color.White;
            this.MasterVolumeLabel.Location = new System.Drawing.Point(18, 166);
            this.MasterVolumeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MasterVolumeLabel.Name = "MasterVolumeLabel";
            this.MasterVolumeLabel.Size = new System.Drawing.Size(241, 37);
            this.MasterVolumeLabel.TabIndex = 19;
            this.MasterVolumeLabel.Text = "Master Volume:";
            // 
            // backBtn
            // 
            this.backBtn.BackColor = System.Drawing.Color.Transparent;
            this.backBtn.Image = global::TheHunt.Properties.Resources.backBtn;
            this.backBtn.Location = new System.Drawing.Point(-134, 544);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(614, 150);
            this.backBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.backBtn.TabIndex = 25;
            this.backBtn.TabStop = false;
            this.backBtn.Visible = false;
            // 
            // form_startscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheHunt.Properties.Resources.achtergrond;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.optionPanel);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.optionBtn);
            this.Controls.Add(this.HighscoreBtn);
            this.Controls.Add(this.CreateLvlBtn);
            this.Controls.Add(this.PlayBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "form_startscreen";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Hunt";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlayBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateLvlBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighscoreBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MasterTrackBar)).EndInit();
            this.optionPanel.ResumeLayout(false);
            this.optionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uitlegPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffectsTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MusicTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backBtn)).EndInit();
            this.ResumeLayout(false);

        }

        private void buttonControlsOk_Click(object sender, EventArgs e)
        {
            labelOptionsHeader.Visible = true;
            buttonFuSc.Visible = true;
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            //buttonUp.Text = "Press a key...";
            //string key = Console.ReadKey().Key.ToString();
            //buttonUp.Text = "Up: " + key;
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            //buttonDown.Text = "Press a key...";
            //string key = Console.ReadKey().Key.ToString();
            //buttonDown.Text = "Down: " + key;
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            //buttonLeft.Text = "Press a key...";
            //string key = Console.ReadKey().Key.ToString();
            //buttonLeft.Text = "Left: " + key;
        }


        private void buttonContr_Click(object sender, EventArgs e)
        {

        }







        private void pictureBox3_click(object sender, EventArgs e)
        {

        }

        #endregion
        private System.Windows.Forms.PictureBox PlayBtn;
        private System.Windows.Forms.PictureBox CreateLvlBtn;
        private System.Windows.Forms.PictureBox HighscoreBtn;
        private System.Windows.Forms.PictureBox optionBtn;
        private System.Windows.Forms.PictureBox exitBtn;
        private System.Windows.Forms.Button buttonFuSc;
        private System.Windows.Forms.Label labelOptionsHeader;
        private System.Windows.Forms.TrackBar MasterTrackBar;
        private System.Windows.Forms.Panel optionPanel;
        private System.Windows.Forms.TrackBar EffectsTrackbar;
        private System.Windows.Forms.TrackBar MusicTrackBar;
        private System.Windows.Forms.Label EffectsVolumeLabel;
        private System.Windows.Forms.Label MusicVolumeLabel;
        private System.Windows.Forms.Label MasterVolumeLabel;
        private PictureBox uitlegPictureBox;
        private PictureBox backBtn;
    }
}

