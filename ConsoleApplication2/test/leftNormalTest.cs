using System;

namespace ExpertSystem
{
    public class leftNormalTest
    {
        public static void Test() // A => B
        {
            Console.WriteLine("Expression: A => B");

            Core core = initCore();
            
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("B"), Result.FALSE);
            
            core.setTrue("A");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("B"), Result.TRUE);
        }
        
        private static Core initCore() 
        {
            Core.resetCore();
            Core core = Core.getCore();
                        
            Symbole symA = new Symbole("A");
            Symbole symB = new Symbole("B");
            
            symB.addRelation(new RightNormal(symA));
            return core;
        }

    }
}