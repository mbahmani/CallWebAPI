using CallWebAPI.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CallWebAPI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = "your data can be a class or json or very object that can keep up your fields";
            var service = APIManager. CallApi<Result>("Service Url", data);
            service.Wait();

            var result = service.Result;
        }
    }
}
