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
                    @"F:\My Files\Heroes of Might and Magic 3 Complete\H3MAPED.HLP",
                    @"C:\Users\iseep\Desktop"
                ));
                fileOperation.AddOperation(new DeleteFileOperation(
                    @"C:\Users\iseep\Desktop\h3ccmped.cnt"
                ));
                fileOperation.AddOperation(new CopyFileOperation(
                    @"F:\My Files\Heroes of Might and Magic 3 Complete\h3ccmped.cnt",
                    @"C:\Users\iseep\Desktop"
                ));
                fileOperation.AddOperation(new CopyFileOperation(
                    @"F:\My Files\Heroes of Might and Magic 3 Complete\H3AB_Manual.pdf",
                    @"C:\Users\iseep\Desktop"
                ));
                fileOperation.PerformOperations();
            }
        }
    }
}
