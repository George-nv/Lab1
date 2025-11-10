class Program
{
    static void Main()
    {
        List<Transport> transports = new List<Transport>();

        while (true)
        {
            Console.WriteLine("1 - Добавить экземпляр класса Transport");
            Console.WriteLine("2 - Добавить экземпляр класса Electric_scooter");
            Console.WriteLine("3 - Добавить экземпляр класса Car");
            Console.WriteLine("4 - Вывести весь список");
            Console.WriteLine("5 - Выход из программы");
            Console.WriteLine("Выберите команду:");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddTransport(transports, 1);
                    Console.WriteLine("Транспорт добавлен");
                    break;
                case "2":
                    AddTransport(transports, 2);
                    Console.WriteLine("Электросамокат добавлен");
                    break;
                case "3":
                    AddTransport(transports, 3);
                    Console.WriteLine("Машина добавлена");
                    break;
                case "4":
                    PrintTransports(transports);
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Введите корректное значение");
                    break;
            }
            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }

    static void AddTransport(List<Transport> transports, int choice)
    {
        int year;
        while (true)
        {
            Console.Write("Введите год производства:");
            if (int.TryParse(Console.ReadLine(), out year) && year > 1960 && year <= 2025)
                break;
            Console.WriteLine("Введите корректное значение (1960-2025)");
        }

        int power;
        while (true)
        {
            Console.Write("Введите мощность:");
            if (int.TryParse(Console.ReadLine(), out power) && power > 0 && power <= 1000)
                break;
            Console.WriteLine("Введите корректное значение (0-1000)");
        }

        int price;
        while (true)
        {
            Console.Write("Введите цену:");
            if (int.TryParse(Console.ReadLine(), out price) && price >= 0)
                break;
            Console.WriteLine("Введите корректное значение (>=0)");
        }

        string name;
        while (true)
        {
            Console.Write("Введите название:");
            name = Console.ReadLine();
            if (name != null && name.Length > 0 && name.Length <= 50)
                break;
            Console.WriteLine("Введите корректное значение (1-50 символов)");
        }

        string manufacturer = "";
        if (choice == 2)
        {
            while (true)
            {
                Console.Write("Введите производителя:");
                manufacturer = Console.ReadLine();
                if (manufacturer != null && manufacturer.Length > 0 && manufacturer.Length <= 50)
                    break;
                Console.WriteLine("Введите корректное значение (1-50 символов)");
            }
        }

        string color = "";
        if (choice == 3)
        {
            while (true)
            {
                Console.Write("Введите цвет:");
                color = Console.ReadLine();
                if (color != null && color.Length > 0 && color.Length <= 20)
                    break;
                Console.WriteLine("Введите корректное значение (1-20 символов)");
            }
        }

        switch (choice)
        {
            case 1:
                transports.Add(new Transport(year, power, price, name));
                break;
            case 2:
                transports.Add(new Electric_scooter(year, power, price, manufacturer, name));
                break;
            case 3:
                transports.Add(new Car(year, power, price, color, name));
                break;
        }
    }

    static void PrintTransports(List<Transport> transports)
    {
        if (transports.Count == 0)
        {
            Console.WriteLine("Список пуст");
            return;
        }
        Console.WriteLine("Список транспорта:");
        for (int i = 0; i < transports.Count; i++)
        {
            Console.WriteLine($"Транспорт №{i + 1}:");
            transports[i].Print();
        }
    }
}
class Transport
{
    private int year;
    private int power;
    private int price;
    private string name;

    public int Year
    {
        get => year;
        protected set
        {
            if (value > 1999 && value <= 2025)
                year = value;
            else
                year = 2025;
        }
    }

    public int Power
    {
        get => power;
        protected set
        {
            if (value > 0 && value <= 1000)
                power = value;
            else
                power = 60;
        }
    }

    public int Price
    {
        get => price;
        protected set
        {
            if (value >= 0)
                price = value;
            else
                price = 0;
        }
    }

    public string Name
    {
        get => name;
        protected set
        {
            if (value != null && value.Length > 0 && value.Length <= 50)
                name = value;
            else
                name = "Unnamed";
        }
    }
    public Transport()
    {
        year = 2025;
        power = 60;
        price = 0;
        name = "Unnamed";
    }
    public Transport(int year, int power, int price, string name)
    {
        Year = year;
        Power = power;
        Price = price;
        Name = name;
    }
    public virtual void Print()
    {
        Console.WriteLine($"Год производства - {Year}");
        Console.WriteLine($"Мощность - {Power}Вт");
        Console.WriteLine($"Цена - {Price}$");
        Console.WriteLine($"Название модели - {Name}");
    }
}
class Electric_scooter : Transport
{
    private string manufacturer;

    public string Manufacturer
    {
        get => manufacturer;
        private set
        {
            if (value != null && value.Length > 0 && value.Length <= 50)
                manufacturer = value;
            else
                manufacturer = "Unnamed";
        }
    }
    public Electric_scooter() : base()
    {
        manufacturer = "Unnamed";
    }
    public Electric_scooter(int year, int power, int price, string manufacturer, string name)
    : base(year, power, price, name)
    {
        Manufacturer = manufacturer;
    }
    public override void Print()
    {
        Console.WriteLine($"Год производства - {Year}");
        Console.WriteLine($"Мощность - {Power}Вт");
        Console.WriteLine($"Цена - {Price}$");
        Console.WriteLine($"Название модели - {Name}");
        Console.WriteLine($"Производитель - {Manufacturer}");
    }
}
class Car : Transport
{
    private string color;

    public string Color
    {
        get => color;
        private set
        {
            if (value != null && value.Length > 0 && value.Length <= 20)
                color = value;
            else
                color = "Unnamed";
        }
    }
    public Car() : base()
    {
        color = "Undefined";
    }
    public Car(int year, int power, int price, string color, string name)
    : base(year, power, price, name)
    {
        Color = color;
    }
    public override void Print()
    {
        Console.WriteLine($"Год производства - {Year}");
        Console.WriteLine($"Мощность - {Power}Вт");
        Console.WriteLine($"Цена - {Price}$");
        Console.WriteLine($"Название модели - {Name}");
        Console.WriteLine($"Цвет - {Color}");
    }
}