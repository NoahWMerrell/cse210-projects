public class Check
{
    private int _bonus;
    private int _advantage;
    private int _disadvantage;

    public Check(int bonus, int advantage, int disadvantage)
    {
        _bonus = bonus;
        _advantage = advantage;
        _disadvantage = disadvantage;
    }

    public int Roll()
    {
        Random random = new Random();
        List<int> dice = new List<int>();
        int advDis = _advantage - _disadvantage;
        for (int i = 0; i < (3 + Math.Abs(advDis)); i++)
        {
            dice.Add(random.Next(1, 7));
        }
        dice.Sort();
        int sum = 0;
        if (advDis > 0)
        {
            // Highest three
            sum = dice.Skip(dice.Count - 3).Sum();
        }
        else
        {
            // Lowest three (or first three)
            sum = dice.Take(3).Sum();
        }
        // dice.ForEach(Console.WriteLine);
        return sum + _bonus;
    }
}