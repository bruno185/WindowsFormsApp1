using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class PInvoke1App
        {
            [DllImport("user32.dll")]
            static extern int MessageBoxA(int hWnd, string strMsg, string strCaption, int iType);
            [DllImport("DLL.dll")]
            static extern long  mafonction();

            public static void CallDll()
            {
                string hello = "Hello, World!";
                long i;
                i = mafonction();
                hello = i.ToString("X");
                
                MessageBoxA(0, hello, "This is called from a C# app!", 0);

            }
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PInvoke1App.CallDll();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 4);
            int i;
            int j = 15;
            for (i = 0; i < 10; i++)
            {
                g.DrawLine(p, 50 + j * i, 50, 151 + j * i, 151);
            }
            g.Dispose();

        }
    }
}
