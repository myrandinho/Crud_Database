

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Entities;
using Infrastructure.Services;
using System.Collections.ObjectModel;

namespace WpfApp1.Mvvm.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly CustomerService _customerService;

    public MainWindowViewModel(CustomerService customerService)
    {
        _customerService = customerService;
        LoadCustomers();
    }

    private ObservableCollection<CustomerEntity> _customerList;
    public ObservableCollection<CustomerEntity> CustomerList
    {
        get { return _customerList;}
        set { SetProperty(ref _customerList, value); }
    }

    private void LoadCustomers()
    {
        CustomerList = new ObservableCollection<CustomerEntity>(_customerService.GetCustomers());
    }

    private string _customerInfo;
    public string CustomerInfo
    {
        get { return _customerInfo; }
        set
        {
            _customerInfo = value;
            OnPropertyChanged(nameof(CustomerInfo));
        }
    }

    [RelayCommand]
    public void RemoveCustomerFromDatabase(CustomerEntity customer)
    {
        if (customer != null) 
        {
            CustomerList.Remove(customer);
            bool deleteCustomerEntity = _customerService.DeleteCustomer(customer.Id);

        }
    }

    [RelayCommand]
    public void ShowCustomerInformation(CustomerEntity customer)
    {
        if (customer != null)
        {
            CustomerInfo = $"{customer.FirstName} {customer.LastName} ({customer.Role.RoleName}){System.Environment.NewLine}{customer.Email}{System.Environment.NewLine}{customer.Adress.StreetName}{System.Environment.NewLine}{customer.Adress.PostalCode} {customer.Adress.City}";

        }
    }
}
