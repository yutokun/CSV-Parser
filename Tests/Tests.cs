using NUnit.Framework;

namespace yutokun.Tests
{
    public class Tests
    {
        [Test]
        public void RFC4180_1()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/RFC 4180 Examples/1.csv");
            Assert.That(sheet.Count, Is.EqualTo(2));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "aaa", "bbb", "ccc" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "zzz", "yyy", "xxx" }));
        }

        [Test]
        public void RFC4180_2()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/RFC 4180 Examples/2.csv");
            Assert.That(sheet.Count, Is.EqualTo(2));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "aaa", "bbb", "ccc" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "zzz", "yyy", "xxx" }));
        }

        [Test]
        public void RFC4180_3()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/RFC 4180 Examples/3.csv");
            Assert.That(sheet.Count, Is.EqualTo(3));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "field_name", "field_name", "field_name" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "aaa", "bbb", "ccc" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "zzz", "yyy", "xxx" }));
        }

        [Test]
        public void RFC4180_4()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/RFC 4180 Examples/4.csv");
            Assert.That(sheet.Count, Is.EqualTo(1));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "aaa", "bbb", "ccc" }));
        }

        [Test]
        public void RFC4180_5()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/RFC 4180 Examples/5.csv");
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "aaa", "bbb", "ccc" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "zzz", "yyy", "xxx" }));
            Assert.That(sheet.Count, Is.EqualTo(2));
        }

        [Test]
        public void RFC4180_6()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/RFC 4180 Examples/6.csv");
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "aaa", "b\r\nbb", "ccc" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "zzz", "yyy", "xxx" }));
            Assert.That(sheet.Count, Is.EqualTo(2));
        }

        [Test]
        public void RFC4180_7()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/RFC 4180 Examples/7.csv");
            Assert.That(sheet.Count, Is.EqualTo(1));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "aaa", "b\"bb", "ccc" }));
        }

        [Test]
        public void CSVLevel1()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/CSV/level1.csv");
            Assert.That(sheet.Count, Is.EqualTo(4));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "first", "second" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "third", "fourth" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "fifth", "sixth" }));
            Assert.That(sheet[3], Is.EquivalentTo(new[] { "seventh", "eighth" }));
        }

        [Test]
        public void CSVLevel2()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/CSV/level2.csv");
            Assert.That(sheet.Count, Is.EqualTo(3));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "fir\r\nst", "sec,on\"\"d" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "th\",\"\",,ird", "fourth" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "fifth", "sixth" }));
        }

        [Test]
        public void CSVLevel3()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/CSV/level3.csv");
            Assert.That(sheet.Count, Is.EqualTo(6));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "名前", "容量", "備考" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "カフェラテ", "300", "甘い" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "カフェオレ", "250", "\"某コンビニで購入" }));
            Assert.That(sheet[3], Is.EquivalentTo(new[] { "", "", "" }));
            Assert.That(sheet[4], Is.EquivalentTo(new[] { "かなり甘い\"", "", "" }));
            Assert.That(sheet[5], Is.EquivalentTo(new[] { "値", "", "" }));
        }

        [Test]
        public void CSVCR()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/CSV/CR.csv");
            Assert.That(sheet.Count, Is.EqualTo(6));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "名前", "容量", "備考" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "カフェラテ", "300", "甘い" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "カフェオレ", "250", "某コンビニで購入" }));
            Assert.That(sheet[3], Is.EquivalentTo(new[] { "", "", "" }));
            Assert.That(sheet[4], Is.EquivalentTo(new[] { "かなり甘い", "", "" }));
            Assert.That(sheet[5], Is.EquivalentTo(new[] { "値", "", "" }));
        }

        [Test]
        public void CSVLF()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/CSV/LF.csv");
            Assert.That(sheet.Count, Is.EqualTo(6));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "名前", "容量", "備考" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "カフェラテ", "300", "甘い" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "カフェオレ", "250", "某コンビニで購入" }));
            Assert.That(sheet[3], Is.EquivalentTo(new[] { "", "", "" }));
            Assert.That(sheet[4], Is.EquivalentTo(new[] { "かなり甘い", "", "" }));
            Assert.That(sheet[5], Is.EquivalentTo(new[] { "値", "", "" }));
        }

        [Test]
        public void CSVDemoData()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/CSV/demodata.csv");
            Assert.That(sheet.Count, Is.EqualTo(11));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "clientid", "date", "weekdays", "gains", "prices", "up" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "0", "2008-04-30", "Wed", "-0.52458192906686452", "7791404.0091921333", "False" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "1", "2008-05-01", "Thu", "0.076191536201738269", "3167180.7366340165", "True" }));
            Assert.That(sheet[3], Is.EquivalentTo(new[] { "2", "2008-05-02", "Fri", "-0.86850970062880861", "9589766.9613829032", "False" }));
            Assert.That(sheet[4], Is.EquivalentTo(new[] { "3", "2008-05-03", "Sat", "-0.42701083852713395", "8949415.1867596991", "False" }));
            Assert.That(sheet[5], Is.EquivalentTo(new[] { "4", "2008-05-04", "Sun", "0.2532553652693274", "937163.44375252665", "True" }));
            Assert.That(sheet[6], Is.EquivalentTo(new[] { "5", "2008-05-05", "Mon", "-0.68151636911081892", "949579.88022264629", "False" }));
            Assert.That(sheet[7], Is.EquivalentTo(new[] { "6", "2008-05-06", "Tue", "0.0071911579626532168", "7268426.906552773", "True" }));
            Assert.That(sheet[8], Is.EquivalentTo(new[] { "7", "2008-05-07", "Wed", "0.67449747200412147", "7517014.782897247", "True" }));
            Assert.That(sheet[9], Is.EquivalentTo(new[] { "8", "2008-05-08", "Thu", "-1.1841008656818983", "1920959.5423492221", "False" }));
            Assert.That(sheet[10], Is.EquivalentTo(new[] { "9", "2008-05-09", "Fri", "-1.5803692595811152", "8456240.6198725495", "False" }));
        }

        [Test]
        public void FromWikipedia()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/From Wikipedia/From Wikipedia.csv");
            Assert.That(sheet.Count, Is.EqualTo(1));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "日本\r\n国", "\"東京\"", "127,767,944" }));
        }

        [Test]
        public void TSVLevel1()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/TSV/level1.txt", Delimiter.Tab);
            Assert.That(sheet.Count, Is.EqualTo(4));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "first", "second" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "third", "fourth" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "fifth", "sixth" }));
            Assert.That(sheet[3], Is.EquivalentTo(new[] { "seventh", "eighth" }));
        }

        [Test]
        public void TSVLevel2()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/TSV/level2.txt", Delimiter.Tab);
            Assert.That(sheet.Count, Is.EqualTo(3));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "fir\r\nst", "sec,on\"\"d" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "th\",\"\",,ird", "fourth" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "fifth", "sixth" }));
        }

        [Test]
        public void TSVLevel3()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/TSV/level3.txt", Delimiter.Tab);
            Assert.That(sheet.Count, Is.EqualTo(6));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "名前", "容量", "備考" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "カフェラテ", "300", "甘い" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "カフェオレ", "250", "\"某コンビニで購入" }));
            Assert.That(sheet[3], Is.EquivalentTo(new[] { "", "", "" }));
            Assert.That(sheet[4], Is.EquivalentTo(new[] { "かなり甘い\"", "", "" }));
            Assert.That(sheet[5], Is.EquivalentTo(new[] { "値", "", "" }));
        }

        [Test]
        public void TSVCR()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/TSV/CR.txt", Delimiter.Tab);
            Assert.That(sheet.Count, Is.EqualTo(6));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "名前", "容量", "備考" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "カフェラテ", "300", "甘い" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "カフェオレ", "250", "某コンビニで購入" }));
            Assert.That(sheet[3], Is.EquivalentTo(new[] { "", "", "" }));
            Assert.That(sheet[4], Is.EquivalentTo(new[] { "かなり甘い", "", "" }));
            Assert.That(sheet[5], Is.EquivalentTo(new[] { "値", "", "" }));
        }

        [Test]
        public void TSVLF()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/TSV/LF.txt", Delimiter.Tab);
            Assert.That(sheet.Count, Is.EqualTo(6));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "名前", "容量", "備考" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "カフェラテ", "300", "甘い" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "カフェオレ", "250", "某コンビニで購入" }));
            Assert.That(sheet[3], Is.EquivalentTo(new[] { "", "", "" }));
            Assert.That(sheet[4], Is.EquivalentTo(new[] { "かなり甘い", "", "" }));
            Assert.That(sheet[5], Is.EquivalentTo(new[] { "値", "", "" }));
        }

        [Test]
        public void TSVDemoData()
        {
            var sheet = CSVParser.LoadFromPath("../../../TesterSheets/TSV/demodata.txt", Delimiter.Tab);
            Assert.That(sheet.Count, Is.EqualTo(11));
            Assert.That(sheet[0], Is.EquivalentTo(new[] { "clientid", "date", "weekdays", "gains", "prices", "up" }));
            Assert.That(sheet[1], Is.EquivalentTo(new[] { "0", "2008-04-30", "Wed", "-0.52458192906686452", "7791404.0091921333", "False" }));
            Assert.That(sheet[2], Is.EquivalentTo(new[] { "1", "2008-05-01", "Thu", "0.076191536201738269", "3167180.7366340165", "True" }));
            Assert.That(sheet[3], Is.EquivalentTo(new[] { "2", "2008-05-02", "Fri", "-0.86850970062880861", "9589766.9613829032", "False" }));
            Assert.That(sheet[4], Is.EquivalentTo(new[] { "3", "2008-05-03", "Sat", "-0.42701083852713395", "8949415.1867596991", "False" }));
            Assert.That(sheet[5], Is.EquivalentTo(new[] { "4", "2008-05-04", "Sun", "0.2532553652693274", "937163.44375252665", "True" }));
            Assert.That(sheet[6], Is.EquivalentTo(new[] { "5", "2008-05-05", "Mon", "-0.68151636911081892", "949579.88022264629", "False" }));
            Assert.That(sheet[7], Is.EquivalentTo(new[] { "6", "2008-05-06", "Tue", "0.0071911579626532168", "7268426.906552773", "True" }));
            Assert.That(sheet[8], Is.EquivalentTo(new[] { "7", "2008-05-07", "Wed", "0.67449747200412147", "7517014.782897247", "True" }));
            Assert.That(sheet[9], Is.EquivalentTo(new[] { "8", "2008-05-08", "Thu", "-1.1841008656818983", "1920959.5423492221", "False" }));
            Assert.That(sheet[10], Is.EquivalentTo(new[] { "9", "2008-05-09", "Fri", "-1.5803692595811152", "8456240.6198725495", "False" }));
        }
    }
}
