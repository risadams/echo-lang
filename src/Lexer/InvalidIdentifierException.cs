using System.Runtime.Serialization;

namespace Echo
{
  /// <summary>
  ///   Class InvalidIdentifierException.
  ///   Implements the <see cref="System.Exception" />
  /// </summary>
  /// <seealso cref="System.Exception" />
  [Serializable]
  public class InvalidIdentifierException : Exception
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="InvalidIdentifierException" /> class.
    /// </summary>
    public InvalidIdentifierException() { }

    /// <summary>
    ///   Initializes a new instance of the <see cref="InvalidIdentifierException" /> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InvalidIdentifierException(string message) : base(message) { }

    /// <summary>
    ///   Initializes a new instance of the <see cref="InvalidIdentifierException" /> class.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="inner">The inner.</param>
    public InvalidIdentifierException(string message, Exception inner) : base(message, inner) { }

    /// <summary>
    ///   Initializes a new instance of the <see cref="InvalidIdentifierException" /> class.
    /// </summary>
    /// <param name="info">
    ///   The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
    ///   data about the exception being thrown.
    /// </param>
    /// <param name="context">
    ///   The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
    ///   information about the source or destination.
    /// </param>
    protected InvalidIdentifierException(
      SerializationInfo info,
      StreamingContext context) : base(info, context) { }
  }
}
