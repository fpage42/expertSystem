using System;

namespace ExpertSystem
{
    public class testInfinityLoopThreeSymbole
    {
        /*
         * A => B
         * B => C
         * C => B
         * ?C
         */
        public static void Test()
        {
            Console.WriteLine("Expression: A => B");
            Console.WriteLine("Expression: B => C");
            Console.WriteLine("Expression: C => B");
            Console.WriteLine("Expression: ?C");
            Core core = initCore();
            
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.FALSE);
            
            core.setTrue("A");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.FALSE);
        
            core.setTrue("B");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.TRUE);
        }

        private static Core initCore() 
        {
            Core.resetCore();
            Core core = Core.getCore();
                        
            Symbole symA = new Symbole("A");
            Symbole symB = new Symbole("B");
            Symbole symC = new Symbole("C");
            
            symA.addRelation(new RightNormal(symB));
            symB.addRelation(new RightNormal(symC));
            symC.addRelation(new RightNormal(symB));
            return core;
        }
    }
}