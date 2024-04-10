using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class CustomerHelper : ICustomerHelper
    {
        IServiceRepository ServiceRepository;

        public CustomerHelper(IServiceRepository serviceRepository)
        {
            ServiceRepository = serviceRepository;
        }


        public CustomerViewModel AddCustomer(CustomerViewModel customer)
        {

            HttpResponseMessage responseMessage = ServiceRepository.PostResponse("api/Customer", Convertir(customer));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  customerAPI = JsonConvert.DeserializeObject<Customer>(content);
            }

            return customer;
        }


        Customer Convertir(CustomerViewModel customer)
        {
            return new Customer
            {
                CustomerId = customer.CustomerId,
                PersonId = customer.PersonId,
                StoreId = customer.StoreId,
                TerritoryId = customer.TerritoryId,
                AccountNumber = customer.AccountNumber,
                Rowguid = customer.Rowguid,
                ModifiedDate = customer.ModifiedDate,
                Person = customer.Person,
                SalesOrderHeaders = customer.SalesOrderHeaders,
                Store = customer.Store,
                Territory = customer.Territory
            };
        }

        CustomerViewModel Convertir(Customer customer)
        {
            return new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                PersonId = customer.PersonId,
                StoreId = customer.StoreId,
                TerritoryId = customer.TerritoryId,
                AccountNumber = customer.AccountNumber,
                Rowguid = customer.Rowguid,
                ModifiedDate = customer.ModifiedDate,
                Person = customer.Person,
                SalesOrderHeaders = customer.SalesOrderHeaders,
                Store = customer.Store,
                Territory = customer.Territory
            };
        }


        public CustomerViewModel DeleteCustomer(int id)
        {

            HttpResponseMessage responseMessage = ServiceRepository.DeleteResponse("api/Customer/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;

            }

            return new CustomerViewModel();
        }

        public List<CustomerViewModel> GetCustomers()
        {
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/customer");
            List<Customer> resultado = new List<Customer>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                resultado = JsonConvert.DeserializeObject<List<Customer>>(content);
            }
            List<CustomerViewModel> lista = new List<CustomerViewModel>();

            if (resultado != null && resultado.Count > 0)
            {
                foreach (var item in resultado)
                {
                    lista.Add(Convertir(item));
                }
            }

            return lista;



        }

        public CustomerViewModel GetCustomer(int id)
        {
            CustomerViewModel customer = new CustomerViewModel();
            HttpResponseMessage responseMessage = ServiceRepository.GetResponse("api/Customer/" + id.ToString());
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                customer = Convertir(JsonConvert.DeserializeObject<Customer>(content));
            }

            return customer;
        }

        public CustomerViewModel UpdateCustomer(CustomerViewModel customer)
        {
            HttpResponseMessage responseMessage = ServiceRepository.PutResponse("api/Customer", Convertir(customer));
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                // var  customerAPI = JsonConvert.DeserializeObject<Customer>(content);
            }

            return customer;
        }
    }
}