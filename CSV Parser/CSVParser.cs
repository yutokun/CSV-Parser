/*
 * Simple CSV Parser for C# without any dependency. 
 *
 * These codes are licensed under CC0.
 * https://github.com/yutokun/CSV-Parser
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace yutokun
{
    public static class CSVParser
    {
        /// <summary>
        /// Load CSV data from specified path.
        /// </summary>
        /// <param name="path">CSV file path.</param>
        /// <param name="delimiter">Delimiter.</param>
        /// <param name="encoding">Type of text encoding. (default UTF-8)</param>
        /// <returns>Nested list that CSV parsed.</returns>
        public static List<List<string>> LoadFromPath(string path, Delimiter delimiter = Delimiter.Auto, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;

            if (delimiter == Delimiter.Auto)
            {
                var extension = Path.GetExtension(path);
                if (extension.Equals(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    delimiter = Delimiter.Comma;
                }
                else if (extension.Equals(".tsv", StringComparison.OrdinalIgnoreCase))
                {
                    delimiter = Delimiter.Tab;
                }
                else
                {
                    throw new Exception($"Delimiter estimation failed. Unknown Extension: {extension}");
                }
            }

            var data = File.ReadAllText(path, encoding); // TODO async
            return Parse(data, delimiter);
        }

        /// <summary>
        /// Load CSV data from string.
        /// </summary>
        /// <param name="data">CSV string</param>
        /// <param name="delimiter">Delimiter.</param>
        /// <returns>Nested list that CSV parsed.</returns>
        public static List<List<string>> LoadFromString(string data, Delimiter delimiter = Delimiter.Comma)
        {
            if (delimiter == Delimiter.Auto) throw new InvalidEnumArgumentException("Delimiter estimation from string is not supported.");
            return Parse(data, delimiter);
        }

        static List<List<string>> Parse(string data, Delimiter delimiter)
        {
            ConvertToCrlf(ref data);

            var sheet = new List<List<string>>();
            var row = new List<string>();
            var cell = new StringBuilder();
            var insideQuoteCell = false;

            // TODO Span<> で速くならないか

            while (data.Length > 0)
            {
                if (data.StartsWith(delimiter.ToChar().ToString()))
                {
                    if (insideQuoteCell)
                    {
                        cell.Append(delimiter.ToChar());
                    }
                    else
                    {
                        AddCell(row, cell);
                    }

                    data = data.Remove(0, 1);
                }
                else if (data.StartsWith("\r\n"))
                {
                    if (insideQuoteCell)
                    {
                        cell.Append("\r\n");
                    }
                    else
                    {
                        AddCell(row, cell);
                        AddRow(sheet, ref row);
                    }

                    data = data.Remove(0, 2);
                }
                else if (data.StartsWith("\"\""))
                {
                    cell.Append("\"");
                    data = data.Remove(0, 2);
                }
                else if (data.StartsWith("\""))
                {
                    insideQuoteCell = !insideQuoteCell;
                    data = data.Remove(0, 1);
                }
                else
                {
                    cell.Append(data[0]);
                    data = data.Remove(0, 1);
                }
            }

            if (row.Count > 0)
            {
                AddCell(row, cell);
                AddRow(sheet, ref row);
            }

            return sheet;
        }

        static void AddCell(List<string> row, StringBuilder cell)
        {
            row.Add(cell.ToString());
            cell.Length = 0; // Old C#.
        }

        static void AddRow(List<List<string>> sheet, ref List<string> row)
        {
            sheet.Add(row);
            row = new List<string>();
        }

        static void ConvertToCrlf(ref string data)
        {
            data = Regex.Replace(data, @"\r\n|\r|\n", "\r\n");
        }
    }
}
