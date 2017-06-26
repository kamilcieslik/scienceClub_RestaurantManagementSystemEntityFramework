using KamilCieślikLab4PD.Model;
using KamilCieślikLab4PD.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KamilCieślikLab4PD
{
    public partial class FormSellerPanel : Form
    {

        KamilCieślikLab4PDContext context;
        ReadRepository<MenuProduct> readMenuProductRepository;
        WriteRepository<Order> writeOrderRepository;
        IList<MenuProduct> products;

        Seller currentSeller;
        public FormSellerPanel(Seller currentSeller, KamilCieślikLab4PDContext context, ReadRepository<MenuProduct> readMenuProductRepository, WriteRepository<Order> writeOrderRepository)
        {
            products = new List<MenuProduct>();
            this.context = context;
            this.readMenuProductRepository = readMenuProductRepository;
            this.writeOrderRepository = writeOrderRepository;
            this.currentSeller = currentSeller;
            InitializeComponent();
            SetCurrentSellerName();

        }

        //Metoda ustawiająca imię i nazwisko zalogowanego sprzedawcy w głównym labelu FormSellerPanel.
        public void SetCurrentSellerName()
        {
            labelCurrentSellerNameAndSurname.Text = currentSeller.Name + " " + currentSeller.Surname;
        }

        private void buttonLogoutFromSellerPanel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Po kliknięciu danego przycisku okoreślającego kategorię produktów menu wyświetli się lista tychże produktów.
        private void buttonCategories_Click(object sender, EventArgs e)
        {
            string option;

            Button button = (Button)sender;
            option = button.Text;

            switch (option)
            {
                case "Kubełki":

                    dataGridViewListOfProducts.DataSource = null;
                    dataGridViewListOfProducts.DataSource = readMenuProductRepository.GetAll().Where(x => x.Category == "kubełek").Select(x => new
                    {
                        ID = x.ID,
                        Kategoria = x.Category,
                        Nazwa = x.Name,
                        Ilosc_Kcal = x.AmountOfCalories,
                        Cena = x.Price
                    }).ToList();
                    break;
                case "Big Boxy":
                    dataGridViewListOfProducts.DataSource = null;
                    dataGridViewListOfProducts.DataSource = readMenuProductRepository.GetAll().Where(x => x.Category == "big box").Select(x => new
                    {
                        ID = x.ID,
                        Kategoria = x.Category,
                        Nazwa = x.Name,
                        Ilosc_Kcal = x.AmountOfCalories,
                        Cena = x.Price
                    }).ToList();
                    break;
                case "Zestawy":
                    dataGridViewListOfProducts.DataSource = null;
                    dataGridViewListOfProducts.DataSource = readMenuProductRepository.GetAll().Where(x => x.Category == "zestaw").Select(x => new
                    {
                        ID = x.ID,
                        Kategoria = x.Category,
                        Nazwa = x.Name,
                        Ilosc_Kcal = x.AmountOfCalories,
                        Cena = x.Price
                    }).ToList();
                    break;
                case "Kanapki":
                    dataGridViewListOfProducts.DataSource = null;
                    dataGridViewListOfProducts.DataSource = readMenuProductRepository.GetAll().Where(x => x.Category == "kanapka").Select(x => new
                    {
                        ID = x.ID,
                        Kategoria = x.Category,
                        Nazwa = x.Name,
                        Ilosc_Kcal = x.AmountOfCalories,
                        Cena = x.Price
                    }).ToList();
                    break;
                case "Sałatki":
                    dataGridViewListOfProducts.DataSource = null;
                    dataGridViewListOfProducts.DataSource = readMenuProductRepository.GetAll().Where(x => x.Category == "sałatka").Select(x => new
                    {
                        ID = x.ID,
                        Kategoria = x.Category,
                        Nazwa = x.Name,
                        Ilosc_Kcal = x.AmountOfCalories,
                        Cena = x.Price
                    }).ToList();
                    break;
                case "Napoje":
                    dataGridViewListOfProducts.DataSource = null;
                    dataGridViewListOfProducts.DataSource = readMenuProductRepository.GetAll().Where(x => x.Category == "napój").Select(x => new
                    {
                        ID = x.ID,
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
            string menuProductID;
            int actualPrice = 0;
            int actualAmountOfCalories = 0;

            if (dataGridViewListOfProducts.SelectedRows.Count > 0)
            {
                menuProductID = dataGridViewListOfProducts.SelectedRows[0].Cells["ID"].Value.ToString();
                products.Add(readMenuProductRepository.GetByID(int.Parse(menuProductID)));

                dataGridViewNewOrderListOfProducts.DataSource = null;

                dataGridViewNewOrderListOfProducts.DataSource = products;


                foreach (MenuProduct product in products)
                {
                    actualPrice += product.Price;
                    actualAmountOfCalories += product.AmountOfCalories;


                }
                labelActualSumPrice.Text = actualPrice.ToString();
                labelActualSumAmountOfCalories.Text = actualAmountOfCalories.ToString();

            }
            else
            {
                MessageBox.Show("Aby dodać produkt do listy nowego zamówienia w pierwszej kolejności musisz jakiś wybrać!");
            }

        }

        //Usuwanie zaznaczonych produktów z listy produktów zamówienia.
        private void buttonDeleteSelectedProductFromNewOrder_Click(object sender, EventArgs e)
        {
            string menuProductID;
            int menuProductToRemoveIndex = 0;
            int iterator = 0;
            int actualPrice = 0;
            int actualAmountOfCalories = 0;

            if (dataGridViewNewOrderListOfProducts.SelectedRows.Count > 0)
            {
                menuProductID = dataGridViewNewOrderListOfProducts.SelectedRows[0].Cells["ID"].Value.ToString();
                foreach (MenuProduct product in products)
                {
                    if (product.ID == int.Parse(menuProductID))
                    {
                        menuProductToRemoveIndex = iterator;
                        break;
                    }
                    iterator++;

                }
                products.RemoveAt(menuProductToRemoveIndex);

                dataGridViewNewOrderListOfProducts.DataSource = null;
                dataGridViewNewOrderListOfProducts.DataSource = products;

                foreach (MenuProduct product in products)
                {
                    actualPrice += product.Price;
                    actualAmountOfCalories += product.AmountOfCalories;
                }
                labelActualSumPrice.Text = actualPrice.ToString();
                labelActualSumAmountOfCalories.Text = actualAmountOfCalories.ToString();

            }
            else
            {
                MessageBox.Show("Aby usunąć produkt z listy nowego zamówienia w pierwszej kolejności musisz jakiś wybrać!");
            }
        }

        //Dodawanie zamówienia.
        private void buttonAcceptNewOrder_Click(object sender, EventArgs e)
        {
            if (products.Count != 0)
            {
                Order order = new Order()
                {
                    SellerID = currentSeller.ID,
                    Price = int.Parse(labelActualSumPrice.Text),
                    AmountOfCalories = int.Parse(labelActualSumAmountOfCalories.Text),
                    Products = products
                };
                writeOrderRepository.Create(order);
                products.Clear();

                dataGridViewNewOrderListOfProducts.DataSource = null;
                dataGridViewNewOrderListOfProducts.DataSource = null;
                labelActualSumPrice.Text = "0";
                labelActualSumAmountOfCalories.Text = "0";
                MessageBox.Show("Pomyślnie dodano zamówienie");
            }
            else
            {
                MessageBox.Show("Próba akceptacji - dodania zamówienia nieudana. Brak produktów!");
            }

        }
    }
}
