using MyFinancialCrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FrmUser loginForm = new FrmUser();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                int userId = loginForm.GetLoggedInUserId();
                Application.Run(new FrmBanks(userId));
            }
        }
    }
}
