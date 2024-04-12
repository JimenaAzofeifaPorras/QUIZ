using Entities.Entities;

namespace FrontEnd.Models
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }

        /// <summary>
        /// Foreign key to Person.BusinessEntityID
        /// </summary>
        public int? PersonId { get; set; }

        /// <summary>
        /// Foreign key to Store.BusinessEntityID
        /// </summary>
        public int? StoreId { get; set; }

        /// <summary>
        /// ID of the territory in which the customer is located. Foreign key to SalesTerritory.SalesTerritoryID.
        /// </summary>
        public int? TerritoryId { get; set; }

        /// <summary>
        /// Unique number identifying the customer assigned by the accounting system.
        /// </summary>
        public string AccountNumber { get; set; } = null!;

        /// <summary>
        /// ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
        /// </summary>
        public Guid Rowguid { get; set; }

        /// <summary>
        /// Date and time the record was last updated.
        /// </summary>
        public DateTime ModifiedDate { get; set; }

    }
}
