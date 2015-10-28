namespace TheHunt.Controller.Highscore
{
    partial class Show
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
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.btnChangeName = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(0);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersVisible = false;
            this.dataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGrid.ShowCellErrors = false;
            this.dataGrid.ShowCellToolTips = false;
            this.dataGrid.ShowEditingIcon = false;
            this.dataGrid.ShowRowErrors = false;
            this.dataGrid.Size = new System.Drawing.Size(727, 594);
            this.dataGrid.TabIndex = 0;
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBackToMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackToMenu.Location = new System.Drawing.Point(15, 610);
            this.buttonBackToMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(200, 50);
            this.buttonBackToMenu.TabIndex = 5;
            this.buttonBackToMenu.Text = "Back To Menu";
            this.buttonBackToMenu.UseVisualStyleBackColor = true;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click);
            // 
            // btnChangeName
            // 
            this.btnChangeName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChangeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeName.Location = new System.Drawing.Point(509, 610);
            this.btnChangeName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChangeName.Name = "btnChangeName";
            this.btnChangeName.Size = new System.Drawing.Size(200, 50);
            this.btnChangeName.TabIndex = 6;
            this.btnChangeName.Text = "Change Name";
            this.btnChangeName.UseVisualStyleBackColor = true;
            this.btnChangeName.Click += new System.EventHandler(this.btnChangeName_Click);
            // 
            // Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(724, 674);
            this.Controls.Add(this.btnChangeName);
            this.Controls.Add(this.buttonBackToMenu);
            this.Controls.Add(this.dataGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Show";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Highscores";
            this.Load += new System.EventHandler(this.Highscores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Button buttonBackToMenu;
        private System.Windows.Forms.Button btnChangeName;
    }
}