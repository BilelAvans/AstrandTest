namespace AstrandTest
{
    partial class TestGUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestGUI));
            this.startTestButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.ageTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.weightTextBox = new System.Windows.Forms.TextBox();
            this.trainingsListView = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pauseTestButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.requiredRPMLabel = new System.Windows.Forms.Label();
            this.currentHeartRateLabel = new System.Windows.Forms.Label();
            this.currentPowerLabel = new System.Windows.Forms.Label();
            this.sexComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.bikeConnectionStatusLabel = new System.Windows.Forms.Label();
            this.connectToBikeButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.runStatusLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // startTestButton
            // 
            this.startTestButton.Location = new System.Drawing.Point(11, 67);
            this.startTestButton.Margin = new System.Windows.Forms.Padding(2);
            this.startTestButton.Name = "startTestButton";
            this.startTestButton.Size = new System.Drawing.Size(136, 29);
            this.startTestButton.TabIndex = 1;
            this.startTestButton.Text = "Start Test";
            this.startTestButton.UseVisualStyleBackColor = true;
            this.startTestButton.Click += new System.EventHandler(this.startTestButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(178, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time: ";
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTimeLabel.Location = new System.Drawing.Point(177, 69);
            this.currentTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(70, 29);
            this.currentTimeLabel.TabIndex = 3;
            this.currentTimeLabel.Text = "0 : 00";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(62, 5);
            this.ageTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(86, 20);
            this.ageTextBox.TabIndex = 4;
            this.ageTextBox.Text = "24";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Age";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Weight";
            // 
            // weightTextBox
            // 
            this.weightTextBox.Location = new System.Drawing.Point(62, 25);
            this.weightTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(86, 20);
            this.weightTextBox.TabIndex = 7;
            this.weightTextBox.Text = "80";
            // 
            // trainingsListView
            // 
            this.trainingsListView.Location = new System.Drawing.Point(434, 25);
            this.trainingsListView.Margin = new System.Windows.Forms.Padding(2);
            this.trainingsListView.Name = "trainingsListView";
            this.trainingsListView.Size = new System.Drawing.Size(124, 201);
            this.trainingsListView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.trainingsListView.TabIndex = 8;
            this.trainingsListView.UseCompatibleStateImageBehavior = false;
            this.trainingsListView.View = System.Windows.Forms.View.List;
            this.trainingsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.trainingsListView_ItemSelectionChanged);
            this.trainingsListView.SelectedIndexChanged += new System.EventHandler(this.trainingsListView_SelectedIndexChanged);
            this.trainingsListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(431, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Trainings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Location = new System.Drawing.Point(11, 230);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(608, 186);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "History";
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(5, 16);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(599, 163);
            this.tabControl1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(284, 67);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "HeartRate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(284, 39);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "RPM";
            // 
            // pauseTestButton
            // 
            this.pauseTestButton.Location = new System.Drawing.Point(11, 100);
            this.pauseTestButton.Margin = new System.Windows.Forms.Padding(2);
            this.pauseTestButton.Name = "pauseTestButton";
            this.pauseTestButton.Size = new System.Drawing.Size(136, 29);
            this.pauseTestButton.TabIndex = 13;
            this.pauseTestButton.Text = "Pause Test";
            this.pauseTestButton.UseVisualStyleBackColor = true;
            this.pauseTestButton.Click += new System.EventHandler(this.pauseTestButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(11, 133);
            this.resetButton.Margin = new System.Windows.Forms.Padding(2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(136, 29);
            this.resetButton.TabIndex = 14;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(284, 94);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Power";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(175, 118);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // requiredRPMLabel
            // 
            this.requiredRPMLabel.AutoSize = true;
            this.requiredRPMLabel.Location = new System.Drawing.Point(361, 39);
            this.requiredRPMLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.requiredRPMLabel.Name = "requiredRPMLabel";
            this.requiredRPMLabel.Size = new System.Drawing.Size(13, 13);
            this.requiredRPMLabel.TabIndex = 17;
            this.requiredRPMLabel.Text = "0";
            // 
            // currentHeartRateLabel
            // 
            this.currentHeartRateLabel.AutoSize = true;
            this.currentHeartRateLabel.Location = new System.Drawing.Point(361, 67);
            this.currentHeartRateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentHeartRateLabel.Name = "currentHeartRateLabel";
            this.currentHeartRateLabel.Size = new System.Drawing.Size(13, 13);
            this.currentHeartRateLabel.TabIndex = 18;
            this.currentHeartRateLabel.Text = "0";
            // 
            // currentPowerLabel
            // 
            this.currentPowerLabel.AutoSize = true;
            this.currentPowerLabel.Location = new System.Drawing.Point(361, 94);
            this.currentPowerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentPowerLabel.Name = "currentPowerLabel";
            this.currentPowerLabel.Size = new System.Drawing.Size(13, 13);
            this.currentPowerLabel.TabIndex = 19;
            this.currentPowerLabel.Text = "0";
            // 
            // sexComboBox
            // 
            this.sexComboBox.FormattingEnabled = true;
            this.sexComboBox.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Unicorn",
            "Other"});
            this.sexComboBox.Location = new System.Drawing.Point(62, 45);
            this.sexComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.sexComboBox.Name = "sexComboBox";
            this.sexComboBox.Size = new System.Drawing.Size(86, 21);
            this.sexComboBox.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 47);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Sex";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 422);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "BikeStatus:";
            // 
            // bikeConnectionStatusLabel
            // 
            this.bikeConnectionStatusLabel.AutoSize = true;
            this.bikeConnectionStatusLabel.Location = new System.Drawing.Point(80, 422);
            this.bikeConnectionStatusLabel.Name = "bikeConnectionStatusLabel";
            this.bikeConnectionStatusLabel.Size = new System.Drawing.Size(79, 13);
            this.bikeConnectionStatusLabel.TabIndex = 23;
            this.bikeConnectionStatusLabel.Text = "Not Connected";
            // 
            // connectToBikeButton
            // 
            this.connectToBikeButton.Location = new System.Drawing.Point(172, 417);
            this.connectToBikeButton.Name = "connectToBikeButton";
            this.connectToBikeButton.Size = new System.Drawing.Size(75, 23);
            this.connectToBikeButton.TabIndex = 24;
            this.connectToBikeButton.Text = "tryConnect";
            this.connectToBikeButton.UseVisualStyleBackColor = true;
            this.connectToBikeButton.Click += new System.EventHandler(this.connectToBikeButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(175, 6);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(37, 13);
            this.label14.TabIndex = 25;
            this.label14.Text = "Status";
            // 
            // runStatusLabel
            // 
            this.runStatusLabel.AutoSize = true;
            this.runStatusLabel.Location = new System.Drawing.Point(218, 6);
            this.runStatusLabel.Name = "runStatusLabel";
            this.runStatusLabel.Size = new System.Drawing.Size(62, 13);
            this.runStatusLabel.TabIndex = 26;
            this.runStatusLabel.Text = "Not running";
            // 
            // TestGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 450);
            this.Controls.Add(this.runStatusLabel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.connectToBikeButton);
            this.Controls.Add(this.bikeConnectionStatusLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.sexComboBox);
            this.Controls.Add(this.currentPowerLabel);
            this.Controls.Add(this.currentHeartRateLabel);
            this.Controls.Add(this.requiredRPMLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.pauseTestButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trainingsListView);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startTestButton);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TestGUI";
            this.Text = "TestGUI";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startTestButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.TextBox ageTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox weightTextBox;
        private System.Windows.Forms.ListView trainingsListView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button pauseTestButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label requiredRPMLabel;
        private System.Windows.Forms.Label currentHeartRateLabel;
        private System.Windows.Forms.Label currentPowerLabel;
        private System.Windows.Forms.ComboBox sexComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label bikeConnectionStatusLabel;
        private System.Windows.Forms.Button connectToBikeButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label runStatusLabel;
    }
}