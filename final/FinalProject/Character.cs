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
    private Boolean _mentalAttack;
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
        int attackType = Program.SelectInput($"1.  Physical\n2.  Mental\nIs {_name}'s attack a Physical or Mental attack? ", 1, 2);
        if (attackType == 1)
        {
            _mentalAttack = false;
        }
        else
        {
            _mentalAttack = true;
        }
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

    public Character(string name, int level, int might, int agility, int cunning, int influence, int physicalDefense, Attack attack, Boolean mentalAttack, Boolean hostile)
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
        _mentalAttack = mentalAttack;
        _hostile = hostile;
    }

    // Displays info for character
    public void Display()
    {
        string hostileStr = "";
        if (!_hostile)
        {
            hostileStr = "Friendly";
        }
        else
        {
            hostileStr = "Hostile";
        }
        Console.WriteLine($"----------------------------------\n{_name} ({hostileStr})\n----------------------------------");
        foreach (Attribute a in _attributes)
        {
            Console.WriteLine($"{a.GetName()}: {a.GetModifier()}");
        }
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"Proficiency: {_proficiency}");
        Console.WriteLine($"Hit Points: {_hitPoints}");
        Console.WriteLine($"PD: {_physicalDefense}");
        Console.WriteLine($"MD: {_mentalDefense}");
        string attackTypeStr;
        if (_mentalAttack == false)
        {
            attackTypeStr = "Physical";
        }
        else
        {
            attackTypeStr = "Mental";
        }
        string positiveBonus = "";
        if (_attack.GetBonus() >= 0)
        {
            positiveBonus = "+";
        }
        Console.WriteLine($"Attack: [{positiveBonus}{_attack.GetBonus()}] {_attack.GetDamage()} damage ({attackTypeStr})");
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
        int input = Program.SelectInput($"Armor:\n1.  None\n2.  Light (Common)\n3.  Heavy (Common)\n4.  Light (Rare)\n5.  Heavy (Rare)\n6.  Light (Exotic)\n7.  Heavy (Exotic)\n8.  Unarmored Defense\nWhat type of armor is {_name} wearing? ", 1, 8);
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
            int unarmoredInput = Program.SelectInput($"Unarmored Defense:\n1.  Might\n2.  Cunning\n3.  Influence\nWhich attribute does {_name} use for Unarmored Defense? ", 1, 3);
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
        int shieldInput = Program.SelectInput($"Shield:\n1.  Yes\n2.  No\nDoes {_name} have a shield equipped? ", 1, 2);
        if (shieldInput == 1)
        {
            _physicalDefense += 2;
        }
    }

    // Makes an attack against a target.
    public void PerformAttack(Character target, int disadvantage)
    {
        if (_mentalAttack == false)
        {
            _attack.SetDefense(target.GetPD());
        }
        else
        {
            _attack.SetDefense(target.GetMD());
        }
        int damage = _attack.Damage(disadvantage);
        target._currentHitPoints -= damage;
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

    // Save character to a file
    public void SaveCharacter()
    {
        string filename = Program.EnterString("What would you like to save the file as (do not include '.txt')? ") + ".txt";
        using (StreamWriter writer = new StreamWriter("characters\\" + filename))
        {
            writer.WriteLine(_name);
            writer.WriteLine(_level);
            foreach (Attribute attribute in _attributes)
            {
                writer.WriteLine($"{attribute.GetName()}:{attribute.GetModifier()}");
            }
            writer.WriteLine(_physicalDefense);
            writer.WriteLine(_mentalAttack);
            writer.WriteLine(_hostile);
            writer.WriteLine(_attack.Serialize());
        }
    }

    // Load character from a file
    public static Character LoadCharacter()
    {
        string filename = "";
        Boolean fileExists = false;
        while (!fileExists)
        {
            // Asks for filename to load
            filename = Program.EnterString("What is the name of the file to load (do not include '.txt')? ") + ".txt";

            // Determines if file exists
            if (File.Exists("characters\\" + filename))
            {
                fileExists = true;
            }
            else
            {
                Console.WriteLine("File does not exist! Please enter a valid file.");
            }
        }

        using (StreamReader reader = new StreamReader("characters\\" + filename))
        {
            string name = reader.ReadLine();
            int level = int.Parse(reader.ReadLine());
            List<Attribute> attributes = new List<Attribute>();
            for (int i = 0; i < 4; i++)
            {
                string[] parts = reader.ReadLine().Split(':');
                attributes.Add(new Attribute(parts[0], int.Parse(parts[1])));
            }
            int physicalDefense = int.Parse(reader.ReadLine());
            bool mentalAttack = bool.Parse(reader.ReadLine());
            bool hostile = bool.Parse(reader.ReadLine());
            Attack attack = Attack.Deserialize(reader.ReadLine());

            return new Character(name, level, attributes[0].GetModifier(), attributes[1].GetModifier(), attributes[2].GetModifier(), attributes[3].GetModifier(), physicalDefense, attack, mentalAttack, hostile);
        }
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