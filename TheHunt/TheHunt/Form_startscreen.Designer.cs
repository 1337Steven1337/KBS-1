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
            ((System.ComponentModel.ISupportInitialize)(this.PlayBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CreateLvlBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HighscoreBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitBtn)).BeginInit();
            this.SuspendLayout();
            // 
            // PlayBtn
            // 
            this.PlayBtn.BackColor = System.Drawing.Color.Transparent;
            this.PlayBtn.Image = global::TheHunt.Properties.Resources.playBtn;
            this.PlayBtn.Location = new System.Drawing.Point(398, 42);
            this.PlayBtn.Margin = new System.Windows.Forms.Padding(4);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(546, 120);
            this.PlayBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PlayBtn.TabIndex = 5;
            this.PlayBtn.TabStop = false;
            this.PlayBtn.Click += new System.EventHandler(this.btn_PlayGame);
            // 
            // CreateLvlBtn
            // 
            this.CreateLvlBtn.BackColor = System.Drawing.Color.Transparent;
            this.CreateLvlBtn.Image = global::TheHunt.Properties.Resources.crlvBtn;
            this.CreateLvlBtn.Location = new System.Drawing.Point(398, 170);
            this.CreateLvlBtn.Margin = new System.Windows.Forms.Padding(4);
            this.CreateLvlBtn.Name = "CreateLvlBtn";
            this.CreateLvlBtn.Size = new System.Drawing.Size(546, 120);
            this.CreateLvlBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.CreateLvlBtn.TabIndex = 6;
            this.CreateLvlBtn.TabStop = false;
            this.CreateLvlBtn.Click += new System.EventHandler(this.openDesigner);
            // 
            // HighscoreBtn
            // 
            this.HighscoreBtn.BackColor = System.Drawing.Color.Transparent;
            this.HighscoreBtn.Image = global::TheHunt.Properties.Resources.highscores;
            this.HighscoreBtn.Location = new System.Drawing.Point(398, 296);
            this.HighscoreBtn.Margin = new System.Windows.Forms.Padding(4);
            this.HighscoreBtn.Name = "HighscoreBtn";
            this.HighscoreBtn.Size = new System.Drawing.Size(546, 122);
            this.HighscoreBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.HighscoreBtn.TabIndex = 7;
            this.HighscoreBtn.TabStop = false;
            this.HighscoreBtn.Click += new System.EventHandler(this.speelKlikGeluid);
            // 
            // optionBtn
            // 
            this.optionBtn.BackColor = System.Drawing.Color.Transparent;
            this.optionBtn.Image = global::TheHunt.Properties.Resources.optionsBtn;
            this.optionBtn.Location = new System.Drawing.Point(398, 426);
            this.optionBtn.Margin = new System.Windows.Forms.Padding(4);
            this.optionBtn.Name = "optionBtn";
            this.optionBtn.Size = new System.Drawing.Size(546, 120);
            this.optionBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.optionBtn.TabIndex = 8;
            this.optionBtn.TabStop = false;
            this.optionBtn.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Transparent;
            this.exitBtn.Image = global::TheHunt.Properties.Resources.exitBtn;
            this.exitBtn.Location = new System.Drawing.Point(398, 552);
            this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(546, 117);
            this.exitBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.exitBtn.TabIndex = 9;
            this.exitBtn.TabStop = false;
            this.exitBtn.Click += new System.EventHandler(this.Afsluiten);
            // 
            // form_startscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheHunt.Properties.Resources.achtergrond;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1138, 576);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.optionBtn);
            this.Controls.Add(this.HighscoreBtn);
            this.Controls.Add(this.CreateLvlBtn);
            this.Controls.Add(this.PlayBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
            this.ResumeLayout(false);

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
    }
}

