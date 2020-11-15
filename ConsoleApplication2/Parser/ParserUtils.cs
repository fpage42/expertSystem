using System;

namespace ExpertSystem
{
    public class ParserUtils
    {
        public static Token skipEol(Lexer lexer, Token currentToken)
        {
            while (currentToken.tokenType == TokenType.Eol)
            {
                currentToken = lexer.nextToken();
            }

            return currentToken;
        }

        void parseRightSymbol()
        {
            
        }
        
        public static ProgramObject parseRightAnd(ProgramObject s1, ProgramObject s2, ProgramObject leftExpression)
        {
            var left = (Symbole) s1;
            var right = (Symbole) s2;

            left.addRelation(new RightAnd(right, leftExpression));
            right.addRelation(new RightAnd(left, leftExpression));
            return null;

        }
        
        public static ProgramObject parseRightOr(ProgramObject s1, ProgramObject s2, ProgramObject leftExpression)
        {
            var left = (Symbole) s1;
            var right = (Symbole) s2;

            left.addRelation(new RightOr(right, leftExpression));
            right.addRelation(new RightOr(left, leftExpression));
            return null;
        }
        
        public static ProgramObject parseRightXor(ProgramObject s1, ProgramObject s2, ProgramObject leftExpression)
        {
            var left = (Symbole) s1;
            var right = (Symbole) s2;

            left.addRelation(new RightXor(right, leftExpression));
            right.addRelation(new RightXor(left, leftExpression));
            return null;
        }
    }
}