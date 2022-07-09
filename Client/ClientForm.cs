using Server;
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

namespace Client
{
    public partial class ClientForm : Form
    {
        private OpenFileDialog ofd;
        private string file;
        private ClientNetwork client;
        
        public ClientForm()
        {
            client = new ClientNetwork();
            ofd = new OpenFileDialog();
            InitializeComponent();
            client.SendMsg += ShowMessage;
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                file = ofd.FileName;
                client.SendFile(file);
            }
        }

        private void ShowMessage(string msg)
        {
            MessageBox.Show(msg);
        }

        private void getFileBtn_Click(object sender, EventArgs e)
        {
            if (fileIdTB.Text.Equals(String.Empty))
                return;
            client.GetFile(fileIdTB.Text);
            fileIdTB.Text = String.Empty;

        }

        private void enablePremBtn_Click(object sender, EventArgs e)
        {
            client.EnablePremium();
        }
    }
}
