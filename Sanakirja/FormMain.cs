using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanakirja
{
    public partial class FormMain : Form
    {
        int index = -1;
        List<Sana> sanaList = new List<Sana>();
        async Task getSana()
        {
            buttonNext.Hide();
            buttonPrev.Hide();
            Kirja kirja = new Kirja();
            Sana sana;
            Task<Sana> task = kirja.nrandAsync(1);
            sana = await task;
            sanaList.Add(sana);
            labelSana.Text = sana.Fi;
            //labelEn.Text = sana.En;
            labelEn.Text = index.ToString() + " " + sana.En;
        }
        public void showSana()
        {
            if (0 < sanaList.Count && 0 <= index && index < sanaList.Count)
            {
                Sana sana = sanaList[index];
                labelSana.Text = sana.Fi;
                //labelEn.Text = sana.En;
                labelEn.Text = index.ToString() + " " + sana.En;
            }
        }
        public FormMain()
        {
            InitializeComponent();
            index++;
            _ = getSana();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            index = sanaList.Count;
            _ = getSana();
            buttonPrev.Show();
            buttonNext.Hide();
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            string fi = labelSana.Text;
            Clipboard.SetDataObject(fi, true);
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (0 < index)
            {
                index -= 1;
            }
            showSana();
            if (0 < index)
            {
                ((Button)sender).Show();
            }
            else
            {
                ((Button)sender).Hide();
            }
            buttonNext.Show();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (index < sanaList.Count - 1)
            {
                index++;
            }
            showSana();
            buttonPrev.Show();
            if (index < sanaList.Count - 1)
            {
                buttonNext.Show();
            }
            else
            {
                buttonNext.Hide();
            }
        }
    }
}
