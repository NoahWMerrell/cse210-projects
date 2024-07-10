public class Check
{
    // Attributes
    protected int _bonus;
    protected int _advantage;
    protected int _disadvantage;

    // Constructors
    public Check()
    {
        _bonus = Program.SelectInput("What is the bonus to the check? ", -30, 30);
        _advantage = Program.SelectInput("What is the advantage value for the check? ", -30, 30);
        _disadvantage = Program.SelectInput("What is the disadvantage value for the check? ", -30, 30);
    }

    public Check(int bonus)
    {
        _bonus = bonus;
        _advantage = 0;
        _disadvantage = 0;
    }

    public Check(int bonus, int advantage, int disadvantage)
    {
        _bonus = bonus;
        _advantage = advantage;
        _disadvantage = disadvantage;
    }

    // Rolls the Check and determines the result
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
        // dice.ForEach(Console.WriteLine); // For testing
        return sum + _bonus;
    }

    public void Select()
    {
        Program.SelectInput("", 1, 20);
    }
}