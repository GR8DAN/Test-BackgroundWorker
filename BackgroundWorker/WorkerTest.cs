using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;

namespace WorkerTest
{
    public partial class WorkerTest : Form
    {
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
        #region Buttons and Listbox
        //Get the file
        private void ButChooseFile_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                TxtFile.Text = FileDialog.FileName;
                ButGo.Enabled = true;
            }
        }
        //Process the file
        private void ButGo_Click(object sender, EventArgs e)
        {
            ButCancel.Enabled = true;
            //Clear previous results
            ButClear_Click(this, null);
            if (!File.Exists(TxtFile.Text))
            {
                AddMessage("The file " + TxtFile.Text + " does not exist.");
            }
            else
            {
                AddMessage("Starting letter analysis...");
                if (BgrdWorker.IsBusy != true)
                {
                    ButGo.Enabled = false;
                    // Start the asynchronous operation.
                    BgrdWorker.RunWorkerAsync(TxtFile.Text);
                }
            }
        }
        //Cancel the processing
        private void ButCancel_Click(object sender, EventArgs e)
        {
            if (BgrdWorker.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                BgrdWorker.CancelAsync();
            }
        }
        //Clear the data
        private void ButClear_Click(object sender, EventArgs e)
        {
            LstStatus.Items.Clear();
            Progress.Value = 0;
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
        //User feedback in listbox
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
        #endregion
        #region  BackgroundWorker
        private void BgrdWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string file;            //name of file to analyse
            long fileLength;        //store total number bytes to process
            long bytesProcessed;    //Count the characters processed
            int nextChar;           //stores each char to analyse
            int progress;           //percentage for progress reporting
            BackgroundWorker worker = sender as BackgroundWorker;   //who called us
                       
            try
            {
                //get the file to process
                file = (string)e.Argument;
                //How many bytes to process?
                fileLength = (new FileInfo(TxtFile.Text)).Length;
                bytesProcessed = 0; //none so far
                // Create an instance of StreamReader to read from file
                // The using statement also closes the StreamReader
                using (StreamReader sr = new StreamReader(file))
                {
                    //until end of the file
                    while((nextChar = sr.Read()) != -1)
                    {
                        //has the operation been cancelled
                        if (worker.CancellationPending == true)
                        {
                            e.Cancel = true;
                            break;
                        }
                        else
                        {
                            //Now process the character
                            AnalyseChar((char)nextChar);
                            bytesProcessed += 1;
                            //Report back every 100000 chars
                            if (bytesProcessed % 100000 == 0)
                            {
                                //report progress
                                //actual percentage calculated on number of processed bytes
                                progress =(int)Math.Ceiling(((float)bytesProcessed / fileLength) * 100);
                                worker.ReportProgress(progress, bytesProcessed);
                            }
                        }
                    }
                    e.Result = bytesProcessed;
                }
            }
            catch (Exception ex)
            {
                throw new Exception ("Error analysing text file: " + ex.ToString());
            }
        }
        //Inform user of pregress
        private void BgrdWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            AddMessage("Processed: " + ((long)e.UserState).ToString() + " bytes");
            Progress.Value = e.ProgressPercentage;
            LblPercent.Text = Progress.Value.ToString() + "%";
        }
        //Finished the processing
        private void BgrdWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ButCancel.Enabled = false;
            ButGo.Enabled = true;
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
                //100% completed
                Progress.Value = 100;
                LblPercent.Text = "100%";
                //Print results
                AddMessage("Analysis completed, bytes processed: " + ((long)e.Result).ToString());
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
                //Show frequency of english letters
                if (EnglishLetter > 0)
                {
                    AddMessage("Total number of English letters:" + EnglishLetter.ToString());
                    double LetterPercentage;
                    string PrintResult;
                    for (int i = 0; i < 26; i++)
                    {
                        LetterPercentage = ((double)LetterFrequency[i] / EnglishLetter) * 100.0;
                        PrintResult = ((char)(i + 65)).ToString();
                        for (int j = 0; j < Math.Round(LetterPercentage); j++)
                            PrintResult += "-";
                        AddMessage(PrintResult + " " + LetterPercentage.ToString("n3") + "%");
                    }
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
            else if (char.IsUpper(Character))
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
        #endregion
    }
}
