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
            this.panel1 = new System.Windows.Forms.Panel();
            this.runStatusLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // startTestButton
            // 
            this.startTestButton.BackColor = System.Drawing.Color.White;
            this.startTestButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.startTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTestButton.ForeColor = System.Drawing.Color.Black;
            this.startTestButton.Location = new System.Drawing.Point(10, 88);
            this.startTestButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.startTestButton.Name = "startTestButton";
            this.startTestButton.Size = new System.Drawing.Size(136, 39);
            this.startTestButton.TabIndex = 1;
            this.startTestButton.Text = "Start Test";
            this.startTestButton.UseVisualStyleBackColor = false;
            this.startTestButton.Click += new System.EventHandler(this.startTestButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time";
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.BackColor = System.Drawing.Color.Black;
            this.currentTimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentTimeLabel.ForeColor = System.Drawing.Color.White;
            this.currentTimeLabel.Location = new System.Drawing.Point(18, 38);
            this.currentTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(55, 24);
            this.currentTimeLabel.TabIndex = 3;
            this.currentTimeLabel.Text = "0 : 00";
            // 
            // ageTextBox
            // 
            this.ageTextBox.Location = new System.Drawing.Point(62, 5);
            this.ageTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ageTextBox.Name = "ageTextBox";
            this.ageTextBox.Size = new System.Drawing.Size(86, 20);
            this.ageTextBox.TabIndex = 4;
            this.ageTextBox.Text = "23";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Black;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(8, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Age";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Black;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(8, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Weight";
            // 
            // weightTextBox
            // 
            this.weightTextBox.Location = new System.Drawing.Point(62, 30);
            this.weightTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.weightTextBox.Name = "weightTextBox";
            this.weightTextBox.Size = new System.Drawing.Size(86, 20);
            this.weightTextBox.TabIndex = 7;
            this.weightTextBox.Text = "80";
            // 
            // trainingsListView
            // 
            this.trainingsListView.Location = new System.Drawing.Point(425, 24);
            this.trainingsListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.trainingsListView.Name = "trainingsListView";
            this.trainingsListView.Size = new System.Drawing.Size(119, 181);
            this.trainingsListView.TabIndex = 8;
            this.trainingsListView.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Black;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(423, 5);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "History";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Black;
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(10, 205);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(532, 162);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measurements";
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(5, 16);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(523, 139);
            this.tabControl1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Black;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(18, 63);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 24);
            this.label6.TabIndex = 11;
            this.label6.Text = "HeartRate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Black;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(142, 13);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "RPM";
            // 
            // pauseTestButton
            // 
            this.pauseTestButton.BackColor = System.Drawing.Color.White;
            this.pauseTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseTestButton.ForeColor = System.Drawing.Color.Black;
            this.pauseTestButton.Location = new System.Drawing.Point(10, 136);
            this.pauseTestButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pauseTestButton.Name = "pauseTestButton";
            this.pauseTestButton.Size = new System.Drawing.Size(136, 29);
            this.pauseTestButton.TabIndex = 13;
            this.pauseTestButton.Text = "Pause Test";
            this.pauseTestButton.UseVisualStyleBackColor = false;
            this.pauseTestButton.Click += new System.EventHandler(this.pauseTestButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.White;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.ForeColor = System.Drawing.Color.Black;
            this.resetButton.Location = new System.Drawing.Point(10, 169);
            this.resetButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(136, 29);
            this.resetButton.TabIndex = 14;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(142, 63);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "Power";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(169, 122);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 105);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // requiredRPMLabel
            // 
            this.requiredRPMLabel.AutoSize = true;
            this.requiredRPMLabel.BackColor = System.Drawing.Color.Black;
            this.requiredRPMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requiredRPMLabel.ForeColor = System.Drawing.Color.White;
            this.requiredRPMLabel.Location = new System.Drawing.Point(142, 38);
            this.requiredRPMLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.requiredRPMLabel.Name = "requiredRPMLabel";
            this.requiredRPMLabel.Size = new System.Drawing.Size(20, 24);
            this.requiredRPMLabel.TabIndex = 17;
            this.requiredRPMLabel.Text = "0";
            // 
            // currentHeartRateLabel
            // 
            this.currentHeartRateLabel.AutoSize = true;
            this.currentHeartRateLabel.BackColor = System.Drawing.Color.Black;
            this.currentHeartRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentHeartRateLabel.ForeColor = System.Drawing.Color.White;
            this.currentHeartRateLabel.Location = new System.Drawing.Point(18, 89);
            this.currentHeartRateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentHeartRateLabel.Name = "currentHeartRateLabel";
            this.currentHeartRateLabel.Size = new System.Drawing.Size(20, 24);
            this.currentHeartRateLabel.TabIndex = 18;
            this.currentHeartRateLabel.Text = "0";
            // 
            // currentPowerLabel
            // 
            this.currentPowerLabel.AutoSize = true;
            this.currentPowerLabel.BackColor = System.Drawing.Color.Black;
            this.currentPowerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPowerLabel.ForeColor = System.Drawing.Color.White;
            this.currentPowerLabel.Location = new System.Drawing.Point(142, 89);
            this.currentPowerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentPowerLabel.Name = "currentPowerLabel";
            this.currentPowerLabel.Size = new System.Drawing.Size(20, 24);
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
            this.sexComboBox.Location = new System.Drawing.Point(62, 55);
            this.sexComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sexComboBox.Name = "sexComboBox";
            this.sexComboBox.Size = new System.Drawing.Size(86, 21);
            this.sexComboBox.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Black;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(8, 56);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 15);
            this.label12.TabIndex = 21;
            this.label12.Text = "Sex";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Black;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(14, 377);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 15);
            this.label13.TabIndex = 22;
            this.label13.Text = "BikeStatus:";
            // 
            // bikeConnectionStatusLabel
            // 
            this.bikeConnectionStatusLabel.AutoSize = true;
            this.bikeConnectionStatusLabel.BackColor = System.Drawing.Color.Black;
            this.bikeConnectionStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bikeConnectionStatusLabel.ForeColor = System.Drawing.Color.White;
            this.bikeConnectionStatusLabel.Location = new System.Drawing.Point(93, 377);
            this.bikeConnectionStatusLabel.Name = "bikeConnectionStatusLabel";
            this.bikeConnectionStatusLabel.Size = new System.Drawing.Size(88, 15);
            this.bikeConnectionStatusLabel.TabIndex = 23;
            this.bikeConnectionStatusLabel.Text = "Not Connected";
            // 
            // connectToBikeButton
            // 
            this.connectToBikeButton.BackColor = System.Drawing.Color.White;
            this.connectToBikeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectToBikeButton.ForeColor = System.Drawing.Color.Black;
            this.connectToBikeButton.Location = new System.Drawing.Point(426, 374);
            this.connectToBikeButton.Name = "connectToBikeButton";
            this.connectToBikeButton.Size = new System.Drawing.Size(112, 23);
            this.connectToBikeButton.TabIndex = 24;
            this.connectToBikeButton.Text = "Connect to bike";
            this.connectToBikeButton.UseVisualStyleBackColor = false;
            this.connectToBikeButton.Click += new System.EventHandler(this.connectToBikeButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.currentPowerLabel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.requiredRPMLabel);
            this.panel1.Controls.Add(this.currentTimeLabel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.currentHeartRateLabel);
            this.panel1.Location = new System.Drawing.Point(169, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 126);
            this.panel1.TabIndex = 20;
            // 
            // runStatusLabel
            // 
            this.runStatusLabel.AutoSize = true;
            this.runStatusLabel.Location = new System.Drawing.Point(315, 380);
            this.runStatusLabel.Name = "runStatusLabel";
            this.runStatusLabel.Size = new System.Drawing.Size(35, 13);
            this.runStatusLabel.TabIndex = 25;
            this.runStatusLabel.Text = "label2";
            // 
            // TestGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(551, 405);
            this.Controls.Add(this.runStatusLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.connectToBikeButton);
            this.Controls.Add(this.bikeConnectionStatusLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.sexComboBox);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.pauseTestButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trainingsListView);
            this.Controls.Add(this.weightTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ageTextBox);
            this.Controls.Add(this.startTestButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TestGUI";
            this.Text = "Astrand Test";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Label requiredRPMLabel;
        private System.Windows.Forms.Label currentHeartRateLabel;
        private System.Windows.Forms.Label currentPowerLabel;
        private System.Windows.Forms.ComboBox sexComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label bikeConnectionStatusLabel;
        private System.Windows.Forms.Button connectToBikeButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label runStatusLabel;
    }
}