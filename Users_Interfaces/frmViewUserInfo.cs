using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sawa_Store_Project
{
    public partial class frmViewUserInfo : Form
    {
        private int _UserID = -1;

        public frmViewUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            ctrlUserInfo1.LoadUserInfo(UserID);
        }
    }
}
