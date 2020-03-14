using Core.Entities;

namespace UnitTest.Parameters
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductType { get; set; }
        public string Description { get; set; }
        public char Status { get; set; }

    }
}
