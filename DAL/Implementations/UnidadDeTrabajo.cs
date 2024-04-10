using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {

        public ICustomerDAL _customerDAL { get; }

        private readonly AdventureWorks2016Context _context;

        public UnidadDeTrabajo(AdventureWorks2016Context adventureWorks2016Context,
                                ICustomerDAL customerDAL
                                )
        {
            _context = adventureWorks2016Context;
            _customerDAL = customerDAL;
        }


        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}