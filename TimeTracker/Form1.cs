using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class Form1 : Form
    {
        public static List<Story> stories = new List<Story>();
        public static Story currentStory = new Story();
        public static string systemPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string folderName = "TimeLogging";
        public static string fileName = "timeLogger.txt";
        TimeSpan takeABreak = new TimeSpan(0, 0, 1);
        TimeSpan currentWork; 
        bool isStopped = true;

        public Form1()
        {
            InitializeComponent();
            CheckAndCreateLoggingDirectoryAndFile();
            GetStoryTimeList();
            IsGoDisplayUpdate(false);
        }

        private void GetStoryTimeList()
        {
            string[] lines = File.ReadAllLines($"{systemPath}\\{folderName}\\{fileName}");
            foreach (string line in lines)
            {
                string[] items = line.Split(",".ToCharArray());
                Story story = new Story();
                story.StoryNumber = int.Parse(items[0]);
                story.TimeSpent = TimeSpan.Parse(items[1]);
                stories.Add(story);
            }
        }
              
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtStroyNumber.Text, out int storyNumber))
            {
                MessageBox.Show("This needs to be a whole number");
                return;
            }

            var found = false;

            foreach (Story story in stories)
            {
                if (story.StoryNumber == storyNumber)
                {
                    currentStory = story;
                    found = true;
                }
            }
            if (!found)
            {
                currentStory.StoryNumber = storyNumber;
            }
            IsGoDisplayUpdate(true);
            currentWork = currentStory.TimeSpent;
            var thread = new Thread(timer);
            thread.IsBackground = true;
            thread.Start();
           
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            IsGoDisplayUpdate(false);
            SaveTime();
        }

        private void IsGoDisplayUpdate(bool isGo)
        {
            isStopped = !isGo;
            btnGo.Enabled = !isGo;
            btnStop.Enabled = isGo;            
            btnGo.BackColor = isGo ? Color.Black : Color.Green;
            btnStop.BackColor = !isGo ? Color.Black : Color.Red;
            if (currentStory.StoryNumber > 0 && isGo)
            {
                txtStroyNumber.Enabled = false;
                btnMinus.Show();
                btnAddTime.Show();
            }
            else
            {
                takeABreak = new TimeSpan(0, 0, 1);
                txtStroyNumber.Enabled = true;
                btnAddTime.Hide();
                btnMinus.Hide();
            }      
        }        

        private void timer()
        {
            while (!isStopped)
            {                 
                currentStory.TimeSpent += new TimeSpan(0, 0, 1);
                btnGo.Invoke(new DisplayTimeDelegate(DisplayTime), currentStory.TimeSpent);
                Thread.Sleep(1000);
                if (takeABreak + currentWork < currentStory.TimeSpent)
                {
                    var result = MessageBox.Show(new Form() { TopMost = true }, "Are you still there? If yes I will ask again in 30 mins", "Pause Story", MessageBoxButtons.YesNo);
                    if (DialogResult.No == result)
                    {
                        btnGo.Invoke(new IsGoDisplayUpdateDelegate(IsGoDisplayUpdate), false);
                        return;
                    }

                    currentWork = currentStory.TimeSpent;
                    takeABreak = new TimeSpan(0, 30, 0);
                }
            }
        }
       
        private delegate void IsGoDisplayUpdateDelegate(bool isGo);

        private delegate void DisplayTimeDelegate(TimeSpan timeSpan);

        private void DisplayTime(TimeSpan timeSpan)
        {
            int hours = (timeSpan.Days * 24) + timeSpan.Hours;

            lblhours.Text = hours.ToString();
            lblMintutes.Text = timeSpan.ToString("%m");
            lblSeconds.Text = timeSpan.ToString("%s");
        }

        private void CheckAndCreateLoggingDirectoryAndFile()
        {
            var fullPath = $"{systemPath}\\{folderName}\\{fileName}";

            if (!Directory.Exists($"{systemPath}\\{folderName}"))
            {
                Directory.CreateDirectory($"{systemPath}\\{folderName}");
                if (!File.Exists(fullPath))
                {
                    var file = File.Create(fullPath);
                    file.Close();
                }
            }
        }

        public static void SaveTime()
        {
            var found = false;
            var lines = new List<string>();
            foreach (Story story in stories)
            {
                if (currentStory.StoryNumber == story.StoryNumber)
                {
                    story.TimeSpent = currentStory.TimeSpent;
                    found = true;
                }                
            }
            if (!found)
            {
                stories.Add(currentStory);
            }
            foreach (Story story in stories)
            {
                lines.Add($"{story.StoryNumber},{story.TimeSpent}");
            }

            if(lines.Count > 0)
            {
                File.WriteAllLines($"{systemPath}\\{folderName}\\{fileName}", lines);
            }
            currentStory = new Story();
        }

        int addCounter = 0;
        private void btnAddTime_Click(object sender, EventArgs e)
        {
            currentStory.TimeSpent += new TimeSpan(0, 30, 0);
            DisplayTime(currentStory.TimeSpent);
            addCounter++;
            if(addCounter > 50)
            {
                AddSnarkyText();
            }
        }

        int minusCounter = 0;
        private void btnMinus_Click(object sender, EventArgs e)
        {
            if(currentStory.TimeSpent > new TimeSpan())
            {
                currentStory.TimeSpent += new TimeSpan(0, -30, 0);
                DisplayTime(currentStory.TimeSpent);
            }
            else
            {
                MessageBox.Show("Whoa there! Your breaking things here! I'm setting it to zero");
                currentStory.TimeSpent = new TimeSpan();
            }
            minusCounter++;
            if (minusCounter > 50)
            {
                AddSnarkyText();
            }

        }

        private void AddSnarkyText()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 6);
            switch (randomNumber)
            {
                case 1:
                    MessageBox.Show("Pressing buttons must be your favorite");
                    break;
                case 2:
                    MessageBox.Show("You must be fairly forgetful, or you never close this program");
                    break;
                case 3:
                    MessageBox.Show("You have crashed this program, sending report to managment for button smashing");
                    break;
                case 4:
                    MessageBox.Show("Ah ah ah! You didn't say the magic word!");
                    break;
                case 5:
                    MessageBox.Show("This button has been pressed fifty times, maybe give this program a break and restart it");
                    break;
                default:
                    MessageBox.Show("I have no idea how you got here, this shouldn't happen");
                    break;
            }
        }
        

        private void btnOpenForm_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.FormClosed += new FormClosedEventHandler(form2_FormClosed);
            form2.Show();
            Hide();
        }
        private void form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Show();
        }
    }
}
