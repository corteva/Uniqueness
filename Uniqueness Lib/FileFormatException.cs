using System;

namespace Similarity_Search_Lib
{
    public class FileFormatException : Exception
    {
        public FileFormatException()
        {
        }

        public FileFormatException(string message)
            : base(message)
        {
        }

        public FileFormatException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
