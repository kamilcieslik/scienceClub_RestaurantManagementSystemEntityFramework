using KamilCieślikLab4PD.Model;
using KamilCieślikLab4PD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KamilCieślikLab4PD.Repository.Commands;
using KamilCieślikLab4PD.Repository.Queries;

namespace KamilCieślikLab4PD
{
    public partial class FormSellerPanel : Form
    {
        private KamilCieślikLab4PdContext _context;
        private readonly ReadRepository<MenuProduct> _readMenuProductRepository;
        private readonly WriteRepository<Order> _writeOrderRepository;
        private readonly IList<MenuProduct> _products;

        private readonly Seller _currentSeller;
        public FormSellerPanel(Seller currentSeller, KamilCieślikLab4PdContext context, ReadRepository<MenuProduct> readMenuProductRepository, WriteRepository<Order> writeOrderRepository)
        {
            _products = new List<MenuProduct>();
            _context = context;
            _readMenuProductRepository = readMenuProductRepository;
            _writeOrderRepository = writeOrderRepository;
            _currentSeller = currentSeller;
            InitializeComponent();
            SetCurrentSellerName();
        }

        //Metoda ustawiająca imię i nazwisko zalogowanego sprzedawcy w głównym labelu FormSellerPanel.
        public void SetCurrentSellerName()
        {
            labelCurrentSellerNameAndSurname.Text = _currentSeller.Name + @" " + _currentSeller.Surname;
        }

        private void buttonLogoutFromSellerPanel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Po kliknięciu danego przycisku okoreślającego kategorię produktów menu wyświetli się lista tychże produktów.
        private void buttonCategories_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var option = button.Text;

            switch (option)
            {
                case "Kubełki":

                    dataGridViewListOfProducts.DataSource = null;
                    dataGridViewListOfProducts.DataSource = _readMenuProductRepository.GetAll().Where(x => x.Category == "kubełek").Select(x => new
                    {
                        x.ID,
                        Kategoria = x.Category,
                        Nazwa = x.Name,
                        Ilosc_Kcal = x.AmountOfCalories,
                        Cena = x.Price
                    }).ToList();
                    break;
                case "Big Boxy":
                    dataGridViewListOfProducts.DataSource = null;
                    dataGridViewListOfProducts.DataSource = _readMenuProductRepository.GetAll().Where(x => x.Category == "big box").Select(x => new
                    {
                        x.ID,
                        Kategoria = x.Category,
                        Nazwa = x.Name,
                        Ilosc_Kcal = x.AmountOfCalories,
                        Cena = x.Price
                    }).ToList();
                    break;
                case "Zestawy":
                    dataGridViewListOfProducts.DataSource = null;
                    dataGridViewListOfProducts.DataSource = _readMenuProductRepository.GetAll().Where(x => x.Category == "zestaw").Select(x => new
                    {
                        x.ID,
                        Kategoria = x.Category,
                        Nazwa = x.Name,
                        Ilosc_Kcal = x.AmountOfCalories,
                        Cena = x.Price
                    }).ToList();
                    break;
                case "Kanapki":
                    dataGridViewListOfProducts.DataSource = null;
                    dataGridViewListOfProducts.DataSource = _readMenuProductRepository.GetAll().Where(x => x.Category == "kanapka").Select(x => new
                    {
                        x.ID,
                        Kategoria = x.Category,
                        Nazwa = x.Name,
                        Ilosc_Kcal = x.AmountOfCalories,
                        Cena = x.Price
                    }).ToList();
                    break;
                case "Sałatki":
                    dataGridViewListOfProducts.DataSource = null;
                    dataGridViewListOfProducts.DataSource = _readMenuProductRepository.GetAll().Where(x => x.Category == "sałatka").Select(x => new
                    {
                        x.ID,
                        Kategoria = x.Category,
                        Nazwa = x.Name,
                        Ilosc_Kcal = x.AmountOfCalories,
                        Cena = x.Price
                    }).ToList();
                    break;
                case "Napoje":
                    dataGridViewListOfProducts.DataSource = null;
                    dataGridViewListOfProducts.DataSource = _readMenuProductRepository.GetAll().Where(x => x.Category == "napój").Select(x => new
                    {
                        x.ID,
                        Kategoria = x.Category,
                        Nazwa = x.Name,
                        Ilosc_Kcal = x.AmountOfCalories,
                        Cena = x.Price
                    }).ToList();
                    break;
            }
        }

        //Dodawanie zaznaczonych produktów do listy produktów zamówienia.
        private void buttonAddProductToNewOrderListOfProducts_Click(object sender, EventArgs e)
        {
            var actualPrice = 0;
            var actualAmountOfCalories = 0;

            if (dataGridViewListOfProducts.SelectedRows.Count > 0)
            {
                var menuProductId = dataGridViewListOfProducts.SelectedRows[0].Cells["ID"].Value.ToString();
                _products.Add(_readMenuProductRepository.GetByID(int.Parse(menuProductId)));

                dataGridViewNewOrderListOfProducts.DataSource = null;
                dataGridViewNewOrderListOfProducts.DataSource = _products;

                foreach (var product in _products)
                {
                    actualPrice += product.Price;
                    actualAmountOfCalories += product.AmountOfCalories;
                }
                labelActualSumPrice.Text = actualPrice.ToString();
                labelActualSumAmountOfCalories.Text = actualAmountOfCalories.ToString();
            }
            else
            {
                MessageBox.Show(@"Aby dodać produkt do listy nowego zamówienia w pierwszej kolejności musisz jakiś wybrać!");
            }
        }

        //Usuwanie zaznaczonych produktów z listy produktów zamówienia.
        private void buttonDeleteSelectedProductFromNewOrder_Click(object sender, EventArgs e)
        {
            var menuProductToRemoveIndex = 0;
            var iterator = 0;
            var actualPrice = 0;
            var actualAmountOfCalories = 0;

            if (dataGridViewNewOrderListOfProducts.SelectedRows.Count > 0)
            {
                var menuProductId = dataGridViewNewOrderListOfProducts.SelectedRows[0].Cells["ID"].Value.ToString();
                foreach (var product in _products)
                {
                    if (product.ID == int.Parse(menuProductId))
                    {
                        menuProductToRemoveIndex = iterator;
                        break;
                    }
                    iterator++;

                }
                _products.RemoveAt(menuProductToRemoveIndex);

                dataGridViewNewOrderListOfProducts.DataSource = null;
                dataGridViewNewOrderListOfProducts.DataSource = _products;

                foreach (var product in _products)
                {
                    actualPrice += product.Price;
                    actualAmountOfCalories += product.AmountOfCalories;
                }
                labelActualSumPrice.Text = actualPrice.ToString();
                labelActualSumAmountOfCalories.Text = actualAmountOfCalories.ToString();
            }
            else
            {
                MessageBox.Show(@"Aby usunąć produkt z listy nowego zamówienia w pierwszej kolejności musisz jakiś wybrać!");
            }
        }

        //Dodawanie zamówienia.
        private void buttonAcceptNewOrder_Click(object sender, EventArgs e)
        {
            if (_products.Count != 0)
            {
                var order = new Order()
                {
                    SellerID = _currentSeller.ID,
                    Price = int.Parse(labelActualSumPrice.Text),
                    AmountOfCalories = int.Parse(labelActualSumAmountOfCalories.Text),
                    Products = _products
                };
                _writeOrderRepository.Create(order);
                _products.Clear();

                dataGridViewNewOrderListOfProducts.DataSource = null;
                dataGridViewNewOrderListOfProducts.DataSource = null;
                labelActualSumPrice.Text = @"0";
                labelActualSumAmountOfCalories.Text = @"0";
                MessageBox.Show(@"Pomyślnie dodano zamówienie");
            }
            else
            {
                MessageBox.Show(@"Próba akceptacji - dodania zamówienia nieudana. Brak produktów!");
            }
        }
    }
}
