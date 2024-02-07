
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Entities;
using Infrastructure.Services;
using System.Collections.ObjectModel;
using System.Windows;
using WpfApp1.Mvvm.ViewModels;


namespace WpfApp1
{

    public partial class MainWindow : Window
    {

        private readonly CustomerService _customerService;
        private readonly AdressService _adressService;
        private readonly RoleService _roleService;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public MainWindow(CustomerService customerService, AdressService adressService, RoleService roleService, MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            _customerService = customerService;
            _adressService = adressService;
            _roleService = roleService;
            _mainWindowViewModel = mainWindowViewModel;
            DataContext = _mainWindowViewModel;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            ResultStatus.Content = "";

            var customerForm = new CustomerEntity()
            {
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Email = Email.Text,

            };

            var adressForm = new AdressEntity()
            {
                StreetName = StreetName.Text,
                PostalCode = PostalCode.Text,
                City = City.Text,
            };

            var roleForm = new RoleEntity()
            {
                RoleName = RoleName.Text,
            };



            //var adressResult = _adressService.CreateAdress(StreetName.Text, PostalCode.Text, City.Text);
            //var roleResult = _roleService.CreateRole(RoleName.Text);
            var result = _customerService.CreateCustomer(FirstName.Text, LastName.Text, Email.Text, StreetName.Text, PostalCode.Text, City.Text, RoleName.Text);

            if (result != null)
            {
                ResultStatus.Content = "Customer created succesfully!";
                _mainWindowViewModel.CustomerList.Add(result);
            }

            else
            {
                ResultStatus.Content = "Something went wrong..";
            }


            ClearForm();


        }

        private void ClearForm()
        {
            FirstName.Text = "";
            LastName.Text = "";
            Email.Text = "";
            StreetName.Text = "";
            PostalCode.Text = "";
            City.Text = "";
            RoleName.Text = "";
        }



        
        
    }
}