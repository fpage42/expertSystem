using System;
using System.IO;

namespace ExpertSystem
{
    public class ErrorLog
    {
        /*private string errorFileName = "errorLog.txt";
        private string errorFilePath = "./";*/
        
        public ErrorLog()
        {
            
        }

        public void printError(ErrorType type, Token token)
        {
            if (type == ErrorType.Lexer)
            {
                Console.WriteLine("Unexpected token : " + token.value + " at line "
                                  + token.nLine + ", col " + token.nCol);
            }
            else if (type == ErrorType.Parser)
            {
                Console.WriteLine("Syntax Error : " + token.value + " at line "
                                  + token.nLine + ", col " + token.nCol);
            }
            else
            {
                Console.WriteLine("Error");
            }
            /*using (StreamWriter w = File.AppendText(errorFilePath+ "\\" + errorFileName))
            {
                w.WriteLine("Error of "+ type + " at " + value);
            }*/
        }
    }
}