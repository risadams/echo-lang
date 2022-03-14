using System.Diagnostics;

namespace Echo
{
  [DebuggerDisplay("{Type,nq} => {Literal}")]
  public readonly struct Token : IEquatable<Token>
  {
    public Token(TokenType type, string literal)
    {
      Type    = type;
      Literal = literal;
    }

    public TokenType Type { get; }
    public string Literal { get; }

    public override bool Equals(object? obj) => base.Equals(obj);
    public bool Equals(Token other) => Type == other.Type && Literal == other.Literal;
    public override int GetHashCode() => HashCode.Combine((int) Type, Literal);
    public static bool operator ==(Token left, Token right) => left.Equals(right);
    public static bool operator !=(Token left, Token right) => !(left == right);
  }
}
