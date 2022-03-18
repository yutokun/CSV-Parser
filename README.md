# CSV Parser for C#

[![Test](https://github.com/yutokun/CSV-Parser/actions/workflows/test.yml/badge.svg)](https://github.com/yutokun/CSV-Parser/actions/workflows/test.yml)

CSV Parser with CC0 License.

Best for: 

- [Unity](https://unity3d.com/) projects requires cross-platform CSV parser. (maybe works on any platform supported by Unity)
- Commercial products that you could not display the license.

## Prerequisites

| Environment             | Prerequisites                                                             |
| ----------------------- | ------------------------------------------------------------------------- |
| Unity 2021.2 or later   | None                                                                      |
| Unity 2019.1 - 2021.1   | Some DLLs in your project                                                 |
| Unity 2018.4 or earlier | .NET 4.x Equivalent                                                       |
| .NET Project            | [System.Memory](https://www.nuget.org/packages/System.Memory/) from NuGet |

## Download

[**Releases**](https://github.com/yutokun/CSV-Parser/releases)

## Usage

### Methods

This returns CSV data as `List<List<string>>`.

```c#
CSVParser.LoadFromString(string data)  
```

or

```c#
CSVParser.LoadFromPath(string path, Encoding encoding = null)
```

### Examples

```c#
var sheet = CSVParser.LoadFromString(csvString);

var styled = new StringBuilder();
foreach (var row in sheet)
{
    styled.Append("| );

    foreach (var cell in row)
    {
        styled.Append(cell);
        styled.Append(" | ");
    }

    styled.AppendLine();
}

Debug.Log(styled.ToString());         // Unity
Console.WriteLine(styled.ToString()); // C# 
```

## Specs

Compliant with [RFC 4180](http://www.ietf.org/rfc/rfc4180.txt).

- Correctly parse new lines, commas, quotation marks inside cell.
- Escaped double quotes.
- Some encoding types. (default UTF-8)

## Beta

Tab delimiter support is in beta.

## License

[CC0](https://creativecommons.org/publicdomain/zero/1.0/) or [Public Domain](LICENSE)
