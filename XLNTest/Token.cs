using System;
namespace XLNTest
{
    /// <summary>
    /// This class is the priamry data structure of this class. as it stores and ecapsulates,
    /// the properties of each token.
    /// </summary>
    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Token(TokenType type, string value, bool isVariable = false)
        {
            Type = type;
            Value = value;
        }
    }
}

