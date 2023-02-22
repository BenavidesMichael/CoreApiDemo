namespace CoreApiDemo.Entities
{
    public class Offer
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Discount { get; set; }

        public int TheaterId { get; set; }
        public Theater Theater { get; set; }
    }
}
