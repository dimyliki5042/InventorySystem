namespace InventorySystem
{
    public class Book : Item
    {
        public Book(int amount)
        {
            Name = this.GetType().Name;
            Amount = amount;
        }
    }
}
