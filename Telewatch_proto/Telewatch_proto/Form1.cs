using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Telewatch_proto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e) { axWindowsMediaPlayer1.fullScreen = true; }

        private void button1_Click(object sender, EventArgs e)
        {
            // Removal
            List<string> removals = new List<string>();
            foreach(object item in checkedListBox1.Items)
            {
                CheckBox box = (CheckBox)item;
                if (box.Checked) removals.Add(box.Text.Split(',')[0]);
            }
            string value = Shared.POST("removal", JsonConvert.SerializeObject(removals));
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            // Pause
            // Resume
            // Set time
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load video
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Play video if loaded

            // Update list
            Task<string> task = Shared.GET("Users");
            task.RunSynchronously();
            // List<string> users = JsonSerializer.Deserialize<List<string> >(task.Result);
        }
    }
}