using SawaStore_BusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Sawa_Store_Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        clsCustomers newCustomer;


        private void btnSignUp_Click(object sender, EventArgs e)
        {
            tcSwitcher.SelectedIndex =   1;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            tcSwitcher.SelectedIndex = 0;

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Email = "", Password = "";

            if(clsGlobal.GetStoredCredential(ref Email, ref Password))
            {
                txtEmail.Text = Email;
                txtpassword.Text = Password;
                cbRememberMe.Checked = true;
                btnSignIn.Focus();
            }
            else
            {
                cbRememberMe.Checked = false;
            }
        }

        private void llForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (!clsValidation.IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Invalid email format", "Invalid email", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
                txtEmail.Focus();
                return;
            }

            int userID = clsUsers.FindByEmailAndPassword(txtEmail.Text.Trim(),
                txtpassword.Text.Trim());

            if(userID != -1)
            {
                clsUsers LoggedInUser = clsUsers.Find(userID);

                if (cbRememberMe.Checked)
                {
                    clsGlobal.RememberEmailAndPassword(txtEmail.Text.Trim(), txtpassword.Text.Trim());
                }
                else
                {
                    clsGlobal.RememberEmailAndPassword("", "");
                }


                if(!LoggedInUser.IsActive)
                {
                    txtEmail.Focus();
                    MessageBox.Show("User Account isn't active, Contact Admin", "Error", MessageBoxButtons.OK
                        , MessageBoxIcon.Stop);
                    return;
                }

                clsGlobal.CurrentUser = LoggedInUser;
                this.Hide();
                frmAdminDashboard adminDashboard = new frmAdminDashboard();
                adminDashboard.ShowDialog();
                this.Show();
            }
            else if (clsCustomers.FindCustomerByEmailAndPassword(txtEmail.Text.Trim(), txtpassword.Text.Trim()) != -1)
            {
                clsGlobal.LoggedInCustomer = clsCustomers.Find(clsCustomers.FindCustomerByEmailAndPassword(txtEmail.Text.Trim(), txtpassword.Text.Trim()));

                frmClientView frmClientMainScreen = new frmClientView(clsGlobal.LoggedInCustomer.CustomerID);
                this.Hide();
                frmClientMainScreen.ShowDialog();
                this.Show();
            }
            else
            {
                txtEmail.Focus();
                MessageBox.Show("Email or password invalid", "Wrong Credential", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnSignUpAsCustomer_Click(object sender, EventArgs e)
        {
            if (txtSignUpAddress.Text == "" || txtSignUpConfirmPassword.Text == "" || txtSignUpEmail.Text == ""
                || txtSignUpName.Text == "" || txtSignUpPhone.Text == "" || txtSignUpPassword.Text == "" || txtSignUpUserName.Text =="")
            {
                MessageBox.Show("There are empty fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            if (!clsValidation.IsValidEmail(txtSignUpEmail.Text.Trim()))
            {
                MessageBox.Show("Invalid email format", "Invalid email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            if(txtSignUpPassword.Text.Trim() != txtSignUpConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Password confirmation doesn't match", "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                txtSignUpConfirmPassword.Focus();
                return;
            }

            if(clsCustomers.IsCustomerByEmail(txtSignUpEmail.Text.Trim()))
            {
                MessageBox.Show("Customer is already has account, sign in instead!", "Invalid sign up", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return;
            }

            clsPeople newPerson = new clsPeople();

            newCustomer = new clsCustomers();

            newPerson.Name = txtSignUpName.Text.Trim();
            newPerson.Email = txtSignUpEmail.Text.Trim();
            newPerson.Phone = txtSignUpPhone.Text.Trim();
            newPerson.Address = txtSignUpAddress.Text.Trim();
            
            if(newPerson.Save())
            {
                newCustomer.Person = newPerson;
                newCustomer.PersonID = newPerson.PersonID;
                newCustomer.UserName = txtSignUpUserName.Text.Trim();
                newCustomer.Password = txtSignUpPassword.Text.Trim();

                if (newCustomer.Save())
                {
                    clsGlobal.LoggedInCustomer = clsCustomers.Find(clsCustomers.FindCustomerByEmailAndPassword(txtSignUpEmail.Text.Trim(), txtSignUpPassword.Text.Trim()));

                    frmClientView clientForm = new frmClientView(clsGlobal.LoggedInCustomer.CustomerID);
                    this.Hide();
                    clientForm.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sorry, something went wrong", "Error", MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void txtSignUpPassword_TextChanged(object sender, EventArgs e)
        {
            var checkPasswordStrength = clsValidation.PasswordStrengthChecker(txtSignUpPassword.Text.Trim());

            if(!checkPasswordStrength.Strength)
            {
                lblPasswordStrengthMessage.Visible = true;
                lblPasswordStrengthMessage.ForeColor = Color.Red;
                lblPasswordStrengthMessage.Text = "Weak Password";
                txtpassword.Focus();
                btnSignUpAsCustomer.Enabled = false;
            }
            else if(checkPasswordStrength.Strength)
            {
                lblPasswordStrengthMessage.Visible = true;
                if(checkPasswordStrength.Message == "good")
                {
                    lblPasswordStrengthMessage.Text = "Good Password";
                    lblPasswordStrengthMessage.ForeColor = Color.FromArgb(255, 204, 64);
                }
                else if (checkPasswordStrength.Message == "strong")
                {
                    lblPasswordStrengthMessage.Text = "Strong Password";
                    lblPasswordStrengthMessage.ForeColor = Color.Green;
                }

                btnSignUpAsCustomer.Enabled = true;
            }
            
        }

        private void txtSignUpEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
