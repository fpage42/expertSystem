using System;

namespace ExpertSystem.evaluationTest
{
    public class ANDConditionAndConclusions
    {   
        public static void Test() // A ^ B => C
        {
            Console.WriteLine("https://github.com/Binary-Hackers/42_Corrections/blob/master/00_Projects/02_Algorithmic/expert_system/01.png");
            Core core = initCore();
               
            core.setTrue("D");
            core.setTrue("E");
            core.setTrue("I");
            core.setTrue("J");
            core.setTrue("O");
            core.setTrue("P");
            
            Console.WriteLine("Test A");           
            global::ExpertSystem.Test.writeResult(core.getValueOf("A"), Result.TRUE);
            Console.WriteLine("Test F");           
            global::ExpertSystem.Test.writeResult(core.getValueOf("F"), Result.TRUE);
            Console.WriteLine("Test K");           
            global::ExpertSystem.Test.writeResult(core.getValueOf("K"), Result.TRUE);
            Console.WriteLine("Test P");           
            global::ExpertSystem.Test.writeResult(core.getValueOf("P"), Result.TRUE);
            
            Console.WriteLine("CORE RESET");
            
            core = initCore();
            core.setTrue("D");
            core.setTrue("E");
            core.setTrue("I");
            core.setTrue("J");
            core.setTrue("P");
            
            Console.WriteLine("Test A");           
            global::ExpertSystem.Test.writeResult(core.getValueOf("A"), Result.TRUE);
            Console.WriteLine("Test F");           
            global::ExpertSystem.Test.writeResult(core.getValueOf("F"), Result.TRUE);
            Console.WriteLine("Test K");           
            global::ExpertSystem.Test.writeResult(core.getValueOf("K"), Result.FALSE);
            Console.WriteLine("Test P");           
            global::ExpertSystem.Test.writeResult(core.getValueOf("P"), Result.TRUE);

        }

        
        private static Core initCore() 
        {
            Core.resetCore();
            Core core = Core.getCore();
                        
            Symbole symA = new Symbole("A");
            Symbole symB = new Symbole("B");
            Symbole symD = new Symbole("D");
            Symbole symE = new Symbole("E");
            Symbole symG = new Symbole("G");
            Symbole symH = new Symbole("H");
            Symbole symF = new Symbole("F");
            Symbole symI = new Symbole("I");
            Symbole symJ = new Symbole("J");
            Symbole symL = new Symbole("L");
            Symbole symM = new Symbole("M");
            Symbole symK = new Symbole("K");
            Symbole symO = new Symbole("O");
            Symbole symP = new Symbole("P");
            Symbole symN = new Symbole("N");

            symA.addRelation(new RightNormal(symB));
            symB.addRelation(new RightNormal(new LeftAnd(symD, symE)));
            symF.addRelation(new RightNormal(new LeftAnd(symG, symH)));
            symG.addRelation(new RightNormal(new LeftAnd(symI, symJ)));
            symH.addRelation(new RightNormal(symG));
            symK.addRelation(new RightNormal(new LeftAnd(symL, symM)));
            symL.addRelation(new RightAnd(symN, new LeftAnd(symO, symP)));
            symN.addRelation(new RightAnd(symL, new LeftAnd(symO, symP)));
            symM.addRelation(new RightNormal(symN));
            return core;
        }

    }
}