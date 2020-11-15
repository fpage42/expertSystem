using System;

namespace ExpertSystem.secondLevelTest
{
    public class LeftOrRightOrTest
    {
        public static void Test() // A | B => C | D
        {
            Console.WriteLine("Expression: A | B => C | D");
            Core core = initCore();
            
    //        Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C") + ", D=" + core.getValueOf("D"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("D"), Result.FALSE);
            
            core.setTrue("A");
      //      Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C") + ", D=" + core.getValueOf("D"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("D"), Result.TRUE);

            core.setTrue("B");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C") + ", D=" + core.getValueOf("D"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("D"), Result.TRUE);
         
            core.setTrue("C");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C") + ", D=" + core.getValueOf("D"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("D"), Result.UNDEFINED);

            core = initCore();
            
            core.setTrue("B");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C") + ", D=" + core.getValueOf("D"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("D"), Result.TRUE);
            
            core.setTrue("C");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C") + ", D=" + core.getValueOf("D"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("D"), Result.UNDEFINED);

            core = initCore();
            
            core.setTrue("C");
            Console.WriteLine("Test: A=" + core.getValueOf("A") + ", B=" + core.getValueOf("B") + ", C=" + core.getValueOf("C") + ", D=" + core.getValueOf("D"));
            global::ExpertSystem.Test.writeResult(core.getValueOf("D"), Result.UNDEFINED);

        }
        
        private static Core initCore() 
        {
            Core.resetCore();
            Core core = Core.getCore();
                        
            Symbole symA = new Symbole("A");
            Symbole symB = new Symbole("B");
            Symbole symC = new Symbole("C");
            Symbole symD = new Symbole("D");
            
            symD.addRelation(new RightOr(symC, new LeftOr(symA, symB)));
            symC.addRelation(new RightOr(symD, new LeftOr(symA, symB)));
            return core;
        }

    }
}