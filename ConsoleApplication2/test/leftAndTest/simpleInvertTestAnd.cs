using System;

namespace ExpertSystem.leftAndTest
{
    public class simpleInvertTestAnd
    {
        public static void Test() //A + !B => C 
        {
            Console.WriteLine("Expression: A + !B => C");
            Core core = Core.getCore();
                        
            Symbole symA = new Symbole("A");
            Symbole symB = new Symbole("B");
            Symbole symC = new Symbole("C");
            
            symC.addRelation(new RightNormal(new LeftAnd(symA, new LeftInvert(symB))));

            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + " Res=" + core.getValueOf("C"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.FALSE);

            core.setTrue("A");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + " Res=" + core.getValueOf("C"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.TRUE);

            core.setTrue("B");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + " Res=" + core.getValueOf("C"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("C"), Result.FALSE);

            Core.resetCore();
        }

    }
}