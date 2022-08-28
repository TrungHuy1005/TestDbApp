namespace TestDbApp.Models
{
    public class CryptoCurrencyEntity
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Change { get; set; }
        public decimal PercentChange { get; set; }
        public decimal MarketCap { get; set; }
        public string VolumeInCurrency { get; set; }
        public decimal TotalVolumeAllCurrency { get; set; }
        public decimal CirculatingSupply { get; set; }
    }
}
