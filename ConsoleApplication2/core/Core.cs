using System;
using System.Collections.Generic;

namespace ExpertSystem
{
    public class Core
    {
        private static Core c;

        public static Core getCore()
        {
            if (c != null)
                return c;
            return (c = new Core());
        }

        public static void resetCore()
        {
            c = null;
        }
        
        private readonly Dictionary<string, Symbole> symboles = new Dictionary<string, Symbole>();

        public void addSymbole(string value, Symbole s)
        {
            this.symboles[value] = s;
        }

        public Symbole getSymbole(string value)
        {
           return this.symboles.ContainsKey(value) ? this.symboles[value]:null;
        }

        public void setTrue(string value)
        {
            if (this.symboles.ContainsKey(value))
                this.symboles[value].setTrue();
        }

        public Result getValueOf(string value)
        {
            Symbole s = null;

            try
            {
                s = this.symboles[value];
            }
            catch (Exception e)
            {}
            if (s != null)
                try
                {
                    return this.symboles[value].checkValue(new Contexte())?Result.TRUE:Result.FALSE;
                }
                catch (UndefinedValueException)
                {
                    return Result.UNDEFINED;
                }
            else
            {
                Console.WriteLine("Impossible de trouver le symbole " + value);
                return Result.FALSE;
            }
        }
    }
}