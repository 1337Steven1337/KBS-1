using System;

namespace TheHunt
{
    partial class Player
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Player));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelMenu = new System.Windows.Forms.Label();
            this.buttonOptions = new System.Windows.Forms.Button();
            this.buttonQuitMenu = new System.Windows.Forms.Button();
            this.buttonQuitDesktop = new System.Windows.Forms.Button();
            this.buttonResume = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelMenu);
            this.panel1.Controls.Add(this.buttonOptions);
            this.panel1.Controls.Add(this.buttonQuitMenu);
            this.panel1.Controls.Add(this.buttonQuitDesktop);
            this.panel1.Controls.Add(this.buttonResume);
            this.panel1.Location = new System.Drawing.Point(277, 146);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 202);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // labelMenu
            // 
            this.labelMenu.AutoSize = true;
            this.labelMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMenu.Location = new System.Drawing.Point(60, 0);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(90, 32);
            this.labelMenu.TabIndex = 0;
            this.labelMenu.Text = "Menu";
            // 
            // buttonOptions
            // 
            this.buttonOptions.Location = new System.Drawing.Point(45, 71);
            this.buttonOptions.Name = "buttonOptions";
            this.buttonOptions.Size = new System.Drawing.Size(120, 30);
            this.buttonOptions.TabIndex = 1;
            this.buttonOptions.Text = "Options";
            this.buttonOptions.UseVisualStyleBackColor = true;
            this.buttonOptions.Click += new System.EventHandler(this.buttonOptions_Click);
            // 
            // buttonQuitMenu
            // 
            this.buttonQuitMenu.Location = new System.Drawing.Point(45, 107);
            this.buttonQuitMenu.Name = "buttonQuitMenu";
            this.buttonQuitMenu.Size = new System.Drawing.Size(120, 30);
            this.buttonQuitMenu.TabIndex = 2;
            this.buttonQuitMenu.Text = "Exit To Menu";
            this.buttonQuitMenu.UseVisualStyleBackColor = true;
            this.buttonQuitMenu.Click += new System.EventHandler(this.buttonQuitMenu_Click);
            // 
            // buttonQuitDesktop
            // 
            this.buttonQuitDesktop.Location = new System.Drawing.Point(45, 143);
            this.buttonQuitDesktop.Name = "buttonQuitDesktop";
            this.buttonQuitDesktop.Size = new System.Drawing.Size(120, 30);
            this.buttonQuitDesktop.TabIndex = 3;
            this.buttonQuitDesktop.Text = "Exit To Desktop";
            this.buttonQuitDesktop.UseVisualStyleBackColor = true;
            this.buttonQuitDesktop.Click += new System.EventHandler(this.buttonQuitDesktop_Click);
            // 
            // buttonResume
            // 
            this.buttonResume.Location = new System.Drawing.Point(45, 35);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(120, 30);
            this.buttonResume.TabIndex = 4;
            this.buttonResume.Text = "Continue";
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Player";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map";
            this.Load += new System.EventHandler(this.Map_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Map_OnKeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Map_OnKeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonQuitDesktop;
        private System.Windows.Forms.Button buttonQuitMenu;
        private System.Windows.Forms.Button buttonOptions;
        private System.Windows.Forms.Label labelMenu;
        private System.Windows.Forms.Button buttonResume;
    }
}