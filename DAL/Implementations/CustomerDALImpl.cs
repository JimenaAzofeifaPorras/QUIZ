using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CustomerDALImpl : DALGenericoImpl<Customer>, ICustomerDAL
    {
        AdventureWorks2016Context _context;

        public CustomerDALImpl(AdventureWorks2016Context context) : base(context)
        {
            _context = context;
        }


    }
}