using System;
using System.Drawing;
using System.Windows.Forms;

namespace TheHunt
{
    partial class Form1
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
            
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.buttonFuSc = new System.Windows.Forms.Button();
            this.buttonContr = new System.Windows.Forms.Button();
            this.labelOptionsHeader = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::TheHunt.Properties.Resources.playBtn;
            this.pictureBox1.Location = new System.Drawing.Point(448, 52);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(614, 150);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btn_PlayGame);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TheHunt.Properties.Resources.crlvBtn;
            this.pictureBox2.Location = new System.Drawing.Point(448, 212);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(614, 150);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.speelKlikGeluid);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::TheHunt.Properties.Resources.highscores;
            this.pictureBox3.Location = new System.Drawing.Point(448, 370);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(614, 152);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.speelKlikGeluid);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::TheHunt.Properties.Resources.optionsBtn;
            this.pictureBox4.Location = new System.Drawing.Point(448, 532);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(614, 150);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::TheHunt.Properties.Resources.exitBtn;
            this.pictureBox5.Location = new System.Drawing.Point(448, 690);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(614, 146);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.Afsluiten);
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
            // buttonContr
            // 
            this.buttonContr.AutoSize = true;
            this.buttonContr.Location = new System.Drawing.Point(297, 412);
            this.buttonContr.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonContr.Name = "buttonContr";
            this.buttonContr.Size = new System.Drawing.Size(169, 50);
            this.buttonContr.TabIndex = 14;
            this.buttonContr.Text = "Controls";
            this.buttonContr.UseVisualStyleBackColor = true;
            this.buttonContr.Visible = false;
            this.buttonContr.Click += new System.EventHandler(this.buttonContr_Click);
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
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(268, 166);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(225, 69);
            this.trackBar1.TabIndex = 18;
            this.trackBar1.Value = 10;
            this.trackBar1.Visible = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.trackBar3);
            this.panel1.Controls.Add(this.trackBar2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.labelOptionsHeader);
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.buttonContr);
            this.panel1.Controls.Add(this.buttonFuSc);
            this.panel1.Location = new System.Drawing.Point(253, 155);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 504);
            this.panel1.TabIndex = 19;
            this.panel1.Visible = false;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox6.Location = new System.Drawing.Point(577, 108);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(341, 354);
            this.pictureBox6.TabIndex = 24;
            this.pictureBox6.TabStop = false;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(268, 287);
            this.trackBar3.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(225, 69);
            this.trackBar3.TabIndex = 23;
            this.trackBar3.Value = 50;
            this.trackBar3.Visible = false;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(268, 226);
            this.trackBar2.Margin = new System.Windows.Forms.Padding(2);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(225, 69);
            this.trackBar2.TabIndex = 22;
            this.trackBar2.Value = 50;
            this.trackBar2.Visible = false;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(18, 298);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 37);
            this.label3.TabIndex = 21;
            this.label3.Text = "Effects Volume";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(18, 226);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(227, 37);
            this.label2.TabIndex = 20;
            this.label2.Text = "Music Volume:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 166);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 37);
            this.label1.TabIndex = 19;
            this.label1.Text = "Master Volume:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TheHunt.Properties.Resources.achtergrond;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Hunt";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);

        }

        private void buttonControlsOk_Click(object sender, EventArgs e)
        {
            labelOptionsHeader.Visible = true;
            buttonFuSc.Visible = true;
            buttonContr.Visible = true;
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

        //In de onderstaande variabele wordt actief bijgehouden of de applicatie fullscreen draait
        private Boolean goFullScreen = true;

        private void buttonFuSc_Click(object sender, EventArgs e)
        {
            GoFullscreen(goFullScreen);
        }








        private void pictureBox3_click(object sender, EventArgs e)
        {

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button buttonFuSc;
        private System.Windows.Forms.Button buttonContr;
        private System.Windows.Forms.Label labelOptionsHeader;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private PictureBox pictureBox6;
    }
}

