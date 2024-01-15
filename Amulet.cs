namespace InventorySystem
{
    public class Amulet : Item
    {
        public Amulet(int amount = 1)
        {
            Amount = amount;
            Name = this.GetType().Name;
        }
    }
}
