﻿namespace Entityframeworklearning.Data
{
    public class BookPrice
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public double Amount { get; set; }
        public int CurrencyTypeId { get; set; }

        public Book Book{ get; set; }
        public CurrencyType CurrencyType { get; set; }
    }
}
