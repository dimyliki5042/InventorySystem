namespace InventorySystem
{
    public class Money : Item
    {
        public Money(int amount)
        {
            Amount = amount;
            Name = this.GetType().Name;
        }
    }
}
