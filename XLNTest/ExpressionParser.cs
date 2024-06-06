using System;
namespace XLNTest
{
	public class ExpressionParser
	{
        private readonly List<Token> tokens;

        public ExpressionParser()
		{
			tokens = new List<Token>();
		}

        private bool IsOperator(string _operator)
        {
            return _operator == "+" || _operator == "-" || _operator == "*" || _operator == "/";
        }


        public List<Token> TypeParser(string userInput)
		{
            string[] TokenizedInput = userInput.Split(' ');
            double isNumber;

			Console.WriteLine(userInput);

            foreach (string token in TokenizedInput)
            {
                if (double.TryParse(token, out isNumber))
                {
                    tokens.Add(new Token(TokenType.Operand, token));
                } else if (IsOperator(token))
                {
                    tokens.Add(new Token(TokenType.Operator, token));
                } else if (token.ToLower() == "p")
                {
                    tokens.Add(new Token(TokenType.Print, token));
                } else
                {
                    throw new ArgumentException($"Invalid Token");
                }
            }

            return tokens;
        }
	}
}

