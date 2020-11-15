using System;
using System.Linq.Expressions;

namespace ExpertSystem
{
    public class Parser
    {
        private Lexer lexer;
        private ErrorLog error;
        private Token currentToken;
        private Core core;

        public Parser(string filePath)
        {
            this.lexer = new Lexer(filePath);
            core = Core.getCore();
            currentToken = lexer.nextToken();
            
            /* Parse les règles*/
            parseRules();
            currentToken = ParserUtils.skipEol(lexer, currentToken);
            /*Parse les faits initiaux*/
            parseInitialFacts();
            currentToken = ParserUtils.skipEol(lexer, currentToken);
            /*Parse la requête*/
            parseQuery();
            currentToken = ParserUtils.skipEol(lexer, currentToken);
            if (currentToken.tokenType != TokenType.Eof)
                throw new UnexpectedTokenException(currentToken.value);
        }

        private void parseQuery()
        {
            if (currentToken.tokenType == TokenType.Query)
            {
                currentToken = lexer.nextToken();
                while (currentToken.tokenType != TokenType.Eol && currentToken.tokenType != TokenType.Eof)
                {
                    if (currentToken.tokenType == TokenType.Symbol)
                    {
                        if (core.getValueOf(currentToken.value) == Result.TRUE)
                            Console.WriteLine(currentToken.value + " is true");
                        else if (core.getValueOf(currentToken.value) == Result.FALSE)
                            Console.WriteLine(currentToken.value + " is false");
                        else
                            Console.WriteLine(currentToken.value + " is undefined");
                        currentToken = lexer.nextToken();
                    }
                    else
                        throw new UnexpectedTokenException(currentToken.value);
                }
            }
            else
                throw new UnexpectedTokenException(currentToken.value);
        }

        private void parseInitialFacts()
        {
            if (currentToken.tokenType == TokenType.Facts)
            {
                currentToken = lexer.nextToken();
                while (currentToken.tokenType != TokenType.Eol && currentToken.tokenType != TokenType.Eof)
                {
                    if (currentToken.tokenType == TokenType.Symbol)
                    {
                        core.setTrue(currentToken.value);
                        currentToken = lexer.nextToken();
                    }
                    else
                        throw new UnexpectedTokenException(currentToken.value);
                }
            }
            else
                throw new UnexpectedTokenException(currentToken.value);

        }

        private void parseRules()
        {
            while (currentToken.tokenType != TokenType.Facts && currentToken.tokenType != TokenType.Eof)
            {
                currentToken = ParserUtils.skipEol(lexer, currentToken);
                parseRule();
                if (currentToken.tokenType == TokenType.Eol)
                    currentToken = ParserUtils.skipEol(lexer, currentToken);
                else
                    throw new UnexpectedTokenException(currentToken.value);
            }
        }
        
        private void parseRule()
        {
            ProgramObject left;
            
            left = this.parseLowerOrderExpression();
            if (currentToken.tokenType == TokenType.Then)
            {
                currentToken = lexer.nextToken();
                this.parseRightExpression(left);
            }
            else
                throw new UnexpectedTokenException(currentToken.value);
        }

        private void parseRightExpression(ProgramObject leftExpression)
        {
            bool not = false;

            if (currentToken.tokenType == TokenType.Not)
            {
                not = true;
                currentToken = lexer.nextToken();
            }
            if (currentToken.tokenType == TokenType.Symbol)
            {
                var s1 = core.getSymbole(currentToken.value) ?? new Symbole(currentToken.value);
                currentToken = lexer.nextToken();
                if (currentToken.tokenType == TokenType.Eol)
                {
                    if (not)
                        s1.addRelation(new RightInvert(leftExpression));
                    else
                        s1.addRelation(new RightNormal(leftExpression));
                }
                else if (currentToken.tokenType == TokenType.And)
                {
                    currentToken = lexer.nextToken();
                    if (currentToken.tokenType == TokenType.Symbol)
                    {
                        var s2 = core.getSymbole(currentToken.value) ?? new Symbole(currentToken.value);
                        currentToken = lexer.nextToken();
                        s2.addRelation(new RightAnd(s1, leftExpression));
                        s1.addRelation(new RightAnd(s2, leftExpression));
                    }
                    else
                        throw new UnexpectedTokenException(currentToken.value);
                }
                else if (currentToken.tokenType == TokenType.Or)
                {
                    currentToken = lexer.nextToken();
                    if (currentToken.tokenType == TokenType.Symbol)
                    {
                        var s2 = core.getSymbole(currentToken.value) ?? new Symbole(currentToken.value);
                        currentToken = lexer.nextToken();
                        s1.addRelation(new RightOr(s2, leftExpression));
                        s2.addRelation(new RightOr(s1, leftExpression));
                    }
                    else
                        throw new UnexpectedTokenException(currentToken.value);
                }
                else if (currentToken.tokenType == TokenType.Xor)
                {
                    currentToken = lexer.nextToken();
                    if (currentToken.tokenType == TokenType.Symbol)
                    {
                        var s2 = core.getSymbole(currentToken.value) ?? new Symbole(currentToken.value);
                        currentToken = lexer.nextToken();
                        s1.addRelation(new RightXor(s2, leftExpression));
                        s2.addRelation(new RightXor(s1, leftExpression));
                    }
                    else
                        throw new UnexpectedTokenException(currentToken.value);
                }
                else
                    throw new UnexpectedTokenException(currentToken.value);
            }
            else
                throw new UnexpectedTokenException(currentToken.value);
        }

        private ProgramObject parseParenthesis()
        {
            ProgramObject pReturn = parseLowerOrderExpression();

            if (currentToken.tokenType == TokenType.CParenthesis)
                currentToken = lexer.nextToken();
            else
                throw new UnexpectedTokenException(currentToken.value);
            return pReturn;
        }
        
        private ProgramObject parseLowerOrderExpression()
        {
            ProgramObject expression;
            ProgramObject tmp;

            expression = parseHigherOrderExpression();
            while (currentToken.tokenType != TokenType.Then
                   && currentToken.tokenType != TokenType.Eol
                   && currentToken.tokenType != TokenType.Eof)
            {
                switch (currentToken.tokenType)
                {
                    case TokenType.And:
                        tmp = expression;
                        currentToken = lexer.nextToken();
                        expression = new LeftAnd(tmp, parseHigherOrderExpression());
                        break;
                    case TokenType.Or:
                        tmp = expression;
                        currentToken = lexer.nextToken();
                        expression = new LeftOr(tmp, parseHigherOrderExpression());
                        break;
                    case TokenType.Xor:
                        tmp = expression;
                        currentToken = lexer.nextToken();
                        expression = new LeftXor(tmp, parseHigherOrderExpression());
                        break;
                    case TokenType.OParenthesis:
                        currentToken = lexer.nextToken();
                        expression = parseParenthesis();
                        break;
                    case TokenType.CParenthesis:
                        return expression;
                    default:
                        throw new UnexpectedTokenException(currentToken.value);
                }
            }
            return expression;
        }

        private ProgramObject parseHigherOrderExpression()
        {
            ProgramObject expression = null;
            ProgramObject s;

            if (currentToken.tokenType == TokenType.Not || currentToken.tokenType == TokenType.Symbol)
            {
                s = parseSymbol();
                switch (currentToken.tokenType)
                {
                    case TokenType.And:
                        currentToken = lexer.nextToken();
                        expression = new LeftAnd(s, parseHigherOrderExpression());
                        break;
                    case TokenType.Or:
                    case TokenType.Xor:
                    case TokenType.Then:
                    case TokenType.OParenthesis:
                    case TokenType.CParenthesis:
                    case TokenType.Eol:
                    case TokenType.Eof:
                        expression = s;
                        break;
                }
            }
            else if (currentToken.tokenType == TokenType.OParenthesis)
            {
                currentToken = lexer.nextToken();
                expression = parseParenthesis();
            }
            else
                throw new UnexpectedTokenException(currentToken.value);
            return expression;
        }

        private ProgramObject parseSymbol()
        {
            ProgramObject s;
            
            bool not = false;
 
            if (currentToken.tokenType == TokenType.Not)
            {
                not = true;
                currentToken = lexer.nextToken();
            }

            if (currentToken.tokenType == TokenType.Symbol)
            {
                s = core.getSymbole(currentToken.value) ?? new Symbole(currentToken.value);
                currentToken = lexer.nextToken();
            }
            else
                throw new UnexpectedTokenException(currentToken.value);
            if (not)
                return new LeftInvert(s);
            return s;
        }
    }
}