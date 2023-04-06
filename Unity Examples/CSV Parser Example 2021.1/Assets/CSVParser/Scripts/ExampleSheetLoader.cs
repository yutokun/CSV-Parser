using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace yutokun
{
    public class ExampleSheetLoader : MonoBehaviour
    {
        [SerializeField]
        Text result;

        [SerializeField]
        TextAsset[] examples;

        int index = -1;

        void Start()
        {
            ShowNextSheet();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ShowNextSheet();
            }
        }

        void ShowNextSheet()
        {
            index = (int)Mathf.Repeat(index + 1, examples.Length);
            var sheet = CSVParser.LoadFromString(examples[index].text);
            var styled = Stylize(sheet);

            Debug.Log(styled);
            result.text = styled;
        }

        static string Stylize(List<List<string>> sheet)
        {
            var styled = new StringBuilder();
            foreach (var row in sheet)
            {
                styled.Append("| ");

                foreach (var cell in row)
                {
                    styled.Append(cell);
                    styled.Append(" | ");
                }

                styled.AppendLine();
            }

            return styled.ToString();
        }
    }
}
