using SawaStore_BusinessLayer;
using System;
using System.Windows.Forms;

namespace Sawa_Store_Project
{
    public partial class ctrlUserInfo : UserControl
    {
        private int _UserID = -1;
        private clsUsers _UserInfo;

        public ctrlUserInfo()
        {
            InitializeComponent();
        }

        private void ctrlUserInfo_Load(object sender, EventArgs e)
        {
            //lblUserID.Text     = "???";
            //lblAddress.Text    = "???";
            //lblEmail.Text      = "???";
            //lblPhone.Text      = "???";
            //lblName.Text       = "???";
            //lblUsername.Text   = "???";
        }

        public void LoadUserInfo(int UserID)
        {
            clsUsers user = clsUsers.Find(UserID);

            if(user != null)
            {
                _UserInfo = user;
                _UserID = UserID;

                lblUserID.Text    = _UserID.ToString();
                lblAddress.Text   = _UserInfo.Person.Address;
                lblEmail.Text  = _UserInfo.Person.Email;
                lblPhone.Text = _UserInfo.Person.Phone;
                lblName.Text   = _UserInfo.Person.Name;
                lblUsername.Text  = _UserInfo.UserName;

                // Needed update on database
                if (_UserInfo.IsActive)
                {
                    lblIsActive.Text = "Active";
                }
                else
                {
                    lblIsActive.Text = "Unactive";
                }
            }
            else
            {
                MessageBox.Show("User not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) ;
                ctrlUserInfo_Load(null, null);
                return;
            }
        }
    }
}
