using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckAndCreateLoggingDirectoryAndFile();
            GetStoryTimeList();
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
        List<Story> stories = new List<Story>();
        Story currentStory = new Story();
        string systemPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string folderName = "TimeLogging";
        string fileName = "timeLogger.txt";
        bool isStopped = true;

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
            isStopped = false;
            var thread = new Thread(timer);
            thread.IsBackground = true;
            thread.Start();
            btnGo.Enabled = false;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isStopped = true;
            btnGo.Enabled = true;
            SaveTime();
        }

        private void timer()
        {
            while (!isStopped)
            {
                currentStory.TimeSpent += new TimeSpan(0, 0, 1);
                lblhours.Invoke(new DisplayTimeDelegate(DisplayTime), currentStory.TimeSpent);
                Thread.Sleep(1000);
            }
        }

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

        private void SaveTime()
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
    }
}
