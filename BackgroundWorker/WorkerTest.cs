using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace WorkerTest
{
    public partial class WorkerTest : Form
    {
        long FileLength;        //Store the length of the file being processed
        long BytesProcessed;    //Count the characters processed

        //Count the frequency of different characters
        long LowercaseEnglishLetter = 0;
        long LowercaseNonEnglishLetter = 0;
        long UppercaseEnglishLetter = 0;
        long UppercaseNonEnglishLetter = 0;
        long EnglishLetter = 0;
        long Digit0to9 = 0;
        long Whitespace = 0;
        long ControlCharacter = 0;
        //Count the frequency of English letters
        long[] LetterFrequency=new long[26];

        public WorkerTest()
        {
            InitializeComponent();
        }

        #region  BackgroundWorker
        private void BgrdWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int nextChar;
 
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(TxtFile.Text))
                {
                    while((nextChar = sr.Read()) != -1)
                    {
                        if (worker.CancellationPending == true)
                        {
                            e.Cancel = true;
                            break;
                        }
                        else
                        {
                            //Now process the character
                            AnalyseChar((char)nextChar);
                            BytesProcessed += 1;
                            //Report back every 100,000 chars
                            if (BytesProcessed % 100000 == 0)
                            {
                                //report progress
                                worker.ReportProgress(1, BytesProcessed);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // What was the problem
                AddMessage(ex.Message);
            }
        }

        private void BgrdWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            AddMessage("Processed: " + ((long)e.UserState).ToString() + " bytes");
            Progress.Value = (int)Math.Ceiling(((float)BytesProcessed / FileLength) * 100);
            LblPercent.Text = Progress.Value.ToString() + "%";
        }

        private void BgrdWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ButCancel.Enabled = false;
            if (e.Cancelled == true)
            {
                AddMessage("Analysis aborted.");
            }
            else if (e.Error != null)
            {
                AddMessage("Analysis error: " + e.Error.Message);
            }
            else
            {
                AddMessage("Analysis completed, bytes processed: " + BytesProcessed.ToString());
                Progress.Value = 100;
                LblPercent.Text = "100%";

                if (LowercaseEnglishLetter > 0)
                    AddMessage("Total Lowercase English Letters=" + LowercaseEnglishLetter.ToString());
                if (UppercaseEnglishLetter > 0)
                    AddMessage("Total Uppercase English Letters=" + UppercaseEnglishLetter.ToString());
                if (LowercaseNonEnglishLetter > 0)
                    AddMessage("Total Lowercase Non-English Letters=" + LowercaseNonEnglishLetter.ToString());
                if (UppercaseNonEnglishLetter > 0)
                    AddMessage("Total Uppercase Non-english Letters=" + UppercaseNonEnglishLetter.ToString());
                if (Digit0to9 > 0)
                    AddMessage("Total Digits=" + Digit0to9.ToString());
                if (Whitespace > 0)
                    AddMessage("Total Whitespace=" + Whitespace.ToString());
                if (ControlCharacter > 0)
                    AddMessage("Total Control Characters=" + ControlCharacter.ToString());
                AddMessage("");
                if (EnglishLetter > 0) {
                    AddMessage("Total number of English letters:" + EnglishLetter.ToString());
                    double LetterPercentage;
                    string PrintResult;
                    for (int i = 0; i < 26; i++)
                    {
                        LetterPercentage= ((double)LetterFrequency[i] / EnglishLetter) * 100.0;
                        PrintResult=((char)(i + 65)).ToString();
                        for (int j = 0; j < Math.Round(LetterPercentage); j++)
                            PrintResult += "-";
                        AddMessage(PrintResult + " " + LetterPercentage.ToString("n3") + "%");
                    }
                }
            }
        }
        #endregion
        #region Buttons
        private void ButChooseFile_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                TxtFile.Text = FileDialog.FileName;
                ButGo.Enabled = true;
            }
        }

        private void ButGo_Click(object sender, EventArgs e)
        {
            ButCancel.Enabled = true;
            Analysis();
        }

        private void ButCancel_Click(object sender, EventArgs e)
        {
            if (BgrdWorker.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                BgrdWorker.CancelAsync();
            }
        }

        private void ButClear_Click(object sender, EventArgs e)
        {
            LstStatus.Items.Clear();
            Progress.Value = 0;
            FileLength = 0;
            BytesProcessed = 0;
            LetterFrequency = new long[26];
            LowercaseEnglishLetter = 0;
            LowercaseNonEnglishLetter = 0;
            UppercaseEnglishLetter = 0;
            UppercaseNonEnglishLetter = 0;
            EnglishLetter = 0;
            Digit0to9 = 0;
            Whitespace = 0;
            ControlCharacter = 0;
        }
        #endregion

        //Analyse the text file
        void Analysis()
        {
            //Clear previous results
            ButClear_Click(this,null);
            if (!File.Exists(TxtFile.Text))
            {
                AddMessage("The file " + TxtFile.Text + " does not exist.");
            }
            else
            {
                AddMessage("Starting letter analysis...");
                if (BgrdWorker.IsBusy != true)
                {
                    FileLength = (new FileInfo(TxtFile.Text)).Length;
                    // Start the asynchronous operation.
                    BgrdWorker.RunWorkerAsync();
                }
                else
                {
                    AddMessage("Please wait.");
                }
            }
        }
        //Analyse a single character
        void AnalyseChar(char Character)
        {
            if (char.IsLower(Character))
            {
                if (Character >= 'a' && Character <= 'z')
                {
                    LowercaseEnglishLetter++;
                    LetterFrequency[Character - 'a']++;
                }
                else
                {
                    LowercaseNonEnglishLetter++;
                }
            }
            else if(char.IsUpper(Character))
            {
                if (Character >= 'A' && Character <= 'Z')
                {
                    UppercaseEnglishLetter++;
                    LetterFrequency[Character - 'A']++;
                }
                else
                {
                    UppercaseNonEnglishLetter++;
                }
            }
            else if (char.IsDigit(Character))
            {
                Digit0to9++;
            }
            else if (char.IsWhiteSpace(Character))
            {
                Whitespace++;
            }
            else if (char.IsControl(Character))
            {
                ControlCharacter++;
            }
            EnglishLetter = LowercaseEnglishLetter + UppercaseEnglishLetter;
        }
        //User feedback
        int AddMessage(string MessageToAdd)
        {
            //Limit number of items
            if (LstStatus.Items.Count >= 60000)
                LstStatus.Items.RemoveAt(0);
            int ret = LstStatus.Items.Add(MessageToAdd);
            //ensure new item is visible
            LstStatus.TopIndex = LstStatus.Items.Count - 1;
            return ret;
        }
    }
}
