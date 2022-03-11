namespace Echo
{

  /// <summary>
  /// Defines the type of each token in our lexical analysis,
  /// Enum is a bye type (a single unsigned int)
  /// default value is INVALID
  /// </summary>
  enum TokenType : byte
  {
    // control
    INVALID = 0,
    EOF,

    // literals
    Identifier,
    Int,

    // operators
    Assign,
    Plus,
    Minus,

    // delimiters
    Comma,
    Semicolon,

    LParen,
    RParen,
    LBrace,
    RBrace,

    // keywords
    Function,
    Let
  }

  public class Token
  {
    public TokenType Type { get; }
    public string Literal { get; }
  }

}
