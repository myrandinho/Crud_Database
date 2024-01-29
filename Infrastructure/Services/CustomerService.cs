

using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class CustomerService
{
    private readonly CustomerRepository _customerRepository;
    private readonly RoleService _roleService;
    private readonly AdressService _adressService;

    public CustomerService(CustomerRepository customerRepository, RoleService roleService, AdressService adressService)
    {
        _customerRepository = customerRepository;
        _roleService = roleService;
        _adressService = adressService;
    }



    public CustomerEntity CreateCustomer(string firstName, string lastName, string email, string streetName, string postalCode, string city, string roleName)
    {
        var roleEntity = _roleService.CreateRole(roleName);
        var adressEntity = _adressService.CreateAdress(streetName, postalCode, city);

        var customerEntity = new CustomerEntity
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            RoleId = roleEntity.Id,
            AdressId = adressEntity.Id,
        };

        customerEntity = _customerRepository.Create(customerEntity);
        return customerEntity;
    }


    public CustomerEntity GetCustomerByEmail(string email)
    {
        var customerEntity = _customerRepository.Get(x => x.Email == email);
        return customerEntity;
    }


    public CustomerEntity GetCustomerById(int id)
    {
        var customerEntity = _customerRepository.Get(x => x.Id == id);
        return customerEntity;
    }

    public IEnumerable<CustomerEntity> GetCustomers()
    {
        var customer = _customerRepository.GetAll();
        return customer;
    }

    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        var updatedCustomerEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
        return updatedCustomerEntity;
    }

    public void DeleteCustomer(int id)
    {
        _customerRepository.Delete(x => x.Id == id);
    }
}
