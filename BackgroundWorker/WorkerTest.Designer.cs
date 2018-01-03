namespace WorkerTest
{
    partial class WorkerTest
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
            this.LstStatus = new System.Windows.Forms.ListBox();
            this.BgrdWorker = new System.ComponentModel.BackgroundWorker();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ButCancel = new System.Windows.Forms.Button();
            this.ButGo = new System.Windows.Forms.Button();
            this.TxtFile = new System.Windows.Forms.TextBox();
            this.ButChooseFile = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.LblPercent = new System.Windows.Forms.Label();
            this.ButClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LstStatus
            // 
            this.LstStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstStatus.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LstStatus.FormattingEnabled = true;
            this.LstStatus.ItemHeight = 20;
            this.LstStatus.Location = new System.Drawing.Point(14, 92);
            this.LstStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LstStatus.Name = "LstStatus";
            this.LstStatus.Size = new System.Drawing.Size(588, 244);
            this.LstStatus.TabIndex = 0;
            // 
            // BgrdWorker
            // 
            this.BgrdWorker.WorkerReportsProgress = true;
            this.BgrdWorker.WorkerSupportsCancellation = true;
            this.BgrdWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgrdWorker_DoWork);
            this.BgrdWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgrdWorker_ProgressChanged);
            this.BgrdWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgrdWorker_RunWorkerCompleted);
            // 
            // Progress
            // 
            this.Progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Progress.Location = new System.Drawing.Point(68, 63);
            this.Progress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(536, 20);
            this.Progress.TabIndex = 1;
            // 
            // FileDialog
            // 
            this.FileDialog.Filter = "Text files|*.txt|All files|*.*";
            // 
            // ButCancel
            // 
            this.ButCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButCancel.Enabled = false;
            this.ButCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButCancel.Location = new System.Drawing.Point(558, 15);
            this.ButCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButCancel.Name = "ButCancel";
            this.ButCancel.Size = new System.Drawing.Size(45, 35);
            this.ButCancel.TabIndex = 11;
            this.ButCancel.Text = "[]";
            this.ButCancel.UseVisualStyleBackColor = true;
            this.ButCancel.Click += new System.EventHandler(this.ButCancel_Click);
            // 
            // ButGo
            // 
            this.ButGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButGo.Enabled = false;
            this.ButGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButGo.Location = new System.Drawing.Point(504, 15);
            this.ButGo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButGo.Name = "ButGo";
            this.ButGo.Size = new System.Drawing.Size(45, 35);
            this.ButGo.TabIndex = 10;
            this.ButGo.Text = ">";
            this.ButGo.UseVisualStyleBackColor = true;
            this.ButGo.Click += new System.EventHandler(this.ButGo_Click);
            // 
            // TxtFile
            // 
            this.TxtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFile.Location = new System.Drawing.Point(68, 18);
            this.TxtFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtFile.Name = "TxtFile";
            this.TxtFile.Size = new System.Drawing.Size(372, 26);
            this.TxtFile.TabIndex = 9;
            // 
            // ButChooseFile
            // 
            this.ButChooseFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButChooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButChooseFile.Location = new System.Drawing.Point(450, 15);
            this.ButChooseFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButChooseFile.Name = "ButChooseFile";
            this.ButChooseFile.Size = new System.Drawing.Size(45, 35);
            this.ButChooseFile.TabIndex = 8;
            this.ButChooseFile.Text = "...";
            this.ButChooseFile.UseVisualStyleBackColor = true;
            this.ButChooseFile.Click += new System.EventHandler(this.ButChooseFile_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(9, 23);
            this.lblFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(38, 20);
            this.lblFile.TabIndex = 7;
            this.lblFile.Text = "File:";
            // 
            // LblPercent
            // 
            this.LblPercent.AutoSize = true;
            this.LblPercent.Location = new System.Drawing.Point(9, 63);
            this.LblPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPercent.Name = "LblPercent";
            this.LblPercent.Size = new System.Drawing.Size(50, 20);
            this.LblPercent.TabIndex = 12;
            this.LblPercent.Text = "100%";
            // 
            // ButClear
            // 
            this.ButClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButClear.Location = new System.Drawing.Point(14, 366);
            this.ButClear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButClear.Name = "ButClear";
            this.ButClear.Size = new System.Drawing.Size(68, 35);
            this.ButClear.TabIndex = 13;
            this.ButClear.Text = "Clear";
            this.ButClear.UseVisualStyleBackColor = true;
            this.ButClear.Click += new System.EventHandler(this.ButClear_Click);
            // 
            // WorkerTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 411);
            this.Controls.Add(this.ButClear);
            this.Controls.Add(this.LblPercent);
            this.Controls.Add(this.ButCancel);
            this.Controls.Add(this.ButGo);
            this.Controls.Add(this.TxtFile);
            this.Controls.Add(this.ButChooseFile);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.LstStatus);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(364, 354);
            this.Name = "WorkerTest";
            this.Text = "Background Worker Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LstStatus;
        private System.ComponentModel.BackgroundWorker BgrdWorker;
        private System.Windows.Forms.ProgressBar Progress;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button ButCancel;
        private System.Windows.Forms.Button ButGo;
        private System.Windows.Forms.TextBox TxtFile;
        private System.Windows.Forms.Button ButChooseFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label LblPercent;
        private System.Windows.Forms.Button ButClear;
    }
}

