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
    [InlineData("(", TokenType.LeftParen)]
    [InlineData(")", TokenType.RightParen)]
    [InlineData("{", TokenType.LeftBrace)]
    [InlineData("}", TokenType.RightBrace)]
    [InlineData("let", TokenType.Let)]
    [InlineData("5", TokenType.Number)]
    [InlineData("ten", TokenType.Identifier)]
    [InlineData("add", TokenType.Identifier)]
    [InlineData("fn", TokenType.Function)]
    [InlineData("function", TokenType.Function)]
    [InlineData("x", TokenType.Identifier)]
    [InlineData("", TokenType.EndOfFile)]
    public void TestNextToken(string literal, TokenType type)
    {
      var l   = new Lexer(literal);
      var tok = l.NextToken();

      Assert.Equal(type, tok.Type);
      Assert.Equal(literal, tok.Literal);
    }

    [Fact]
    public void TestTokenLexing()
    {
      const string input = @"let five = 5;
  let add = fn(x, y) {
    x + y;
  };";

      var l   = new Lexer(input);

      var tok = l.NextToken();
      Assert.Equal(TokenType.Let, tok.Type);
      Assert.Equal("let", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Identifier, tok.Type);
      Assert.Equal("five", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Assign, tok.Type);
      Assert.Equal("=", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Number, tok.Type);
      Assert.Equal("5", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Let, tok.Type);
      Assert.Equal("let", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Identifier, tok.Type);
      Assert.Equal("add", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Assign, tok.Type);
      Assert.Equal("=", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Function, tok.Type);
      Assert.Equal("fn", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.LeftParen, tok.Type);
      Assert.Equal("(", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Identifier, tok.Type);
      Assert.Equal("x", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Comma, tok.Type);
      Assert.Equal(",", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Identifier, tok.Type);
      Assert.Equal("y", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.RightParen, tok.Type);
      Assert.Equal(")", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.LeftBrace, tok.Type);
      Assert.Equal("{", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Identifier, tok.Type);
      Assert.Equal("x", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Plus, tok.Type);
      Assert.Equal("+", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.Identifier, tok.Type);
      Assert.Equal("y", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.RightBrace, tok.Type);
      Assert.Equal("}", tok.Literal);

      tok = l.NextToken();
      Assert.Equal(TokenType.EndOfFile, tok.Type);
      Assert.Equal("", tok.Literal);
    }
  }
}
