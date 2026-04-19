using SawaStore_BusinessLayer;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sawa_Store_Project
{
    public partial class frmAddNewUser : Form
    {
        private enum enMode {AddNew = 1, Update = 2};

        private enMode Mode = enMode.AddNew;
        private int _UserID = -1;
        private clsPeople _Person;
        private clsUsers _User;

        public frmAddNewUser(int UserID)
        {
            InitializeComponent();

            if(UserID == -1)
            {
                _UserID = -1;
                lblCaption.Text = "Add New User";
                Mode = enMode.AddNew;
                _Person = new clsPeople();
                _User = new clsUsers();
            }
            else
            {
                Mode = enMode.Update;
                lblCaption.Text = "Update User";
                _UserID = UserID;
                _User = clsUsers.Find(_UserID);
                _Person = _User.Person;
                _LoadUserData();
            }
        }

        private void _LoadUserData()
        {
            clsUsers user = clsUsers.Find(_UserID);

            if(user != null)
            {
                txtName.Text = user.Person.Name.Trim();
                txtAddress.Text = user.Person.Address.Trim();
                txtEmail.Text = user.Person.Email.Trim();
                txtPhone.Text = user.Person.Phone.Trim();

                txtPassword.Text = user.Password.Trim();
                txtConfirmPassword.Text = user.Password.Trim();
                txtUserName.Text = user.UserName.Trim();
                cbIsActive.Checked = user.IsActive;
            }

            btnSave.Focus();

        }

        private void btnAddUser_MouseHover(object sender, EventArgs e)
        {
            btnSave.FillColor = Color.FromArgb(234, 134, 0);
        }

        private void btnAddUser_MouseLeave(object sender, EventArgs e)
        {
            btnSave.FillColor = Color.White;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.FillColor = Color.FromArgb(234, 134, 0);
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.FillColor = Color.White;
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "" || txtAddress.Text == "" || txtConfirmPassword.Text == "" || txtPassword.Text == ""
                || txtPhone.Text == "" || txtUserName.Text == "" || txtEmail.Text == "")
            {
                MessageBox.Show("There are some empty fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(clsValidation.IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid email format.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            _Person.Name = txtName.Text.Trim().ToString();
            _Person.Email = txtEmail.Text.Trim().ToString();
            _Person.Address = txtAddress.Text.Trim().ToString();
            _Person.Phone = txtPhone.Text.Trim().ToString();


            if(_Person.Save())
            {
                if (Mode == enMode.AddNew)
                {
                    if (clsUsers.IsPersonAlreadyUser(_Person.PersonID))
                    {
                        MessageBox.Show("This Person is already exist...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if(txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    MessageBox.Show("Wrong Password confirmation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _User.Person = _Person;
                _User.PersonID = _Person.PersonID;
                _User.UserName = txtUserName.Text.Trim().ToString();  
                _User.Password = txtPassword.Text.Trim().ToString();

                if(cbIsActive.Checked)
                    _User.IsActive = true; 
                else
                    _User.IsActive = false;
                
                if (_User.Save())
                {
                    MessageBox.Show("User saved successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Something went wrong", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
