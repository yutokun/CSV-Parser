using System;
using UnityEngine;
using UnityEngine.UI;

public class SheetLoadingExample : MonoBehaviour
{
	[SerializeField] Text uiText;
	[SerializeField] TextAsset textAsset;
	[SerializeField] CSVParser.Delimiter delimiter;

	void Load()
	{
		var sheet = CSVParser.LoadFromString(textAsset.text, delimiter);

		var log = "";
		foreach (var row in sheet)
		{
			log += "|";

			foreach (var cell in row)
			{
				log += cell + "|";
			}

			log += "\n";
		}

		Debug.Log(log);         // Unity
		Console.WriteLine(log); // C#
		uiText.text = log;
	}

	void OnValidate()
	{
		Load();
	}
}
