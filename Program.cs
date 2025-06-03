using System;
using System.Collections.Generic;

public class ParenthesesValidator
{
    
    public static bool ValidateParentheses(string input)
    {
        Stack<char> stack = new Stack<char>();
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>()
        {
            {'(', ')'},
            {'[', ']'},
            {'{', '}'}
        };

        foreach (char c in input)
        {
            // If character is an opening bracket, push to stack
            if (bracketPairs.ContainsKey(c))
            {
                stack.Push(c);
            }
            // If character is a closing bracket
            else if (bracketPairs.ContainsValue(c))
            {
                // Check if stack is empty or if the closing bracket matches
                if (stack.Count == 0 || bracketPairs[stack.Pop()] != c)
                {
                    return false;
                }
            }
        }

        // If stack is empty, all brackets were properly closed
        return stack.Count == 0;
    }

    public static void Main(string[] args)
    {
        // Test cases
        Console.WriteLine(ValidateParentheses("()"));      // True
        Console.WriteLine(ValidateParentheses("()[]{}"));  // True
        Console.WriteLine(ValidateParentheses("(]"));     // False
        Console.WriteLine(ValidateParentheses("([{}])"));  // True
        Console.WriteLine(ValidateParentheses("([)]"));    // False
        Console.WriteLine(ValidateParentheses("{"));       // False
        Console.WriteLine(ValidateParentheses(""));       // True
    }
}
