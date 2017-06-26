using KamilCieślikLab4PD.Model;
using KamilCieślikLab4PD.Repository;
using System;
using System.Linq;
using System.Windows.Forms;
using KamilCieślikLab4PD.Repository.Commands;
using KamilCieślikLab4PD.Repository.Queries;

namespace KamilCieślikLab4PD
{
    public partial class MainFrame : Form
    {
        private readonly KamilCieślikLab4PdContext _context;
        private readonly ReadRepository<Seller> _readSellerRepository;
        private readonly ReadRepository<Supplier> _readSupplierRepository;
        private readonly ReadRepository<Supply> _readSupplyRepository;
        private readonly ReadRepository<MenuProduct> _readMenuProductRepository;
        private readonly ReadRepository<Order> _readOrderRepository;

        private readonly WriteRepository<Seller> _writeSellerRepository;
        private readonly WriteRepository<Supplier> _writeSupplierRepository;
        private readonly WriteRepository<Supply> _writeSupplyRepository;
        private readonly WriteRepository<MenuProduct> _writeMenuProductRepository;
        private readonly WriteRepository<Order> _writeOrderRepository;

        private string _currentTable;

        public MainFrame()
        {
            _context = new KamilCieślikLab4PdContext();
            _readSellerRepository = new ReadRepository<Seller>(_context);
            _readSupplierRepository = new ReadRepository<Supplier>(_context);
            _readSupplyRepository = new ReadRepository<Supply>(_context);
            _readMenuProductRepository = new ReadRepository<MenuProduct>(_context);
            _readOrderRepository = new ReadRepository<Order>(_context);

            _writeSellerRepository = new WriteRepository<Seller>(_context);
            _writeSupplierRepository = new WriteRepository<Supplier>(_context);
            _writeSupplyRepository = new WriteRepository<Supply>(_context);
            _writeMenuProductRepository = new WriteRepository<MenuProduct>(_context);
            _writeOrderRepository = new WriteRepository<Order>(_context);

            InitializeComponent();
        }

        //Przyciski dodające obiekty do baz danych.
        private void buttonRegisterNewSeller_Click(object sender, EventArgs e)
        {
            try
            {
                var seller = new Seller()
                {
                    Name = textBoxSellerName.Text,
                    Surname = textBoxSellerSurname.Text,
                    YearsOfExperience = int.Parse(comboBoxSellerYearsOfExperience.Text),
                    EnglishLevel = comboBoxSellerEnglishLevel.Text,
                    Password = textBoxSellerPassword.Text
                };
                _writeSellerRepository.Create(seller);
                ShowSellers();
            }
            catch (Exception)
            {
                MessageBox.Show(@"Błędne/niepełne dane sprzedawcy!");
            }
            ClearTextBoxes();
        }

        private void buttonAddNewSupplier_Click(object sender, EventArgs e)
        {
            try
            {
                var supplier = new Supplier()
                {
                    Name = textBoxSupplierName.Text,
                    Localization = comboBoxSupplierLocalization.Text,
                    DeliveryTime = int.Parse(textBoxSupplierDeliveryTime.Text)
                };
                _writeSupplierRepository.Create(supplier);
                ShowSuppliers();
            }
            catch (Exception)
            {
                MessageBox.Show(@"Błędne/niepełne dane dostawcy!");
            }
            ClearTextBoxes();
        }

        private void buttonAddNewSupply_Click(object sender, EventArgs e)
        {
            if ((_currentTable == "suppliers") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                var supplierId = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                try
                {
                    var supply = new Supply()
                    {
                        Date = DateTime.Parse(textBoxSupplyDate.Text),
                        OrderedProduct = textBoxSupplyOrderedProduct.Text,
                        Price = int.Parse(textBoxSupplyPrice.Text),
                        ProviderID = int.Parse(supplierId)
                    };
                    _writeSupplyRepository.Create(supply);
                    ShowSupplies();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Błędne/niepełne dane dostawy!");
                }
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show(@"Pamietaj o wyborze dostawcy przed dodaniem sfinaliowaniem dostawy!");
            }
        }

        private void buttonAddProductMenu_Click(object sender, EventArgs e)
        {
            try
            {
                var menuProduct = new MenuProduct()
                {
                    Category = comboBoxMenuProductCategory.Text,
                    Name = textBoxMenuProductName.Text,
                    AmountOfCalories = int.Parse(textBoxMenuProductAmountOfCalories.Text),
                    Price = int.Parse(textBoxMenuProductPrice.Text)
                };
                _writeMenuProductRepository.Create(menuProduct);
                ShowMenuProducts();
            }
            catch (Exception)
            {
                MessageBox.Show(@"Błędne/niepełne dane produktu menu!");
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

            labelProfit.Text = @"-";
            labelGain.Text = @"-";
            labelCostOfSupplies.Text = @"-";
            labelAverageDeliveryTime.Text = @"-";
            labelMostExpensiveOrder.Text = @"-";
            labelAverageYearsOfExperience.Text = @"-";
        }

        //Metody wyświetlające obiekty tabel z bazy danych w DataGridView
        public void ShowSellers()
        {
            dataGridViewRestaurantManagementSystem.DataSource = null;
            dataGridViewRestaurantManagementSystem.DataSource = _readSellerRepository
                .GetAll()
                .Select(x => new
                {
                    x.ID,
                    Imie_Sprzedawcy = x.Name,
                    Nazwisko = x.Surname,
                    Lata_Doswiadczenia = x.YearsOfExperience,
                    Znajomosc_Angielskiego = x.EnglishLevel,
                }).ToList();
            _currentTable = "sellers";
        }

        public void ShowSuppliers()
        {
            dataGridViewRestaurantManagementSystem.DataSource = null;
            dataGridViewRestaurantManagementSystem.DataSource = _readSupplierRepository
                .GetAll()
                .Select(x => new
                {
                    x.ID,
                    Nazwa = x.Name,
                    Lokalizacja = x.Localization,
                    Czas_Dostaw = x.DeliveryTime,
                }).ToList();
            _currentTable = "suppliers";
        }

        public void ShowSupplies()
        {
            dataGridViewRestaurantManagementSystem.DataSource = null;
            dataGridViewRestaurantManagementSystem.DataSource = _readSupplyRepository
                .GetAll()
                .Select(x => new
                {
                    x.ID,
                    Data_Zamowienia = x.Date,
                    Zamowiony_Produkt = x.OrderedProduct,
                    Cena = x.Price,
                    Dostawca = _readSupplierRepository.GetByID(x.ProviderID).Name
                }).ToList();
            _currentTable = "supplies";
        }

        public void ShowMenuProducts()
        {
            dataGridViewRestaurantManagementSystem.DataSource = null;
            dataGridViewRestaurantManagementSystem.DataSource = _readMenuProductRepository
                .GetAll()
                .Select(x => new
                {
                    x.ID,
                    Kategoria = x.Category,
                    Nazwa = x.Name,
                    Ilosc_Kcal = x.AmountOfCalories,
                    Cena = x.Price
                }).ToList();
            _currentTable = "menuproducts";
        }

        public void ShowOrders()
        {
            dataGridViewRestaurantManagementSystem.DataSource = null;
            dataGridViewRestaurantManagementSystem.DataSource = _readOrderRepository
                .GetAll()
                .Select(x => new
                {
                    x.ID,
                    Data = x.Date,
                    Sprzedajacy = _readSellerRepository.GetByID(x.SellerID).Name + " " + _readSellerRepository.GetByID(x.SellerID).Surname,
                    Cena = x.Price,
                    Kalorie = x.AmountOfCalories,
                }).ToList();
            _currentTable = "orders";
        }

        //Przyciski usuwające obiekty tabel z bazy danych.
        private void buttonDeleteSelectedSeller_Click(object sender, EventArgs e)
        {
            if ((_currentTable == "sellers") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                var sellerId = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                _writeSellerRepository.Delete(_readSellerRepository.GetByID(int.Parse(sellerId)));
                ShowSellers();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show(@"Aby usunąc sprzedawce w pierwszej kolejności musisz jakiegoś wybrać!");
            }
            ClearTextBoxes();
        }

        private void buttonDeleteSelectedSupplier_Click(object sender, EventArgs e)
        {
            if ((_currentTable == "suppliers") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                var supplierId = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                _writeSupplierRepository.Delete(_readSupplierRepository.GetByID(int.Parse(supplierId)));
                ShowSuppliers();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show(@"Aby usunąc dostawce w pierwszej kolejności musisz jakiegoś wybrać!");
            }
            ClearTextBoxes();
        }

        private void buttonDeleteSelectedSupply_Click(object sender, EventArgs e)
        {
            if ((_currentTable == "supplies") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                var supplyId = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                _writeSupplyRepository.Delete(_readSupplyRepository.GetByID(int.Parse(supplyId)));
                ShowSupplies();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show(@"Aby usunąc dostawce w pierwszej kolejności musisz jakiegoś wybrać!");
            }
            ClearTextBoxes();
        }

        private void buttonDeleteSelectedMenuProduct_Click(object sender, EventArgs e)
        {
            if ((_currentTable == "menuproducts") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                var menuProductId = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                _writeMenuProductRepository.Delete(_readMenuProductRepository.GetByID(int.Parse(menuProductId)));
                ShowMenuProducts();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show(@"Aby usunąc produkt menu w pierwszej kolejności musisz jakiś wybrać!");
            }
            ClearTextBoxes();
        }

        //Przyciski edytujące obiekty tabel z bazy danych.
        private void buttonEditSelectedSeller_Click(object sender, EventArgs e)
        {
            if ((_currentTable == "sellers") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                var sellerId = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                try
                {
                    Seller seller = new Seller()
                    {

                        ID = int.Parse(sellerId),
                        Name = textBoxSellerName.Text,
                        Surname = textBoxSellerSurname.Text,
                        YearsOfExperience = int.Parse(comboBoxSellerYearsOfExperience.Text),
                        EnglishLevel = comboBoxSellerEnglishLevel.Text,
                        Password = textBoxSellerPassword.Text
                    };
                    _writeSellerRepository.Edit(_readSellerRepository.GetByID(int.Parse(sellerId)), seller);
                    ShowSellers();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Błędne/niepełne dane dla edytowanego sprzedawcy!");
                }
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show(@"Aby edytowac dane sprzedawcy w pierwszej kolejności musisz jakiegoś wybrać!");
            }
        }

        private void buttonEditSelectedSupplier_Click(object sender, EventArgs e)
        {
            if ((_currentTable == "suppliers") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                var supplierId = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                try
                {
                    Supplier supplier = new Supplier()
                    {
                        ID = int.Parse(supplierId),
                        Name = textBoxSupplierName.Text,
                        Localization = comboBoxSupplierLocalization.Text,
                        DeliveryTime = int.Parse(textBoxSupplierDeliveryTime.Text)
                    };
                    _writeSupplierRepository.Edit(_readSupplierRepository.GetByID(int.Parse(supplierId)), supplier);
                    ShowSuppliers();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Błędne/niepełne dane dla edytowanego dostawcy!");
                }
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show(@"Aby edytowac dane dostawcy w pierwszej kolejności musisz jakiegoś wybrać!");
            }
        }

        private void buttonEditSelectedSupply_Click(object sender, EventArgs e)
        {
            if ((_currentTable == "supplies") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                var supplyId = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                var providerId = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID_Dostawcy"].Value.ToString();
                try
                {
                    Supply supply = new Supply()
                    {
                        ID = int.Parse(supplyId),
                        Date = DateTime.Parse(textBoxSupplyDate.Text),
                        OrderedProduct = textBoxSupplyOrderedProduct.Text,
                        Price = int.Parse(textBoxSupplyPrice.Text),
                        ProviderID = int.Parse(providerId)
                    };
                    _writeSupplyRepository.Edit(_readSupplyRepository.GetByID(int.Parse(supplyId)), supply);
                    ShowSupplies();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Błędne/niepełne dane dla edytowanej dostawy!");
                }
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show(@"Aby edytowac dane dostawy w pierwszej kolejności musisz jakąś wybrać!");
            }
        }


        private void buttonEditSelectedProductMenu_Click(object sender, EventArgs e)
        {
            if ((_currentTable == "menuproducts") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                var menuProductId = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                try
                {
                    MenuProduct menuProduct = new MenuProduct()
                    {
                        ID = int.Parse(menuProductId),
                        Category = comboBoxMenuProductCategory.Text,
                        Name = textBoxMenuProductName.Text,
                        AmountOfCalories = int.Parse(textBoxMenuProductAmountOfCalories.Text),
                        Price = int.Parse(textBoxMenuProductPrice.Text)
                    };
                    _writeMenuProductRepository.Edit(_readMenuProductRepository.GetByID(int.Parse(menuProductId)), menuProduct);
                    ShowMenuProducts();
                }
                catch (Exception)
                {
                    MessageBox.Show(@"Błędne/niepełne dane dla edytowanego dostawcy!");
                }
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show(@"Aby edytowac dane produktu menu w pierwszej kolejności musisz jakiś wybrać!");
            }
        }

        //Przyciski do sortowania obiektów tabel z bazy danych po wskazanym wzorcu.
        private void buttonSellersSortBy_Click(object sender, EventArgs e)
        {
            if (comboBoxSellersSortBy.SelectedIndex != -1)
            {
                var option = comboBoxSellersSortBy.Text;
                dataGridViewRestaurantManagementSystem.DataSource = null;

                switch (option)
                {
                    case "Name":
                        dataGridViewRestaurantManagementSystem.DataSource = _readSellerRepository.GetAll().OrderBy(x => x.Name).ThenBy(x => x.Surname).Select(x => new
                        {
                            x.ID,
                            Imie_Sprzedawcy = x.Name,
                            Nazwisko = x.Surname,
                            Lata_Doswiadczenia = x.YearsOfExperience,
                            Znajomosc_Angielskiego = x.EnglishLevel,
                        }).ToList();
                        break;
                    case "YearsOfExperience":
                        dataGridViewRestaurantManagementSystem.DataSource = _readSellerRepository.GetAll().OrderBy(x => x.YearsOfExperience).Select(x => new
                        {
                            x.ID,
                            Imie_Sprzedawcy = x.Name,
                            Nazwisko = x.Surname,
                            Lata_Doswiadczenia = x.YearsOfExperience,
                            Znajomosc_Angielskiego = x.EnglishLevel,
                        }).ToList();
                        break;
                    case "EnglishLevel":
                        dataGridViewRestaurantManagementSystem.DataSource = _readSellerRepository.GetAll().OrderBy(x => x.EnglishLevel).Select(x => new
                        {
                            x.ID,
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
                MessageBox.Show(@"Aby posortować dane sprzedawców w pierwszej kolejności musisz wybrać rodzaj sortowania!");
            }
        }

        private void buttonSuppliersSortBy_Click(object sender, EventArgs e)
        {
            if (comboBoxSuppliersSortBy.SelectedIndex != -1)
            {
                var option = comboBoxSuppliersSortBy.Text;
                dataGridViewRestaurantManagementSystem.DataSource = null;

                switch (option)
                {
                    case "Name":
                        dataGridViewRestaurantManagementSystem.DataSource = _readSupplierRepository.GetAll().OrderBy(x => x.Name).Select(x => new
                        {
                            x.ID,
                            Nazwa = x.Name,
                            Lokalizacja = x.Localization,
                            Czas_Dostaw = x.DeliveryTime,
                        }).ToList();
                        break;

                    case "Localization":
                        dataGridViewRestaurantManagementSystem.DataSource = _readSupplierRepository.GetAll().OrderBy(x => x.Localization).Select(x => new
                        {
                            x.ID,
                            Nazwa = x.Name,
                            Lokalizacja = x.Localization,
                            Czas_Dostaw = x.DeliveryTime,
                        }).ToList();
                        break;

                    case "DeliveryTime":
                        dataGridViewRestaurantManagementSystem.DataSource = _readSupplierRepository.GetAll().OrderBy(x => x.DeliveryTime).Select(x => new
                        {
                            x.ID,
                            Nazwa = x.Name,
                            Lokalizacja = x.Localization,
                            Czas_Dostaw = x.DeliveryTime,
                        }).ToList();
                        break;
                }
            }
            else
            {
                MessageBox.Show(@"Aby posortować dane dostawców w pierwszej kolejności musisz wybrać rodzaj sortowania!");
            }
        }

        private void buttonOrdersSortByPrice_Click(object sender, EventArgs e)
        {
            dataGridViewRestaurantManagementSystem.DataSource = _readOrderRepository.GetAll().OrderBy(x => x.Price).Select(x => new
            {
                x.ID,
                Data = x.Date,
                Sprzedajacy = _readSellerRepository.GetByID(x.SellerID).Name + " " + _readSellerRepository.GetByID(x.SellerID).Surname,
                Cena = x.Price,
                Kalorie = x.AmountOfCalories,
            }).ToList();
        }

        private void buttonOrdersSortByAmountOfCalories_Click(object sender, EventArgs e)
        {
            dataGridViewRestaurantManagementSystem.DataSource = _readOrderRepository.GetAll().OrderBy(x => x.AmountOfCalories).Select(x => new
            {
                x.ID,
                Data = x.Date,
                Sprzedajacy = _readSellerRepository.GetByID(x.SellerID).Name + " " + _readSellerRepository.GetByID(x.SellerID).Surname,
                Cena = x.Price,
                Kalorie = x.AmountOfCalories,
            }).ToList();
        }

        private void buttonSuppliesSortBy_Click(object sender, EventArgs e)
        {
            if (comboBoxSuppliesSortBy.SelectedIndex != -1)
            {
                var option = comboBoxSuppliesSortBy.Text;
                dataGridViewRestaurantManagementSystem.DataSource = null;

                switch (option)
                {
                    case "Date":
                        dataGridViewRestaurantManagementSystem.DataSource = _readSupplyRepository.GetAll().OrderBy(x => x.Date).Select(x => new
                        {
                            x.ID,
                            Data_Zamowienia = x.Date,
                            Zamowiony_Produkt = x.OrderedProduct,
                            Cena = x.Price,
                            Dostawca = _readSupplierRepository.GetByID(x.ProviderID).Name
                        }).ToList();
                        break;

                    case "OrderedProduct":
                        dataGridViewRestaurantManagementSystem.DataSource = _readSupplyRepository.GetAll().OrderBy(x => x.OrderedProduct).Select(x => new
                        {
                            x.ID,
                            Data_Zamowienia = x.Date,
                            Zamowiony_Produkt = x.OrderedProduct,
                            Cena = x.Price,
                            Dostawca = _readSupplierRepository.GetByID(x.ProviderID).Name
                        }).ToList();
                        break;

                    case "Price":
                        dataGridViewRestaurantManagementSystem.DataSource = _readSupplyRepository.GetAll().OrderBy(x => x.Price).Select(x => new
                        {
                            x.ID,
                            Data_Zamowienia = x.Date,
                            Zamowiony_Produkt = x.OrderedProduct,
                            Cena = x.Price,
                            Dostawca = _readSupplierRepository.GetByID(x.ProviderID).Name
                        }).ToList();
                        break;
                }
            }
            else
            {
                MessageBox.Show(@"Aby posortować dane dostaw w pierwszej kolejności musisz wybrać rodzaj sortowania!");
            }
        }

        private void buttonMenuProductsSortBy_Click(object sender, EventArgs e)
        {
            if (comboBoxMenuProductsSortBy.SelectedIndex != -1)
            {
                var option = comboBoxMenuProductsSortBy.Text;
                dataGridViewRestaurantManagementSystem.DataSource = null;

                switch (option)
                {
                    case "Category":
                        dataGridViewRestaurantManagementSystem.DataSource = _readMenuProductRepository.GetAll().OrderBy(x => x.Category).Select(x => new
                        {
                            x.ID,
                            Kategoria = x.Category,
                            Nazwa = x.Name,
                            Ilosc_Kcal = x.AmountOfCalories,
                            Cena = x.Price
                        }).ToList();
                        break;

                    case "Name":
                        dataGridViewRestaurantManagementSystem.DataSource = _readMenuProductRepository.GetAll().OrderBy(x => x.Name).Select(x => new
                        {
                            x.ID,
                            Kategoria = x.Category,
                            Nazwa = x.Name,
                            Ilosc_Kcal = x.AmountOfCalories,
                            Cena = x.Price
                        }).ToList();
                        break;

                    case "AmountOfCalories":
                        dataGridViewRestaurantManagementSystem.DataSource = _readMenuProductRepository.GetAll().OrderBy(x => x.AmountOfCalories).Select(x => new
                        {
                            x.ID,
                            Kategoria = x.Category,
                            Nazwa = x.Name,
                            Ilosc_Kcal = x.AmountOfCalories,
                            Cena = x.Price
                        }).ToList();
                        break;
                    case "Price":
                        dataGridViewRestaurantManagementSystem.DataSource = _readMenuProductRepository.GetAll().OrderBy(x => x.Price).Select(x => new
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
            else
            {
                MessageBox.Show(@"Aby posortować dane produktów menu w pierwszej kolejności musisz wybrać rodzaj sortowania!");
            }
        }

        //Przyciski do wyświetlania obiektów tabel z bazy danych po wskazanym wzorcu.
        private void buttonShowBySellerYearsOfExperience_Click(object sender, EventArgs e)
        {
            if (comboBoxShowBySellerYearsOfExperience.SelectedIndex != -1)
            {
                var option = comboBoxShowBySellerYearsOfExperience.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = _readSellerRepository.GetAll().Where(x => x.YearsOfExperience == int.Parse(option)).Select(x => new
                {
                    x.ID,
                    Imie_Sprzedawcy = x.Name,
                    Nazwisko = x.Surname,
                    Lata_Doswiadczenia = x.YearsOfExperience,
                    Znajomosc_Angielskiego = x.EnglishLevel
                }).ToList();
            }
            else
            {
                MessageBox.Show(@"Aby wypisać odpowiednich sprzedawców w pierwszej kolejności musisz wybrać wzorzec!");
            }
        }

        private void buttonShowBySellerEnglishLevel_Click(object sender, EventArgs e)
        {
            if (comboBoxShowBySellerEnglishLevel.SelectedIndex != -1)
            {
                var option = comboBoxShowBySellerEnglishLevel.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = _readSellerRepository.GetAll().Where(x => x.EnglishLevel == option).Select(x => new
                {
                    x.ID,
                    Imie_Sprzedawcy = x.Name,
                    Nazwisko = x.Surname,
                    Lata_Doswiadczenia = x.YearsOfExperience,
                    Znajomosc_Angielskiego = x.EnglishLevel
                }).ToList();
            }
            else
            {
                MessageBox.Show(@"Aby wypisać odpowiednich sprzedawców w pierwszej kolejności musisz wybrać wzorzec!");
            }
        }

        private void buttonShowBySupplierLocalization_Click(object sender, EventArgs e)
        {
            if (comboBoxShowBySupplierLocalization.SelectedIndex != -1)
            {
                var option = comboBoxShowBySupplierLocalization.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = _readSupplierRepository.GetAll().Where(x => x.Localization == option).Select(x => new
                {
                    x.ID,
                    Nazwa = x.Name,
                    Lokalizacja = x.Localization,
                    Czas_Dostaw = x.DeliveryTime,
                }).ToList();
            }
            else
            {
                MessageBox.Show(@"Aby wypisać odpowiednich dostawców w pierwszej kolejności musisz wybrać wzorzec!");
            }
        }

        private void buttonShowByMenuProductCategory_Click(object sender, EventArgs e)
        {
            if (comboBoxShowByMenuProductCategory.SelectedIndex != -1)
            {
                var option = comboBoxShowByMenuProductCategory.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = _readMenuProductRepository.GetAll().Where(x => x.Category == option).Select(x => new
                {
                    x.ID,
                    Kategoria = x.Category,
                    Nazwa = x.Name,
                    Ilosc_Kcal = x.AmountOfCalories,
                    Cena = x.Price
                }).ToList();
            }
            else
            {
                MessageBox.Show(@"Aby wypisać odpowiednie produkty menu w pierwszej kolejności musisz wybrać wzorzec!");
            }
        }

        private void buttonSearchSupplyByOrderedProduct_Click(object sender, EventArgs e)
        {
            if (textBoxSearchSupplyByOrderedProduct.Text != "")
            {
                var option = textBoxSearchSupplyByOrderedProduct.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = _readSupplyRepository.GetAll().Where(x => x.OrderedProduct.Contains(option)).Select(x => new
                {
                    x.ID,
                    Data_Zamowienia = x.Date,
                    Zamowiony_Produkt = x.OrderedProduct,
                    Cena = x.Price,
                    ID_Dostawcy = x.ProviderID
                }).ToList();
            }
            else
            {
                MessageBox.Show(@"Aby wypisać odpowiednie produkty menu w pierwszej kolejności musisz wybrać wzorzec!");
            }
        }

        //Przyciski wyświetlające obiekty tabel z bazy danych z zadanego przedziału danego wzorca.
        private void buttonSearchSuppliersFromToByDeliveryTime_Click(object sender, EventArgs e)
        {
            if ((textBoxSupplierDeliveryTimeFrom.Text != "") && (textBoxSupplierDeliveryTimeTo.Text != ""))
            {
                var from = textBoxSupplierDeliveryTimeFrom.Text;
                var to = textBoxSupplierDeliveryTimeTo.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = _readSupplierRepository.GetAll().Where(x => x.DeliveryTime >= int.Parse(from) && x.DeliveryTime <= int.Parse(to)).Select(x => new
                {
                    x.ID,
                    Nazwa = x.Name,
                    Lokalizacja = x.Localization,
                    Czas_Dostaw = x.DeliveryTime,
                }).ToList();
            }
            else
            {
                MessageBox.Show(@"Aby wypisać odpowiednich dostawców w pierwszej kolejności musisz podać przedział!");
            }
        }

        private void buttonSearchSuppliesFromToByPrice_Click(object sender, EventArgs e)
        {
            if ((textBoxSuppliesPriceFrom.Text != "") && (textBoxSuppliesPriceTo.Text != ""))
            {
                var from = textBoxSuppliesPriceFrom.Text;
                var to = textBoxSuppliesPriceTo.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = _readSupplyRepository.GetAll().Where(x => x.Price >= int.Parse(from) && x.Price <= int.Parse(to)).Select(x => new
                {
                    x.ID,
                    Data_Zamowienia = x.Date,
                    Zamowiony_Produkt = x.OrderedProduct,
                    Cena = x.Price,
                    ID_Dostawcy = x.ProviderID
                }).ToList();
            }
            else
            {
                MessageBox.Show(@"Aby wypisać odpowiednie dostawy w pierwszej kolejności musisz podać przedział!");
            }
        }

        private void buttonSearchMenuProductsFromToByPrice_Click(object sender, EventArgs e)
        {
            if ((textBoxMenuProductPriceTimeFrom.Text != "") && (textBoxMenuProductPriceTimeTo.Text != ""))
            {
                var from = textBoxMenuProductPriceTimeFrom.Text;
                var to = textBoxMenuProductPriceTimeTo.Text;

                dataGridViewRestaurantManagementSystem.DataSource = null;
                dataGridViewRestaurantManagementSystem.DataSource = _readMenuProductRepository.GetAll().Where(x => x.Price >= int.Parse(from) && x.Price <= int.Parse(to)).Select(x => new
                {
                    x.ID,
                    Kategoria = x.Category,
                    Nazwa = x.Name,
                    Ilosc_Kcal = x.AmountOfCalories,
                    Cena = x.Price
                }).ToList();
            }
            else
            {
                MessageBox.Show(@"Aby wypisać odpowiednie produkty menu w pierwszej kolejności musisz podać przedział!");
            }
        }

        //Logowanie do panelu sprzedawcy. W panelu sprzedawcy możliwość realizowania zamówień.
        private void buttonLogInToCash_Click(object sender, EventArgs e)
        {
            if ((_currentTable == "sellers") && (dataGridViewRestaurantManagementSystem.SelectedRows.Count > 0))
            {
                var sellerId = dataGridViewRestaurantManagementSystem.SelectedRows[0].Cells["ID"].Value.ToString();
                if (_readSellerRepository.GetByID(int.Parse(sellerId)).Password == textBoxEnterSellerPassword.Text)
                {
                    var formSellerPanel = new FormSellerPanel(_readSellerRepository.GetByID(int.Parse(sellerId)), _context, _readMenuProductRepository, _writeOrderRepository);
                    Visible = false;
                    formSellerPanel.ShowDialog();
                    if (formSellerPanel.IsAccessible) return;
                    Visible = true;
                    ClearTextBoxes();
                }

                else
                {
                    MessageBox.Show(@"Wprowadz poprawne haslo!");
                }
            }
            else
            {
                MessageBox.Show(@"Aby zalogować się do kasy w pierwszej kolejności wybierz sprzedawcę!");
            }
        }

        //Przyciski obliczające statystyki.
        private void buttonSumProfit_Click(object sender, EventArgs e)
        {
            var tmp = _readOrderRepository.GetAll().Sum(x => x.Price);
            labelProfit.Text = tmp.ToString();

        }

        private void buttonSumCostOfSupplies_Click(object sender, EventArgs e)
        {
            var tmp = _readSupplyRepository.GetAll().Sum(x => x.Price);
            labelCostOfSupplies.Text = tmp.ToString();
        }

        private void buttonSumGain_Click(object sender, EventArgs e)
        {
            var tmp = _readOrderRepository.GetAll().Sum(x => x.Price) - _readSupplyRepository.GetAll().Sum(x => x.Price);
            labelGain.Text = tmp.ToString();
        }

        private void buttonAvgDeliveryTime_Click(object sender, EventArgs e)
        {
            var tmp = _readSupplierRepository.GetAll().Average(x => x.DeliveryTime);
            labelAverageDeliveryTime.Text = tmp.ToString("#.##");
        }

        private void buttonMaxMostExpensiveOrder_Click(object sender, EventArgs e)
        {
            var tmp = _readOrderRepository.GetAll().Max(x => x.Price);
            labelMostExpensiveOrder.Text = tmp.ToString();
        }

        private void buttonAvgYearsOfExperience_Click(object sender, EventArgs e)
        {
            var tmp = _readSellerRepository.GetAll().Average(x => x.YearsOfExperience);
            labelAverageYearsOfExperience.Text = tmp.ToString("#.##");
        }
    }
}
