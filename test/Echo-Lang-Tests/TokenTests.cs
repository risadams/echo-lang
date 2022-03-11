using Echo;
using Xunit;

namespace Echo_Lang_Tests
{
  public class TokenTests
  {
    [Theory]
    [InlineData("=", TokenType.Assign)]
    [InlineData("+", TokenType.Plus)]
    [InlineData("-", TokenType.Minus)]
    [InlineData(",", TokenType.Comma)]
    [InlineData(";", TokenType.Semicolon)]
    [InlineData("(", TokenType.LParen)]
    [InlineData(")", TokenType.RParen)]
    [InlineData("{", TokenType.LBrace)]
    [InlineData("}", TokenType.RBrace)]
    public void TestNextToken(string literal, TokenType type)
    {
      var l   = new Lexer(literal);
      var tok = l.NextToken();

      Assert.Equal(type, tok.Type);
      Assert.Equal(literal, tok.Literal);
    }
  }
}
