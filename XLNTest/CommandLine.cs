using System;
namespace XLNTest
{
	public class CommandLine
	{
		public CommandLine()
		{
		}

        public void Start()
        {
            Console.Write("Please enter your expression in postfix: ");
            string userInput = "10 2 9 * + p"; //"10 + 2 * 9"; //"10 2 9 * + p"; //Console.ReadLine();

            ExpressionParser expression = new ExpressionParser();
            var parsedExpression = expression.TypeParser(userInput);

            Evaluator evaluator = new Evaluator();
            var answer = evaluator.EvaluatePostfix(parsedExpression);

            PrintAnswer(userInput, answer);
        }

        private void PrintAnswer(string userInput, double answer)
        {
            Console.WriteLine("User input: " + userInput + "\t Output: " + answer);
        }
    }
}

