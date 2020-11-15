using System;

namespace ExpertSystem
{
    class ExpertSystem
    {
        static void Main(string[] args)
        {
            Test.startTest();
            Core.resetCore();
            if (args.Length != 1)
            {
                Console.WriteLine("Veuillez entrer un fichier en paramètre.");
                return ;
            }

            try
            {
                new Parser(args[0]);
            }
            catch (UnexpectedTokenException e)
            {
                Console.WriteLine(e.tokenValue + " token was not expected.");
            }
            catch (UnexpectedCharacterException e)
            {
                Console.WriteLine(e.characterValue);
            }
        }
    }
}
