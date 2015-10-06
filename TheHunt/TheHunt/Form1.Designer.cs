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
            this.pictureBox1.Location = new System.Drawing.Point(598, 65);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(818, 188);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btn_PlayGame);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TheHunt.Properties.Resources.Levels;
            this.pictureBox2.Location = new System.Drawing.Point(598, 265);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(818, 188);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // OptionsButton
            // 
            this.OptionsButton.Image = global::TheHunt.Properties.Resources.Options;
            this.OptionsButton.Location = new System.Drawing.Point(598, 463);
            this.OptionsButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(818, 190);
            this.OptionsButton.TabIndex = 7;
            this.OptionsButton.TabStop = false;
            this.OptionsButton.Click += new System.EventHandler(this.Options_click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::TheHunt.Properties.Resources.Maak_Level;
            this.pictureBox4.Location = new System.Drawing.Point(598, 665);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(818, 187);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::TheHunt.Properties.Resources.Exit;
            this.pictureBox5.Location = new System.Drawing.Point(598, 863);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(818, 183);
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // buttonSnd
            // 
            this.buttonSnd.Location = new System.Drawing.Point(198, 194);
            this.buttonSnd.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.buttonSnd.Name = "buttonSnd";
            this.buttonSnd.Size = new System.Drawing.Size(150, 44);
            this.buttonSnd.TabIndex = 10;
            this.buttonSnd.Text = "button1";
            this.buttonSnd.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1920, 1125);
            this.Controls.Add(this.buttonSnd);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.OptionsButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Hunt";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OptionsButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

        }

        private void buttonSound_Click(object sender, EventArgs e)
        {
            if(buttonSnd.Text=="Sound: On")
            {
                buttonSnd.Text = "Sound: Off";
            }
            else if(buttonSnd.Text=="Sound: Off")
            {
                buttonSnd.Text = "Sound: On";
            }
        }

        private void Options_click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            OptionsButton.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            buttonSnd.Visible = true;
        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox OptionsButton;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Button buttonSnd;
    }
}

