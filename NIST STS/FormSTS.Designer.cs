namespace VTDev.Tools.STS
{
    partial class FormSTS
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
            this.grpOutput = new System.Windows.Forms.GroupBox();
            this.btnDialog = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.grpTests = new System.Windows.Forms.GroupBox();
            this.OverlappingTemplate = new System.Windows.Forms.CheckBox();
            this.Frequency = new System.Windows.Forms.CheckBox();
            this.RandomExcursionsVariant = new System.Windows.Forms.CheckBox();
            this.RandomExcursions = new System.Windows.Forms.CheckBox();
            this.CumulativeSums = new System.Windows.Forms.CheckBox();
            this.ApproximateEntropy = new System.Windows.Forms.CheckBox();
            this.Serial = new System.Windows.Forms.CheckBox();
            this.LinearComplexity = new System.Windows.Forms.CheckBox();
            this.NonOverlappingTemplate = new System.Windows.Forms.CheckBox();
            this.Universal = new System.Windows.Forms.CheckBox();
            this.Rank = new System.Windows.Forms.CheckBox();
            this.LongestRun = new System.Windows.Forms.CheckBox();
            this.FFT = new System.Windows.Forms.CheckBox();
            this.Runs = new System.Windows.Forms.CheckBox();
            this.BlockFrequency = new System.Windows.Forms.CheckBox();
            this.grpAlgorithm = new System.Windows.Forms.GroupBox();
            this.lvAlgorithmTest = new System.Windows.Forms.ListView();
            this.col1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.col3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.lblBuildSize = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.chkLogResults = new System.Windows.Forms.CheckBox();
            this.grpOutput.SuspendLayout();
            this.grpTests.SuspendLayout();
            this.grpAlgorithm.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.btnDialog);
            this.grpOutput.Controls.Add(this.txtOutput);
            this.grpOutput.Location = new System.Drawing.Point(8, 15);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(402, 72);
            this.grpOutput.TabIndex = 11;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Select a Test File";
            // 
            // btnDialog
            // 
            this.btnDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDialog.Location = new System.Drawing.Point(360, 19);
            this.btnDialog.Name = "btnDialog";
            this.btnDialog.Size = new System.Drawing.Size(30, 30);
            this.btnDialog.TabIndex = 1;
            this.btnDialog.Text = "...";
            this.btnDialog.UseVisualStyleBackColor = true;
            this.btnDialog.Click += new System.EventHandler(this.OnDialogClick);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(6, 24);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(341, 20);
            this.txtOutput.TabIndex = 2;
            this.txtOutput.Text = "[Select an Input File to Test]";
            // 
            // grpTests
            // 
            this.grpTests.Controls.Add(this.OverlappingTemplate);
            this.grpTests.Controls.Add(this.Frequency);
            this.grpTests.Controls.Add(this.RandomExcursionsVariant);
            this.grpTests.Controls.Add(this.RandomExcursions);
            this.grpTests.Controls.Add(this.CumulativeSums);
            this.grpTests.Controls.Add(this.ApproximateEntropy);
            this.grpTests.Controls.Add(this.Serial);
            this.grpTests.Controls.Add(this.LinearComplexity);
            this.grpTests.Controls.Add(this.NonOverlappingTemplate);
            this.grpTests.Controls.Add(this.Universal);
            this.grpTests.Controls.Add(this.Rank);
            this.grpTests.Controls.Add(this.LongestRun);
            this.grpTests.Controls.Add(this.FFT);
            this.grpTests.Controls.Add(this.Runs);
            this.grpTests.Controls.Add(this.BlockFrequency);
            this.grpTests.Location = new System.Drawing.Point(416, 15);
            this.grpTests.Name = "grpTests";
            this.grpTests.Size = new System.Drawing.Size(213, 364);
            this.grpTests.TabIndex = 12;
            this.grpTests.TabStop = false;
            this.grpTests.Text = "Test Groups";
            // 
            // OverlappingTemplate
            // 
            this.OverlappingTemplate.AutoSize = true;
            this.OverlappingTemplate.Checked = true;
            this.OverlappingTemplate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OverlappingTemplate.Location = new System.Drawing.Point(9, 226);
            this.OverlappingTemplate.Name = "OverlappingTemplate";
            this.OverlappingTemplate.Size = new System.Drawing.Size(177, 17);
            this.OverlappingTemplate.TabIndex = 84;
            this.OverlappingTemplate.Text = "Overlapping Template Matching";
            this.OverlappingTemplate.UseVisualStyleBackColor = true;
            this.OverlappingTemplate.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // Frequency
            // 
            this.Frequency.AutoSize = true;
            this.Frequency.Checked = true;
            this.Frequency.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Frequency.Location = new System.Drawing.Point(9, 111);
            this.Frequency.Name = "Frequency";
            this.Frequency.Size = new System.Drawing.Size(117, 17);
            this.Frequency.TabIndex = 69;
            this.Frequency.Text = "Frequency Monobit";
            this.Frequency.UseVisualStyleBackColor = true;
            this.Frequency.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // RandomExcursionsVariant
            // 
            this.RandomExcursionsVariant.AutoSize = true;
            this.RandomExcursionsVariant.Checked = true;
            this.RandomExcursionsVariant.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RandomExcursionsVariant.Location = new System.Drawing.Point(9, 272);
            this.RandomExcursionsVariant.Name = "RandomExcursionsVariant";
            this.RandomExcursionsVariant.Size = new System.Drawing.Size(194, 17);
            this.RandomExcursionsVariant.TabIndex = 83;
            this.RandomExcursionsVariant.Text = "Random Excursions Variant (1Mib+)";
            this.RandomExcursionsVariant.UseVisualStyleBackColor = true;
            this.RandomExcursionsVariant.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // RandomExcursions
            // 
            this.RandomExcursions.AutoSize = true;
            this.RandomExcursions.Checked = true;
            this.RandomExcursions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RandomExcursions.Location = new System.Drawing.Point(9, 249);
            this.RandomExcursions.Name = "RandomExcursions";
            this.RandomExcursions.Size = new System.Drawing.Size(158, 17);
            this.RandomExcursions.TabIndex = 82;
            this.RandomExcursions.Text = "Random Excursions (1Mib+)";
            this.RandomExcursions.UseVisualStyleBackColor = true;
            this.RandomExcursions.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // CumulativeSums
            // 
            this.CumulativeSums.AutoSize = true;
            this.CumulativeSums.Checked = true;
            this.CumulativeSums.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CumulativeSums.Location = new System.Drawing.Point(9, 65);
            this.CumulativeSums.Name = "CumulativeSums";
            this.CumulativeSums.Size = new System.Drawing.Size(107, 17);
            this.CumulativeSums.TabIndex = 81;
            this.CumulativeSums.Text = "Cumulative Sums";
            this.CumulativeSums.UseVisualStyleBackColor = true;
            this.CumulativeSums.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // ApproximateEntropy
            // 
            this.ApproximateEntropy.AutoSize = true;
            this.ApproximateEntropy.Checked = true;
            this.ApproximateEntropy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ApproximateEntropy.Location = new System.Drawing.Point(9, 19);
            this.ApproximateEntropy.Name = "ApproximateEntropy";
            this.ApproximateEntropy.Size = new System.Drawing.Size(123, 17);
            this.ApproximateEntropy.TabIndex = 80;
            this.ApproximateEntropy.Text = "Approximate Entropy";
            this.ApproximateEntropy.UseVisualStyleBackColor = true;
            this.ApproximateEntropy.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // Serial
            // 
            this.Serial.AutoSize = true;
            this.Serial.Checked = true;
            this.Serial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Serial.Location = new System.Drawing.Point(9, 318);
            this.Serial.Name = "Serial";
            this.Serial.Size = new System.Drawing.Size(52, 17);
            this.Serial.TabIndex = 79;
            this.Serial.Text = "Serial";
            this.Serial.UseVisualStyleBackColor = true;
            this.Serial.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // LinearComplexity
            // 
            this.LinearComplexity.AutoSize = true;
            this.LinearComplexity.Checked = true;
            this.LinearComplexity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LinearComplexity.Location = new System.Drawing.Point(9, 157);
            this.LinearComplexity.Name = "LinearComplexity";
            this.LinearComplexity.Size = new System.Drawing.Size(108, 17);
            this.LinearComplexity.TabIndex = 78;
            this.LinearComplexity.Text = "Linear Complexity";
            this.LinearComplexity.UseVisualStyleBackColor = true;
            this.LinearComplexity.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // NonOverlappingTemplate
            // 
            this.NonOverlappingTemplate.AutoSize = true;
            this.NonOverlappingTemplate.Checked = true;
            this.NonOverlappingTemplate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NonOverlappingTemplate.Location = new System.Drawing.Point(9, 203);
            this.NonOverlappingTemplate.Name = "NonOverlappingTemplate";
            this.NonOverlappingTemplate.Size = new System.Drawing.Size(200, 17);
            this.NonOverlappingTemplate.TabIndex = 76;
            this.NonOverlappingTemplate.Text = "Non Overlapping Template Matching";
            this.NonOverlappingTemplate.UseVisualStyleBackColor = true;
            this.NonOverlappingTemplate.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // Universal
            // 
            this.Universal.AutoSize = true;
            this.Universal.Checked = true;
            this.Universal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Universal.Location = new System.Drawing.Point(9, 341);
            this.Universal.Name = "Universal";
            this.Universal.Size = new System.Drawing.Size(108, 17);
            this.Universal.TabIndex = 75;
            this.Universal.Text = "Universal (1Mib+)";
            this.Universal.UseVisualStyleBackColor = true;
            this.Universal.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // Rank
            // 
            this.Rank.AutoSize = true;
            this.Rank.Checked = true;
            this.Rank.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Rank.Location = new System.Drawing.Point(9, 42);
            this.Rank.Name = "Rank";
            this.Rank.Size = new System.Drawing.Size(115, 17);
            this.Rank.TabIndex = 74;
            this.Rank.Text = "Binary Matrix Rank";
            this.Rank.UseVisualStyleBackColor = true;
            this.Rank.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // LongestRun
            // 
            this.LongestRun.AutoSize = true;
            this.LongestRun.Checked = true;
            this.LongestRun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LongestRun.Location = new System.Drawing.Point(9, 180);
            this.LongestRun.Name = "LongestRun";
            this.LongestRun.Size = new System.Drawing.Size(177, 17);
            this.LongestRun.TabIndex = 73;
            this.LongestRun.Text = "Longest Run of Ones in a Block";
            this.LongestRun.UseVisualStyleBackColor = true;
            this.LongestRun.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // FFT
            // 
            this.FFT.AutoSize = true;
            this.FFT.Checked = true;
            this.FFT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FFT.Location = new System.Drawing.Point(9, 88);
            this.FFT.Name = "FFT";
            this.FFT.Size = new System.Drawing.Size(198, 17);
            this.FFT.TabIndex = 72;
            this.FFT.Text = "Discrete Fourier Transform (Spectral)";
            this.FFT.UseVisualStyleBackColor = true;
            this.FFT.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // Runs
            // 
            this.Runs.AutoSize = true;
            this.Runs.Checked = true;
            this.Runs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Runs.Location = new System.Drawing.Point(9, 295);
            this.Runs.Name = "Runs";
            this.Runs.Size = new System.Drawing.Size(51, 17);
            this.Runs.TabIndex = 71;
            this.Runs.Text = "Runs";
            this.Runs.UseVisualStyleBackColor = true;
            this.Runs.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // BlockFrequency
            // 
            this.BlockFrequency.AutoSize = true;
            this.BlockFrequency.Checked = true;
            this.BlockFrequency.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BlockFrequency.Location = new System.Drawing.Point(9, 134);
            this.BlockFrequency.Name = "BlockFrequency";
            this.BlockFrequency.Size = new System.Drawing.Size(172, 17);
            this.BlockFrequency.TabIndex = 70;
            this.BlockFrequency.Text = "Frequency Test Within a Block";
            this.BlockFrequency.UseVisualStyleBackColor = true;
            this.BlockFrequency.CheckedChanged += new System.EventHandler(this.OnTestCountChanged);
            // 
            // grpAlgorithm
            // 
            this.grpAlgorithm.Controls.Add(this.lvAlgorithmTest);
            this.grpAlgorithm.Controls.Add(this.btnAnalyze);
            this.grpAlgorithm.Location = new System.Drawing.Point(8, 87);
            this.grpAlgorithm.Name = "grpAlgorithm";
            this.grpAlgorithm.Size = new System.Drawing.Size(402, 346);
            this.grpAlgorithm.TabIndex = 10;
            this.grpAlgorithm.TabStop = false;
            this.grpAlgorithm.Text = "AlgorithmTest";
            // 
            // lvAlgorithmTest
            // 
            this.lvAlgorithmTest.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col1,
            this.col2,
            this.col3});
            this.lvAlgorithmTest.FullRowSelect = true;
            this.lvAlgorithmTest.GridLines = true;
            this.lvAlgorithmTest.Location = new System.Drawing.Point(9, 22);
            this.lvAlgorithmTest.Name = "lvAlgorithmTest";
            this.lvAlgorithmTest.Size = new System.Drawing.Size(381, 266);
            this.lvAlgorithmTest.TabIndex = 0;
            this.lvAlgorithmTest.UseCompatibleStateImageBehavior = false;
            this.lvAlgorithmTest.View = System.Windows.Forms.View.Details;
            // 
            // col1
            // 
            this.col1.Text = "Test Name";
            this.col1.Width = 139;
            // 
            // col2
            // 
            this.col2.Text = "P Value";
            this.col2.Width = 125;
            // 
            // col3
            // 
            this.col3.Text = "State";
            this.col3.Width = 112;
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(315, 298);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(75, 35);
            this.btnAnalyze.TabIndex = 1;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.OnAnalyzeClick);
            // 
            // lblBuildSize
            // 
            this.lblBuildSize.AutoSize = true;
            this.lblBuildSize.Location = new System.Drawing.Point(441, 447);
            this.lblBuildSize.Name = "lblBuildSize";
            this.lblBuildSize.Size = new System.Drawing.Size(16, 13);
            this.lblBuildSize.TabIndex = 19;
            this.lblBuildSize.Text = "...";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(216, 447);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(52, 13);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Waiting...";
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(3, 445);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(206, 16);
            this.pbStatus.TabIndex = 16;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 442);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(638, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.chkLogResults);
            this.grpOptions.Location = new System.Drawing.Point(417, 389);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(212, 44);
            this.grpOptions.TabIndex = 20;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // chkLogResults
            // 
            this.chkLogResults.AutoSize = true;
            this.chkLogResults.Location = new System.Drawing.Point(9, 17);
            this.chkLogResults.Name = "chkLogResults";
            this.chkLogResults.Size = new System.Drawing.Size(117, 17);
            this.chkLogResults.TabIndex = 0;
            this.chkLogResults.Text = "Save Results to file";
            this.chkLogResults.UseVisualStyleBackColor = true;
            // 
            // FormSTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 464);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.lblBuildSize);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.grpAlgorithm);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.grpTests);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(654, 511);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(654, 511);
            this.Name = "FormSTS";
            this.Text = "NIST Statistical Test Suite";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClose);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.grpOutput.ResumeLayout(false);
            this.grpOutput.PerformLayout();
            this.grpTests.ResumeLayout(false);
            this.grpTests.PerformLayout();
            this.grpAlgorithm.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOutput;
        private System.Windows.Forms.Button btnDialog;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.GroupBox grpTests;
        private System.Windows.Forms.CheckBox OverlappingTemplate;
        private System.Windows.Forms.CheckBox Frequency;
        private System.Windows.Forms.CheckBox RandomExcursionsVariant;
        private System.Windows.Forms.CheckBox RandomExcursions;
        private System.Windows.Forms.CheckBox CumulativeSums;
        private System.Windows.Forms.CheckBox ApproximateEntropy;
        private System.Windows.Forms.CheckBox Serial;
        private System.Windows.Forms.CheckBox LinearComplexity;
        private System.Windows.Forms.CheckBox NonOverlappingTemplate;
        private System.Windows.Forms.CheckBox Universal;
        private System.Windows.Forms.CheckBox Rank;
        private System.Windows.Forms.CheckBox LongestRun;
        private System.Windows.Forms.CheckBox FFT;
        private System.Windows.Forms.CheckBox Runs;
        private System.Windows.Forms.CheckBox BlockFrequency;
        private System.Windows.Forms.GroupBox grpAlgorithm;
        private System.Windows.Forms.ListView lvAlgorithmTest;
        private System.Windows.Forms.ColumnHeader col1;
        private System.Windows.Forms.ColumnHeader col2;
        private System.Windows.Forms.ColumnHeader col3;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Label lblBuildSize;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar pbStatus;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.CheckBox chkLogResults;
    }
}

