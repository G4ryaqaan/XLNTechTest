/*using System;
using System.Collections;

namespace XLNTest;

class Program
{
    static void Main(string[] args)
    {
        CommandLine command = new CommandLine();
        command.Start();
    }
}*/

using System;
using System.Collections.Generic;

/// <summary>
/// this ...
/// </summary>
/// <returns>
/// This will return ...
/// </returns>
using System;
using System.Collections.Generic;

public class PostfixCalculator
{
    public bool PDetected { get; private set; } = false;

    public int EvaluatePostfix(string expression)
    {
        Stack<int> stack = new Stack<int>();
        string[] tokens = expression.Split(' ');

        foreach (string token in tokens)
        {
            if (token == "p")
            {
                PDetected = true;
                continue; 
            }

            if (IsPositiveInteger(token, out int number))
            {
                stack.Push(number);
            }
            else
            {
                ProcessOperator(stack, token);
            }
        }

        if (stack.Count != 1)
        {
            throw new InvalidOperationException("Invalid postfix expression.");
        }

        return stack.Pop();
    }

    private bool IsPositiveInteger(string token, out int number)
    {
        return int.TryParse(token, out number) && number > 0;
    }

    private void ProcessOperator(Stack<int> stack, string operatorToken)
    {
        if (stack.Count < 2)
        {
            throw new InvalidOperationException("Insufficient values in the expression for the operation.");
        }

        int b = stack.Pop();
        int a = stack.Pop();

        switch (operatorToken)
        {
            case "+":
                stack.Push(a + b);
                break;
            case "-":
                stack.Push(a - b);
                break;
            case "*":
                stack.Push(a * b);
                break;
            case "/":
                if (b == 0)
                    throw new DivideByZeroException("Cannot divide by zero.");
                stack.Push(a / b);
                break;
            default:
                throw new InvalidOperationException("Invalid operator.");
        }
    }
}


public class Program
{
    public static void Main()
    {
        PostfixCalculator calculator = new PostfixCalculator();
        string inputExpression = "10000 2 9 * + p";  // Modify or test with valid expressions only.
        try
        {
            double result = calculator.EvaluatePostfix(inputExpression);

            if (calculator.PDetected)
                Console.WriteLine("Result: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}



////"10 + 2 * 9";