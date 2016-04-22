using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_Rating
{
    public partial class AddGameForm : Form
    {
        public string whiteName { get; set; }
        public string blackName { get; set; }
        public double whiteScore { get; set; }
        public AddGameForm()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            whiteName = whiteNameBox.Text;
            blackName = blackNameBox.Text;
            if (winnerBox.SelectedIndex == 0) whiteScore = 1;
            else if (winnerBox.SelectedIndex == 2) whiteScore = .5;
            else whiteScore = 0;
        }
    }
}
