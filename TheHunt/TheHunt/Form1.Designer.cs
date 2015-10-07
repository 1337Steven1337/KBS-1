using System;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.OptionsButton = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.buttonSnd = new System.Windows.Forms.Button();
            this.buttonSndEf = new System.Windows.Forms.Button();
            this.buttonSndMu = new System.Windows.Forms.Button();
            this.buttonFuSc = new System.Windows.Forms.Button();
            this.buttonContr = new System.Windows.Forms.Button();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.labelOptionsHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pictureBox1.Image = global::TheHunt.Properties.Resources.Play;
            this.pictureBox1.Location = new System.Drawing.Point(398, 42);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(546, 120);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btn_PlayGame);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TheHunt.Properties.Resources.Levels;
            this.pictureBox2.Location = new System.Drawing.Point(398, 170);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(546, 120);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // OptionsButton
            // 
            this.OptionsButton.Image = global::TheHunt.Properties.Resources.Options;
            this.OptionsButton.Location = new System.Drawing.Point(398, 296);
            this.OptionsButton.Margin = new System.Windows.Forms.Padding(4);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(546, 122);
            this.OptionsButton.TabIndex = 7;
            this.OptionsButton.TabStop = false;
            this.OptionsButton.Click += new System.EventHandler(this.Options_click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::TheHunt.Properties.Resources.Maak_Level;
            this.pictureBox4.Location = new System.Drawing.Point(398, 426);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(546, 120);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::TheHunt.Properties.Resources.Exit;
            this.pictureBox5.Location = new System.Drawing.Point(398, 552);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(546, 117);
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // buttonSnd
            // 
            this.buttonSnd.Location = new System.Drawing.Point(59, 122);
            this.buttonSnd.Name = "buttonSnd";
            this.buttonSnd.Size = new System.Drawing.Size(150, 40);
            this.buttonSnd.TabIndex = 16;
            this.buttonSnd.Text = "Sound: On";
            this.buttonSnd.UseVisualStyleBackColor = true;
            this.buttonSnd.Visible = false;
            //this.buttonSnd.Click += new System.EventHandler(this.buttonSnd_Click);
            // 
            // buttonSndEf
            // 
            this.buttonSndEf.Location = new System.Drawing.Point(59, 168);
            this.buttonSndEf.Name = "buttonSndEf";
            this.buttonSndEf.Size = new System.Drawing.Size(150, 40);
            this.buttonSndEf.TabIndex = 11;
            this.buttonSndEf.Text = "Soundeffects: On";
            this.buttonSndEf.UseVisualStyleBackColor = true;
            this.buttonSndEf.Visible = false;
            this.buttonSndEf.Click += new System.EventHandler(this.buttonSndEf_Click);
            // 
            // buttonSndMu
            // 
            this.buttonSndMu.Location = new System.Drawing.Point(59, 214);
            this.buttonSndMu.Name = "buttonSndMu";
            this.buttonSndMu.Size = new System.Drawing.Size(150, 40);
            this.buttonSndMu.TabIndex = 12;
            this.buttonSndMu.Text = "Music: On";
            this.buttonSndMu.UseVisualStyleBackColor = true;
            this.buttonSndMu.Visible = false;
            this.buttonSndMu.Click += new System.EventHandler(this.buttonSndMu_Click);
            // 
            // buttonFuSc
            // 
            this.buttonFuSc.Location = new System.Drawing.Point(59, 260);
            this.buttonFuSc.Name = "buttonFuSc";
            this.buttonFuSc.Size = new System.Drawing.Size(150, 40);
            this.buttonFuSc.TabIndex = 13;
            this.buttonFuSc.Text = "Full Screen: Off";
            this.buttonFuSc.UseVisualStyleBackColor = true;
            this.buttonFuSc.Visible = false;
            this.buttonFuSc.Click += new System.EventHandler(this.buttonFuSc_Click);
            // 
            // buttonContr
            // 
            this.buttonContr.Location = new System.Drawing.Point(59, 306);
            this.buttonContr.Name = "buttonContr";
            this.buttonContr.Size = new System.Drawing.Size(150, 40);
            this.buttonContr.TabIndex = 14;
            this.buttonContr.Text = "Controls";
            this.buttonContr.UseVisualStyleBackColor = true;
            this.buttonContr.Visible = false;
            this.buttonContr.Click += new System.EventHandler(this.buttonContr_Click);
            // 
            // buttonMenu
            // 
            this.buttonMenu.Location = new System.Drawing.Point(59, 352);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(150, 40);
            this.buttonMenu.TabIndex = 15;
            this.buttonMenu.Text = "Back To Menu";
            this.buttonMenu.UseVisualStyleBackColor = true;
            this.buttonMenu.Visible = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // labelOptionsHeader
            // 
            this.labelOptionsHeader.AutoSize = true;
            this.labelOptionsHeader.BackColor = System.Drawing.Color.Transparent;
            this.labelOptionsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOptionsHeader.ForeColor = System.Drawing.Color.White;
            this.labelOptionsHeader.Location = new System.Drawing.Point(75, 87);
            this.labelOptionsHeader.Name = "labelOptionsHeader";
            this.labelOptionsHeader.Size = new System.Drawing.Size(121, 32);
            this.labelOptionsHeader.TabIndex = 17;
            this.labelOptionsHeader.Text = "Options";
            this.labelOptionsHeader.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.labelOptionsHeader);
            this.Controls.Add(this.buttonMenu);
            this.Controls.Add(this.buttonContr);
            this.Controls.Add(this.buttonFuSc);
            this.Controls.Add(this.buttonSndMu);
            this.Controls.Add(this.buttonSndEf);
            this.Controls.Add(this.buttonSnd);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Hunt";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            buttonSnd.Visible = false;
            buttonSndEf.Visible = false;
            buttonSndMu.Visible = false;
            buttonFuSc.Visible = false;
            buttonContr.Visible = false;
            buttonMenu.Visible = false;
            labelOptionsHeader.Visible = false;
            pictureBox1.Visible = true;
            pictureBox2.Visible = true;
            OptionsButton.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
        }

        private void buttonContr_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonFuSc_Click(object sender, EventArgs e)
        {
            if (buttonFuSc.Text == "Full Screen: On")
            {
                buttonFuSc.Text = "Full Screen: Off";
            }
            else if (buttonFuSc.Text == "Full Screen: Off")
            {
                buttonFuSc.Text = "Full Screen: On";
            }
        }

        private void buttonSndMu_Click(object sender, EventArgs e)
        {
            if (buttonSndMu.Text == "Music: On")
            {
                buttonSndMu.Text = "Music: Off";
            }
            else if (buttonSndMu.Text == "Music: Off")
            {
                buttonSndMu.Text = "Music: On";
            }
        }

        private void buttonSndEf_Click(object sender, EventArgs e)
        {
            if (buttonSndEf.Text == "Soundeffects: On")
            {
                buttonSndEf.Text = "Soundeffects: Off";
        }
            else if (buttonSndEf.Text == "Soundeffects: Off")
            {
                buttonSndEf.Text = "Soundeffects: On";
            }
        }

        //private void buttonSnd_Click(object sender, EventArgs e)
        //{
        //    if(buttonSnd.Text=="Sound: On")
        //    {
        //        buttonSnd.Text = "Sound: Off";
        //    }
        //    else if(buttonSnd.Text=="Sound: Off")
        //    {
        //        buttonSnd.Text = "Sound: On";
        //    }
        //}


        private void Options_click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            OptionsButton.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            labelOptionsHeader.Visible = true;
            buttonSnd.Visible = true;
            buttonSndEf.Visible = true;
            buttonSndMu.Visible = true;
            buttonFuSc.Visible = true;
            buttonContr.Visible = true;
            buttonMenu.Visible = true;
        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox OptionsButton;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button buttonSnd;
        private System.Windows.Forms.Button buttonSndEf;
        private System.Windows.Forms.Button buttonSndMu;
        private System.Windows.Forms.Button buttonFuSc;
        private System.Windows.Forms.Button buttonContr;
        private System.Windows.Forms.Button buttonMenu;
        private System.Windows.Forms.Label labelOptionsHeader;
    }
}

