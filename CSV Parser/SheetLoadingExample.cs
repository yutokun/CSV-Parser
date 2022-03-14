namespace yutokun
{
    public class SheetLoadingExample
    {
        // TODO Recreate Unity sample
        void Load()
        {
            var sheet = CSVParser.LoadFromString("textAsset.text", Delimiter.Tab);

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
        }
    }
}
