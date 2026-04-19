using SawaStore_BusinessLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Sawa_Store_Project
{
    public partial class frmAddEditCustomers : Form
    {
        private enum enMode { AddNew = 1, Update = 2 };

        private enMode Mode = enMode.AddNew;
        private int _CustomerID = -1;
        private clsPeople _Person;
        private clsCustomers _Customer;

        public frmAddEditCustomers(int CustomerID)
        {
            InitializeComponent();

            if (CustomerID == -1)
            {
                _CustomerID = -1;
                lblCaption.Text = "Add New User";
                Mode = enMode.AddNew;
                _Person = new clsPeople();
                _Customer = new clsCustomers();
            }
            else
            {
                Mode = enMode.Update;
                lblCaption.Text = "Update User";
                _CustomerID = CustomerID;
                _Customer = clsCustomers.Find(_CustomerID);
                _Person = _Customer.Person;
                _LoadUserData();
            }
        }

        private void _LoadUserData()
        {
            clsCustomers customer = clsCustomers.Find(_CustomerID);

            if (customer != null)
            {
                txtName.Text = customer.Person.Name.Trim();
                txtAddress.Text = customer.Person.Address.Trim();
                txtEmail.Text = customer.Person.Email.Trim();
                txtPhone.Text = customer.Person.Phone.Trim();

                txtPassword.Text = customer.Password.Trim();
                txtConfirmPassword.Text = customer.Password.Trim();
                txtUserName.Text = customer.UserName.Trim();
            }

            btnSave.Focus();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtAddress.Text == "" || txtEmail.Text == "" || txtName.Text == "" || txtPassword.Text == "" || txtPhone.Text == "" 
                || txtConfirmPassword.Text == "" || txtUserName.Text == "" )
            {
                MessageBox.Show("Some field are empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(Mode == enMode.AddNew)
            {
                if(clsCustomers.IsCustomerByEmail(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("This customer is already in the System", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Mode = enMode.Update;
                    return;
                }

            }

            _Person.Name = txtName.Text.Trim().ToString();
            _Person.Email = txtEmail.Text.Trim().ToString();
            _Person.Address = txtAddress.Text.Trim().ToString();
            _Person.Phone = txtPhone.Text.Trim().ToString();

            if (_Person.Save())
            {

                if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
                {
                    MessageBox.Show("Wrong Password confirmation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _Customer.Person = _Person;
                _Customer.PersonID = _Person.PersonID;
                _Customer.UserName = txtUserName.Text.Trim().ToString();
                _Customer.Password = txtPassword.Text.Trim().ToString();

                if (_Customer.Save())
                {
                    MessageBox.Show("Customer saved successfully!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Mode = enMode.Update;
                    return;
                }
                else
                {
                    MessageBox.Show("Customer saved Failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Something went wrong", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_MouseHover(object sender, EventArgs e)
        {
            btnSave.FillColor = Color.FromArgb(234, 134, 0);
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.FillColor = Color.White;
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.FillColor = Color.FromArgb(234, 134, 0);

        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.FillColor = Color.White;
        }
    }
}
