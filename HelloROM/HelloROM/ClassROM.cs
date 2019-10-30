using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HelloROM
{
    public class ROM
    {
        public string Name { get; set; } = "AOSP";//имя прошивки
        public string Base { get; set; } = "AOSP";//прошивка, на которой базируется прошивка, обычно это Lineage OS/CyanogenMod или AOSP
        public string Image { get; set; } = "https://github.com/Roker2/HelloROM/raw/master/Images/404.png";
        public string Description { get; set; } = "Description is not exist";
        public string SiteUrl { get; set; } = null;
        public string GerritUrl { get; set; } = null;
        public string GithubUrl { get; set; } = null;
        public List<String> Screenshots { get; set; } = new List<String> { };
        //string[] Features;//набор настроек
        //string[] Devices;//официально поддерживаемые усройства

        public ROM(string _Name, string _Base, string _Image = null, string _Site = null, string _Gerrit = null, string _Github = null)
        {
            Name = _Name;
            Base = _Base;
            if (_Image != null)
                Image = _Image;
            SiteUrl = _Site;
            GerritUrl = _Gerrit;
            GithubUrl = _Github;
        }

        public void AddScreenshot(string URL)
        {
            Screenshots.Add(URL);
        }

        //с 1 до number добавит снимки экрана
        public void AddScreenshots(string URLPartOne, int number, string URLPartTwo)
        {
            for (int i = 1; i <= number; i++)
            {
                char temp_ch = (char)(i + 48);
                AddScreenshot(URLPartOne + temp_ch + URLPartTwo);
            }
        }

        public void AddDescription(string _description = null)
        {
            if (_description != null)
                Description = _description;
        }

        string ToJSONInf(string Tag, string Info)
        {
            return "\"" + Tag + "\":\"" + Info + "\"";
        }

        public string ToJSON()
        {
            string JSON_str = "{";
            JSON_str += ToJSONInf("Name", Name) + ",\n" + ToJSONInf("Base", Name) + ",\n";
            if (!string.IsNullOrEmpty(Image))
                JSON_str += ToJSONInf("Image", Image) + ",\n";
            if (!string.IsNullOrEmpty(Description))
                JSON_str += ToJSONInf("Description", Description) + ",\n";
            if (!string.IsNullOrEmpty(SiteUrl))
                JSON_str += ToJSONInf("SiteUrl", SiteUrl) + ",\n";
            if (!string.IsNullOrEmpty(GerritUrl))
                JSON_str += ToJSONInf("GerritUrl", GerritUrl) + ",\n";
            if (!string.IsNullOrEmpty(GithubUrl))
                JSON_str += ToJSONInf("GithubUrl", GithubUrl) + ",\n";
            JSON_str += "\"Screenshots\":\n[";
            for (int i = 0; i < Screenshots.Count; i++)
            {
                JSON_str += "\"" + Screenshots[i] + "\"";
                if (i != Screenshots.Count - 1)
                    JSON_str += ",\n";
            }
            JSON_str += "]}";
            return JSON_str;
        }
    }

    class ROMs : IEnumerable<ROM>
    {
        private List<ROM> _roms;

        public ROMs(List<ROM> pArray)
        {
            _roms = pArray;
        }

        public void SortByName()
        {
            _roms = _roms.OrderBy(x => x.Name).ToList<ROM>();
        }

        public void SortByBase()
        {
            _roms = _roms.OrderBy(x => x.Base).ToList<ROM>();
        }

        public IEnumerator<ROM> GetEnumerator()
        {
            for (int i = 0; i < _roms.Count; i++)
            {
                yield return _roms[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}