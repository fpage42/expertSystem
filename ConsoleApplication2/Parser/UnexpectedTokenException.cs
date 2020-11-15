using System;

namespace ExpertSystem
{
    public class UnexpectedTokenException : Exception
    {
        public string tokenValue;
        
        public UnexpectedTokenException(string message) : base(message)
        {
            if (message == "" + (char) 13)
                this.tokenValue = "End of line";
            else if (message == "")
                this.tokenValue = "End of file";
            else
                this.tokenValue = "'" +  message + "'";
        }
    }
}