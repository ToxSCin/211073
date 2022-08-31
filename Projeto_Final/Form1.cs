using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Projeto_Final
{
    public partial class Form1 : Form
    {
        double total,selecao;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Insert(0, new DataGridViewCheckBoxColumn());
            dataGridView1.Columns.Insert(1, new DataGridViewTextBoxColumn());
            dataGridView1.Columns.Insert(2, new DataGridViewTextBoxColumn());
            dataGridView1.Columns.Insert(3, new DataGridViewTextBoxColumn());


            dataGridView1.Columns[0].Name = "Ok";
            dataGridView1.Columns[1].Name = "Codigo";
            dataGridView1.Columns[2].Name = "Descrição";
            dataGridView1.Columns[3].Name = "Valor";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToDeleteRows = true;

            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Format = "###,###,##0.00";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 0;

            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

            StreamReader arquivo = File.OpenText(openFileDialog1.FileName);

            string linha;
            while ((linha = arquivo.ReadLine()) != null)
            {
                string[] dados = linha.Split(';');
                string codigo = dados[0];
                string descricao = dados[1];
                double valor = double.Parse(dados[2]);

                dataGridView1.Rows.Add(false, codigo, descricao, valor);
                total += valor;
            }
            label2.Text = total.ToString("C");
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0 && e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[0].Value) == false)
                {
                    dataGridView1.CurrentRow.Cells[0].Value = true;
                    selecao += Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value);
                }
                else
                {
                    dataGridView1.CurrentRow.Cells[0].Value = false;
                    selecao -= Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value);
                }
                label4.Text = selecao.ToString("C");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selecao = 0;
            foreach (DataGridViewRow linha in dataGridView1.Rows)
            
                linha.Cells[0].Value = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                {
                    selecao -= Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    total -= Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value);
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selecao = 0;
            foreach (DataGridViewRow linha in dataGridView1.Rows)
            {
                linha.Cells[0].Value = true;
                selecao += Convert.ToDouble(linha.Cells[3].Value);
            }
            label2.Text = selecao.ToString("C");
        }


    }
}
