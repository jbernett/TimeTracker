using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTracker
{
    public partial class Form2 : Form
    {   
        public Form2()
        {
            InitializeComponent();
            FillList();
        }

        int storyNumber = 0;
        int selectedIndex = -1;
        private void FillList()
        {
            foreach (Story story in Form1.stories)
            {
                var hours = (story.TimeSpent.Days * 24) + story.TimeSpent.Hours;
                var minutes = story.TimeSpent.Minutes;
                lstStoriesBugs.Items.Add($"{story.StoryNumber}:  [Hours ({hours})  Minutes ({minutes})]");
            }
        }

        private void lstStoriesBugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = lstStoriesBugs.SelectedIndex;
            if (selectedIndex < 0)
            {
                return;
            }
            btnRemove.Visible = true;
            var selected = lstStoriesBugs.SelectedItem.ToString();
            var splitString = selected.Split(":".ToCharArray());
            storyNumber = int.Parse(splitString[0]);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you wist to delete this story?", "Hello",MessageBoxButtons.YesNo);
            if(DialogResult.No == result)
            {
                return;
            }
            foreach (Story story in Form1.stories)
            {
                if (storyNumber == story.StoryNumber)
                {
                    Form1.stories.Remove(story);
                    Form1.SaveTime();
                    lstStoriesBugs.Items.RemoveAt(selectedIndex);
                    storyNumber = 0;
                    selectedIndex = -1;
                    btnRemove.Visible = false;
                    MessageBox.Show("Success!");
                    return;
                }
            }
            MessageBox.Show("Welp somthing went wrong");
        }

        private void btnSave_Click(object sender, EventArgs e)
        { 
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Save";
            saveDialog.Filter = "Text Files (*.txt)|*.txt" + "|" +
                                "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                                "All Files (*.*)|*.*";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> lines = new List<string>();
                foreach(var item in lstStoriesBugs.Items)
                {
                    lines.Add(item.ToString());
                }
                File.WriteAllLines(saveDialog.FileName, lines);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddStory_Click(object sender, EventArgs e)
        {

        }
    }
}
