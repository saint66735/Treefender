public class Currency
{
    public static int currencyOwned;

    public static void SetCurrency(int amount)
    {
        currencyOwned = amount;
    }

    public static void AddCurrency(int amount)
    {
        currencyOwned += amount;
    }

    public static void RemoveCurrency(int amount)
    {
        currencyOwned -= amount;
    }

    public static int GetCurrency()
    {
        return currencyOwned;
    }
}
