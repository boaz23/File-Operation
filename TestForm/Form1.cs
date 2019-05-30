using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileOperation;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var fileOperation = new FileOperation.FileOperation(this.Handle))
            {
                fileOperation.AddOperation(new CopyFileOperation(
                    @"D:\Program Files (x86)\3DO\Heroes 3 Complete\H3MAPED.HLP",
                    @"D:\Desktop"
                ));
                fileOperation.AddOperation(new DeleteFileOperation(
                    @"D:\Desktop\a.txt"
                ));
                fileOperation.AddOperation(new CopyFileOperation(
                    @"D:\Program Files (x86)\3DO\Heroes 3 Complete\h3ccmped.cnt",
                    @"D:\\Desktop"
                ));
                fileOperation.AddOperation(new CopyFileOperation(
                    @"D:\Program Files (x86)\3DO\Heroes 3 Complete\H3AB_Manual.pdf",
                    @"D:\Desktop"
                ));
                fileOperation.PerformOperations();
            }
        }
    }
}
