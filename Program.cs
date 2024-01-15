namespace InventorySystem
{
    public class Program
    {
        private static List<Item> Table = new List<Item>()
        {
            new Book(1),
            new Money(33),
            new Amulet(1)
        };
        private static List<Item> Inventory = new List<Item>();

        private static void Main(string[] args)
        {
            while (true)
            {
                CheckTable();
                CheckInventory();
                Console.Write("Введите команду (введите help для вывода списка комманд): ");
                string? command = Console.ReadLine();
                Console.Clear();
                switch (command)
                {
                    case "help":
                        OutputCommands();
                        break;
                    case "take":
                        TakeItem();
                        break;
                    case "exit":
                        CloseProgramm();
                        break;
                    default:
                        Console.WriteLine("Команда введена неправильно.");
                        break;
                }
            }
        }

        private static void TakeItem() // Метод взятия предметов со стола
        {
            Console.Write("Введите предмет который необходимо взять: ");
            string? itemStr = Console.ReadLine();

            if (Table.Count > 0 && itemStr != null) // Проверка на наличие предметов на столе и ввел ли пользователь что-нибудь
            {
                int itemIndex = Table.FindIndex(x => x.GetType().Name == itemStr); // Поиск индекса предмета на столе

                if (itemIndex != -1) // Если индекс предмета найден
                {
                    Console.Write($"Введите количество которое необходимо взять(доступно {Table[itemIndex].Amount}): ");
                    string? amountStr = Console.ReadLine();
                    int.TryParse(amountStr, out int amount); // Попытка конвертировать string в int для получения количества объектов

                    if (amount > 0)
                    {
                        Item? itemInInventory = Inventory.Find(x => x.GetType() == Table[itemIndex].GetType()); // Поиск похожего предмета в инвентаре
                        if (amount >= Table[itemIndex].Amount) // Если количество, которое хочет взять пользователь больше чем есть на столе
                        {
                            amount = Table[itemIndex].Amount;
                            Table.RemoveAt(itemIndex);
                        }
                        else
                        {
                            Table[itemIndex].Amount -= amount;
                        }

                        if (itemInInventory != null) // Если предмет найден в инвентаре
                        {
                            itemInInventory.Amount += amount;
                        }
                        else
                        {
                            CreateClass(itemStr, amount);
                        }
                    }
                }   
            }
        }

        private static void CreateClass(string type, int amount) // Создание нового экземпляра класса в инвентаре
        {
            switch (type) // Проверка на тип объекта и создание соответствующего класса
            {
                case "Book":
                    Inventory.Add(new Book(amount));
                    break;
                case "Money":
                    Inventory.Add(new Money(amount));
                    break;
                case "Amulet":
                    Inventory.Add(new Amulet(amount));
                    break;
                default:
                    return;
            }
        }

        private static void OutputCommands() // Вывод существующих комманд
        {
            Console.WriteLine("---COMMANDS---\n" +
                                "take - взять предмет в инвентарь\n" +
                                "exit - завершение работы программы\n" +
                                "--------------------");
        }

        private static void CheckTable() // Вывод содержимого стола
        {
            if (Table.Count == 0)
            {
                Console.WriteLine("На столе ничего нет");
                return;
            }

            Console.WriteLine("---TABLE---");

            foreach (Item item in Table)
            {
                Console.WriteLine($"{item.Name} - {item.Amount}");
            }

            Console.WriteLine("---------");
        }

        private static void CheckInventory() // Вывод содержимого инвентаря
        {
            if (Inventory.Count == 0)
            {
                Console.WriteLine("В инвентаре ничего нет");
                return;
            }

            Console.WriteLine("---INVENTORY---");

            foreach (Item item in Inventory)
            {
                Console.WriteLine($"{item.Name} - {item.Amount}");
            }

            Console.WriteLine("---------");
        }

        private static void CloseProgramm() //Метод закрытия программы
        {
            Environment.Exit(0);
        }
    }
}
