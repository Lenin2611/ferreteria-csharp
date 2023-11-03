using ferreteria.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        Core core = new Core();
        bool loop = true;
        while (loop)
        {
            bool loop2 = true;
            byte option = 0;
            while (loop2)
            {
                try
                {
                    core.MainMenu();
                    option = byte.Parse(Console.ReadLine());
                    if (option >= 0 && option < 7)
                    {
                        loop2 = false;
                    }
                    else
                    {
                        core.InvalidOption();
                    }
                }
                catch (Exception)
                {
                    core.InvalidOption();
                }
            }
            switch (option)
            {
                case 1:
                    core.ProductsList();
                    break;
                case 2:
                    core.ProductsRunOut();
                    break;
                case 3:
                    core.ProductsToBuy();
                    break;
                case 4:
                    core.JanuaryInvoices();
                    break;
                case 5:
                    core.ProductsSold();
                    break;
                case 6:
                    core.TotalInventory();
                    break;
                case 0:
                    Console.Clear();
                    loop = false;
                    break;
                default:
                    core.InvalidOption();
                    break;
            }
        }
    }
}