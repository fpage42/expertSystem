using System;

namespace ExpertSystem.rightAndTest
{
    public class simpleTestAnd
    {

        public static void Test() // A => B + C
        {
            Console.WriteLine("Expression: A => B + C");
            Core core = initCore();
            
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + " C=" +
                              core.getValueOf("C"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.FALSE);
            
            core.setTrue("A");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + " C=" +
                              core.getValueOf("C"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.TRUE);

            core.setTrue("B");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + " C=" +
                              core.getValueOf("C"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.TRUE);

            core = initCore();
            
            core.setTrue("B");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + " C=" +
                              core.getValueOf("C"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.FALSE);
        }
        
        private static Core initCore()
        {
            Core.resetCore();
            Core core = Core.getCore();
                        
            Symbole symA = new Symbole("A");
            Symbole symB = new Symbole("B");
            Symbole symC = new Symbole("C");
            
            symC.addRelation(new RightAnd(symB, symA));
            symB.addRelation(new RightAnd(symC, symA));

            return core;
        }

    }
}