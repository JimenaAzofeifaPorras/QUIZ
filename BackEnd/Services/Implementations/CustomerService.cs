using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class CustomerService : ICustomerService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public CustomerService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddCustomer(CustomerModel customer)
        {
            Customer entity = Convertir(customer);
            _unidadDeTrabajo._customerDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        CustomerModel Convertir(Customer customer)
        {
            return new CustomerModel
            {
                CustomerId = customer.CustomerId,
                PersonId = customer.PersonId,
                StoreId = customer.StoreId,
                TerritoryId = customer.TerritoryId,
                AccountNumber = customer.AccountNumber,
                Rowguid = customer.Rowguid,
                ModifiedDate = customer.ModifiedDate
            };
        }

        Customer Convertir(CustomerModel customer)
        {
            return new Customer
            {
                CustomerId = customer.CustomerId,
                PersonId = customer.PersonId,
                StoreId = customer.StoreId,
                TerritoryId = customer.TerritoryId,
                AccountNumber = customer.AccountNumber,
                Rowguid = customer.Rowguid,
                ModifiedDate = customer.ModifiedDate
            };
        }
        public bool DeleteCustomer(CustomerModel customer)
        {
            Customer entity = Convertir(customer);
            _unidadDeTrabajo._customerDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public CustomerModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._customerDAL.Get(id);

            CustomerModel customerModel = Convertir(entity);
            return customerModel;
        }

        public IEnumerable<CustomerModel> GetCustomers()
        {

            var result = _unidadDeTrabajo._customerDAL.GetAll();
            List<CustomerModel> lista = new List<CustomerModel>();
            foreach (var customer in result)
            {
                lista.Add(Convertir(customer));


            }
            return lista;
        }

        public bool UpdateCustomer(CustomerModel customer)
        {
            Customer entity = Convertir(customer);
            _unidadDeTrabajo._customerDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}