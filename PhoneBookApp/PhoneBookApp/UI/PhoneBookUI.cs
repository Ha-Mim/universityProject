using System;
using System.Windows.Forms;
using PhoneBookApp.BLL;
using PhoneBookApp.DAL.DAO;

namespace PhoneBookApp.UI
{
    public partial class PhoneBookUI : Form
    {
        public PhoneBookUI()
        {
            InitializeComponent();
        }
        PhoneBookManager aBookManager = new PhoneBookManager();
        private void saveButton_Click(object sender, EventArgs e)
        {
            PhoneBook aBook = new PhoneBook();
            aBook.Name = nameTextBox.Text;
            aBook.MobileNo = mobileNoTextBox.Text;
            aBook.Details = detailsTextBox.Text;
            MessageBox.Show(aBookManager.Save(aBook));
            GetAllNumber();
            nameTextBox.Text = "";
            mobileNoTextBox.Text = "";
            detailsTextBox.Text = "";
        }

        public void GetAllNumber()
        {
            foreach (PhoneBook aBook in aBookManager.GetAll())
            {
                ListViewItem myView= new ListViewItem();
                myView.Text = aBook.Id.ToString();
                myView.SubItems.Add(aBook.Name);
                myView.SubItems.Add(aBook.MobileNo);
                myView.SubItems.Add(aBook.Details);
                showListView.Items.Add(myView);
            }
        }
        private void PhoneBookUI_Load(object sender, EventArgs e)
        {
            GetAllNumber();
        }
    }
}
