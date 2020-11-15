using System;

namespace ExpertSystem.leftAndTest
{
    public class twoExpressionTestAnd2
    {
        /*
         * C + B => D
         * A + B => C
         * ?D
         */
        
        public static void Test()
        {
            Console.WriteLine("Expression: C + B => D");
            Console.WriteLine("Expression: A + B => C");
            Core core = initCore();
            
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C") + " D=" + core.getValueOf("D"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("D"), Result.FALSE);
            
            core.setTrue("A");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C") + " D=" + core.getValueOf("D"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("D"), Result.FALSE);

            core.setTrue("B");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C") + " D=" + core.getValueOf("D"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("D"), Result.TRUE);
        }
        
        private static Core initCore()
        {
            Core.resetCore();
            Core core = Core.getCore();
                        
            Symbole symA = new Symbole("A");
            Symbole symB = new Symbole("B");
            Symbole symC = new Symbole("C");
            Symbole symD = new Symbole("D");
            
            symD.addRelation(new RightNormal(new LeftAnd(symC, symB)));
            symC.addRelation(new RightNormal(new LeftAnd(symA, symB)));            
            return core;
            
        }


    }
}