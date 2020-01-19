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
using System.Xml.Serialization;

namespace ReadXml
{
    public partial class Form1 : Form
    {
        XmlSerializer xs;
        List<StudentClass> ls;
        public Form1()
        {
            InitializeComponent();

            ls = new List<StudentClass>();
            xs = new XmlSerializer(typeof(List<StudentClass>));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("C:\\Users\\Tinsu\\Desktop\\DBA 1\\student.xml", FileMode.Create, FileAccess.Write);
            StudentClass sc = new StudentClass();
            sc.Name = nameText.Text;
            sc.Class = int.Parse(classText.Text);
            sc.sub = subText.Text;

            ls.Add(sc);

            xs.Serialize(fs, ls);
            fs.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("C:\\Users\\Tinsu\\Desktop\\DBA 1\\student.xml", FileMode.Open, FileAccess.Read);
            ls = (List<StudentClass>)xs.Deserialize(fs);

            StudentClass s = ls[0];
            MessageBox.Show(s.Name);

            dataGridView1.DataSource = ls;
            fs.Close();
        }
    }
}
