using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class Character
{
    // Attributes
    private string _name;
    private List<Attribute> attributes;
    private int _level;
    private int _proficiency;
    private int _hitPoints;
    private int _currentHitPoints;
    private int _physicalDefense;
    private int _mentalDefense;
    private Attack _attack;
    private Boolean _hostile;

    // Constructor
    public Character()
    {
        _name = Program.EnterString("What is this character's name? ");
        attributes = new List<Attribute>
        {
            new Attribute("Might", Program.SelectInput($"What is {_name}'s might? ", -5, 10)),
            new Attribute("Agility", Program.SelectInput($"What is {_name}'s agility? ", -5, 10)),
            new Attribute("Cunning", Program.SelectInput($"What is {_name}'s cunning? ", -5, 10)),
            new Attribute("Influence", Program.SelectInput($"What is {_name}'s influence? ", -5, 10))
        };
        _level = Program.SelectInput($"What level is {_name}? ", 1, 20);
        _proficiency = 1 + (int)Math.Ceiling((double)_level / 4); 
        _hitPoints = 3 + _proficiency + attributes[0].GetModifier();
        _currentHitPoints = _hitPoints;
        SetPD();
        _mentalDefense = 8 + _proficiency + attributes[2].GetModifier() + attributes[3].GetModifier();
        Attack attack = new Attack();
        attack.CharacterSet();
        int hostileInput = Program.SelectInput($"1.  Yes\n2.  No\nIs {_name} a hostile creature? ", 1, 2);
        if (hostileInput == 1)
        {
            _hostile = true;
        }
        else
        {
            _hostile = false;
        }
    }

    public Character(string name, int level, int might, int agility, int cunning, int influence, int physicalDefense, Attack attack, Boolean hostile)
    {
        _name = name;
        attributes = new List<Attribute>
        {
            new Attribute("Might", might),
            new Attribute("Agility", agility),
            new Attribute("Cunning", cunning),
            new Attribute("Influence", influence)
        };
        _level = level;
        _proficiency = 1 + (int)Math.Ceiling((double)level / 4); 
        _hitPoints = 3 + _proficiency + attributes[0].GetModifier();
        _currentHitPoints = _hitPoints;
        _physicalDefense = physicalDefense;
        _mentalDefense = 8 + _proficiency + attributes[2].GetModifier() + attributes[3].GetModifier();
        _attack = attack;
        _hostile = hostile;
    }

    // Displays info for character
    public void Display()
    {
        Console.WriteLine($"----------------------------------\n{_name}\n----------------------------------");
        foreach (Attribute a in attributes)
        {
            Console.WriteLine($"{a.GetName()}: {a.GetModifier()}");
        }
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"Proficiency: {_proficiency}");
        Console.WriteLine($"Hit Points: {_hitPoints}");
        Console.WriteLine($"PD: {_physicalDefense}");
        Console.WriteLine($"MD: {_mentalDefense}");
    }

    // Sets the Physical Defense based off of the armor the user selects
    public void SetPD()
    {
        int input = Program.SelectInput($"1.  None\n2.  Light (Common)\n3.  Heavy (Common)\n4.  Light (Rare)\n5.  Heavy (Rare)\n6.  Light (Exotic)\n7.  Heavy (Exotic)\n8.  Unarmored Defense\nWhat type of armor is {_name} wearing? ", 1, 8);
        if (input == 1)
        {
            _physicalDefense = 8 + _proficiency + attributes[1].GetModifier();
        }
        else if (input == 2)
        {
            _physicalDefense = 9 + _proficiency + attributes[1].GetModifier();
        }
        else if (input == 3)
        {
            _physicalDefense = 14 + _proficiency;
        }
        else if (input == 4)
        {
            _physicalDefense = 10 + _proficiency + attributes[1].GetModifier();
        }
        else if (input == 5)
        {
            _physicalDefense = 15 + _proficiency;
        }
        else if (input == 6)
        {
            _physicalDefense = 11 + _proficiency + attributes[1].GetModifier();
        }
        else if (input == 7)
        {
            _physicalDefense = 16 + _proficiency;
        }
        else
        {
            int unarmoredInput = Program.SelectInput($"1.  Might\n2.  Cunning\n3.  Influence\nWhich attribute does {_name} use for Unarmored Defense? ", 1, 3);
            if (unarmoredInput == 1)
            {
                _physicalDefense = 8 + _proficiency + attributes[1].GetModifier() + attributes[0].GetModifier();
            }
            else if (unarmoredInput == 2)
            {
                _physicalDefense = 8 + _proficiency + attributes[1].GetModifier() + attributes[2].GetModifier();
            }
            else
            {
                _physicalDefense = 8 + _proficiency + attributes[1].GetModifier() + attributes[3].GetModifier();
            }
        }
        int shieldInput = Program.SelectInput($"1.  Yes\n2.  No\nDoes {_name} have a shield equipped? ", 1, 2);
        if (shieldInput == 1)
        {
            _physicalDefense += 2;
        }
    }

    // Makes an attack against a target.
    public void Attack(Character target, Boolean mental)
    {
        if (mental == false)
        {
            _attack.SetDefense(target.GetPD());
        }
        else
        {
            _attack.SetDefense(target.GetMD());
        }
        _attack.Damage();
    }

    // Getters
    public int GetPD()
    {
        return _physicalDefense;
    }
    public int GetMD()
    {
        return _mentalDefense;
    }
}