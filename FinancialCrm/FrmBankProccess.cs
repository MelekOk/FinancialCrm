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
    public partial class FrmBankProccess : Form
    {
        private int loggedInUserId;
        public FrmBankProccess(int userId)
        {
            InitializeComponent();
            loggedInUserId = userId;
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmBankProccess_Load(object sender, EventArgs e)
        {
            var values = db.BankProcesses
        .Select(b => new
        {
            İşlemTarihi = b.ProcessDate,       
            Miktar = b.Amount,         
            Açıklama = b.Description,
            İşlemTürü = b.ProcessType,
            BankaAdi = b.Banks.BankTitle
        })
        .ToList();

            dataGridView1.DataSource = values;
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

        private void btnExpensesFrm_Click(object sender, EventArgs e)
        {
            FrmSpending frm = new FrmSpending(loggedInUserId);
            frm.Show();
            this.Hide();
        }
       
        private void btnSettingsFrm_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings(loggedInUserId);
            frm.Show();
            this.Hide();
        }
    }
}
