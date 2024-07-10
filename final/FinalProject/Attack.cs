public class Attack : Check
{
    private int _baseDamage;
    private int _defense;

    // Constructors
    public Attack() // Not working properly
    {
        _bonus = Program.SelectInput("What is the bonus to the attack? ", -30, 30);
        _advantage = Program.SelectInput("What is the advantage value for the attack? ", -30, 30);
        _disadvantage = Program.SelectInput("What is the disadvantage value for the attack? ", -30, 30);
        _baseDamage = Program.SelectInput("What is the base damage of the attack? ", 0, 10);
        _defense = Program.SelectInput("What is the defense for the target? ", 0, 40);
    }

    public Attack(int bonus, int baseDamage, int defense): base(bonus)
    {
        _advantage = 0;
        _disadvantage = 0;
        _baseDamage = baseDamage;
        _defense = defense;
    }

    public Attack(int bonus, int advantage, int disadvantage, int baseDamage, int defense): base(bonus, advantage, disadvantage)
    {
        _baseDamage = baseDamage;
        _defense = defense;
    }

    // Calculates the damage of the attack
    public int Damage()
    {
        int hit = Roll() - _defense;
        if (hit >= 0)
        {
            return _baseDamage + (int)Math.Floor((double)hit / 5);
        }
        else
        {
            return 0;
        }
    }

    // Setter
    public void SetDefense(int defense)
    {
        _defense = defense;
    }
}