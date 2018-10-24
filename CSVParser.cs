using System.Collections.Generic;
using System.IO;
using System.Text;

public class CSVParser
{
	public static List<List<string>> LoadFromPath(string path)
	{
		var data = File.ReadAllText(path);
		return LoadFromString(data);
	}

	public static List<List<string>> LoadFromString(string data)
	{
		var sheet = new List<List<string>>();
		var row = new List<string>();
		var cell = new StringBuilder();
		var afterQuote = false;
		var isInsideQuote = false;
		var readyToEndQuote = false;

		// TODO : コードパスがひじょーにアレなので見やすく改良

		foreach (var character in data)
		{
			// Inside the quotation marks.
			if (isInsideQuote)
			{
				if (afterQuote)
				{
					if (character == '"')
					{
						// Consecutive quotes : A quotation mark.
						cell.Append("\"");
						afterQuote = false;
					}
					else if (readyToEndQuote && character != '"')
					{
						// Non-consecutive quotes : End of the quotation.
						afterQuote = false;
						isInsideQuote = false;

						if (character == ',')
						{
							AddCell(ref row, ref cell);
						}
					}
					else
					{
						cell.Append(character);
						afterQuote = false;
					}

					readyToEndQuote = false;
				}
				else if (character == '"')
				{
					// A quot mark inside the quotation.
					// Determine by the next character.
					afterQuote = true;
					readyToEndQuote = true;
				}
				else
				{
					cell.Append(character);
				}
			}
			else
			{
				// Outside the quotation marks.
				if (character == ',')
				{
					AddCell(ref row, ref cell);
				}
				else if (character == '\n')
				{
					AddCell(ref row, ref cell);
					AddRow(ref sheet, ref row);
				}
				else if (character == '"')
				{
					afterQuote = true;
					isInsideQuote = true;
				}
				else
				{
					cell.Append(character);
				}
			}
		}

		return sheet;
	}

	static void AddCell(ref List<string> row, ref StringBuilder cell)
	{
		row.Add(cell.ToString());
		cell.Length = 0; // Old C#.
	}

	static void AddRow(ref List<List<string>> sheet, ref List<string> row)
	{
		sheet.Add(row);
		row = new List<string>();
	}
}