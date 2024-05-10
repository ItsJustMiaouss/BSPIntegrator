namespace BSPIntegrator
{
    partial class Main
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
            inputBSPLabel = new Label();
            outputBSPLabel = new Label();
            inputBSPTextbox = new TextBox();
            inputBSPButton = new Button();
            outputBSPButton = new Button();
            outputBSPTextbox = new TextBox();
            executeButton = new Button();
            contentFolderLabel = new Label();
            contentFolderButton = new Button();
            contentFolderTextbox = new TextBox();
            SuspendLayout();
            // 
            // inputBSPLabel
            // 
            inputBSPLabel.AutoSize = true;
            inputBSPLabel.Location = new Point(12, 33);
            inputBSPLabel.Name = "inputBSPLabel";
            inputBSPLabel.Size = new Size(58, 15);
            inputBSPLabel.TabIndex = 0;
            inputBSPLabel.Text = "Input BSP";
            // 
            // outputBSPLabel
            // 
            outputBSPLabel.AutoSize = true;
            outputBSPLabel.Location = new Point(12, 158);
            outputBSPLabel.Name = "outputBSPLabel";
            outputBSPLabel.Size = new Size(95, 15);
            outputBSPLabel.TabIndex = 1;
            outputBSPLabel.Text = "Output BSP Path";
            // 
            // inputBSPTextbox
            // 
            inputBSPTextbox.Enabled = false;
            inputBSPTextbox.Location = new Point(160, 52);
            inputBSPTextbox.Name = "inputBSPTextbox";
            inputBSPTextbox.ReadOnly = true;
            inputBSPTextbox.Size = new Size(499, 23);
            inputBSPTextbox.TabIndex = 2;
            inputBSPTextbox.TabStop = false;
            // 
            // inputBSPButton
            // 
            inputBSPButton.Location = new Point(12, 51);
            inputBSPButton.Name = "inputBSPButton";
            inputBSPButton.Size = new Size(142, 23);
            inputBSPButton.TabIndex = 3;
            inputBSPButton.Text = "Select input BSP";
            inputBSPButton.UseVisualStyleBackColor = true;
            inputBSPButton.Click += inputBSPButton_Click;
            // 
            // outputBSPButton
            // 
            outputBSPButton.Location = new Point(12, 176);
            outputBSPButton.Name = "outputBSPButton";
            outputBSPButton.Size = new Size(142, 23);
            outputBSPButton.TabIndex = 4;
            outputBSPButton.Text = "Select output BSP";
            outputBSPButton.UseVisualStyleBackColor = true;
            outputBSPButton.Click += outputBSPButton_Click;
            // 
            // outputBSPTextbox
            // 
            outputBSPTextbox.Enabled = false;
            outputBSPTextbox.Location = new Point(160, 177);
            outputBSPTextbox.Name = "outputBSPTextbox";
            outputBSPTextbox.ReadOnly = true;
            outputBSPTextbox.Size = new Size(499, 23);
            outputBSPTextbox.TabIndex = 5;
            outputBSPTextbox.TabStop = false;
            // 
            // executeButton
            // 
            executeButton.Location = new Point(245, 214);
            executeButton.Name = "executeButton";
            executeButton.Size = new Size(166, 23);
            executeButton.TabIndex = 6;
            executeButton.Text = "Execute";
            executeButton.UseVisualStyleBackColor = true;
            executeButton.Click += executeButton_Click;
            // 
            // contentFolderLabel
            // 
            contentFolderLabel.AutoSize = true;
            contentFolderLabel.Location = new Point(12, 97);
            contentFolderLabel.Name = "contentFolderLabel";
            contentFolderLabel.Size = new Size(84, 15);
            contentFolderLabel.TabIndex = 8;
            contentFolderLabel.Text = "Content folder";
            // 
            // contentFolderButton
            // 
            contentFolderButton.Location = new Point(12, 115);
            contentFolderButton.Name = "contentFolderButton";
            contentFolderButton.Size = new Size(142, 23);
            contentFolderButton.TabIndex = 9;
            contentFolderButton.Text = "Select content folder";
            contentFolderButton.UseVisualStyleBackColor = true;
            contentFolderButton.Click += contentFolderButton_Click;
            // 
            // contentFolderTextbox
            // 
            contentFolderTextbox.Enabled = false;
            contentFolderTextbox.Location = new Point(160, 116);
            contentFolderTextbox.Name = "contentFolderTextbox";
            contentFolderTextbox.ReadOnly = true;
            contentFolderTextbox.Size = new Size(499, 23);
            contentFolderTextbox.TabIndex = 10;
            contentFolderTextbox.TabStop = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(671, 266);
            Controls.Add(contentFolderTextbox);
            Controls.Add(contentFolderButton);
            Controls.Add(contentFolderLabel);
            Controls.Add(executeButton);
            Controls.Add(outputBSPTextbox);
            Controls.Add(outputBSPButton);
            Controls.Add(inputBSPButton);
            Controls.Add(inputBSPTextbox);
            Controls.Add(outputBSPLabel);
            Controls.Add(inputBSPLabel);
            MaximizeBox = false;
            Name = "Main";
            ShowIcon = false;
            Text = "BSPIntegrator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label inputBSPLabel;
        private Label outputBSPLabel;
        private TextBox inputBSPTextbox;
        private Button inputBSPButton;
        private Button outputBSPButton;
        private TextBox outputBSPTextbox;
        private Button executeButton;
        private Label contentFolderLabel;
        private Button contentFolderButton;
        private TextBox contentFolderTextbox;
    }
}