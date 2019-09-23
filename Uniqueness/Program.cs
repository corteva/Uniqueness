using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Similarity_Search
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var splash = new UniquenessAboutBox();
            splash.StartPosition = FormStartPosition.CenterScreen;
            splash.ShowDialog();

            var mf = new MainForm(new Model());
            mf.StartPosition = FormStartPosition.CenterScreen;
            Application.Run(mf);
        }
    }
}
