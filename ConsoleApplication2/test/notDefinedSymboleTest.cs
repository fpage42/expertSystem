using System;

namespace ExpertSystem
{
    public class notDefinedSymboleTest
    {
        /*
         * A => B
         * ?C
         */
        public static void Test()
        {
            Console.WriteLine("Expression: A => B");
            Console.WriteLine("Expression: ?C");
            Core core = initCore();
            
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.FALSE);
            
            core.setTrue("A");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.FALSE);
            
            core.setTrue("B");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.FALSE);
        }

        private static Core initCore() 
        {
            Core.resetCore();
            Core core = Core.getCore();
                        
            Symbole symA = new Symbole("A");
            Symbole symB = new Symbole("B");
            
            symB.addRelation(new RightNormal(symA));
            symA.addRelation(new RightNormal(symB));
            return core;
        }
    }
}