public class Prompt
{
    // Creates list of prompts
    static public List<string> _prompts = new List<string>{
        "What are three things that made you smile today, and why?",
        "Describe a challenge you faced recently and how you overcame it.",
        "Write about a person who has had a significant impact on your life, and why they are important to you.",
        "If you could travel anywhere in the world right now, where would you go and why?",
        "What are three things you are grateful for in your life, and why?",
        "Reflect on a recent mistake you made and what you learned from it.",
        "Write about a goal you have for the next month, and outline steps you can take to achieve it.",
        "Describe your ideal day from start to finish.",
        "What is something you've been procrastinating on, and how can you take steps to tackle it?",
        "Write a letter to your future self, expressing your hopes and aspirations.",
        "Reflect on a recent moment of kindness you witnessed or experienced, and how it made you feel.",
        "Describe a hobby or activity that brings you joy, and why you enjoy it.",
        "Write about a book, movie, or piece of art that has inspired you recently, and why it resonated with you.",
        "What are three qualities you admire in yourself, and why?",
        "Reflect on a time when you felt proud of an accomplishment, big or small.",
        "Describe a place from your past that holds special memories for you, and why it is significant.",
        "Write about a fear you have and explore where it comes from and how you can work to overcome it.",
        "Reflect on a difficult decision you had to make recently and how you concluded.",
        "What is something new you would like to learn, and why does it interest you?",
        "Write about a dream or aspiration you have for your future, and what steps you can take to move closer to it."
    };

    // Determines if 
    public static string Generate()
    {
        Console.WriteLine("1. Random\n2. Select");
        Console.Write("How should the prompt be determined? ");
        string optionStr = Console.ReadLine();
        int option = 0;
        string prompt = "";

        // Detect if it isn't an integer and will display error
        do
        {
            if (!int.TryParse(optionStr, out option))
            {
                Console.WriteLine("Invalid input! Please enter an integer.");
                continue;
            }
            option = int.Parse(optionStr);
            if (option == 1)
            {
                prompt = Prompt.Random();
            }
            else if (option == 2)
            {
                // Display all prompts
                for (int i = 0; i < Prompt._prompts.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {_prompts[i]}");
                }
                // Get user input for prompt selection
                int promptIndex;
                do
                {
                    Console.Write("Which option would you like? ");
                    string promptIndexStr = Console.ReadLine();

                    // Detect if it isn't an integer and will display error
                    if (!int.TryParse(promptIndexStr, out promptIndex))
                    {
                        Console.WriteLine("Invalid input! Please enter an integer.");
                        continue;
                    }

                    // Check if prompt is range of list
                    if (promptIndex < 1 || promptIndex > Prompt._prompts.Count)
                    {
                        Console.WriteLine("Invalid input! Please enter a valid prompt index.");
                    }
                    else
                    {
                        break;
                    }
                } while (true);
                prompt = Prompt._prompts[promptIndex - 1];
            }
            else
            {
                Console.WriteLine("Invalid input! Please enter valid option.");
            }
        } while ((option != 1) && (option != 2));
        return prompt;
    }
    
    // Randomly generates a prompt
    public static string Random()
    {
        Random random = new Random();
        int randomIndex = random.Next(0,_prompts.Count);
        return Prompt.Select(randomIndex);
    }

    // Returns a prompt based on index
    public static string Select(int index)
    {
        List<string> _prompts = Prompt._prompts;
        return _prompts[index];
    }
}