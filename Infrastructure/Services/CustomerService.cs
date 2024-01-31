

using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

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
        try
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
            if (customerEntity != null)
            {
                return customerEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }


    public CustomerEntity GetCustomerByEmail(string email)
    {
        try
        {
            var customerEntity = _customerRepository.Get(x => x.Email == email);
            if (customerEntity != null)
            {
                return customerEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;

    }


    public CustomerEntity GetCustomerById(int id)
    {
        try
        {
            var customerEntity = _customerRepository.Get(x => x.Id == id);
            if (customerEntity != null)
            {
                return customerEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public IEnumerable<CustomerEntity> GetCustomers()
    {
        try
        {
            var customer = _customerRepository.GetAll();
            if (customer != null)
            {
                return customer;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        try
        {
            var updatedCustomerEntity = _customerRepository.Update(x => x.Id == customerEntity.Id, customerEntity);
            if (updatedCustomerEntity != null)
            {
                return updatedCustomerEntity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public bool DeleteCustomer(int id)
    {
        try
        {
            if (id != 0)
            {
                _customerRepository.Delete(x => x.Id == id);
                return true;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}
