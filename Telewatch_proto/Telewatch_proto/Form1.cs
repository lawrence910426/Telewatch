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
using Newtonsoft.Json.Linq;

namespace Telewatch_proto
{
    public partial class Form1 : Form
    {
        string room_id;
        public Form1(string room_id)
        {
            this.room_id = room_id;
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

        int last = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            // Play video if loaded
            Task<string> taskState = Shared.GET("State/" + room_id);
            taskState.RunSynchronously();
            JObject state = JObject.Parse(taskState.Result);
            if(state["play"].ToString() == "true")
            {
                // Start the player
            }
            if (state["stop"].ToString() == "true")
            {
                // Stop the player
            }
            if (state["set"]["last"].ToObject<int>() >= last)
            {
                string time = state["set"]["time"].ToString();
                // Stop and set the player
            }


            // Update list
            Task<string> taskUsers = Shared.GET("Users/" + room_id);
            taskUsers.RunSynchronously();
            
            // List<string> users = JsonSerializer.Deserialize<List<string> >(task.Result);
        }
    }
}