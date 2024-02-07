namespace WildOmissionServerConfigurator
{
    partial class Window
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            AdminIDTextBox = new TextBox();
            ServerNameTextBox = new TextBox();
            PortTextBox = new TextBox();
            ServerNameLabel = new Label();
            ServerPortLabel = new Label();
            AdminIDLabel = new Label();
            StartServerButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // AdminIDTextBox
            // 
            AdminIDTextBox.Location = new Point(15, 115);
            AdminIDTextBox.Name = "AdminIDTextBox";
            AdminIDTextBox.Size = new Size(773, 23);
            AdminIDTextBox.TabIndex = 0;
            // 
            // ServerNameTextBox
            // 
            ServerNameTextBox.Location = new Point(12, 27);
            ServerNameTextBox.Name = "ServerNameTextBox";
            ServerNameTextBox.Size = new Size(776, 23);
            ServerNameTextBox.TabIndex = 1;
            // 
            // PortTextBox
            // 
            PortTextBox.Location = new Point(12, 71);
            PortTextBox.Name = "PortTextBox";
            PortTextBox.Size = new Size(776, 23);
            PortTextBox.TabIndex = 2;
            // 
            // ServerNameLabel
            // 
            ServerNameLabel.AutoSize = true;
            ServerNameLabel.Location = new Point(12, 9);
            ServerNameLabel.Name = "ServerNameLabel";
            ServerNameLabel.Size = new Size(74, 15);
            ServerNameLabel.TabIndex = 3;
            ServerNameLabel.Text = "Server Name";
            // 
            // ServerPortLabel
            // 
            ServerPortLabel.AutoSize = true;
            ServerPortLabel.Location = new Point(15, 53);
            ServerPortLabel.Name = "ServerPortLabel";
            ServerPortLabel.Size = new Size(64, 15);
            ServerPortLabel.TabIndex = 4;
            ServerPortLabel.Text = "Server Port";
            // 
            // AdminIDLabel
            // 
            AdminIDLabel.AutoSize = true;
            AdminIDLabel.Location = new Point(12, 97);
            AdminIDLabel.Name = "AdminIDLabel";
            AdminIDLabel.Size = new Size(236, 15);
            AdminIDLabel.TabIndex = 5;
            AdminIDLabel.Text = "Administrator Steam IDs (Separate with \", \")";
            // 
            // StartServerButton
            // 
            StartServerButton.Location = new Point(15, 153);
            StartServerButton.Name = "StartServerButton";
            StartServerButton.Size = new Size(773, 23);
            StartServerButton.TabIndex = 6;
            StartServerButton.Text = "Start Server";
            StartServerButton.UseVisualStyleBackColor = true;
            StartServerButton.Click += StartServerButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(15, 182);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(773, 23);
            CancelButton.TabIndex = 7;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 220);
            Controls.Add(CancelButton);
            Controls.Add(StartServerButton);
            Controls.Add(AdminIDLabel);
            Controls.Add(ServerPortLabel);
            Controls.Add(ServerNameLabel);
            Controls.Add(PortTextBox);
            Controls.Add(ServerNameTextBox);
            Controls.Add(AdminIDTextBox);
            Name = "Window";
            Text = "Wild Omission Server Configurator";
            Load += Window_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox AdminIDTextBox;
        private TextBox ServerNameTextBox;
        private TextBox PortTextBox;
        private Label ServerNameLabel;
        private Label ServerPortLabel;
        private Label AdminIDLabel;
        private Button StartServerButton;
        private Button CancelButton;
    }
}
