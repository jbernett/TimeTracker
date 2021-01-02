using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        Story story = new Story();
        int storyHours = 0;
        int storyMinutes = 0;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(story.StoryNumber == 0)
            {
                MessageBox.Show("Please input a different story number");
                return;
            }

            story.TimeSpent = new TimeSpan(storyHours, storyMinutes, 0);

            Form1.stories.Add(story);

            MessageBox.Show("Success!");

            txtHours.Text = "";
            txtMinutes.Text = "";
            txtStoryNumber.Text = "";

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtStoryNumber_Leave(object sender, EventArgs e)
        {
            if(txtStoryNumber.Text == "")
            {
                return;
            }

            if (!int.TryParse(txtStoryNumber.Text, out int storyNumber))
            {
                MessageBox.Show("This needs to be a whole number");
                txtStoryNumber.Text = "";
                txtStoryNumber.Focus();
                return;
            }

            foreach (Story story in Form1.stories)
            {
                if (story.StoryNumber == storyNumber)
                {
                    MessageBox.Show("A story with that identification already exists");
                    txtStoryNumber.Text = "";
                    txtStoryNumber.Focus();
                    return;
                }
            }

            story.StoryNumber = storyNumber;
        }

        private void txtHours_Leave(object sender, EventArgs e)
        {
            if (txtHours.Text == "")
            {
                return;
            } 

            if (!int.TryParse(txtHours.Text, out int hours))
            {
                MessageBox.Show("This needs to be a whole number");
                txtHours.Text = "";
                txtHours.Focus();
                return;
            }

            storyHours = hours;            
        }

        private void txtMinutes_Leave(object sender, EventArgs e)
        {
            if (txtMinutes.Text == "")
            {
                return;
            }

            if (!int.TryParse(txtMinutes.Text, out int minutes))
            {
                MessageBox.Show("This needs to be a whole number");
                txtMinutes.Text = "";
                txtMinutes.Focus();
                return;
            }

            if(minutes >= 60)
            {
                MessageBox.Show("This needs to be 59 or less");
                txtMinutes.Text = "";
                txtMinutes.Focus();
            }

            storyMinutes = minutes;
        }
    }
}
