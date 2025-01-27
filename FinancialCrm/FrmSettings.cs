using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialCrm.Models;
using MyFinancialCrm;

namespace FinancialCrm
{
    public partial class FrmSettings : Form
    {
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private int loggedInUserId;
        public FrmSettings(int userId)
        {
            InitializeComponent();
            loggedInUserId = userId;
        }
        private void FrmSettings_Load(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string currentPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            string newUsername = txtNewUsername.Text.Trim();

            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Şifre alanları boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Yeni şifreler eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var user = db.Users.FirstOrDefault(u => u.UserId == loggedInUserId);
            if (user == null)
            {
                MessageBox.Show("Kullanıcı bulunamadı! Kullanıcı ID: " + loggedInUserId, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (user.Password != currentPassword)
            {
                MessageBox.Show("Mevcut şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            user.Password = newPassword;

            if (!string.IsNullOrEmpty(newUsername))
            {
                user.Username = newUsername;
            }
            db.SaveChanges();

            MessageBox.Show("Kullanıcı bilgileri başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FrmSettings frmSettings = new FrmSettings(loggedInUserId);
            frmSettings.Show();
            this.Close();
        }


        private void btnCategoryFrm_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory(loggedInUserId);
            frm.Show();
            this.Hide();
        }

        private void btnBanksFrm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks(loggedInUserId);
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {
            FrmBilling frm = new FrmBilling(loggedInUserId);
            frm.Show();
            this.Hide();
        }

        private void btnExpensesFrm_Click(object sender, EventArgs e)
        {
            FrmSpending frm = new FrmSpending(loggedInUserId);
            frm.Show();
            this.Hide();
        }

        private void btnBanksActionFrm_Click(object sender, EventArgs e)
        {
            FrmBankProccess frm = new FrmBankProccess(loggedInUserId);
            frm.Show();
            this.Hide();
        }

        private void btnDashboardFrm_Click(object sender, EventArgs e)
        {
            FrmDashboard frm = new FrmDashboard(loggedInUserId);
            frm.Show();
            this.Hide();
        }

        private void btnExitFrm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
