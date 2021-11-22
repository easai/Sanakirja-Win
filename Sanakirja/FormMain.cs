using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sanakirja
{
    public partial class FormMain : Form
    {
        async Task getSana()
        {
            Kirja kirja = new Kirja();
            Task<Sana> task = kirja.nrandAsync(1);
            Sana sana = await task;
            labelSana.Text = sana.Fi;
            labelEn.Text = sana.En;
        }
        public FormMain()
        {
            InitializeComponent();
            _ = getSana();
        }

        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            _ = getSana();
        }
    }
}
