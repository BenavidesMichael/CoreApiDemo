﻿namespace CoreApiDemo.Entities
{
    public class TheaterOffer
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Discount { get; set; }

        public int TheatherId { get; set; }
        public Theater Theater { get; set; }
    }
}
