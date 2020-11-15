using System;

namespace ExpertSystem
{
    public class Test
    {
        public static bool seeSucces = true;
        public static int error = 0;
        public static void startTest()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("---------------------------------------------");
            leftNormalTest.Test();
            Console.WriteLine("---------------------------------------------");
            leftNormalTestInvertResult.Test();
            Console.WriteLine("---------------------------------------------");
            notDefinedSymboleTest.Test();

            // LOOP TEST
            
            Console.WriteLine("---------------------------------------------");
            simpleTestInfinityLoop.Test();
            Console.WriteLine("---------------------------------------------");
            testInfinityLoopThreeSymbole.Test();

            // AND TEST
            
            Console.WriteLine("---------------------------------------------");
            leftAndTest.simpleTestAnd.Test();
            Console.WriteLine("---------------------------------------------");
            leftAndTest.simpleInvertTestAnd.Test();
            Console.WriteLine("---------------------------------------------");
            leftAndTest.simpleResultInvertTestAnd.Test();
            Console.WriteLine("---------------------------------------------");
            leftAndTest.threeSymboleTestAnd.Test();
            Console.WriteLine("---------------------------------------------");
            leftAndTest.twoExpressionTestAnd.Test();
            Console.WriteLine("---------------------------------------------");
            leftAndTest.twoExpressionTestAnd2.Test();
            Console.WriteLine("---------------------------------------------");
            leftAndTest.undefinedSimpleTestAnd.Test();
            Console.WriteLine("---------------------------------------------");
            rightAndTest.simpleTestAnd.Test();
            Console.WriteLine("---------------------------------------------");
            
            // OR TEST
            
            leftOrTest.simpleTestOr.Test();
            Console.WriteLine("---------------------------------------------");
            leftOrTest.simpleTestOrInvertResult.Test();
            Console.WriteLine("---------------------------------------------");
            leftOrTest.simpleInvertTestOr.Test();
            Console.WriteLine("---------------------------------------------");
            
            // XOR TEST
            leftXorTest.SimpleXorTest.Test();
            rightXorTest.simpleRightXorTest.Test();
            
            // SECOND LEVEL TEST
            secondLevelTest.OrAndTwoSymboleTest.Test();
            Console.WriteLine("---------------------------------------------");
            secondLevelTest.LeftAndRightAndTest.Test();
            Console.WriteLine("---------------------------------------------");
            secondLevelTest.LeftOrRightOrTest.Test();
            Console.WriteLine("---------------------------------------------");

            // EVALUATION TESTS
            
            evaluationTest.ANDConditionAndConclusions.Test();
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("Le programme s'est terminé avec " + error + " erreurs");
            
        }
        
        public static void writeResult(Result res, Result wanted)
        {
            Console.WriteLine("Result: " + res);
            if (res.Equals(wanted))
                writeSuccess();
            else
            {
                Console.WriteLine("Wanted: " + wanted);

                writeError();
            }
        }

        private static void writeSuccess()
        {
            if (seeSucces)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success");
                Console.ForegroundColor = ConsoleColor.Black;                
            }
        }
        private static void writeError()
        {
            error++;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error");
            Console.ForegroundColor = ConsoleColor.Black;
        }

    }
}