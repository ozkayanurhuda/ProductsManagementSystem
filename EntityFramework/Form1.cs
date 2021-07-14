using System;
using System.Linq;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //başta yeni bir productDao nesnesi oluşturuyorum methodlara erişebilmek için
        ProductDao _productDao = new ProductDao();

        //--------------------------------------ürünlerin listelendiği formu doldur
        private void Form1_Load(object sender, System.EventArgs e)
        {
            //kodu düzenlemek için productDao dan çağırdım methodları 
            //burada da yazabilirdim direk
            LoadProducts();
        }

        //Load Products: her seferinde işlemlerden sonra ürünlerin güncellenmesi için
        private void LoadProducts()
        {
            dgwProducts.DataSource = _productDao.GetAllProducts();
        }

        //Listeye bakıp yazdım, Db den yazılan versiyonu da var (küçük büyük harf duyarlı)
        private void SearchProducts(string key)
        {
            // dgwProducts.DataSource = _productDao.GetAllProducts().Where(p=> p.Name.ToLower().Contains(key.ToLower())).ToList();

            var result = _productDao.GetByName(key);
            dgwProducts.DataSource = result;
        }

        //-------------------------------------------Add Button
        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            _productDao.AddProduct(new Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text)
            });
            LoadProducts();
            MessageBox.Show("Product Added!");
        }


        //-----------------------------------------Update Button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDao.UpdateProduct(new Product
            {
                //Id aynı kalıyor/Seçilen idli ürünü update
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text),
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text)
            });
            LoadProducts();
            MessageBox.Show("Product Updated!");
        }


        //----------------------hücrelere tıklandığında o ürünün bilgilerini yazsın oto update için
        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        //------------------------------------------Remove Button
        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productDao.DeleteProduct(new Product
            {
                //seçilen idli ürünü sil
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("Product Deleted!");
        }

        //-------------------------------Search Buttonda her seferinde değişimi farketmek
        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProducts(tbxSearch.Text);

        }

        //id ye göre db den urun al
        private void tbxGetById_Click(object sender, EventArgs e)
        {
            _productDao.GetById(2);
        }
    }
}
