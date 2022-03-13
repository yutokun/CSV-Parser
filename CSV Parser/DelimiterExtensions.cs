using System;

namespace yutokun
{
    public static class DelimiterExtensions
    {
        public static char ToChar(this Delimiter delimiter)
        {
            // C# 7.3: Unity 2018.2 - 2020.1 Compatible
            switch (delimiter)
            {
                case Delimiter.Comma:
                    return ',';
                case Delimiter.Tab:
                    return '\t';
                default:
                    throw new ArgumentOutOfRangeException(nameof(delimiter), delimiter, null);
            }
        }
    }
}
