using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace VTDev.Tools.STS
{
    public partial class FormSTS : Form
    {
        #region Constants
        private const string DIALOG_DEFAULT = "[Select an Input File to Test]";
        private const string RESULTS_NAME = "results.txt";
        private const string LOGFILE_NAME = "results.log";
        private const string ALL_FILT = "All Files | *.*";
        #endregion

        #region Fields
        private Dictionary<string, string> _testResults = new Dictionary<string, string>();
        private ListViewItem[] _compareItems;
        private readonly string[] _compareNames = new string[] { 
            "ApproximateEntropy", 
            "BlockFrequency", 
            "CumulativeSums", 
            "FFT", 
            "Frequency", 
            "LinearComplexity", 
            "LongestRun", 
            "NonOverlappingTemplate", 
            "OverlappingTemplate", 
            "Rank", 
            "Runs", 
            "Serial", 
            };
        #endregion

        #region Properties
        private string InputFile { get; set; }
        private string InputDirectory { get; set; }
        private int TestCount { get; set; }
        #endregion

        #region Constructor
        public FormSTS()
        {
            InitializeComponent();
        }
        #endregion

        #region Controls
        private void OnAnalyzeClick(object sender, EventArgs e)
        {
            if (this.TestCount == 0)
            {
                MessageBox.Show("There are no tests selected!");
                return;
            }

            // get test params
            GetNistParams();
            // setup progress
            NistSTS.ProgressChanged -= OnNistProgressChanged;
            NistSTS.ProgressChanged += new Action<int, string>(OnNistProgressChanged);
            pbStatus.Value = 0;
            pbStatus.Maximum = this.TestCount + 1;
            // notify
            lblStatus.Text = "Test Started..";
            // clear old data
            _testResults.Clear();
            // disable ui
            EnabledState(false);
            // clear lv
            lvAlgorithmTest.Items.Clear();

            Task cipherTask = Task.Factory.StartNew(() =>
            {
                Analyze();
            });
        }

        private void OnDialogClick(object sender, EventArgs e)
        {
            string inputFile = GetFileOpenPath("Select an Input File");
            txtOutput.Text = DIALOG_DEFAULT;
            lblStatus.Text = "Waiting..";
            pbStatus.Value = 0;

            if (string.IsNullOrEmpty(inputFile))
                return;

            if (!File.Exists(inputFile))
            {
                MessageBox.Show("The file can not be found!");
                InputFile = string.Empty;
            }
            else
            {
                InputFile = inputFile;
                InputDirectory = Path.GetDirectoryName(InputFile);
                txtOutput.Text = InputFile;
                EnabledState(true);
            }
        }

        private void OnFormClose(object sender, FormClosingEventArgs e)
        {
        }

        private void OnFormLoad(object sender, EventArgs e)
        {
            EnabledState(false);
            grpOutput.Enabled = true;
            TestCount = 15;
        }

        private void OnNistProgressChanged(int count, string message)
        {
            pbStatus.Invoke(new MethodInvoker(delegate { pbStatus.Value = (pbStatus.Value == pbStatus.Maximum) ? 0 : pbStatus.Value + 1; }));
            lblStatus.Invoke(new MethodInvoker(delegate { lblStatus.Text = message; }));
        }

        private void OnTestCountChanged(object sender, EventArgs e)
        {
            this.TestCount = 0;

            foreach (CheckBox chk in ((Control)grpTests).Controls)
                if (chk.Checked && chk.Enabled)
                    this.TestCount++;
        }
        #endregion

        #region Private Methods
        private void Analyze()
        {
            try
            {
                _testResults = NistSTS.Run(InputFile);
            }
            finally
            {
                Invoke(new MethodInvoker(() => { Results(); }));
            }
        }

        private void Results()
        {
            // return ui
            EnabledState(true);
            pbStatus.Value = pbStatus.Maximum;

            // whoops
            if (_testResults.Count < 1)
            {
                lblStatus.Text = "The test Failed!";
                return;
            }

            // put the values to list
            foreach (var val in _testResults)
            {
                ListViewItem item = new ListViewItem(val.Key);
                string[] sub = val.Value.Split(',');

                if (sub.Length > 1)
                {
                    item.SubItems.Add(sub[0]);
                    item.SubItems.Add(sub[1]);
                    lvAlgorithmTest.Items.Add(item);
                }
            }
            // yay!
            lblStatus.Text = "Test Complete!";

            if (chkLogResults.Checked)
                AnalysisToLog();
        }

        private void AnalysisToLog()
        {
            string logPath = Path.Combine(this.InputFile, LOGFILE_NAME);
            const string HEADER = "########################## ANALYSIS RESULTS ##########################";

            try
            {
                using (StreamWriter writer = File.AppendText(logPath))
                {
                    writer.WriteLine(HEADER);
                    writer.WriteLine("Recorded at: " + DateTime.Now.ToLongDateString() + " : " + DateTime.Now.ToLongTimeString());

                    for (int i = 0; i < lvAlgorithmTest.Items.Count; i++)
                    {
                        writer.WriteLine(lvAlgorithmTest.Items[i].Text +
                            " P-Value: " + lvAlgorithmTest.Items[i].SubItems[1].Text +
                            " State: " + lvAlgorithmTest.Items[i].SubItems[2].Text);
                    }
                    writer.WriteLine("");
                }
            }
            catch
            {
                MessageBox.Show("The log file can not be written!");
            }
        }

        private void EnabledState(bool Enabled)
        {
            grpAlgorithm.Enabled = Enabled;
            grpTests.Enabled = Enabled;
        }

        private string GetFileOpenPath(string Description, string FileFilter = ALL_FILT, string DefaultDirectory = "")
        {
            using (OpenFileDialog openDialog = new OpenFileDialog()
            {
                AutoUpgradeEnabled = false,
                CheckFileExists = true,
                Filter = FileFilter,
                RestoreDirectory = true,
                Title = Description
            })
            {
                if (!string.IsNullOrEmpty(DefaultDirectory))
                    openDialog.InitialDirectory = DefaultDirectory;
                if (openDialog.ShowDialog() == DialogResult.OK)
                    return openDialog.FileName;
            }

            return string.Empty;
        }

        private void GetNistParams()
        {
            this.TestCount = 0;

            // simple is good..
            foreach (CheckBox chk in ((Control)grpTests).Controls)
            {
                if (chk.Checked && chk.Enabled)
                    this.TestCount++;

                // checkbox name is a member name
                Tests test = (Tests)Enum.Parse(typeof(Tests), chk.Name);
                NistSTS.ParametersKey[test] = chk.Checked && chk.Enabled;
            }
        }

        #endregion
    }
}
