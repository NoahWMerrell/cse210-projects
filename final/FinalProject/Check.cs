public class Check
{
    // Attributes
    protected int _bonus;
    protected int _advantage;
    protected int _disadvantage;

    // Constructors
    public Check() {}

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

    // Allows user to enter values for Check
    public virtual void Set()
    {
        _bonus = Program.SelectInput("What is the bonus to the check? ", -30, 30);
        _advantage = Program.SelectInput("What is the advantage value for the check? ", -30, 30);
        _disadvantage = Program.SelectInput("What is the disadvantage value for the check? ", -30, 30);
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
        return sum + _bonus;
    }
}