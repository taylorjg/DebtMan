namespace DebtMan.WebApp.Models
{
    public class GiftBox
    {
        public string For { get; set; }
        public Gift[] Gifts { get; set; }
    }

    public class Gift
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
