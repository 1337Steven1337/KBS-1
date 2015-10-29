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
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.gameOverReset = new System.Windows.Forms.PictureBox();
            this.gameOverExitMenu = new System.Windows.Forms.PictureBox();
            this.gameOverExitDesktop = new System.Windows.Forms.PictureBox();
            this.pnlMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxContinue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOptions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExitToDesktop)).BeginInit();
            this.pnlGameOver.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameOverReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameOverExitMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameOverExitDesktop)).BeginInit();
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
            this.pnlMenu.Location = new System.Drawing.Point(3, 9);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(451, 560);
            this.pnlMenu.TabIndex = 2;
            this.pnlMenu.Visible = false;
            // 
            // labelMenu
            // 
            this.labelMenu.AutoSize = true;
            this.labelMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.2F, System.Drawing.FontStyle.Bold);
            this.labelMenu.Location = new System.Drawing.Point(112, 2);
            this.labelMenu.Name = "labelMenu";
            this.labelMenu.Size = new System.Drawing.Size(223, 83);
            this.labelMenu.TabIndex = 0;
            this.labelMenu.Text = "Menu";
            // 
            // pictureBoxContinue
            // 
            this.pictureBoxContinue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxContinue.Image = global::TheHunt.Properties.Resources.Continuebutton;
            this.pictureBoxContinue.Location = new System.Drawing.Point(10, 91);
            this.pictureBoxContinue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxContinue.Name = "pictureBoxContinue";
            this.pictureBoxContinue.Size = new System.Drawing.Size(440, 109);
            this.pictureBoxContinue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxContinue.TabIndex = 3;
            this.pictureBoxContinue.TabStop = false;
            this.pictureBoxContinue.Click += new System.EventHandler(this.pictureBoxContinue_Click);
            // 
            // pictureBoxExitToMenu
            // 
            this.pictureBoxExitToMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxExitToMenu.Image = global::TheHunt.Properties.Resources.ExitToMenuButton;
            this.pictureBoxExitToMenu.Location = new System.Drawing.Point(10, 325);
            this.pictureBoxExitToMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExitToMenu.Name = "pictureBoxExitToMenu";
            this.pictureBoxExitToMenu.Size = new System.Drawing.Size(440, 109);
            this.pictureBoxExitToMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExitToMenu.TabIndex = 4;
            this.pictureBoxExitToMenu.TabStop = false;
            this.pictureBoxExitToMenu.Click += new System.EventHandler(this.pictureBoxExitToMenu_Click);
            // 
            // pictureBoxOptions
            // 
            this.pictureBoxOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOptions.Image = global::TheHunt.Properties.Resources.optionsBtn;
            this.pictureBoxOptions.Location = new System.Drawing.Point(10, 208);
            this.pictureBoxOptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxOptions.Name = "pictureBoxOptions";
            this.pictureBoxOptions.Size = new System.Drawing.Size(440, 109);
            this.pictureBoxOptions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxOptions.TabIndex = 5;
            this.pictureBoxOptions.TabStop = false;
            this.pictureBoxOptions.Click += new System.EventHandler(this.pictureBoxOptions_Click);
            // 
            // pictureBoxExitToDesktop
            // 
            this.pictureBoxExitToDesktop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxExitToDesktop.Image = global::TheHunt.Properties.Resources.ExitToDesktopButton;
            this.pictureBoxExitToDesktop.Location = new System.Drawing.Point(10, 442);
            this.pictureBoxExitToDesktop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxExitToDesktop.Name = "pictureBoxExitToDesktop";
            this.pictureBoxExitToDesktop.Size = new System.Drawing.Size(440, 109);
            this.pictureBoxExitToDesktop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxExitToDesktop.TabIndex = 6;
            this.pictureBoxExitToDesktop.TabStop = false;
            this.pictureBoxExitToDesktop.Click += new System.EventHandler(this.pictureBoxExitToDesktop_Click);
            // 
            // pnlGameOver
            // 
            this.pnlGameOver.BackColor = System.Drawing.Color.Transparent;
            this.pnlGameOver.Controls.Add(this.gameOverLabel);
            this.pnlGameOver.Controls.Add(this.gameOverReset);
            this.pnlGameOver.Controls.Add(this.gameOverExitMenu);
            this.pnlGameOver.Controls.Add(this.gameOverExitDesktop);
            this.pnlGameOver.Location = new System.Drawing.Point(467, 15);
            this.pnlGameOver.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlGameOver.Name = "pnlGameOver";
            this.pnlGameOver.Size = new System.Drawing.Size(451, 461);
            this.pnlGameOver.TabIndex = 7;
            this.pnlGameOver.Visible = false;
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36.2F, System.Drawing.FontStyle.Bold);
            this.gameOverLabel.Location = new System.Drawing.Point(19, 9);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(406, 83);
            this.gameOverLabel.TabIndex = 0;
            this.gameOverLabel.Text = "Game over";
            // 
            // gameOverReset
            // 
            this.gameOverReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameOverReset.Image = global::TheHunt.Properties.Resources.restartBtn;
            this.gameOverReset.Location = new System.Drawing.Point(8, 112);
            this.gameOverReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gameOverReset.Name = "gameOverReset";
            this.gameOverReset.Size = new System.Drawing.Size(440, 109);
            this.gameOverReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameOverReset.TabIndex = 3;
            this.gameOverReset.TabStop = false;
            this.gameOverReset.Click += new System.EventHandler(this.pictureBoxRestart_Click);
            // 
            // gameOverExitMenu
            // 
            this.gameOverExitMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameOverExitMenu.Image = global::TheHunt.Properties.Resources.ExitToMenuButton;
            this.gameOverExitMenu.Location = new System.Drawing.Point(9, 228);
            this.gameOverExitMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gameOverExitMenu.Name = "gameOverExitMenu";
            this.gameOverExitMenu.Size = new System.Drawing.Size(440, 109);
            this.gameOverExitMenu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameOverExitMenu.TabIndex = 4;
            this.gameOverExitMenu.TabStop = false;
            this.gameOverExitMenu.Click += new System.EventHandler(this.pictureBoxExitToMenu_Click);
            // 
            // gameOverExitDesktop
            // 
            this.gameOverExitDesktop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameOverExitDesktop.Image = global::TheHunt.Properties.Resources.ExitToDesktopButton;
            this.gameOverExitDesktop.Location = new System.Drawing.Point(9, 346);
            this.gameOverExitDesktop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gameOverExitDesktop.Name = "gameOverExitDesktop";
            this.gameOverExitDesktop.Size = new System.Drawing.Size(440, 109);
            this.gameOverExitDesktop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameOverExitDesktop.TabIndex = 6;
            this.gameOverExitDesktop.TabStop = false;
            this.gameOverExitDesktop.Click += new System.EventHandler(this.pictureBoxExitToDesktop_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 775);
            this.Controls.Add(this.pnlGameOver);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
            ((System.ComponentModel.ISupportInitialize)(this.gameOverReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameOverExitMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameOverExitDesktop)).EndInit();
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
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.PictureBox gameOverReset;
        private System.Windows.Forms.PictureBox gameOverExitMenu;
        private System.Windows.Forms.PictureBox gameOverExitDesktop;
    }
}