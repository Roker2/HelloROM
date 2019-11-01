using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HelloROM
{
    public class ROM
    {
        /// <summary>
        /// ROM Name
        /// </summary>
        public string Name { get; set; } = "AOSP";
        /// <summary>
        /// ROM Base
        /// </summary>
        public string Base { get; set; } = "AOSP";//прошивка, на которой базируется прошивка, обычно это Lineage OS/CyanogenMod или AOSP
        /// <summary>
        /// ROM Image (Logo)
        /// </summary>
        public string Image { get; set; } = "https://github.com/Roker2/HelloROM/raw/master/Images/404.png";
        /// <summary>
        /// ROM Description
        /// </summary>
        public string Description { get; set; } = "Description is not exist";
        /// <summary>
        /// Official ROM Site
        /// </summary>
        public string SiteUrl { get; set; } = null;
        /// <summary>
        /// ROM Code Review
        /// </summary>
        public string GerritUrl { get; set; } = null;
        /// <summary>
        /// Sources
        /// </summary>
        public string GithubUrl { get; set; } = null;
        /// <summary>
        /// ROM Screenshots
        /// </summary>
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

        /// <summary>
        /// Empty constructor
        /// </summary>
        public ROM()
        {

        }

        /// <summary>
        /// Add screenshot
        /// </summary>
        public void AddScreenshot(string URL)
        {
            Screenshots.Add(URL);
        }
        
        /// <summary>
        /// Add screenshots with common names, from 1 to number
        /// </summary>
        public void AddScreenshots(string URLPartOne, int number, string URLPartTwo)
        {
            for (int i = 1; i <= number; i++)
            {
                char temp_ch = (char)(i + 48);
                AddScreenshot(URLPartOne + temp_ch + URLPartTwo);
            }
        }

        /// <summary>
        /// Add description to ROM
        /// </summary>
        public void AddDescription(string _description = null)
        {
            if (_description != null)
                Description = _description;
        }
        
        /// <summary>
        /// Function for help to convert to JSON
        /// </summary>
        string ToJSONInf(string Tag, string Info)
        {
            return "\"" + Tag + "\":\"" + Info + "\"";
        }

        /// <summary>
        /// Convert ROM to JSON
        /// </summary>
        public string ToJSON()
        {
            string JSON_str = "{";
            JSON_str += ToJSONInf("Name", Name) + ",\n" + ToJSONInf("Base", Base) + ",\n";
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