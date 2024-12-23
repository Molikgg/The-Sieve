//..yey..
CheckNumber numberChecker = new CheckNumber(new HumanPlayer());
numberChecker.CheckGivenNumber();
class ChoosingSieveLogic
{
    private bool IsEven(int num) => num % 2 == 0; 
    private bool IsPositive(int num) => num > 0;
    private bool IsMultipleOf10(int num) => num % 10 == 0;

    public Sieve ChoosingSieve() 
    {
        Console.WriteLine("""
        Hello Player Please Choose Seive
        1. Even
        2. Positive
        3. Multiple of 10
        """);
        return int.Parse(Console.ReadLine()!) switch
        {
            1 => new (IsEven),
            2 => new Sieve(IsPositive),
            3 => new Sieve(IsMultipleOf10),
        };
    }
}

class CheckNumber
{
    IPlayer Player; // its work is to check number dosent matter who supplied 
    public CheckNumber(IPlayer player) { Player = player; }
    public void CheckGivenNumber()
    {
        Sieve seive = new ChoosingSieveLogic().ChoosingSieve(); // supplied required method(logic) to work on 

        while (true)
        {
            Console.Write("Enter Num: ");
            if (seive.IsGood(Player.GetNewNumber())) // supplied required parameter
            {
                Console.Write("Good");
            }
            else
            {
                Console.Write("Bad");
            }
            Console.WriteLine();
        }

    }
}

class HumanPlayer : IPlayer
{
    public int GetNewNumber()
    {
        return int.Parse(Console.ReadLine()!);
    }
}
class Sieve 
{
    // The Seive class stores a method (with the required signature) using the constructor
    // and calls it (with supplied parameter) when the IsGood method is invoked.

    Predicate<int> IsSatisfy; 
    public Sieve(Predicate<int> isSatisfy)
    {
        IsSatisfy = isSatisfy;
    }
    public bool IsGood(int number)
    {
        return IsSatisfy(number);  
    }
}
interface IPlayer
{
    int GetNewNumber();
}
