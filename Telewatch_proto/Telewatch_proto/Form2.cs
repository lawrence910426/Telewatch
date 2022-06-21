using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telewatch_proto
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Add
            string room_id = Shared.POST(
                "add_room",
                Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    uri = textBox4.Text,
                    name = textBox3.Text
                })
            );

            new Form1(room_id).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Join
            string room_id = Shared.POST(
                "join_room",
                Newtonsoft.Json.JsonConvert.SerializeObject(new
                {
                    room_id = textBox1.Text,
                    name = textBox2.Text
                })
            );

            if (room_id == "") MessageBox.Show("Room not found");
            else new Form1(room_id).Show();
        }
    }
}
