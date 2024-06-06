using System;
namespace XLNTest
{
	public class Evaluator
	{
		public Evaluator()
		{
		}

        private double EvaluateType(string operation, double operand1, double operand2)
        {
            switch (operation)
            {
                case "+":
                    return (operand1 + operand2);
                case "-":
                    return (operand1 - operand2);
                case "*":
                    return (operand1 * operand2);
                case "/":
                    if (operand2 == 0)
                        throw new DivideByZeroException("Cannot divide by zero.");
                    return (operand1 / operand2);
                default:
                    throw new ArgumentException($"Invalid operator: {operation}");
            }

        }

        public double EvaluatePostfix(List<Token> postfix)
        {
            Stack<double> operandStack = new Stack<double>();

            foreach (var token in postfix)
            {
                if (double.TryParse(token.Value, out double operand))
                    operandStack.Push(operand);

                if (token.Type == TokenType.Operator)
                {
                    if (operandStack.Count < 2)
                        throw new InvalidOperationException("Not enough operands for the operator.");

                    var operand2 = operandStack.Pop();
                    var operand1 = operandStack.Pop();

                    if (operand1 < 0 || operand2 < 0)
                        throw new InvalidOperationException("one or more of the operand's are negative");

                    double result = EvaluateType(token.Value.ToString(), operand1, operand2);
                    operandStack.Push(result);
                }
            }

            return operandStack.Pop();
        }
    }
}

