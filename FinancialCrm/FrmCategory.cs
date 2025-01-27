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
    public partial class FrmCategory : Form
    {
        private int loggedInUserId;
        public FrmCategory(int userId)
        {
            InitializeComponent();
            loggedInUserId = userId;
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();
        private void FrmCategory_Load(object sender, EventArgs e)
        {
                var values = db.Categories
         .Select(b => new
         {
             KategoriId = b.CategoryId,
             KategoriAdi = b.CategoryName
         })
         .ToList();

                dataGridView1.DataSource = values;
        }

        private void btnCategoryList_Click(object sender, EventArgs e)
        {
            var values = db.Categories
            .Select(b => new
            {
            KategoriId = b.CategoryId,
            KategoriAdi = b.CategoryName
            })
            .ToList();

             dataGridView1.DataSource = values;
        }

        private void btnCreateCategory_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;

            Categories category = new Categories();
            category.CategoryName = name;
            db.Categories.Add(category);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Sisteme Eklendi", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnRemoveCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var removeValue = db.Categories.Find(id);
            db.Categories.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Sistemden Silindi", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Categories.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;
            int id = int.Parse(txtCategoryId.Text);

            var values = db.Categories.Find(id);

            values.CategoryName = name;
            db.SaveChanges();
            MessageBox.Show("Kategori Başarılı Bir Şekilde Sistemde Güncellendi", "Kategoriler", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values2 = db.Categories.ToList();
            dataGridView1.DataSource = values2;
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks(loggedInUserId);
            frm.Show();
            this.Hide();
        }

        private void btnBillFrm_Click(object sender, EventArgs e)
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

        private void btnBanksActionFrm_Click(object sender, EventArgs e)
        {
            FrmBankProccess frm = new FrmBankProccess(loggedInUserId);
            frm.Show();
            this.Hide();
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
