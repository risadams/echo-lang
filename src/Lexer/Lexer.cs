namespace Echo
{
  public class Lexer
  {
    private readonly Dictionary<string, TokenType> _identifierLookup = new()
    {
      {"LET", TokenType.Let},
      {"FUNCTION", TokenType.Function},
      {"FN", TokenType.Function}
    };

    private readonly string _input;
    private bool _break;

    private string _current = "";
    private int _position;
    private int _readPosition;

    /// <summary>
    ///   Initializes a new instance of the <see cref="Lexer" /> class.
    /// </summary>
    /// <param name="input">The input text to parse.</param>
    public Lexer(string? input)
    {
      _input = input ?? "";
      ReadChar();
    }

    /// <summary>
    ///   Reads the next character from the input string and advances the position pointers.
    /// </summary>
    public void ReadChar()
    {
      if (_readPosition >= _input.Length)
        _break = true;
      else
        _current = _input[_readPosition].ToString();

      _position     =  _readPosition;
      _readPosition += 1;
    }

    /// <summary>
    ///   Returns the the next available token.
    /// </summary>
    /// <returns>Token.</returns>
    public Token NextToken()
    {
      Token token;

      SkipWhitespace();

      switch (_current)
      {
        case "=":
          token = new Token(TokenType.Assign, _current);
          break;
        case "+":
          token = new Token(TokenType.Plus, _current);
          break;
        case "-":
          token = new Token(TokenType.Minus, _current);
          break;
        case ",":
          token = new Token(TokenType.Comma, _current);
          break;
        case ";":
          token = new Token(TokenType.Semicolon, _current);
          break;
        case "(":
          token = new Token(TokenType.LeftParen, _current);
          break;
        case ")":
          token = new Token(TokenType.RightParen, _current);
          break;
        case "}":
          token = new Token(TokenType.RightBrace, _current);
          break;
        case "{":
          token = new Token(TokenType.LeftBrace, _current);
          break;
        case "":
          token = new Token(TokenType.EndOfFile, _current);
          break;
        default:
          if (_break)
          {
            token = new Token(TokenType.EndOfFile, _current);
            break;
          }

          if (IsValidIdentifierChar(_current))
          {
            var literal = ReadIdentifier();
            var tokType = LookupIdentity(literal);
            token = new Token(tokType, literal);
          }
          else if (IsDigit(_current))
          {
            var literal = ReadNumber();
            token = new Token(TokenType.Number, literal);
          }
          else
          {
            token = new Token(TokenType.Invalid, _current);
          }

          break;
      }

      ReadChar();
      return token;
    }

    /// <summary>
    ///   Skips whitespace between tokens.
    /// </summary>
    private void SkipWhitespace()
    {
      while (!_break && IsWhitespace(_current)) ReadChar();
    }

    /// <summary>
    ///   Determines whether the specified current is whitespace.
    /// </summary>
    /// <param name="currentChar">The current character.</param>
    /// <returns><c>true</c> if the specified current is whitespace; otherwise, <c>false</c>.</returns>
    private static bool IsWhitespace(string currentChar) => string.IsNullOrWhiteSpace(currentChar);

    /// <summary>
    ///   Determines whether the specified current character is a valid identifier character (Letters, -, or _).
    /// </summary>
    /// <param name="currentChar">The current character.</param>
    /// <returns><c>true</c> if this is a valid identifier character; otherwise, <c>false</c>.</returns>
    private static bool IsValidIdentifierChar(string currentChar) => !IsWhitespace(currentChar) && char.IsLetter(currentChar[0]) || currentChar is "-" or "_";

    /// <summary>
    ///   Determines whether the specified current character is digit.
    /// </summary>
    /// <param name="currentChar">The current character.</param>
    /// <returns><c>true</c> if the specified current character is digit; otherwise, <c>false</c>.</returns>
    private static bool IsDigit(string currentChar) => !IsWhitespace(currentChar) && char.IsNumber(currentChar[0]);


    /// <summary>
    ///   Reads the next identifier literal for the current token.
    /// </summary>
    /// <returns>System.String.</returns>
    private string ReadIdentifier()
    {
      var starPosition = _position; //get current start position

      //look ahead to next non-valid identifier
      do
        ReadChar();
      while (!_break && IsValidIdentifierChar(_current));

      // return the string range between the start and current read position
      return _input[starPosition.._position];
    }

    /// <summary>
    ///   Reads the number literal for the current token.
    /// </summary>
    /// <returns>System.String.</returns>
    private string ReadNumber()
    {
      var starPosition = _position; //get current start position

      //look ahead to next non-valid identifier
      do
        ReadChar();
      while (!_break && IsDigit(_current));

      // return the string range between the start and current read position
      return _input[starPosition.._position];
    }

    /// <summary>
    ///   Maps the identifier literal to a token type.
    /// </summary>
    /// <param name="literal">The literal.</param>
    /// <returns>TokenType.</returns>
    /// <exception cref="Echo.InvalidIdentifierException">Invalid Identifier Type: "+literal</exception>
    private TokenType LookupIdentity(string literal)
    {
      var key = literal.ToUpperInvariant();
      return _identifierLookup.ContainsKey(key) ? _identifierLookup[key] : TokenType.Identifier;
      //throw new InvalidIdentifierException("Invalid Identifier Type: " + literal);
    }
  }
}
