

using Infrastructure.Services;

namespace Presentation
{
    public class MainMenu_UI
    {
        private readonly ProductService _productService;
        private readonly CustomerService _customerService;
        private readonly ChampionService _championService;
        private readonly SoftwareProductService _softwareProductService;

        public MainMenu_UI(ProductService productService, CustomerService customerService, ChampionService championService, SoftwareProductService softwareProductService)
        {
            _productService = productService;
            _customerService = customerService;
            _championService = championService;
            _softwareProductService = softwareProductService;
        }

        //Customers
        public void CreateCustomer_UI()
        {
            Console.Clear();
            Console.WriteLine("--- Create Customer ---");

            Console.Write("First Name: ");
            var firstName = Console.ReadLine()!;

            Console.Write("Last Name: ");
            var lastName = Console.ReadLine()!;

            Console.Write("Email: ");
            var email = Console.ReadLine()!;

            Console.Write("Street Name: ");
            var streetName = Console.ReadLine()!;

            Console.Write("Postal Code: ");
            var postalCode = Console.ReadLine()!;

            Console.Write("City: ");
            var city = Console.ReadLine()!;

            Console.Write("Role Name: ");
            var roleName = Console.ReadLine()!;

            var result = _customerService.CreateCustomer(firstName, lastName, email, streetName, postalCode, city, roleName);
            if (result != null)
            {
                Console.Clear();
                Console.WriteLine("Customer was created.");
                Console.ReadKey();
                Main_Menu_App_UI();
            }

        }

        public void GetCustomers_UI()
        {
            Console.Clear();
            var customers = _customerService.GetCustomers();
            Console.Clear();
            foreach (var customer in customers)
            {
                Console.WriteLine($"Name: {customer.FirstName} {customer.LastName} ");
                Console.WriteLine($"Role: {customer.Role.RoleName}");
                Console.WriteLine($"Adress: {customer.Adress.StreetName}, {customer.Adress.PostalCode}, {customer.Adress.City}");
                Console.WriteLine();
            }

            Console.ReadKey();
            Main_Menu_App_UI();
        }

        public void UpdateCustomer_UI()
        {
            Console.Clear();
            Console.Write("Enter Customer Email:");
            var email = Console.ReadLine()!;

            var customer = _customerService.GetCustomerByEmail(email);
            if (customer != null)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"Name: {customer.FirstName} {customer.LastName} ");
                Console.WriteLine($"Role: {customer.Role.RoleName}");
                Console.WriteLine($"Adress: {customer.Adress.StreetName}, {customer.Adress.PostalCode}, {customer.Adress.City}");
                Console.WriteLine();

                Console.Write("New Last Name: ");
                customer.LastName = Console.ReadLine()!;

                var newCustomer = _customerService.UpdateCustomer(customer);
                Console.Clear();
                Console.WriteLine($"Name: {customer.FirstName} {customer.LastName} ");
                Console.WriteLine($"Role: {customer.Role.RoleName}");
                Console.WriteLine($"Adress: {customer.Adress.StreetName}, {customer.Adress.PostalCode}, {customer.Adress.City}");
                Console.WriteLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No customer found.");

            }

            Console.ReadKey();
            Main_Menu_App_UI();
        }

        public void DeleteCustomer_UI()
        {
            Console.Clear();
            Console.Write("Enter customer Email:");
            var email = Console.ReadLine()!;

            var customer = _customerService.GetCustomerByEmail(email);
            if (customer != null)
            {
                Console.Clear();
                _customerService.DeleteCustomer(customer.Id);
                Console.WriteLine("Customer was deleted");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No customer found.");

            }

            Console.ReadKey();
            Main_Menu_App_UI();
        }




        //Products
        public void CreateProduct_UI()
        {
            Console.Clear();
            Console.WriteLine("--- Create Product ---");

            Console.Write("Product Title: ");
            var title = Console.ReadLine()!;

            Console.Write("Product Price: ");
            var price = decimal.Parse(Console.ReadLine()!);

            Console.Write("Product Category: ");
            var categoryName = Console.ReadLine()!;

            var result = _productService.CreateProduct(title, price, categoryName);
            if (result != null)
            {
                Console.Clear();
                Console.WriteLine("Product was created.");
                Console.ReadKey();
                Main_Menu_App_UI();
            }
        }

        public void GetProducts_UI()
        {
            Console.Clear();
            var products = _productService.GetProducts();
            Console.Clear();
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price}) Euro");
                Console.WriteLine();
            }

            Console.ReadKey();
            Main_Menu_App_UI();
        }

        public void UpdateProduct_UI()
        {
            Console.Clear();
            Console.Write("Enter product Id:");
            var id = int.Parse(Console.ReadLine()!);

            var product = _productService.GetProductById(id);
            if (product != null)
            {
                Console.Clear();
                Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price}) Euro");
                Console.WriteLine();

                Console.Write("New Product Title: ");
                product.Title = Console.ReadLine()!;

                var newProduct = _productService.UpdateProduct(product);
                Console.Clear();
                Console.WriteLine($"{product.Title} - {product.Category.CategoryName} ({product.Price}) Euro");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No product found.");

            }

            Console.ReadKey();
            Main_Menu_App_UI();
        }

        public void DeleteProduct_UI()
        {
            Console.Clear();
            Console.Write("Enter product Id:");
            var id = int.Parse(Console.ReadLine()!);

            var product = _productService.GetProductById(id);
            if (product != null)
            {
                Console.Clear();
                _productService.DeleteProduct(product.Id);
                Console.WriteLine("Product was deleted");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("No product found.");

            }

            Console.ReadKey();
            Main_Menu_App_UI();
        }



        //Champions

        public void CreateChampion_UI()
        {
            Console.Clear();

            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine()!);

            Console.Write("Name of Trophy: ");
            string trophy = Console.ReadLine()!;

            Console.Write("Team Name: ");
            string teamName = Console.ReadLine()!;

            Console.Write("League Name: ");
            string leagueName = Console.ReadLine()!;

            Console.Write("Nation: ");
            string nation = Console.ReadLine()!;

            var champion = _championService.CreateChampion(year, trophy, teamName, leagueName, nation);
            if (champion != null)
            {
                Console.Clear();
                Console.WriteLine("Champion was created.");
                Console.ReadKey();
                Main_Menu_App_UI();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Something went wrong. Please try again");
                Console.ReadKey();
                Main_Menu_App_UI();
            }


        }

        public void GetChampions_UI()
        {
            Console.Clear();
            var champions = _championService.GetChampions();
            Console.Clear();

            foreach (var champion in champions)
            {

                Console.WriteLine($"Year: {champion.Year}");
                Console.WriteLine($"Winner: {champion.Team.TeamName}");
                Console.WriteLine($"League: {champion.League.LeagueName}, {champion.League.Nation} ");
                Console.WriteLine($"Trophy: {champion.Throphy}");
                Console.WriteLine();

            }
            Console.ReadKey();
            Main_Menu_App_UI();
        }



        public void UpdateChampion_UI()
        {
            Console.Clear();
            Console.Write("Enter Champion Id: ");
            int id = int.Parse(Console.ReadLine()!);

            var champion = _championService.GetChampionById(id);
            if (champion != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Winner: {champion.Team.TeamName}");



                Console.Write("Enter New Team Name: ");
                champion.Team.TeamName = Console.ReadLine()!;

                var newChampion = _championService.UpdateChampion(champion);
                Console.WriteLine("### UPDATED ###");
                Console.WriteLine();
                Console.WriteLine($"New name: {newChampion.Team.TeamName}");
                Console.WriteLine();


            }
            else
            {
                Console.WriteLine("No champion found.");

            }

            Console.ReadKey();
            Main_Menu_App_UI();
        }



        public void DeleteChampion_UI()
        {
            Console.Clear();
            Console.Write("Enter Champion Id:");
            int id = int.Parse(Console.ReadLine()!);

            var champion = _championService.GetChampionById(id);
            if (champion != null)
            {
                _championService.DeleteChampion(champion.Id);
                Console.WriteLine("Champion was deleted.");
            }
            else
            {
                Console.WriteLine("No champion found.");

            }

            Console.ReadKey();
            Main_Menu_App_UI();
        }



        //SoftwareProducts

        public void CreateSoftwareProduct_UI()
        {
            Console.Clear();
            Console.Write("Title: ");
            string title = Console.ReadLine()!;

            Console.Write("Quantity (for example, 120 if u have 120 gigabytes): ");
            int quantity = int.Parse(Console.ReadLine()!);

            Console.Write("Unit (for example, GB for gigabyte): ");
            string unit = Console.ReadLine()!;

            var softwareProduct = _softwareProductService.CreateSoftwareProduct(title, quantity, unit);
            if (softwareProduct != null)
            {
                Console.Clear();
                Console.WriteLine("Software Product was created.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Something went wrong. Please try again");
                Console.ReadKey();
                Main_Menu_App_UI();
            }

        }


        public void GetSoftwareProducts_UI()
        {
            Console.Clear();
            var softwareProducts = _softwareProductService.GetSoftwareProducts();
            Console.Clear();

            foreach (var sp in softwareProducts)
            {

                Console.WriteLine($"{sp.Title} ({sp.Size.Quantity}{sp.Size.Unit})");
                Console.WriteLine();
            }
            Console.ReadKey();
            Main_Menu_App_UI();
        }

        public void UpdateSoftwareProduct_UI()
        {
            Console.Clear();
            Console.Write("Enter Software Product Id: ");
            int id = int.Parse(Console.ReadLine()!);

            var softwareProduct = _softwareProductService.GetSoftwareProductById(id);
            if (softwareProduct != null)
            {
                Console.WriteLine();
                Console.WriteLine($"Title: {softwareProduct.Title} ({softwareProduct.Size.Quantity}{softwareProduct.Size.Unit})");



                Console.Write("Enter New Title: ");
                softwareProduct.Title = Console.ReadLine()!;

                var newsoftwareProduct = _softwareProductService.UpdateSoftwareProduct(softwareProduct);
                Console.WriteLine("### UPDATED ###");
                Console.WriteLine();
                Console.WriteLine($"New Title: {newsoftwareProduct.Title}");
                Console.WriteLine();


            }
            else
            {
                Console.WriteLine("No Software Product found.");

            }

            Console.ReadKey();
            Main_Menu_App_UI();

        }


        public void DeleteSoftwareProduct_UI()
        {
            Console.Clear();
            Console.Write("Enter Software Product Id:");
            int id = int.Parse(Console.ReadLine()!);

            var softwareProduct = _softwareProductService.GetSoftwareProductById(id);
            if (softwareProduct != null)
            {
                _softwareProductService.DeleteSoftwareProduct(softwareProduct.Id);
                Console.WriteLine("Champion was deleted.");
            }
            else
            {
                Console.WriteLine("No champion found.");

            }

            Console.ReadKey();
            Main_Menu_App_UI();
        }






        public void Main_Menu_App_UI()
        {
            Console.Clear();
            Console.WriteLine("## My CRUD App ##");
            Console.WriteLine();
            Console.WriteLine("1. Product Menu");
            Console.WriteLine("2. Customer Menu");
            Console.WriteLine("3. Champion Menu");
            Console.WriteLine("4. Software Product Menu");
            Console.WriteLine("5. Exit App");
            Console.Write("Your choice(1-5): ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("## Product Menu ##");
                    Console.WriteLine();
                    Console.WriteLine("1. Create");
                    Console.WriteLine("2. Show");
                    Console.WriteLine("3. Update");
                    Console.WriteLine("4. Delete");
                    Console.WriteLine("5. Return to Main Menu");
                    Console.Write("Your choice(1-5): ");
                    string pOption = Console.ReadLine();

                    switch (pOption)
                    {
                        case "1":
                            CreateProduct_UI();
                            break;

                        case "2":
                            GetProducts_UI();
                            break;

                        case "3":
                            UpdateProduct_UI();
                            break;
                        case "4":
                            DeleteProduct_UI();
                            break;
                        case "5":
                            Main_Menu_App_UI();
                            break;
                    }
                    break;

                case "2":
                    Console.Clear();
                    Console.WriteLine("## Customer Menu ##");
                    Console.WriteLine();
                    Console.WriteLine("1. Create");
                    Console.WriteLine("2. Show");
                    Console.WriteLine("3. Update");
                    Console.WriteLine("4. Delete");
                    Console.WriteLine("5. Return to Main Menu");
                    Console.Write("Your choice(1-5): ");
                    string cOption = Console.ReadLine();

                    switch (cOption)
                    {
                        case "1":
                            CreateCustomer_UI();
                            break;

                        case "2":
                            GetCustomers_UI();
                            break;

                        case "3":
                            UpdateCustomer_UI();
                            break;
                        case "4":
                            DeleteCustomer_UI();
                            break;
                        case "5":
                            Main_Menu_App_UI();
                            break;
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("## Champion Menu ##");
                    Console.WriteLine();
                    Console.WriteLine("1. Create");
                    Console.WriteLine("2. Show");
                    Console.WriteLine("3. Update");
                    Console.WriteLine("4. Delete");
                    Console.WriteLine("5. Return to Main Menu");
                    Console.Write("Your choice(1-5): ");
                    string chOption = Console.ReadLine();

                    switch (chOption)
                    {
                        case "1":
                            CreateChampion_UI();
                            break;

                        case "2":
                            GetChampions_UI();
                            break;

                        case "3":
                            UpdateChampion_UI();
                            break;
                        case "4":
                            DeleteChampion_UI();
                            break;
                        case "5":
                            Main_Menu_App_UI();
                            break;
                    }
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("## Software Product Menu ##");
                    Console.WriteLine();
                    Console.WriteLine("1. Create");
                    Console.WriteLine("2. Show");
                    Console.WriteLine("3. Update");
                    Console.WriteLine("4. Delete");
                    Console.WriteLine("5. Return to Main Menu");
                    Console.Write("Your choice(1-5): ");
                    string spOption = Console.ReadLine();

                    switch (spOption)
                    {
                        case "1":
                            CreateSoftwareProduct_UI();
                            break;

                        case "2":
                            GetSoftwareProducts_UI();
                            break;

                        case "3":
                            UpdateSoftwareProduct_UI();
                            break;
                        case "4":
                            DeleteSoftwareProduct_UI();
                            break;
                        case "5":
                            Main_Menu_App_UI();
                            break;
                    }
                    break;

                case "5":
                    Environment.Exit(0);
                    break;
            }

        }
    }
}

