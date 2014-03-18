using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Xml.Linq;
using System.IO;

namespace XmlFormatter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                XDocument xml = XDocument.Parse(textBox1.Text);
                //xml.Declaration = new XDeclaration("1.0", "utf-8", "true");

                using (StringWriter sw = new UTF8StringWriter())
                {
                    xml.Save(sw);
                    textBox2.Text = sw.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("不正な文字列：" + ex.Message);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A & e.Control)
            {
                textBox1.SelectAll();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A & e.Control)
            {
                textBox2.SelectAll();
            }
        }
    }

    class UTF8StringWriter : StringWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
}
