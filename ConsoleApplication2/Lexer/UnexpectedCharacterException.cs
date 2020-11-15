using System;

namespace ExpertSystem
{
    public class UnexpectedCharacterException : Exception
    {
        public string characterValue;
        public UnexpectedCharacterException(string message) : base(message)
        {
            characterValue = message;
        }
    }
}