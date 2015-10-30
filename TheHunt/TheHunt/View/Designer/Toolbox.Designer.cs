namespace TheHunt.View.Designer
{
    partial class Toolbox
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
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.propertiesPanel = new System.Windows.Forms.Panel();
            this.PropertiesLabel = new System.Windows.Forms.Label();
            this.numericRunSpeed = new System.Windows.Forms.NumericUpDown();
            this.runSpeedLabel = new System.Windows.Forms.Label();
            this.numericWalkSpeed = new System.Windows.Forms.NumericUpDown();
            this.walkSpeedLabel = new System.Windows.Forms.Label();
            this.ObjectCoords = new System.Windows.Forms.Label();
            this.previewObjectBox = new System.Windows.Forms.PictureBox();
            this.ObjectName = new System.Windows.Forms.Label();
            this.playerPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.NPCPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.worldPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ObjectDescription = new System.Windows.Forms.RichTextBox();
            this.flowLayout.SuspendLayout();
            this.propertiesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRunSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWalkSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewObjectBox)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayout
            // 
            this.flowLayout.AutoScroll = true;
            this.flowLayout.Controls.Add(this.propertiesPanel);
            this.flowLayout.Controls.Add(this.playerPanel);
            this.flowLayout.Controls.Add(this.NPCPanel);
            this.flowLayout.Controls.Add(this.worldPanel);
            this.flowLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayout.Location = new System.Drawing.Point(0, 0);
            this.flowLayout.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(507, 480);
            this.flowLayout.TabIndex = 0;
            // 
            // propertiesPanel
            // 
            this.propertiesPanel.Controls.Add(this.ObjectDescription);
            this.propertiesPanel.Controls.Add(this.PropertiesLabel);
            this.propertiesPanel.Controls.Add(this.numericRunSpeed);
            this.propertiesPanel.Controls.Add(this.runSpeedLabel);
            this.propertiesPanel.Controls.Add(this.numericWalkSpeed);
            this.propertiesPanel.Controls.Add(this.walkSpeedLabel);
            this.propertiesPanel.Controls.Add(this.ObjectCoords);
            this.propertiesPanel.Controls.Add(this.previewObjectBox);
            this.propertiesPanel.Controls.Add(this.ObjectName);
            this.propertiesPanel.Location = new System.Drawing.Point(3, 3);
            this.propertiesPanel.Name = "propertiesPanel";
            this.propertiesPanel.Size = new System.Drawing.Size(492, 176);
            this.propertiesPanel.TabIndex = 3;
            // 
            // PropertiesLabel
            // 
            this.PropertiesLabel.AutoSize = true;
            this.PropertiesLabel.Location = new System.Drawing.Point(18, 0);
            this.PropertiesLabel.Name = "PropertiesLabel";
            this.PropertiesLabel.Size = new System.Drawing.Size(81, 20);
            this.PropertiesLabel.TabIndex = 7;
            this.PropertiesLabel.Text = "Properties";
            // 
            // numericRunSpeed
            // 
            this.numericRunSpeed.Location = new System.Drawing.Point(350, 129);
            this.numericRunSpeed.Name = "numericRunSpeed";
            this.numericRunSpeed.Size = new System.Drawing.Size(97, 26);
            this.numericRunSpeed.TabIndex = 6;
            // 
            // runSpeedLabel
            // 
            this.runSpeedLabel.AutoSize = true;
            this.runSpeedLabel.Location = new System.Drawing.Point(166, 129);
            this.runSpeedLabel.Name = "runSpeedLabel";
            this.runSpeedLabel.Size = new System.Drawing.Size(95, 20);
            this.runSpeedLabel.TabIndex = 5;
            this.runSpeedLabel.Text = "Run speed :";
            // 
            // numericWalkSpeed
            // 
            this.numericWalkSpeed.Location = new System.Drawing.Point(350, 89);
            this.numericWalkSpeed.Name = "numericWalkSpeed";
            this.numericWalkSpeed.Size = new System.Drawing.Size(97, 26);
            this.numericWalkSpeed.TabIndex = 4;
            // 
            // walkSpeedLabel
            // 
            this.walkSpeedLabel.AutoSize = true;
            this.walkSpeedLabel.Location = new System.Drawing.Point(166, 89);
            this.walkSpeedLabel.Name = "walkSpeedLabel";
            this.walkSpeedLabel.Size = new System.Drawing.Size(100, 20);
            this.walkSpeedLabel.TabIndex = 3;
            this.walkSpeedLabel.Text = "Walk speed :";
            // 
            // ObjectCoords
            // 
            this.ObjectCoords.AutoSize = true;
            this.ObjectCoords.Location = new System.Drawing.Point(166, 53);
            this.ObjectCoords.Name = "ObjectCoords";
            this.ObjectCoords.Size = new System.Drawing.Size(106, 20);
            this.ObjectCoords.TabIndex = 2;
            this.ObjectCoords.Text = "ObjectCoords";
            // 
            // previewObjectBox
            // 
            this.previewObjectBox.Location = new System.Drawing.Point(22, 37);
            this.previewObjectBox.Name = "previewObjectBox";
            this.previewObjectBox.Size = new System.Drawing.Size(138, 131);
            this.previewObjectBox.TabIndex = 1;
            this.previewObjectBox.TabStop = false;
            // 
            // ObjectName
            // 
            this.ObjectName.AutoSize = true;
            this.ObjectName.Location = new System.Drawing.Point(166, 20);
            this.ObjectName.Name = "ObjectName";
            this.ObjectName.Size = new System.Drawing.Size(97, 20);
            this.ObjectName.TabIndex = 0;
            this.ObjectName.Text = "ObjectName";
            // 
            // playerPanel
            // 
            this.playerPanel.Location = new System.Drawing.Point(3, 185);
            this.playerPanel.Name = "playerPanel";
            this.playerPanel.Size = new System.Drawing.Size(492, 100);
            this.playerPanel.TabIndex = 4;
            // 
            // NPCPanel
            // 
            this.NPCPanel.Location = new System.Drawing.Point(3, 291);
            this.NPCPanel.Name = "NPCPanel";
            this.NPCPanel.Size = new System.Drawing.Size(492, 100);
            this.NPCPanel.TabIndex = 5;
            // 
            // worldPanel
            // 
            this.worldPanel.Location = new System.Drawing.Point(3, 397);
            this.worldPanel.Name = "worldPanel";
            this.worldPanel.Size = new System.Drawing.Size(492, 78);
            this.worldPanel.TabIndex = 6;
            // 
            // ObjectDescription
            // 
            this.ObjectDescription.BackColor = System.Drawing.SystemColors.Control;
            this.ObjectDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ObjectDescription.Location = new System.Drawing.Point(170, 153);
            this.ObjectDescription.Name = "ObjectDescription";
            this.ObjectDescription.ReadOnly = true;
            this.ObjectDescription.Size = new System.Drawing.Size(277, 96);
            this.ObjectDescription.TabIndex = 8;
            this.ObjectDescription.Text = "Select an object.";
            // 
            // Toolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 480);
            this.Controls.Add(this.flowLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Toolbox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Toolbox";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Items_Load);
            this.flowLayout.ResumeLayout(false);
            this.propertiesPanel.ResumeLayout(false);
            this.propertiesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericRunSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericWalkSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewObjectBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.Panel propertiesPanel;
        private System.Windows.Forms.NumericUpDown numericRunSpeed;
        private System.Windows.Forms.Label runSpeedLabel;
        private System.Windows.Forms.NumericUpDown numericWalkSpeed;
        private System.Windows.Forms.Label walkSpeedLabel;
        private System.Windows.Forms.Label ObjectCoords;
        private System.Windows.Forms.PictureBox previewObjectBox;
        private System.Windows.Forms.Label ObjectName;
        private System.Windows.Forms.Label PropertiesLabel;
        private System.Windows.Forms.FlowLayoutPanel playerPanel;
        private System.Windows.Forms.FlowLayoutPanel NPCPanel;
        private System.Windows.Forms.FlowLayoutPanel worldPanel;
        private System.Windows.Forms.RichTextBox ObjectDescription;
    }
}