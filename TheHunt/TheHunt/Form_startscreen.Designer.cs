using System;
using System.Drawing;
using System.Windows.Forms;

namespace TheHunt
{
    partial class Form_startscreen
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
            this.picturebox_play_game_btn = new System.Windows.Forms.PictureBox();
            this.picturebox_create_level_btn = new System.Windows.Forms.PictureBox();
            this.picturebox_highscore_btn = new System.Windows.Forms.PictureBox();
            this.picturebox_options_btn = new System.Windows.Forms.PictureBox();
            this.picturebox_exit_game = new System.Windows.Forms.PictureBox();
            this.fullscreen_btn = new System.Windows.Forms.Button();
            this.label_options_header = new System.Windows.Forms.Label();
            this.mastervol_trackbar = new System.Windows.Forms.TrackBar();
            this.panel_options = new System.Windows.Forms.Panel();
            this.picturebox_infotext = new System.Windows.Forms.PictureBox();
            this.effectvol_trackbar = new System.Windows.Forms.TrackBar();
            this.musicvol_trackbar = new System.Windows.Forms.TrackBar();
            this.label_effects_volume = new System.Windows.Forms.Label();
            this.label_music_volume = new System.Windows.Forms.Label();
            this.label_master_volume = new System.Windows.Forms.Label();
            this.picturebox_back_btn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_play_game_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_create_level_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_highscore_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_options_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_exit_game)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mastervol_trackbar)).BeginInit();
            this.panel_options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_infotext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.effectvol_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicvol_trackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_back_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // picturebox_play_game_btn
            // 
            this.picturebox_play_game_btn.BackColor = System.Drawing.Color.Transparent;
            this.picturebox_play_game_btn.Image = global::TheHunt.Properties.Resources.playBtn;
            this.picturebox_play_game_btn.Location = new System.Drawing.Point(398, 42);
            this.picturebox_play_game_btn.Margin = new System.Windows.Forms.Padding(4);
            this.picturebox_play_game_btn.Name = "picturebox_play_game_btn";
            this.picturebox_play_game_btn.Size = new System.Drawing.Size(546, 120);
            this.picturebox_play_game_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picturebox_play_game_btn.TabIndex = 5;
            this.picturebox_play_game_btn.TabStop = false;
            this.picturebox_play_game_btn.Click += new System.EventHandler(this.btn_PlayGame);
            // 
            // picturebox_create_level_btn
            // 
            this.picturebox_create_level_btn.BackColor = System.Drawing.Color.Transparent;
            this.picturebox_create_level_btn.Image = global::TheHunt.Properties.Resources.crlvBtn;
            this.picturebox_create_level_btn.Location = new System.Drawing.Point(398, 170);
            this.picturebox_create_level_btn.Margin = new System.Windows.Forms.Padding(4);
            this.picturebox_create_level_btn.Name = "picturebox_create_level_btn";
            this.picturebox_create_level_btn.Size = new System.Drawing.Size(546, 120);
            this.picturebox_create_level_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picturebox_create_level_btn.TabIndex = 6;
            this.picturebox_create_level_btn.TabStop = false;
            this.picturebox_create_level_btn.Click += new System.EventHandler(this.speelKlikGeluid);
            // 
            // picturebox_highscore_btn
            // 
            this.picturebox_highscore_btn.BackColor = System.Drawing.Color.Transparent;
            this.picturebox_highscore_btn.Image = global::TheHunt.Properties.Resources.highscores;
            this.picturebox_highscore_btn.Location = new System.Drawing.Point(398, 296);
            this.picturebox_highscore_btn.Margin = new System.Windows.Forms.Padding(4);
            this.picturebox_highscore_btn.Name = "picturebox_highscore_btn";
            this.picturebox_highscore_btn.Size = new System.Drawing.Size(546, 122);
            this.picturebox_highscore_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picturebox_highscore_btn.TabIndex = 7;
            this.picturebox_highscore_btn.TabStop = false;
            this.picturebox_highscore_btn.Click += new System.EventHandler(this.speelKlikGeluid);
            // 
            // picturebox_options_btn
            // 
            this.picturebox_options_btn.BackColor = System.Drawing.Color.Transparent;
            this.picturebox_options_btn.Image = global::TheHunt.Properties.Resources.optionsBtn;
            this.picturebox_options_btn.Location = new System.Drawing.Point(398, 426);
            this.picturebox_options_btn.Margin = new System.Windows.Forms.Padding(4);
            this.picturebox_options_btn.Name = "picturebox_options_btn";
            this.picturebox_options_btn.Size = new System.Drawing.Size(546, 120);
            this.picturebox_options_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picturebox_options_btn.TabIndex = 8;
            this.picturebox_options_btn.TabStop = false;
            this.picturebox_options_btn.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // picturebox_exit_game
            // 
            this.picturebox_exit_game.BackColor = System.Drawing.Color.Transparent;
            this.picturebox_exit_game.Image = global::TheHunt.Properties.Resources.exitBtn;
            this.picturebox_exit_game.Location = new System.Drawing.Point(398, 552);
            this.picturebox_exit_game.Margin = new System.Windows.Forms.Padding(4);
            this.picturebox_exit_game.Name = "picturebox_exit_game";
            this.picturebox_exit_game.Size = new System.Drawing.Size(546, 117);
            this.picturebox_exit_game.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picturebox_exit_game.TabIndex = 9;
            this.picturebox_exit_game.TabStop = false;
            this.picturebox_exit_game.Click += new System.EventHandler(this.Afsluiten);
            // 
            // fullscreen_btn
            // 
            this.fullscreen_btn.AutoSize = true;
            this.fullscreen_btn.Location = new System.Drawing.Point(72, 330);
            this.fullscreen_btn.Margin = new System.Windows.Forms.Padding(2);
            this.fullscreen_btn.Name = "fullscreen_btn";
            this.fullscreen_btn.Size = new System.Drawing.Size(150, 40);
            this.fullscreen_btn.TabIndex = 13;
            this.fullscreen_btn.Text = "Full Screen: Off";
            this.fullscreen_btn.UseVisualStyleBackColor = true;
            this.fullscreen_btn.Visible = false;
            this.fullscreen_btn.Click += new System.EventHandler(this.buttonFuSc_Click);
            // 
            // label_options_header
            // 
            this.label_options_header.AutoSize = true;
            this.label_options_header.BackColor = System.Drawing.Color.Transparent;
            this.label_options_header.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.2F, System.Drawing.FontStyle.Bold);
            this.label_options_header.ForeColor = System.Drawing.Color.White;
            this.label_options_header.Location = new System.Drawing.Point(22, 14);
            this.label_options_header.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_options_header.Name = "label_options_header";
            this.label_options_header.Size = new System.Drawing.Size(248, 70);
            this.label_options_header.TabIndex = 17;
            this.label_options_header.Text = "Options";
            this.label_options_header.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_options_header.Visible = false;
            // 
            // mastervol_trackbar
            // 
            this.mastervol_trackbar.Location = new System.Drawing.Point(238, 133);
            this.mastervol_trackbar.Margin = new System.Windows.Forms.Padding(2);
            this.mastervol_trackbar.Maximum = 100;
            this.mastervol_trackbar.Name = "mastervol_trackbar";
            this.mastervol_trackbar.Size = new System.Drawing.Size(200, 56);
            this.mastervol_trackbar.TabIndex = 18;
            this.mastervol_trackbar.Value = 10;
            this.mastervol_trackbar.Visible = false;
            this.mastervol_trackbar.Scroll += new System.EventHandler(this.mastervol_trackbar_Scroll);
            // 
            // panel_options
            // 
            this.panel_options.Controls.Add(this.picturebox_infotext);
            this.panel_options.Controls.Add(this.effectvol_trackbar);
            this.panel_options.Controls.Add(this.musicvol_trackbar);
            this.panel_options.Controls.Add(this.label_effects_volume);
            this.panel_options.Controls.Add(this.label_music_volume);
            this.panel_options.Controls.Add(this.label_master_volume);
            this.panel_options.Controls.Add(this.label_options_header);
            this.panel_options.Controls.Add(this.mastervol_trackbar);
            this.panel_options.Controls.Add(this.fullscreen_btn);
            this.panel_options.Location = new System.Drawing.Point(940, 75);
            this.panel_options.Margin = new System.Windows.Forms.Padding(2);
            this.panel_options.Name = "panel_options";
            this.panel_options.Size = new System.Drawing.Size(865, 403);
            this.panel_options.TabIndex = 19;
            this.panel_options.Visible = false;
            this.panel_options.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // picturebox_infotext
            // 
            this.picturebox_infotext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picturebox_infotext.Location = new System.Drawing.Point(513, 86);
            this.picturebox_infotext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picturebox_infotext.Name = "picturebox_infotext";
            this.picturebox_infotext.Size = new System.Drawing.Size(303, 283);
            this.picturebox_infotext.TabIndex = 24;
            this.picturebox_infotext.TabStop = false;
            this.picturebox_infotext.Visible = false;
            // 
            // effectvol_trackbar
            // 
            this.effectvol_trackbar.Location = new System.Drawing.Point(238, 230);
            this.effectvol_trackbar.Margin = new System.Windows.Forms.Padding(2);
            this.effectvol_trackbar.Maximum = 100;
            this.effectvol_trackbar.Name = "effectvol_trackbar";
            this.effectvol_trackbar.Size = new System.Drawing.Size(200, 56);
            this.effectvol_trackbar.TabIndex = 23;
            this.effectvol_trackbar.Value = 50;
            this.effectvol_trackbar.Visible = false;
            this.effectvol_trackbar.Scroll += new System.EventHandler(this.effectsvol_trackbar_Scroll);
            // 
            // musicvol_trackbar
            // 
            this.musicvol_trackbar.Location = new System.Drawing.Point(238, 181);
            this.musicvol_trackbar.Margin = new System.Windows.Forms.Padding(2);
            this.musicvol_trackbar.Maximum = 100;
            this.musicvol_trackbar.Name = "musicvol_trackbar";
            this.musicvol_trackbar.Size = new System.Drawing.Size(200, 56);
            this.musicvol_trackbar.TabIndex = 22;
            this.musicvol_trackbar.Value = 50;
            this.musicvol_trackbar.Visible = false;
            this.musicvol_trackbar.Scroll += new System.EventHandler(this.musicvol_trackbar_Scroll);
            // 
            // label_effects_volume
            // 
            this.label_effects_volume.AutoSize = true;
            this.label_effects_volume.BackColor = System.Drawing.Color.Transparent;
            this.label_effects_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label_effects_volume.ForeColor = System.Drawing.Color.White;
            this.label_effects_volume.Location = new System.Drawing.Point(16, 238);
            this.label_effects_volume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_effects_volume.Name = "label_effects_volume";
            this.label_effects_volume.Size = new System.Drawing.Size(197, 31);
            this.label_effects_volume.TabIndex = 21;
            this.label_effects_volume.Text = "Effects Volume";
            // 
            // label_music_volume
            // 
            this.label_music_volume.AutoSize = true;
            this.label_music_volume.BackColor = System.Drawing.Color.Transparent;
            this.label_music_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label_music_volume.ForeColor = System.Drawing.Color.White;
            this.label_music_volume.Location = new System.Drawing.Point(16, 181);
            this.label_music_volume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_music_volume.Name = "label_music_volume";
            this.label_music_volume.Size = new System.Drawing.Size(191, 31);
            this.label_music_volume.TabIndex = 20;
            this.label_music_volume.Text = "Music Volume:";
            // 
            // label_master_volume
            // 
            this.label_master_volume.AutoSize = true;
            this.label_master_volume.BackColor = System.Drawing.Color.Transparent;
            this.label_master_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label_master_volume.ForeColor = System.Drawing.Color.White;
            this.label_master_volume.Location = new System.Drawing.Point(16, 133);
            this.label_master_volume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_master_volume.Name = "label_master_volume";
            this.label_master_volume.Size = new System.Drawing.Size(203, 31);
            this.label_master_volume.TabIndex = 19;
            this.label_master_volume.Text = "Master Volume:";
            // 
            // picturebox_back_btn
            // 
            this.picturebox_back_btn.BackColor = System.Drawing.Color.Transparent;
            this.picturebox_back_btn.Image = global::TheHunt.Properties.Resources.backBtn;
            this.picturebox_back_btn.Location = new System.Drawing.Point(269, 466);
            this.picturebox_back_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picturebox_back_btn.Name = "picturebox_back_btn";
            this.picturebox_back_btn.Size = new System.Drawing.Size(546, 120);
            this.picturebox_back_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picturebox_back_btn.TabIndex = 25;
            this.picturebox_back_btn.TabStop = false;
            this.picturebox_back_btn.Visible = false;
            // 
            // form_startsreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheHunt.Properties.Resources.achtergrond;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1138, 576);
            this.Controls.Add(this.picturebox_back_btn);
            this.Controls.Add(this.panel_options);
            this.Controls.Add(this.picturebox_exit_game);
            this.Controls.Add(this.picturebox_options_btn);
            this.Controls.Add(this.picturebox_highscore_btn);
            this.Controls.Add(this.picturebox_create_level_btn);
            this.Controls.Add(this.picturebox_play_game_btn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "form_startsreen";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Hunt";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_play_game_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_create_level_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_highscore_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_options_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_exit_game)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mastervol_trackbar)).EndInit();
            this.panel_options.ResumeLayout(false);
            this.panel_options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_infotext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.effectvol_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.musicvol_trackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_back_btn)).EndInit();
            this.ResumeLayout(false);

        }

        private void buttonControlsOk_Click(object sender, EventArgs e)
        {
            label_options_header.Visible = true;
            fullscreen_btn.Visible = true;
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
        private System.Windows.Forms.PictureBox picturebox_play_game_btn;
        private System.Windows.Forms.PictureBox picturebox_create_level_btn;
        private System.Windows.Forms.PictureBox picturebox_highscore_btn;
        private System.Windows.Forms.PictureBox picturebox_options_btn;
        private System.Windows.Forms.PictureBox picturebox_exit_game;
        private System.Windows.Forms.Button fullscreen_btn;
        private System.Windows.Forms.Label label_options_header;
        private System.Windows.Forms.TrackBar mastervol_trackbar;
        private System.Windows.Forms.Panel panel_options;
        private System.Windows.Forms.TrackBar effectvol_trackbar;
        private System.Windows.Forms.TrackBar musicvol_trackbar;
        private System.Windows.Forms.Label label_effects_volume;
        private System.Windows.Forms.Label label_music_volume;
        private System.Windows.Forms.Label label_master_volume;
        private PictureBox picturebox_infotext;
        private PictureBox picturebox_back_btn;
    }
}

