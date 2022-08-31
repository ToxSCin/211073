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
        double total;
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
            dataGridView1.Columns.Insert(4, new DataGridViewTextBoxColumn());
            dataGridView1.Columns.Insert(5, new DataGridViewTextBoxColumn());
            dataGridView1.Columns.Insert(6, new DataGridViewTextBoxColumn());



            dataGridView1.Columns[0].Name = "Ok";
            dataGridView1.Columns[1].Name = "ID";
            dataGridView1.Columns[2].Name = "Codigo";
            dataGridView1.Columns[3].Name = "Produto";
            dataGridView1.Columns[4].Name = "Venda";
            dataGridView1.Columns[5].Name = "Valor";
            dataGridView1.Columns[6].Name = "Estoque";


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
                int id = int.Parse(dados[0]);
                int codigo = int.Parse(dados[1]);
                string produto = dados[2];
                double valor = double.Parse(dados[3]);
                double venda = double.Parse(dados[4]);
                double Estoque = double.Parse(dados[5]);





                total += valor;

                if (venda <= valor)
                {
                    dataGridView1.Rows.Add(false, id, codigo, produto, valor, venda, Estoque);
                    dataGridView1.Rows[id -1].DefaultCellStyle.BackColor = Color.Red;

                }

            }
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0 && e.ColumnIndex == 0)
            {
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[0].Value) == false)
                {
                    dataGridView1.CurrentRow.Cells[0].Value = true;
                    
                }
                else
                {
                    dataGridView1.CurrentRow.Cells[0].Value = false;
                    
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow linha in dataGridView1.Rows)
            
                linha.Cells[0].Value = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView1.RowCount - 1; i >= 0; i--)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[0].Value) == true)
                {
                    
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             
            foreach (DataGridViewRow linha in dataGridView1.Rows)
            {
                linha.Cells[0].Value = true;
                
            }
            
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
