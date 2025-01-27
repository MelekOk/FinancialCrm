using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;
using MyFinancialCrm;

namespace FinancialCrm
{
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private int loggedInUserId;
        private void btnlogin_Click(object sender, EventArgs e)
        {        
            string username = txtusername.Text.Trim();
            string password = txtuserpassword.Text.Trim();

            var user = db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                loggedInUserId = user.UserId;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public int GetLoggedInUserId()
        {
            return loggedInUserId;
        }
    }
}
