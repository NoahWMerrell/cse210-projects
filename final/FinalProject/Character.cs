using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

public class Character
{
    // Attributes
    private string _name;
    private List<Attribute> _attributes;
    private int _level;
    private int _proficiency;
    private int _hitPoints;
    private int _currentHitPoints;
    private int _physicalDefense;
    private int _mentalDefense;
    private Attack _attack;
    private Boolean _hostile;
    private int _initiative;

    // Constructor
    public Character()
    {
        _name = Program.EnterString("What is this character's name? ");
        _attributes = new List<Attribute>
        {
            new Attribute("Might", Program.SelectInput($"What is {_name}'s might? ", -5, 10)),
            new Attribute("Agility", Program.SelectInput($"What is {_name}'s agility? ", -5, 10)),
            new Attribute("Cunning", Program.SelectInput($"What is {_name}'s cunning? ", -5, 10)),
            new Attribute("Influence", Program.SelectInput($"What is {_name}'s influence? ", -5, 10))
        };
        _level = Program.SelectInput($"What level is {_name}? ", 1, 20);
        _proficiency = 1 + (int)Math.Ceiling((double)_level / 4); 
        _hitPoints = 3 + _proficiency + _attributes[0].GetModifier();
        _currentHitPoints = _hitPoints;
        SetPD();
        _mentalDefense = 10 + _proficiency + _attributes[2].GetModifier() + _attributes[3].GetModifier();
        _attack = new Attack();
        _attack.CharacterSet();
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
        _attributes = new List<Attribute>
        {
            new Attribute("Might", might),
            new Attribute("Agility", agility),
            new Attribute("Cunning", cunning),
            new Attribute("Influence", influence)
        };
        _level = level;
        _proficiency = 1 + (int)Math.Ceiling((double)level / 4); 
        _hitPoints = 3 + _proficiency + _attributes[0].GetModifier();
        _currentHitPoints = _hitPoints;
        _physicalDefense = physicalDefense;
        _mentalDefense = 10 + _proficiency + _attributes[2].GetModifier() + _attributes[3].GetModifier();
        _attack = attack;
        _hostile = hostile;
    }

    // Displays info for character
    public void Display()
    {
        Console.WriteLine($"----------------------------------\n{_name}\n----------------------------------");
        foreach (Attribute a in _attributes)
        {
            Console.WriteLine($"{a.GetName()}: {a.GetModifier()}");
        }
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"Proficiency: {_proficiency}");
        Console.WriteLine($"Hit Points: {_hitPoints}");
        Console.WriteLine($"PD: {_physicalDefense}");
        Console.WriteLine($"MD: {_mentalDefense}");
    }

    public void Status()
    {
        string dying = "";
        if (_currentHitPoints <= 0)
        {
            dying = " (Dying)";
        }
        if (_currentHitPoints < -_proficiency)
        {
            dying = " (Dead)";
        }
        Console.WriteLine($"{_name}: {_currentHitPoints}/{_hitPoints}{dying}");
    }

    // Sets the Physical Defense based off of the armor the user selects
    public void SetPD()
    {
        int input = Program.SelectInput($"1.  None\n2.  Light (Common)\n3.  Heavy (Common)\n4.  Light (Rare)\n5.  Heavy (Rare)\n6.  Light (Exotic)\n7.  Heavy (Exotic)\n8.  Unarmored Defense\nWhat type of armor is {_name} wearing? ", 1, 8);
        if (input == 1)
        {
            _physicalDefense = 10 + _proficiency + _attributes[1].GetModifier();
        }
        else if (input == 2)
        {
            _physicalDefense = 11 + _proficiency + _attributes[1].GetModifier();
        }
        else if (input == 3)
        {
            _physicalDefense = 16 + _proficiency;
        }
        else if (input == 4)
        {
            _physicalDefense = 12 + _proficiency + _attributes[1].GetModifier();
        }
        else if (input == 5)
        {
            _physicalDefense = 17 + _proficiency;
        }
        else if (input == 6)
        {
            _physicalDefense = 13 + _proficiency + _attributes[1].GetModifier();
        }
        else if (input == 7)
        {
            _physicalDefense = 18 + _proficiency;
        }
        else
        {
            int unarmoredInput = Program.SelectInput($"1.  Might\n2.  Cunning\n3.  Influence\nWhich attribute does {_name} use for Unarmored Defense? ", 1, 3);
            if (unarmoredInput == 1)
            {
                _physicalDefense = 10 + _proficiency + _attributes[1].GetModifier() + _attributes[0].GetModifier();
            }
            else if (unarmoredInput == 2)
            {
                _physicalDefense = 10 + _proficiency + _attributes[1].GetModifier() + _attributes[2].GetModifier();
            }
            else
            {
                _physicalDefense = 10 + _proficiency + _attributes[1].GetModifier() + _attributes[3].GetModifier();
            }
        }
        int shieldInput = Program.SelectInput($"1.  Yes\n2.  No\nDoes {_name} have a shield equipped? ", 1, 2);
        if (shieldInput == 1)
        {
            _physicalDefense += 2;
        }
    }

    // Makes an attack against a target.
    public void Attack(Character target, int disadvantage, Boolean mental)
    {
        if (mental == false)
        {
            _attack.SetDefense(target.GetPD());
        }
        else
        {
            _attack.SetDefense(target.GetMD());
        }
        int damage = _attack.Damage(disadvantage);
        target._currentHitPoints -= damage;
        // if (damage > 0)
        // {
        //     Console.WriteLine($"{_name} attacks {target._name} dealing {damage} damage!");
        // }
        // else
        // {
        //     Console.WriteLine($"{_name} attacks {target._name} and missed!");
        // }
    }

    // Rolls initiative for character
    public void RollInitiative()
    {
        Random random = new Random();
        _initiative = random.Next(1, 7) + _attributes[1].GetModifier();
    }

    // Resets the character's hit points to their max
    public void ResetHP()
    {
        _currentHitPoints = _hitPoints;
    }

    // Getters
    public string GetName()
    {
        return _name;
    }

    public int GetMod(string attribute)
    {
        foreach (Attribute a in _attributes)
        {
            if (a.GetName() == attribute)
            {
                return a.GetModifier();
            }
        }
        return 0;
    }

    public int GetProficiency()
    {
        return _proficiency;
    }

    public int GetHP()
    {
        return _currentHitPoints;
    }

    public Boolean GetHostile()
    {
        return _hostile;
    }
    
    public int GetPD()
    {
        return _physicalDefense;
    }
    public int GetMD()
    {
        return _mentalDefense;
    }

    public int GetInitiative()
    {
        return _initiative;
    }
}