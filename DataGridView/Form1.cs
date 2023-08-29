using DataGridView.BLL.Managers;
using DataGridView.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridView
{

    public partial class Form1 : Form
    {
        private ProductManager productManager = new ProductManager();

        public Form1()
        {
            InitializeComponent();
            LoadData();


        }

        private void LoadData()
        {
            dataGridView1.DataSource = productManager.GetProducts();
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtPrice.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && decimal.TryParse(txtPrice.Text, out decimal price))
            {
                productManager.CreateProduct(new ProductDTO
                {
                    Name = txtName.Text,
                    Price = price,
                });

                LoadData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ürün adı ve fiyat girin.");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && decimal.TryParse(txtPrice.Text, out decimal price))
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                productManager.UpdateProduct(new ProductDTO
                {
                    Id = productId,
                    Name = txtName.Text,
                    Price = price,
                });

                LoadData();
                ClearForm();
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz bir ürün seçin ve geçerli bir fiyat girin.");
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {


            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Ürünü silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    int productId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                    productManager.DeleteProduct(new ProductDTO
                    {
                        Id = productId
                    });

                    LoadData();
                    ClearForm();
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir ürün seçin.");
            }
        }


        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtPrice.Text = selectedRow.Cells["Price"].Value.ToString();
            }
        }
    }



}
