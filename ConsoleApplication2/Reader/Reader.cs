using System;
using System.IO;

namespace ExpertSystem
{
    class Reader
    {
        StreamReader sr;
        string filePath;
        bool finished = false;

        public Reader(string path)
        {
            filePath = path;
            sr = new StreamReader(filePath);
        }

        public char peekChar()
        {
            if (finished)
                return (char)0;
            int character = sr.Peek();
            return (char)character;
        }

        public char nextChar()
        {
            if (finished)
                return (char)0;
            int character = sr.Read();
            if (character == -1 && !finished)
            {
                sr.Close();
                finished = true;
                return (char)0;
            }
            else
                return (char)character;
        }
    }
}