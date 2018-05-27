using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormDanLi
{
    public partial class Form2 : Form
    {
        private Form2()
        {
            InitializeComponent();
        }
        public static Form2 _Form2_Instance;

        public static Form2 CreateInstance()
        {
            if (_Form2_Instance == null || _Form2_Instance.IsDisposed)
            {
                _Form2_Instance = new Form2();
            }
            return _Form2_Instance;
        }

    }
}
