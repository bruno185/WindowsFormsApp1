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
        // import des fonctions des DLL
        [DllImport("user32.dll")]
        public static extern void SetWindowText(int hWnd, String text);
        [DllImport("user32.dll")]
        static extern int MessageBoxA(int hWnd, string strMsg, string strCaption, int iType);

        [DllImport("DLL.dll")]
        static extern long mafonction();
        [DllImport("DLL.dll")]
        static extern int DoMul(int entier1, int entier2);

        public IntPtr wHnd;

        public Form1()
        {
            InitializeComponent();
            wHnd = this.Handle;

        }

        class PInvoke1App
        {
            public static void CallDll()
            {
                string hello = "Hello, World!";
                MessageBoxA(0, hello, "MessageBoxA", 0);
                long i;
                i = mafonction();
                hello = i.ToString("X");
                MessageBoxA(0, hello, "mafonction();", 0);
                int i2;
                i2 = DoMul(5, 100);
                hello = i2.ToString();
                MessageBoxA(0, hello, "DoMul(5, 100);", 0);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            PInvoke1App.CallDll();
            SetWindowText(wHnd.ToInt32(), "--- Titre de fenêtre ---");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Black, 4);
            int j = 15;
            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(p, 50 + j * i, 50, 151 + j * i, 151);
            }
            g.Dispose();

        }
    }
}
