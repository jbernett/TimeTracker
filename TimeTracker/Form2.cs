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
    public partial class Form2 : Form
    {        
        public Form2(List<Story> stories)
        {
            InitializeComponent();
            FillList(stories);
        }

        private void FillList(List<Story> stories)
        {
            foreach (Story story in stories)
            {
                var hours = (story.TimeSpent.Days * 24) + story.TimeSpent.Hours;
                var minutes = story.TimeSpent.Minutes;
                lstStoriesBugs.Items.Add($"{story.StoryNumber}  Hours: {hours}  Minutes: {minutes}");
            }
        }

        private void lstStoriesBugs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = lstStoriesBugs.SelectedItem.ToString();
        }
    }
}
