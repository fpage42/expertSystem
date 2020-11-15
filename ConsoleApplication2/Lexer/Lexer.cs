using System;
using System.Collections.Specialized;
using System.ComponentModel.Design.Serialization;

namespace ExpertSystem
{
    public class Lexer
    {
        Reader rd;
        private char currentChar;
        private ErrorLog error;
        private int nLine = 1;
        private int nCol = 1;

        public Lexer(string filePath)
        {
            try
            {
                rd = new Reader(filePath);
                currentChar = rd.nextChar();
            }
            catch
            {
                Console.WriteLine("Le fichier est inexistant ou invalide.");
                Environment.Exit(0);
            }

        }

        private Token createFactsToken()
        {
            Token token = new Token();

            token.tokenType = TokenType.Facts;
            token.value = "=";
            currentChar = rd.nextChar();
            nCol++;
            return token;
        }

        private Token createNotToken()
        {
            Token token = new Token();

            token.tokenType = TokenType.Not;
            token.value = "!";
            currentChar = rd.nextChar();
            nCol++;
            return token;
        }
        
        private Token createSymbolToken()
        {
            Token token = new Token();

            token.tokenType = TokenType.Symbol;
            token.value = token.value + currentChar;
            currentChar = rd.nextChar();
            nCol++;
            return token;
        }

        private Token createOperatorToken()
        {
            Token token = new Token();

            if (currentChar == '+')
            {
                token.tokenType = TokenType.And;
                token.value = "+";
            }
            else if (currentChar == '|')
            {
                token.tokenType = TokenType.Or;
                token.value = "|";
            }
            else if (currentChar == '^')
            {
                token.tokenType = TokenType.Xor;
                token.value = "^";
            }
            else if (currentChar == '=' && rd.peekChar() == '>')
            {
                currentChar = rd.nextChar();
                nCol++;
                token.tokenType = TokenType.Then;
                token.value = "=>";
            }
            currentChar = rd.nextChar();
            nCol++;
            return token;
        }

        private Token createParenthesisToken()
        {
            Token token = new Token();

            if (currentChar == '(')
            {
                token.tokenType = TokenType.OParenthesis;
                token.value = "(";
            }
            else
            {
                token.tokenType = TokenType.CParenthesis;
                token.value = ")";
            }
            currentChar = rd.nextChar();
            nCol++;
            return token;
        }

        private Token createQueryToken()
        {
            Token token = new Token();

            token.tokenType = TokenType.Query;
            token.value = "?";
            currentChar = rd.nextChar();
            nCol++;
            return token;
        }

        private Token createEolToken()
        {
            Token token = new Token();

            token.tokenType = TokenType.Eol;
            token.value = "" + (char)13;
            nCol = 0;
            while ((int)currentChar == 13 || (int)currentChar == 10)
            {
                currentChar = rd.nextChar();
                nLine++;
                /*Fonction exécutée deux fois : ici et au prochain appel de nextToken() le cas échéant (dommage...)*/
                skippingRoutine();
            }
            return token;
        }

        private Token createEofToken()
        {
            Token token = new Token();
            
            token.tokenType = TokenType.Eof;
            token.value = "";
            return token;
        }

        private void skipSpaces()
        {
            while (currentChar == ' ')
            {
                currentChar = rd.nextChar();
                nCol++;
            }
        }

        private void skipComments()
        {
            while (currentChar != '\n' && currentChar != '\r' && currentChar != (char)0)
                currentChar = rd.nextChar();
        }

        private void skippingRoutine()
        {
            while (currentChar == ' ' || currentChar == '#')
            {
                if (currentChar == '#')
                    skipComments();
                else
                    skipSpaces();
            }
        }
        
        public Token nextToken()
        {
            Token token;

            skippingRoutine();

            if (currentChar == '=' && rd.peekChar() != '>')
                token = createFactsToken();
            else if (currentChar == '!')
                token = createNotToken();
            else if (char.IsLetter(currentChar))
                token = createSymbolToken();
            else if (currentChar == '+' || currentChar == '|' || currentChar == '^'
                     || (currentChar == '=' && rd.peekChar() == '>'))
                token = createOperatorToken();
            else if (currentChar == '(' || currentChar == ')')
                token = createParenthesisToken();
            else if (currentChar == '?')
                token = createQueryToken();
            else if (currentChar == '\n' || currentChar == '\r')
                token = createEolToken();
            else if (currentChar == (char) 0)
                token = createEofToken();
            else
                throw new UnexpectedCharacterException("'" + currentChar + "' character (ASCII number " 
                                                                   + (int)currentChar + ") was not expected.");
            return token;
        }
    }
}

