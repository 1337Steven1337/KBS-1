namespace TheHunt
{
    partial class Game
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.labelMenu = new System.Windows.Forms.Label();
            this.pictureBoxContinue = new System.Windows.Forms.PictureBox();
            this.pictureBoxExitToMenu = new System.Windows.Forms.PictureBox();
            this.pictureBoxOptions = new System.Windows.Forms.PictureBox();
            this.pictureBoxExitToDesktop = new System.Windows.Forms.PictureBox();
            this.pnlGameOver = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContinue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToDesktop)).BeginInit();
            this.pnlGameOver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.labelMenu);
            this.pnlMenu.Controls.Add(this.pictureBoxContinue);
            this.pnlMenu.Controls.Add(this.pictureBoxExitToMenu);
            this.pnlMenu.Controls.Add(this.pictureBoxOptions);
            this.pnlMenu.Controls.Add(this.pictureBoxExitToDesktop);
            this.pnlMenu.Location = new System.Drawing.Point(3, 7);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(401, 448);
            this.pnlMenu.TabIndex = 2;
            this.pnlMenu.Visible = false;
            // 
            // labelMenu
            // 
            this.labelMenu.AutoSize = true;
            this.labelMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.2F, System.Drawing.FontStyle.Bold);
            this.labelMenu.Location = new System.Drawing.Point(100, 2);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(187, 70);
            this.labelMenu.TabIndex = 0;
            this.labelMenu.Text = "Menu";
            // 
            // pictureBoxContinue
            // 
            this.pictureBoxContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxContinue.Image = global::TheHunt.Properties.Resources.Continuebutton;
            this.pictureBoxContinue.Location = new System.Drawing.Point(9, 73);
            this.pictureBoxContinue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxContinue.Name = "pictureBoxContinue";
            this.pictureBoxContinue.Size = new System.Drawing.Size(391, 87);
            this.pictureBoxContinue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxContinue.TabIndex = 3;
            this.pictureBoxContinue.TabStop = false;
            this.pictureBoxContinue.Click += new System.EventHandler(this.pictureBoxContinue_Click);
            // 
            // pictureBoxExitToMenu
            // 
            this.pictureBoxExitToMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxExitToMenu.Image = global::TheHunt.Properties.Resources.ExitToMenuButton;
            this.pictureBoxExitToMenu.Location = new System.Drawing.Point(9, 260);
            this.pictureBoxExitToMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExitToMenu.Name = "pictureBoxExitToMenu";
            this.pictureBoxExitToMenu.Size = new System.Drawing.Size(391, 87);
            this.pictureBoxExitToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExitToMenu.TabIndex = 4;
            this.pictureBoxExitToMenu.TabStop = false;
            this.pictureBoxExitToMenu.Click += new System.EventHandler(this.pictureBoxExitToMenu_Click);
            // 
            // pictureBoxOptions
            // 
            this.pictureBoxOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOptions.Image = global::TheHunt.Properties.Resources.optionsBtn;
            this.pictureBoxOptions.Location = new System.Drawing.Point(9, 166);
            this.pictureBoxOptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxOptions.Name = "pictureBoxOptions";
            this.pictureBoxOptions.Size = new System.Drawing.Size(391, 87);
            this.pictureBoxOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOptions.TabIndex = 5;
            this.pictureBoxOptions.TabStop = false;
            this.pictureBoxOptions.Click += new System.EventHandler(this.pictureBoxOptions_Click);
            // 
            // pictureBoxExitToDesktop
            // 
            this.pictureBoxExitToDesktop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxExitToDesktop.Image = global::TheHunt.Properties.Resources.ExitToDesktopButton;
            this.pictureBoxExitToDesktop.Location = new System.Drawing.Point(9, 354);
            this.pictureBoxExitToDesktop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExitToDesktop.Name = "pictureBoxExitToDesktop";
            this.pictureBoxExitToDesktop.Size = new System.Drawing.Size(391, 87);
            this.pictureBoxExitToDesktop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExitToDesktop.TabIndex = 6;
            this.pictureBoxExitToDesktop.TabStop = false;
            this.pictureBoxExitToDesktop.Click += new System.EventHandler(this.pictureBoxExitToDesktop_Click);
            // 
            // pnlGameOver
            // 
            this.pnlGameOver.BackColor = System.Drawing.Color.Transparent;
            this.pnlGameOver.Controls.Add(this.label1);
            this.pnlGameOver.Controls.Add(this.pictureBox1);
            this.pnlGameOver.Controls.Add(this.pictureBox2);
            this.pnlGameOver.Controls.Add(this.pictureBox4);
            this.pnlGameOver.Location = new System.Drawing.Point(415, 12);
            this.pnlGameOver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlGameOver.Name = "pnlGameOver";
            this.pnlGameOver.Size = new System.Drawing.Size(401, 369);
            this.pnlGameOver.TabIndex = 7;
            this.pnlGameOver.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.2F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(17, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 70);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game over";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::TheHunt.Properties.Resources.restartBtn;
            this.pictureBox1.Location = new System.Drawing.Point(7, 90);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(391, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBoxRestart_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::TheHunt.Properties.Resources.ExitToMenuButton;
            this.pictureBox2.Location = new System.Drawing.Point(8, 182);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(391, 87);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBoxExitToMenu_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = global::TheHunt.Properties.Resources.ExitToDesktopButton;
            this.pictureBox4.Location = new System.Drawing.Point(8, 277);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(391, 87);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBoxExitToDesktop_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 620);
            this.Controls.Add(this.pnlGameOver);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContinue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToDesktop)).EndInit();
            this.pnlGameOver.ResumeLayout(false);
            this.pnlGameOver.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label labelMenu;
        private System.Windows.Forms.PictureBox pictureBoxContinue;
        private System.Windows.Forms.PictureBox pictureBoxExitToMenu;
        private System.Windows.Forms.PictureBox pictureBoxOptions;
        private System.Windows.Forms.PictureBox pictureBoxExitToDesktop;
        private System.Windows.Forms.Panel pnlGameOver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}