namespace Echo
{
  /// <summary>
  ///   Defines the type of each token in our lexical analysis,
  ///   Enum is a bye type (a single unsigned int)
  ///   default value is INVALID
  /// </summary>
  public enum TokenType
  {
    // control
    Invalid = 0,
    EndOfFile,

    // literals
    Identifier,
    Number,

    // operators
    Assign,
    Plus,
    Minus,

    // delimiters
    Comma,
    Semicolon,

    LeftParen,
    RightParen,
    LeftBrace,
    RightBrace,

    // keywords
    Function,
    Let
  }
}
