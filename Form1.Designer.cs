namespace NetMonitor
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.cmdSelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSelectOutDir = new System.Windows.Forms.Button();
            this.cmdExit = new System.Windows.Forms.Button();
            this.cmdStartChecking = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // cmdSelectFile
            // 
            this.cmdSelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cmdSelectFile.Location = new System.Drawing.Point(28, 91);
            this.cmdSelectFile.Name = "cmdSelectFile";
            this.cmdSelectFile.Size = new System.Drawing.Size(406, 45);
            this.cmdSelectFile.TabIndex = 0;
            this.cmdSelectFile.Text = "Επιλέξτε &Αρχείο IP Διευθύνσεων - Απλό Text ....";
            this.cmdSelectFile.UseVisualStyleBackColor = true;
            this.cmdSelectFile.Click += new System.EventHandler(this.cmdSelectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(550, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Σύστημα Ελέγχου Λειτουργικότητας Διακομιστών με Διεύθυνση IP:";
            // 
            // cmdSelectOutDir
            // 
            this.cmdSelectOutDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cmdSelectOutDir.Location = new System.Drawing.Point(28, 180);
            this.cmdSelectOutDir.Name = "cmdSelectOutDir";
            this.cmdSelectOutDir.Size = new System.Drawing.Size(406, 45);
            this.cmdSelectOutDir.TabIndex = 2;
            this.cmdSelectOutDir.Text = "Επιλέξτε Φάκελο Εγγραφής των Αποτελεσμάτων....";
            this.cmdSelectOutDir.UseVisualStyleBackColor = true;
            this.cmdSelectOutDir.Click += new System.EventHandler(this.cmdSelectOutDir_Click);
            // 
            // cmdExit
            // 
            this.cmdExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cmdExit.ForeColor = System.Drawing.Color.Red;
            this.cmdExit.Location = new System.Drawing.Point(419, 361);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(154, 45);
            this.cmdExit.TabIndex = 3;
            this.cmdExit.Text = "Έ&ξοδος";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // cmdStartChecking
            // 
            this.cmdStartChecking.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.cmdStartChecking.ForeColor = System.Drawing.Color.Green;
            this.cmdStartChecking.Location = new System.Drawing.Point(28, 271);
            this.cmdStartChecking.Name = "cmdStartChecking";
            this.cmdStartChecking.Size = new System.Drawing.Size(406, 47);
            this.cmdStartChecking.TabIndex = 4;
            this.cmdStartChecking.Text = "Έναρξη Ελέγχου Λειτουργικότητας Διακομιστών";
            this.cmdStartChecking.UseVisualStyleBackColor = true;
            this.cmdStartChecking.Click += new System.EventHandler(this.cmdStartChecking_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 426);
            this.Controls.Add(this.cmdStartChecking);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.cmdSelectOutDir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSelectFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Επιτηρητής Δικτύων";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSelectOutDir;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Button cmdStartChecking;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

