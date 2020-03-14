using Core.Entities;
using Core.Utilities.Enums;

namespace Entities.Dto
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public ProductType ProductType { get; set; }
        public string Description { get; set; }
        public char Status { get; set; }

    }
}
