using System;

namespace ExpertSystem
{
    public class simpleTestInfinityLoop
    {
        /*
         * A => B
         * B => A
         * ?B
         */
        public static void Test()
        {
            Console.WriteLine("Expression: A => B");
            Console.WriteLine("Expression: B => A");
            Console.WriteLine("Expression: ?B");
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
            symA.addRelation(new RightNormal(symB));
            return core;
        }
    }
}