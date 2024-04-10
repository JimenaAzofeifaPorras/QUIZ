using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            CustomerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerModel> Get()
        {
            return CustomerService.GetCustomers().Take(5);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerModel Get(int id)
        {
            return CustomerService.GetById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public string Post([FromBody] CustomerModel customer)
        {
            var result = CustomerService.AddCustomer(customer);

            if (result)
            {
                return "Categoría Agregada Correctamente.";
            }
            return "Hubo un error al agregar  la entidad.";

        }

        // PUT api/<CustomerController>/5
        [HttpPut]
        public string Put([FromBody] CustomerModel customer)
        {
            var result = CustomerService.UpdateCustomer(customer);

            if (result)
            {
                return "Categoría Editada Correctamente.";
            }
            return "Hubo un error al editar  la entidad.";
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {

            CustomerModel customer = new CustomerModel { CustomerId = id };
            var result = CustomerService.DeleteCustomer(customer);

            if (result)
            {
                return "Categoría Eliminada Correctamente.";
            }
            return "Hubo un error al eliminar  la entidad.";

        }
    }
}