namespace Echo
{
  public class Lexer
  {
    private readonly string _input;
    private char _currentChar;
    private int _position;
    private int _readPosition;

    /// <summary>
    ///   Initializes a new instance of the <see cref="Lexer" /> class.
    /// </summary>
    /// <param name="input">The input text to parse.</param>
    public Lexer(string input)
    {
      _input = input;
      ReadChar();
    }

    /// <summary>
    ///   Reads the next character from the input string and advances the position pointers.
    /// </summary>
    public void ReadChar()
    {
      _currentChar = _readPosition >= _input.Length ? _input[0] : _input[_readPosition];

      _position     =  _readPosition;
      _readPosition += 1;
    }

    /// <summary>
    ///   Returns the the next available token.
    /// </summary>
    /// <returns>Token.</returns>
    public Token NextToken()
    {
      var token = _currentChar switch
      {
        '=' => new Token(TokenType.Assign, _currentChar.ToString()),
        '+' => new Token(TokenType.Plus, _currentChar.ToString()),
        '-' => new Token(TokenType.Minus, _currentChar.ToString()),
        ',' => new Token(TokenType.Comma, _currentChar.ToString()),
        ';' => new Token(TokenType.Semicolon, _currentChar.ToString()),
        '(' => new Token(TokenType.LParen, _currentChar.ToString()),
        ')' => new Token(TokenType.RParen, _currentChar.ToString()),
        '}' => new Token(TokenType.RBrace, _currentChar.ToString()),
        '{' => new Token(TokenType.LBrace, _currentChar.ToString()),
        _   => new Token(TokenType.INVALID, "")
      };

      ReadChar();
      return token;
    }
  }
}
