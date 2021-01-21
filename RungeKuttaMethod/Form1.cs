using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RungeKuttaMethod
{
    public partial class Form1 : Form
    {
        FunctionVector systemOfFunctions, systemOfAccurateFunctions;
        Vector y0;
        double a, b;
        int N;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();

            dataGridView1.Rows.Clear();

            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        y1Accurate y1 = new y1Accurate();
                        y2Accurate y2 = new y2Accurate();

                        systemOfAccurateFunctions = new FunctionVector(2);
                        systemOfAccurateFunctions[1] = y1;
                        systemOfAccurateFunctions[2] = y2;

                        for (double i = a; i <= b; i += 0.01)
                        {
                            chart1.Series[0].Points.AddXY(i, y1.Value(i));
                            chart1.Series[1].Points.AddXY(i, y2.Value(i));
                        }

                        systemOfFunctions = new FunctionVector(2);
                        systemOfFunctions[1] = new f1();
                        systemOfFunctions[2] = new f2();

                        string[] y0String = textBox3.Text.Split(' ');
                        y0 = new Vector(2);
                        y0[1] = Convert.ToDouble(y0String[0]);
                        y0[2] = Convert.ToDouble(y0String[1]);

                        break;
                    }
                case 1:
                    {
                        Custom1y1Accurate y1 = new Custom1y1Accurate();
                        systemOfAccurateFunctions = new FunctionVector(1);
                        systemOfAccurateFunctions[1] = y1;

                        for (double i = a; i <= b; i += 0.01)
                        {
                            chart1.Series[0].Points.AddXY(i, y1.Value(i));                            
                        }

                        systemOfFunctions = new FunctionVector(1);
                        systemOfFunctions[1] = new Custom1f1();

                        string[] y0String = textBox3.Text.Split(' ');
                        y0 = new Vector(1);
                        y0[1] = Convert.ToDouble(y0String[0]);

                        break;
                    }
                case 2:
                    {
                        Custom2y1Accurate y1 = new Custom2y1Accurate();
                        Custom2y2Accurate y2 = new Custom2y2Accurate();

                        systemOfAccurateFunctions = new FunctionVector(2);
                        systemOfAccurateFunctions[1] = y1;
                        systemOfAccurateFunctions[2] = y2;

                        for (double i = a; i <= b; i += 0.01)
                        {
                            chart1.Series[0].Points.AddXY(i, y1.Value(i));
                            chart1.Series[1].Points.AddXY(i, y2.Value(i));
                        }

                        systemOfFunctions = new FunctionVector(2);
                        systemOfFunctions[1] = new Custom2f1();
                        systemOfFunctions[2] = new Custom2f2();

                        string[] y0String = textBox3.Text.Split(' ');
                        y0 = new Vector(2);
                        y0[1] = Convert.ToDouble(y0String[0]);
                        y0[2] = Convert.ToDouble(y0String[1]);

                        break;
                    }
            }

            N = Convert.ToInt32(numericUpDown1.Value);

            RungeKuttaMethodThirdOrder RKMethod = new RungeKuttaMethodThirdOrder();
            RKMethod.SetParameters(systemOfFunctions, N, a, b, y0);
            RKMethod.Solve();

            for (int i = 0; i < RKMethod.x.Length; ++i)
            {
                for (int j = 1; j <= systemOfAccurateFunctions.Length; ++j)
                {
                    chart1.Series[j + 1].Points.AddXY(RKMethod.x[i], RKMethod.y[i][j]);
                }                
            }

            double err, maxErr;

            for (int i = 10; i <= 1000000; i *= 10)
            {
                RKMethod.SetParameters(systemOfFunctions, i, a, b, y0);
                RKMethod.Solve();

                maxErr = 0;

                for (int j = 1; j <= systemOfAccurateFunctions.Length; ++j)
                {
                    err = Math.Abs(systemOfAccurateFunctions[j].Value(RKMethod.x[i]) - RKMethod.y[i][j]);

                    if (err > maxErr)
                    {
                        maxErr = err;
                    }
                }

                dataGridView1.Rows.Add(i, maxErr);
            }                            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        textBox1.Text = "1";
                        textBox2.Text = "3";
                        textBox3.Text = "0.5 1";
                        break;
                    }
                case 1:
                    {
                        textBox1.Text = "0";
                        textBox2.Text = "1";
                        textBox3.Text = "0";
                        break;
                    }
                case 2:
                    {
                        textBox1.Text = "0";
                        textBox2.Text = "1";
                        textBox3.Text = "3 0";
                        break;
                    }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataGridViewColumn Ns = new DataGridViewColumn();
            Ns.HeaderText = "N";
            Ns.Width = 120;
            Ns.CellTemplate = new DataGridViewTextBoxCell();

            DataGridViewColumn errors = new DataGridViewColumn();
            errors.HeaderText = "Max Error";
            errors.Width = 275;
            errors.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(Ns);
            dataGridView1.Columns.Add(errors);            
        }
    }
}
