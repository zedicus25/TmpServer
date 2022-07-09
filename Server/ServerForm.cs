using System;
using System.Windows.Forms;

namespace Server
{
    public partial class ServerForm : Form
    {
        ServerNetwork network;
        public ServerForm()
        {
            InitializeComponent();
            network = new ServerNetwork();
            network.AddFile += AddFile;
            network.RemoveFileEvent += RemoveFile;
            foreach (var item in network.Files)
            {
                filesLB.Items.Add(item);
            }
        }
      
        private void AddFile(string file)
        {
            filesLB.Invoke((MethodInvoker)delegate {
                filesLB.Items.Add(file);
            });
        }

        private void RemoveFile(string file)
        {
            filesLB.Invoke((MethodInvoker)delegate {
                filesLB.Items.Clear();
                foreach (var item in network.Files)
                {
                    filesLB.Items.Add(item);
                }
            });
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (filesLB.SelectedItem == null)
                return;
            network.RemoveFile(filesLB.SelectedItem.ToString());
        }

        private void TimeTB_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch((sender as TextBox).Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                (sender as TextBox).Text = (sender as TextBox).Text.Remove((sender as TextBox).Text.Length - 1);
            }
        }

        private void TimeTB_Leave(object sender, EventArgs e)
        {
            if((sender as TextBox).Text.Equals(String.Empty))
                (sender as TextBox).Text = "00";
        }

        private void setTimeBtn_Click(object sender, EventArgs e)
        {
            if (hoursTB.Text.Equals("00") && minutesTB.Text.Equals("00") && secondsTB.Text.Equals("00"))
                return;

            TimeSpan lifeTime = new TimeSpan(int.Parse(hoursTB.Text), int.Parse(minutesTB.Text), int.Parse(secondsTB.Text));

            if (forAllCB.Checked)
            {
                network.SetLifeTimeForAll(lifeTime);
            }
            if(forAllCB.Checked == false)
            {
                if (filesLB.SelectedItem != null)
                    network.SetLifeTime(filesLB.SelectedItem.ToString(), lifeTime);
            }

            hoursTB.Text = "00";
            minutesTB.Text = "00";
            secondsTB.Text = "00";
        }
    }
}
