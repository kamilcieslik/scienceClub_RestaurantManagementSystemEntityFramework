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
    public partial class MainFrame : Form
    {
        private KamilCieślikLab4PDContext context;
        private readonly ReadRepository<Seller> readSellerRepository;
        private readonly ReadRepository<Supplier> readSupplierRepository;
        private readonly ReadRepository<Supply> readSupplyRepository;
        private readonly ReadRepository<MenuProduct> readMenuProductRepository;
        private readonly ReadRepository<Order> readOrderRepository;

        private readonly WriteRepository<Seller> writeSellerRepository;
        private readonly WriteRepository<Supplier> writeSupplierRepository;
        private readonly WriteRepository<Supply> writeSupplyRepository;
        private readonly WriteRepository<MenuProduct> writeMenuProductRepository;
        private readonly WriteRepository<Order> writeOrderRepository;

        private string currentTable;

        public MainFrame()
        {
            context = new KamilCieślikLab4PDContext();
            //context.Database.CreateIfNotExists();
            readSellerRepository = new ReadRepository<Seller>(context);
            readSupplierRepository = new ReadRepository<Supplier>(context);
            readSupplyRepository = new ReadRepository<Supply>(context);
            readMenuProductRepository = new ReadRepository<MenuProduct>(context);
            readOrderRepository = new ReadRepository<Order>(context);

            writeSellerRepository = new WriteRepository<Seller>(context);
            writeSupplierRepository = new WriteRepository<Supplier>(context);
            writeSupplyRepository = new WriteRepository<Supply>(context);
            writeMenuProductRepository = new WriteRepository<MenuProduct>(context);
            writeOrderRepository = new WriteRepository<Order>(context);

            InitializeComponent();
        }

        //Przyciski dodające obiekty do baz danych.
        private void buttonRegisterNewSeller_Click(object sender, EventArgs e)
        {
            try
            {
                Seller seller = new Seller()
                {
                    Name = textBoxSellerName.Text,
                    Surname = textBoxSellerSurname.Text,
                    YearsOfExperience = int.Parse(comboBoxSellerYearsOfExperience.Text),
                    EnglishLevel = comboBoxSellerEnglishLevel.Text,
                    Password = textBoxSellerPassword.Text
                };
                writeSellerRepository.Create(seller);
                ShowSellers();
            }
            catch (Exception)
            {
                MessageBox.Show("Błędne/niepełne dane sprzedawcy!");
            }
            ClearTextBoxes();
        }

        private void buttonAddNewSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                Supplier supplier = new Supplier()
                {
                    Name = textBoxSupplierName.Text,
                    Localization = comboBoxSupplierLocalization.Text,
                    DeliveryTime = int.Parse(textBoxSupplierDeliveryTime.Text)
                };
                writeSupplierRepository.Create(supplier);
                ShowSuppliers();
            }
            catch (Exception)
            {
                MessageBox.Show("Błędne/niepełne dane dostawcy!");
            }
            ClearTextBoxes();
        }

        private void buttonAddNewSupply_Click(object sender, EventArgs e)
        {
            string supplierID;

            if ((currentTable == "suppliers") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                supplierID = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                try
                {
                    Supply supply = new Supply()
                    {
                        Date = DateTime.Parse(textBoxSupplyDate.Text),
                        OrderedProduct = textBoxSupplyOrderedProduct.Text,
                        Price = int.Parse(textBoxSupplyPrice.Text),
                        ProviderID = int.Parse(supplierID)
                    };
                    writeSupplyRepository.Create(supply);
                    ShowSupplies();
                }
                catch (Exception)
                {
                    MessageBox.Show("Błędne/niepełne dane dostawy!");
                }
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Pamietaj o wyborze dostawcy przed dodaniem sfinaliowaniem dostawy!");
            }

        }

        private void buttonAddProductMenu_Click(object sender, EventArgs e)
        {
            try
            {
                MenuProduct menuProduct = new MenuProduct()
                {
                    Category = comboBoxMenuProductCategory.Text,
                    Name = textBoxMenuProductName.Text,
                    AmountOfCalories = int.Parse(textBoxMenuProductAmountOfCalories.Text),
                    Price = int.Parse(textBoxMenuProductPrice.Text)
                };
                writeMenuProductRepository.Create(menuProduct);
                ShowMenuProducts();
            }
            catch (Exception)
            {
                MessageBox.Show("Błędne/niepełne dane produktu menu!");
            }
            ClearTextBoxes();
        }

        //Przyciski wyświetlające obiekty tabel z bazy danych w DataGridView
        private void buttonShowAllSellers_Click(object sender, EventArgs e)
        {
            ShowSellers();
        }

        private void buttonShowAllSuppliers_Click(object sender, EventArgs e)
        {
            ShowSuppliers();
        }

        private void buttonShowAllSupplies_Click(object sender, EventArgs e)
        {
            ShowSupplies();
        }

        private void buttonShowAllMenuProducts_Click(object sender, EventArgs e)
        {
            ShowMenuProducts();
        }

        private void buttonShowAllOrders_Click(object sender, EventArgs e)
        {
            ShowOrders();
        }

        //Czyszczenie textBoxow, comboBoxow i labeli.
        public void ClearTextBoxes()
        {
            textBoxSellerName.Clear();
            textBoxSellerSurname.Clear();
            textBoxSellerPassword.Clear();
            textBoxSupplierName.Clear();
            textBoxSupplierDeliveryTime.Clear();
            textBoxSupplierDeliveryTimeFrom.Clear();
            textBoxSupplierDeliveryTimeTo.Clear();
            textBoxSupplyDate.Clear();
            textBoxSupplyOrderedProduct.Clear();
            textBoxSupplyPrice.Clear();
            textBoxSearchSupplyByOrderedProduct.Clear();
            textBoxSuppliesPriceFrom.Clear();
            textBoxSuppliesPriceTo.Clear();
            textBoxMenuProductName.Clear();
            textBoxMenuProductAmountOfCalories.Clear();
            textBoxMenuProductPrice.Clear();
            textBoxMenuProductPriceTimeFrom.Clear();
            textBoxMenuProductPriceTimeTo.Clear();
            textBoxEnterSellerPassword.Clear();

            comboBoxSellerYearsOfExperience.SelectedIndex = -1;
            comboBoxSellerEnglishLevel.SelectedIndex = -1;
            comboBoxSellersSortBy.SelectedIndex = -1;
            comboBoxShowBySellerYearsOfExperience.SelectedIndex = -1;
            comboBoxShowBySellerEnglishLevel.SelectedIndex = -1;
            comboBoxSupplierLocalization.SelectedIndex = -1;
            comboBoxSuppliersSortBy.SelectedIndex = -1;
            comboBoxShowBySupplierLocalization.SelectedIndex = -1;
            comboBoxSuppliesSortBy.SelectedIndex = -1;
            comboBoxMenuProductCategory.SelectedIndex = -1;
            comboBoxMenuProductsSortBy.SelectedIndex = -1;
            comboBoxShowByMenuProductCategory.SelectedIndex = -1;

            labelProfit.Text = "-";
            labelGain.Text = "-";
            labelCostOfSupplies.Text = "-";
            labelAverageDeliveryTime.Text = "-";
            labelMostExpensiveOrder.Text = "-";
            labelAverageYearsOfExperience.Text = "-";         
        }

        //Metody wyświetlające obiekty tabel z bazy danych w DataGridView
        public void ShowSellers()
        {
            dataGridViewRestaurantManagementSystem.DataSource = null;
            dataGridViewRestaurantManagementSystem.DataSource = readSellerRepository
                .GetAll()
                .Select(x => new
                {
                    ID = x.ID,
                    Imie_Sprzedawcy = x.Name,
                    Nazwisko = x.Surname,
                    Lata_Doswiadczenia = x.YearsOfExperience,
                    Znajomosc_Angielskiego = x.EnglishLevel,
                }).ToList();
            currentTable = "sellers";
        }

        public void ShowSuppliers()
        {
            dataGridViewRestaurantManagementSystem.DataSource = null;
            dataGridViewRestaurantManagementSystem.DataSource = readSupplierRepository
                .GetAll()
                .Select(x => new
                {
                    ID = x.ID,
                    Nazwa = x.Name,
                    Lokalizacja = x.Localization,
                    Czas_Dostaw = x.DeliveryTime,
                }).ToList();
            currentTable = "suppliers";
        }

        public void ShowSupplies()
        {
            dataGridViewRestaurantManagementSystem.DataSource = null;
            dataGridViewRestaurantManagementSystem.DataSource = readSupplyRepository
                .GetAll()
                .Select(x => new
                {
                    ID = x.ID,
                    Data_Zamowienia = x.Date,
                    Zamowiony_Produkt = x.OrderedProduct,
                    Cena = x.Price,
                    Dostawca = readSupplierRepository.GetByID(x.ProviderID).Name
                }).ToList();
            currentTable = "supplies";
        }

        public void ShowMenuProducts()
        {
            dataGridViewRestaurantManagementSystem.DataSource = null;
            dataGridViewRestaurantManagementSystem.DataSource = readMenuProductRepository
                .GetAll()
                .Select(x => new
                {
                    ID = x.ID,
                    Kategoria = x.Category,
                    Nazwa = x.Name,
                    Ilosc_Kcal = x.AmountOfCalories,
                    Cena = x.Price
                }).ToList();
            currentTable = "menuproducts";

        }

        public void ShowOrders()
        {
            dataGridViewRestaurantManagementSystem.DataSource = null;
            dataGridViewRestaurantManagementSystem.DataSource = readOrderRepository
                .GetAll()
                .Select(x => new
                {
                    ID = x.ID,
                    Data = x.Date,
                    Sprzedajacy = readSellerRepository.GetByID(x.SellerID).Name +" "+ readSellerRepository.GetByID(x.SellerID).Surname,
                    Cena = x.Price,
                    Kalorie = x.AmountOfCalories,
                }).ToList();
            currentTable = "orders";
        }

        //Przyciski usuwające obiekty tabel z bazy danych.
        private void buttonDeleteSelectedSeller_Click(object sender, EventArgs e)
        {
            string sellerID;

            if ((currentTable == "sellers") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                sellerID = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                writeSellerRepository.Delete(readSellerRepository.GetByID(int.Parse(sellerID)));
                ShowSellers();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Aby usunąc sprzedawce w pierwszej kolejności musisz jakiegoś wybrać!");
            }
            ClearTextBoxes();
        }

        private void buttonDeleteSelectedSupplier_Click(object sender, EventArgs e)
        {
            string supplierID;

            if ((currentTable == "suppliers") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                supplierID = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                writeSupplierRepository.Delete(readSupplierRepository.GetByID(int.Parse(supplierID)));
                ShowSuppliers();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Aby usunąc dostawce w pierwszej kolejności musisz jakiegoś wybrać!");
            }
            ClearTextBoxes();
        }

        private void buttonDeleteSelectedSupply_Click(object sender, EventArgs e)
        {
            string supplyID;

            if ((currentTable == "supplies") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                supplyID = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                writeSupplyRepository.Delete(readSupplyRepository.GetByID(int.Parse(supplyID)));
                ShowSupplies();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Aby usunąc dostawce w pierwszej kolejności musisz jakiegoś wybrać!");
            }
            ClearTextBoxes();
        }

        private void buttonDeleteSelectedMenuProduct_Click(object sender, EventArgs e)
        {
            string menuProductID;

            if ((currentTable == "menuproducts") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                menuProductID = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                writeMenuProductRepository.Delete(readMenuProductRepository.GetByID(int.Parse(menuProductID)));
                ShowMenuProducts();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Aby usunąc produkt menu w pierwszej kolejności musisz jakiś wybrać!");
            }
            ClearTextBoxes();
        }

        //Przyciski edytujące obiekty tabel z bazy danych.
        private void buttonEditSelectedSeller_Click(object sender, EventArgs e)
        {
            string sellerID;


            if ((currentTable == "sellers") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                sellerID = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                try
                {
                    Seller seller = new Seller()
                    {

                        ID = int.Parse(sellerID),
                        Name = textBoxSellerName.Text,
                        Surname = textBoxSellerSurname.Text,
                        YearsOfExperience = int.Parse(comboBoxSellerYearsOfExperience.Text),
                        EnglishLevel = comboBoxSellerEnglishLevel.Text,
                        Password = textBoxSellerPassword.Text


                    };
                    writeSellerRepository.Edit(readSellerRepository.GetByID(int.Parse(sellerID)), seller);
                    ShowSellers();
                }
                catch (Exception)
                {
                    MessageBox.Show("Błędne/niepełne dane dla edytowanego sprzedawcy!");
                }
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Aby edytowac dane sprzedawcy w pierwszej kolejności musisz jakiegoś wybrać!");
            }
        }

        private void buttonEditSelectedSupplier_Click(object sender, EventArgs e)
        {
            string supplierID;


            if ((currentTable == "suppliers") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                supplierID = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                try
                {
                    Supplier supplier = new Supplier()
                    {
                        ID = int.Parse(supplierID),
                        Name = textBoxSupplierName.Text,
                        Localization = comboBoxSupplierLocalization.Text,
                        DeliveryTime = int.Parse(textBoxSupplierDeliveryTime.Text)
                    };
                    writeSupplierRepository.Edit(readSupplierRepository.GetByID(int.Parse(supplierID)), supplier);
                    ShowSuppliers();
                }
                catch (Exception)
                {
                    MessageBox.Show("Błędne/niepełne dane dla edytowanego dostawcy!");
                }
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Aby edytowac dane dostawcy w pierwszej kolejności musisz jakiegoś wybrać!");
            }
        }

        private void buttonEditSelectedSupply_Click(object sender, EventArgs e)
        {
            string supplyID;
            string providerID;

            if ((currentTable == "supplies") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                supplyID = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                providerID = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID_Dostawcy"].Value.ToString();
                try
                {
                    Supply supply = new Supply()
                    {
                        ID = int.Parse(supplyID),
                        Date = DateTime.Parse(textBoxSupplyDate.Text),
                        OrderedProduct = textBoxSupplyOrderedProduct.Text,
                        Price = int.Parse(textBoxSupplyPrice.Text),
                        ProviderID = int.Parse(providerID)
                    };
                    writeSupplyRepository.Edit(readSupplyRepository.GetByID(int.Parse(supplyID)), supply);
                    ShowSupplies();
                }
                catch (Exception)
                {
                    MessageBox.Show("Błędne/niepełne dane dla edytowanej dostawy!");
                }
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Aby edytowac dane dostawy w pierwszej kolejności musisz jakąś wybrać!");
            }
        }


        private void buttonEditSelectedProductMenu_Click(object sender, EventArgs e)
        {
            string menuProductID;


            if ((currentTable == "menuproducts") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                menuProductID = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                try
                {
                    MenuProduct menuProduct = new MenuProduct()
                    {
                        ID = int.Parse(menuProductID),
                        Category = comboBoxMenuProductCategory.Text,
                        Name = textBoxMenuProductName.Text,
                        AmountOfCalories = int.Parse(textBoxMenuProductAmountOfCalories.Text),
                        Price = int.Parse(textBoxMenuProductPrice.Text)
                    };
                    writeMenuProductRepository.Edit(readMenuProductRepository.GetByID(int.Parse(menuProductID)), menuProduct);
                    ShowMenuProducts();
                }
                catch (Exception)
                {
                    MessageBox.Show("Błędne/niepełne dane dla edytowanego dostawcy!");
                }
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Aby edytowac dane produktu menu w pierwszej kolejności musisz jakiś wybrać!");
            }
        }

        //Przyciski do sortowania obiektów tabel z bazy danych po wskazanym wzorcu.
        private void buttonSellersSortBy_Click(object sender, EventArgs e)
        {
            if (comboBoxSellersSortBy.SelectedIndex != -1)
            {
                string option = comboBoxSellersSortBy.Text;
                dataGridViewRestaurantManagementSystem.DataSource = null;

                switch (option)
                {
                    case "Name":
                        dataGridViewRestaurantManagementSystem.DataSource = readSellerRepository.GetAll().OrderBy(x => x.Name).ThenBy(x => x.Surname).Select(x => new
                        {
                            ID = x.ID,
                            Imie_Sprzedawcy = x.Name,
                            Nazwisko = x.Surname,
                            Lata_Doswiadczenia = x.YearsOfExperience,
                            Znajomosc_Angielskiego = x.EnglishLevel,
                        }).ToList();
                        break;
                    case "YearsOfExperience":
                        dataGridViewRestaurantManagementSystem.DataSource = readSellerRepository.GetAll().OrderBy(x => x.YearsOfExperience).Select(x => new
                        {
                            ID = x.ID,
                            Imie_Sprzedawcy = x.Name,
                            Nazwisko = x.Surname,
                            Lata_Doswiadczenia = x.YearsOfExperience,
                            Znajomosc_Angielskiego = x.EnglishLevel,
                        }).ToList();
                        break;
                    case "EnglishLevel":
                        dataGridViewRestaurantManagementSystem.DataSource = readSellerRepository.GetAll().OrderBy(x => x.EnglishLevel).Select(x => new
                        {
                            ID = x.ID,
                            Imie_Sprzedawcy = x.Name,
                            Nazwisko = x.Surname,
                            Lata_Doswiadczenia = x.YearsOfExperience,
                            Znajomosc_Angielskiego = x.EnglishLevel,
                        }).ToList();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Aby posortować dane sprzedawców w pierwszej kolejności musisz wybrać rodzaj sortowania!");
            }
        }

        private void buttonSuppliersSortBy_Click(object sender, EventArgs e)
        {
            if (comboBoxSuppliersSortBy.SelectedIndex != -1)
            {
                string option = comboBoxSuppliersSortBy.Text;
                dataGridViewRestaurantManagementSystem.DataSource = null;

                switch (option)
                {
                    case "Name":
                        dataGridViewRestaurantManagementSystem.DataSource = readSupplierRepository.GetAll().OrderBy(x => x.Name).Select(x => new
                        {
                            ID = x.ID,
                            Nazwa = x.Name,
                            Lokalizacja = x.Localization,
                            Czas_Dostaw = x.DeliveryTime,
                        }).ToList();
                        break;

                    case "Localization":
                        dataGridViewRestaurantManagementSystem.DataSource = readSupplierRepository.GetAll().OrderBy(x => x.Localization).Select(x => new
                        {
                            ID = x.ID,
                            Nazwa = x.Name,
                            Lokalizacja = x.Localization,
                            Czas_Dostaw = x.DeliveryTime,
                        }).ToList();
                        break;

                    case "DeliveryTime":
                        dataGridViewRestaurantManagementSystem.DataSource = readSupplierRepository.GetAll().OrderBy(x => x.DeliveryTime).Select(x => new
                        {
                            ID = x.ID,
                            Nazwa = x.Name,
                            Lokalizacja = x.Localization,
                            Czas_Dostaw = x.DeliveryTime,
                        }).ToList();
                        break;

                }
            }
            else
            {
                MessageBox.Show("Aby posortować dane dostawców w pierwszej kolejności musisz wybrać rodzaj sortowania!");
            }
        }

        private void buttonOrdersSortByPrice_Click(object sender, EventArgs e)
        {
            dataGridViewRestaurantManagementSystem.DataSource = readOrderRepository.GetAll().OrderBy(x => x.Price).Select(x => new
            {
                ID = x.ID,
                Data = x.Date,
                Sprzedajacy = readSellerRepository.GetByID(x.SellerID).Name + " " + readSellerRepository.GetByID(x.SellerID).Surname,
                Cena = x.Price,
                Kalorie = x.AmountOfCalories,
            }).ToList();
        }

        private void buttonOrdersSortByAmountOfCalories_Click(object sender, EventArgs e)
        {
            dataGridViewRestaurantManagementSystem.DataSource = readOrderRepository.GetAll().OrderBy(x => x.AmountOfCalories).Select(x => new
            {
                ID = x.ID,
                Data = x.Date,
                Sprzedajacy = readSellerRepository.GetByID(x.SellerID).Name + " " + readSellerRepository.GetByID(x.SellerID).Surname,
                Cena = x.Price,
                Kalorie = x.AmountOfCalories,
            }).ToList();
        }

        private void buttonSuppliesSortBy_Click(object sender, EventArgs e)
        {
            if (comboBoxSuppliesSortBy.SelectedIndex != -1)
            {
                string option = comboBoxSuppliesSortBy.Text;
                dataGridViewRestaurantManagementSystem.DataSource = null;

                switch (option)
                {
                    case "Date":
                        dataGridViewRestaurantManagementSystem.DataSource = readSupplyRepository.GetAll().OrderBy(x => x.Date).Select(x => new
                        {
                            ID = x.ID,
                            Data_Zamowienia = x.Date,
                            Zamowiony_Produkt = x.OrderedProduct,
                            Cena = x.Price,
                            Dostawca = readSupplierRepository.GetByID(x.ProviderID).Name
                        }).ToList();
                        break;

                    case "OrderedProduct":
                        dataGridViewRestaurantManagementSystem.DataSource = readSupplyRepository.GetAll().OrderBy(x => x.OrderedProduct).Select(x => new
                        {
                            ID = x.ID,
                            Data_Zamowienia = x.Date,
                            Zamowiony_Produkt = x.OrderedProduct,
                            Cena = x.Price,
                            Dostawca = readSupplierRepository.GetByID(x.ProviderID).Name
                        }).ToList();
                        break;

                    case "Price":
                        dataGridViewRestaurantManagementSystem.DataSource = readSupplyRepository.GetAll().OrderBy(x => x.Price).Select(x => new
                        {
                            ID = x.ID,
                            Data_Zamowienia = x.Date,
                            Zamowiony_Produkt = x.OrderedProduct,
                            Cena = x.Price,
                            Dostawca = readSupplierRepository.GetByID(x.ProviderID).Name
                        }).ToList();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Aby posortować dane dostaw w pierwszej kolejności musisz wybrać rodzaj sortowania!");
            }
        }

        private void buttonMenuProductsSortBy_Click(object sender, EventArgs e)
        {

            if (comboBoxMenuProductsSortBy.SelectedIndex != -1)
            {
                string option = comboBoxMenuProductsSortBy.Text;
                dataGridViewRestaurantManagementSystem.DataSource = null;

                switch (option)
                {
                    case "Category":
                        dataGridViewRestaurantManagementSystem.DataSource = readMenuProductRepository.GetAll().OrderBy(x => x.Category).Select(x => new
                        {
                            ID = x.ID,
                            Kategoria = x.Category,
                            Nazwa = x.Name,
                            Ilosc_Kcal = x.AmountOfCalories,
                            Cena = x.Price
                        }).ToList();
                        break;

                    case "Name":
                        dataGridViewRestaurantManagementSystem.DataSource = readMenuProductRepository.GetAll().OrderBy(x => x.Name).Select(x => new
                        {
                            ID = x.ID,
                            Kategoria = x.Category,
                            Nazwa = x.Name,
                            Ilosc_Kcal = x.AmountOfCalories,
                            Cena = x.Price
                        }).ToList();
                        break;

                    case "AmountOfCalories":
                        dataGridViewRestaurantManagementSystem.DataSource = readMenuProductRepository.GetAll().OrderBy(x => x.AmountOfCalories).Select(x => new
                        {
                            ID = x.ID,
                            Kategoria = x.Category,
                            Nazwa = x.Name,
                            Ilosc_Kcal = x.AmountOfCalories,
                            Cena = x.Price
                        }).ToList();
                        break;
                    case "Price":
                        dataGridViewRestaurantManagementSystem.DataSource = readMenuProductRepository.GetAll().OrderBy(x => x.Price).Select(x => new
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
            else
            {
                MessageBox.Show("Aby posortować dane produktów menu w pierwszej kolejności musisz wybrać rodzaj sortowania!");
            }
        }

        //Przyciski do wyświetlania obiektów tabel z bazy danych po wskazanym wzorcu.
        private void buttonShowBySellerYearsOfExperience_Click(object sender, EventArgs e)
        {

            if (comboBoxShowBySellerYearsOfExperience.SelectedIndex != -1)
            {
                string option = comboBoxShowBySellerYearsOfExperience.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = readSellerRepository.GetAll().Where(x => x.YearsOfExperience == int.Parse(option)).Select(x => new
                {
                    ID = x.ID,
                    Imie_Sprzedawcy = x.Name,
                    Nazwisko = x.Surname,
                    Lata_Doswiadczenia = x.YearsOfExperience,
                    Znajomosc_Angielskiego = x.EnglishLevel
                }).ToList();
            }
            else
            {
                MessageBox.Show("Aby wypisać odpowiednich sprzedawców w pierwszej kolejności musisz wybrać wzorzec!");
            }
        }

        private void buttonShowBySellerEnglishLevel_Click(object sender, EventArgs e)
        {
            if (comboBoxShowBySellerEnglishLevel.SelectedIndex != -1)
            {
                string option = comboBoxShowBySellerEnglishLevel.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = readSellerRepository.GetAll().Where(x => x.EnglishLevel == option).Select(x => new
                {
                    ID = x.ID,
                    Imie_Sprzedawcy = x.Name,
                    Nazwisko = x.Surname,
                    Lata_Doswiadczenia = x.YearsOfExperience,
                    Znajomosc_Angielskiego = x.EnglishLevel
                }).ToList();
            }
            else
            {
                MessageBox.Show("Aby wypisać odpowiednich sprzedawców w pierwszej kolejności musisz wybrać wzorzec!");
            }
        }

        private void buttonShowBySupplierLocalization_Click(object sender, EventArgs e)
        {
            if (comboBoxShowBySupplierLocalization.SelectedIndex != -1)
            {
                string option = comboBoxShowBySupplierLocalization.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = readSupplierRepository.GetAll().Where(x => x.Localization == option).Select(x => new
                {
                    ID = x.ID,
                    Nazwa = x.Name,
                    Lokalizacja = x.Localization,
                    Czas_Dostaw = x.DeliveryTime,
                }).ToList();
            }
            else
            {
                MessageBox.Show("Aby wypisać odpowiednich dostawców w pierwszej kolejności musisz wybrać wzorzec!");
            }
        }

        private void buttonShowByMenuProductCategory_Click(object sender, EventArgs e)
        {
            if (comboBoxShowByMenuProductCategory.SelectedIndex != -1)
            {
                string option = comboBoxShowByMenuProductCategory.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = readMenuProductRepository.GetAll().Where(x => x.Category == option).Select(x => new
                {
                    ID = x.ID,
                    Kategoria = x.Category,
                    Nazwa = x.Name,
                    Ilosc_Kcal = x.AmountOfCalories,
                    Cena = x.Price
                }).ToList();
            }
            else
            {
                MessageBox.Show("Aby wypisać odpowiednie produkty menu w pierwszej kolejności musisz wybrać wzorzec!");
            }
        }

        private void buttonSearchSupplyByOrderedProduct_Click(object sender, EventArgs e)
        {
            if (textBoxSearchSupplyByOrderedProduct.Text != "")
            {
                string option = textBoxSearchSupplyByOrderedProduct.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = readSupplyRepository.GetAll().Where(x => x.OrderedProduct.Contains(option)).Select(x => new
                {
                    ID = x.ID,
                    Data_Zamowienia = x.Date,
                    Zamowiony_Produkt = x.OrderedProduct,
                    Cena = x.Price,
                    ID_Dostawcy = x.ProviderID
                }).ToList();
            }
            else
            {
                MessageBox.Show("Aby wypisać odpowiednie produkty menu w pierwszej kolejności musisz wybrać wzorzec!");
            }
        }

        //Przyciski wyświetlające obiekty tabel z bazy danych z zadanego przedziału danego wzorca.
        private void buttonSearchSuppliersFromToByDeliveryTime_Click(object sender, EventArgs e)
        {
            if ((textBoxSupplierDeliveryTimeFrom.Text != "") && (textBoxSupplierDeliveryTimeTo.Text != ""))
            {
                string from = textBoxSupplierDeliveryTimeFrom.Text;
                string to = textBoxSupplierDeliveryTimeTo.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = readSupplierRepository.GetAll().Where(x => x.DeliveryTime >= int.Parse(from) && x.DeliveryTime <= int.Parse(to)).Select(x => new
                {
                    ID = x.ID,
                    Nazwa = x.Name,
                    Lokalizacja = x.Localization,
                    Czas_Dostaw = x.DeliveryTime,
                }).ToList();
            }
            else
            {
                MessageBox.Show("Aby wypisać odpowiednich dostawców w pierwszej kolejności musisz podać przedział!");
            }
        }

        private void buttonSearchSuppliesFromToByPrice_Click(object sender, EventArgs e)
        {
            if ((textBoxSuppliesPriceFrom.Text != "") && (textBoxSuppliesPriceTo.Text != ""))
            {
                string from = textBoxSuppliesPriceFrom.Text;
                string to = textBoxSuppliesPriceTo.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = readSupplyRepository.GetAll().Where(x => x.Price >= int.Parse(from) && x.Price <= int.Parse(to)).Select(x => new
                {
                    ID = x.ID,
                    Data_Zamowienia = x.Date,
                    Zamowiony_Produkt = x.OrderedProduct,
                    Cena = x.Price,
                    ID_Dostawcy = x.ProviderID
                }).ToList();
            }
            else
            {
                MessageBox.Show("Aby wypisać odpowiednie dostawy w pierwszej kolejności musisz podać przedział!");
            }
        }

        private void buttonSearchMenuProductsFromToByPrice_Click(object sender, EventArgs e)
        {
            if ((textBoxMenuProductPriceTimeFrom.Text != "") && (textBoxMenuProductPriceTimeTo.Text != ""))
            {
                string from = textBoxMenuProductPriceTimeFrom.Text;
                string to = textBoxMenuProductPriceTimeTo.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = readMenuProductRepository.GetAll().Where(x => x.Price >= int.Parse(from) && x.Price <= int.Parse(to)).Select(x => new
                {
                    ID = x.ID,
                    Kategoria = x.Category,
                    Nazwa = x.Name,
                    Ilosc_Kcal = x.AmountOfCalories,
                    Cena = x.Price
                }).ToList();
            }
            else
            {
                MessageBox.Show("Aby wypisać odpowiednie produkty menu w pierwszej kolejności musisz podać przedział!");
            }
        }

        //Logowanie do panelu sprzedawcy. W panelu sprzedawcy możliwość realizowania zamówień.
        private void buttonLogInToCash_Click(object sender, EventArgs e)
        {
            string sellerID;


            if ((currentTable == "sellers") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                sellerID = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                if (readSellerRepository.GetByID(int.Parse(sellerID)).Password == textBoxEnterSellerPassword.Text)
                {
                    FormSellerPanel formSellerPanel = new FormSellerPanel(readSellerRepository.GetByID(int.Parse(sellerID)), context, readMenuProductRepository, writeOrderRepository);
                    this.Visible = false;
                    formSellerPanel.ShowDialog();
                    if (formSellerPanel.IsAccessible == false)
                    {
                        Visible = true;
                        ClearTextBoxes();
                    }
                }

                else
                {
                    MessageBox.Show("Wprowadz poprawne haslo!");
                }

            }
            else
            {
                MessageBox.Show("Aby zalogować się do kasy w pierwszej kolejności wybierz sprzedawcę!");
            }

        }

        //Przyciski obliczające statystyki.
        private void buttonSumProfit_Click(object sender, EventArgs e)
        {
            int tmp = readOrderRepository.GetAll().Sum(x => x.Price);
            labelProfit.Text = tmp.ToString();
               
        }

        private void buttonSumCostOfSupplies_Click(object sender, EventArgs e)
        {
            int tmp = readSupplyRepository.GetAll().Sum(x => x.Price);
            labelCostOfSupplies.Text = tmp.ToString();
        }

        private void buttonSumGain_Click(object sender, EventArgs e)
        {
            int tmp = readOrderRepository.GetAll().Sum(x => x.Price) - readSupplyRepository.GetAll().Sum(x => x.Price);
            labelGain.Text = tmp.ToString();
        }

        private void buttonAvgDeliveryTime_Click(object sender, EventArgs e)
        {
            double tmp = readSupplierRepository.GetAll().Average(x => x.DeliveryTime);
            labelAverageDeliveryTime.Text = tmp.ToString("#.##");
        }

        private void buttonMaxMostExpensiveOrder_Click(object sender, EventArgs e)
        {
            int tmp = readOrderRepository.GetAll().Max(x => x.Price);
            labelMostExpensiveOrder.Text = tmp.ToString();
        }

        private void buttonAvgYearsOfExperience_Click(object sender, EventArgs e)
        {
            double tmp = readSellerRepository.GetAll().Average(x => x.YearsOfExperience);
            labelAverageYearsOfExperience.Text = tmp.ToString("#.##");
        }
    }
}
