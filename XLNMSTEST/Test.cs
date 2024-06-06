using XLNTest;

namespace XLNMSTEST;

[TestClass]
public class UnitTest
{
    // System Testing
    [TestMethod]
    public void TestMethod1()
    {
        ExpressionParser expression = new ExpressionParser();
        var parsedExpression = expression.TypeParser("10 2 9 * + p");

        Evaluator evaluator = new Evaluator();
        var answer = evaluator.EvaluatePostfix(parsedExpression);

        Assert.AreEqual(28, answer
            , "The program returns expected output");


    }

    //Unit Testing

    /// <summary>
    /// Test the expression parser is giving each token the correct expression
    /// </summary>

}
