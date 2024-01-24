using System.Text.RegularExpressions;

bool CheckCodeBrackets(string code)
{
    Stack<char> stack = new Stack<char>();
    Dictionary<char, char> brackets = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

    foreach (char ch in code)
    {
        if (brackets.ContainsKey(ch))
        {
            stack.Push(ch);
        }
        else if (brackets.ContainsValue(ch))
        {
            if (stack.Count == 0 || brackets[stack.Pop()] != ch)
            {
                return false;
            }
        }
    }

    return stack.Count == 0;
}

void CheckChars(string input)
{
    char[] textArray = input.ToCharArray();
    string Rupattern = @"\p{IsCyrillic}";
    string Enpattern = "^[a-zA-Z0-9. -_?]*$";

    int RULowerCase = 0;
    int ENLowerCase = 0;
    int RUUpperCase = 0;
    int ENUpperCase = 0;
    int Digits = 0;
    int WhiteSpace = 0;
    int Punctuation = 0;

    for (int i = 0; i < textArray.Length; i++)
    {
        if (Regex.IsMatch(textArray[i].ToString(), Rupattern))
        {
            if (char.IsLower(textArray[i]))
                RULowerCase++;
            if (char.IsUpper(textArray[i]))
                RUUpperCase++;
        }
        else if (Regex.IsMatch(textArray[i].ToString(), Enpattern))
        {
            if (char.IsLower(textArray[i]))
                ENLowerCase++;
            if (char.IsUpper(textArray[i]))
                ENUpperCase++;
        }
        if (char.IsDigit(textArray[i]))
            Digits++;
        if (char.IsWhiteSpace(textArray[i]))
            WhiteSpace++;
        if (char.IsPunctuation(textArray[i]))
            Punctuation++;

    }
    Console.WriteLine($"EnUpperCase:{ENUpperCase} EnLowerCase:{ENLowerCase} RuUpperCase:{RUUpperCase} RuLowerCase:{RULowerCase} Digits:{Digits} WhiteSpace:{WhiteSpace} Punctuation:{Punctuation}");
}


//string correctCode = "({)}";
//string incorrectCode = "[()}, if ((a > 0) || (b < 3) { ++a; }";

string input = Console.ReadLine();
CheckChars(input);

//Console.WriteLine(CheckCodeBrackets(correctCode));
//Console.WriteLine(CheckCodeBrackets(incorrectCode));

