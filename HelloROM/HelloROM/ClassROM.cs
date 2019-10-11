﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HelloROM
{
    public class ROM
    {
        public string Name { get; set; } = "AOSP";//имя прошивки
        public string Base { get; set; } = "AOSP";//прошивка, на которой базируется прошивка, обычно это Lineage OS/CyanogenMod или AOSP
        public double AndroidVersion { get; set; } = 9.0;//последняя версия Android
        public double ROMVersion = 9.0;//последняя версия прошивки, есть не у всех
        public string Codename = "Pie";//к примеру, у CarbonROM 7.0 (9.0) кодовое имя - OPAL, но оно есть мало у кого
        public string Image { get; set; } = "https://github.com/Roker2/HelloROM/raw/master/Images/404.png";
        public string Description = "Description is not exist";
        public string SiteUrl;
        public string GerritUrl;
        public string GithubUrl;
        public List<String> Screenshots { get; set; } = new List<String> { };
        //string[] Features;//набор настроек
        //string[] Devices;//официально поддерживаемые усройства

        public ROM ()
        {

        }

        public ROM (string _Name, double _AndroidVersion, string _Base, string _Image = null, string _Site = null, string _Gerrit = null, string _Github = null)
        {
            Name = _Name;
            AndroidVersion = _AndroidVersion;
            Base = _Base;
            if (_Image != null)
                Image = _Image;
            SiteUrl = _Site;
            GerritUrl = _Gerrit;
            GithubUrl = _Github;
        }

        public void AddScreenshot (string URL)
        {
            Screenshots.Add(URL);
        }

        //с 1 до number добавит снимки экрана
        public void AddScreenshots (string URLPartOne, int number, string URLPartTwo)
        {
            for (int i = 1; i <= number; i++)
            {
                char temp_ch = (char)(i + 48);
                AddScreenshot(URLPartOne + temp_ch + URLPartTwo);
            }
        }

        /*public ROM (string _Name, double _AndroidVersion, string _Base, string _CodeName)
        {
            Name = _Name;
            AndroidVersion = _AndroidVersion;
            Base = _Base;
            Codename = _CodeName;
        }*/

        public string GetName()
        {
            return Name;
        }

        public double GetAndroidVersion ()
        {
            return AndroidVersion;
        }

        public string GetBase ()
        {
            return Base;
        }
    }

    class ROMs : IEnumerable
    {
        private ROM[] _roms;

        public ROMs ()
        {

        }

        public ROMs (ROM[] pArray)
        {
            _roms = new ROM[pArray.Length];
            for (int i = 0; i < pArray.Length; i++)
                _roms[i] = pArray[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public ROMEnum GetEnumerator()
        {
            return new ROMEnum(_roms);
        }
    }

    class ROMEnum : IEnumerator
    {
        public ROM[] _roms;
        int position = -1; //то есть нигде

        public ROMEnum (ROM[] list)
        {
            _roms = list;
        }

        public bool MoveNext()
        {
            if (position + 1 == _roms.Length)//перемещение произойдет только в случае, если это не конец
                return false;
            position++;
            return true;
        }

        public void Reset ()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public ROM Current
        {
            get
            {
                return _roms[position];
            }
        }

        public int Search (string _name)
        {
            for (int i = 0; i < _roms.Length; i++)
                if (_roms[i].GetName() == _name)
                    return i;
            return -1;
        }

        public void Add (ROM _rom)
        {
            Array.Resize(ref _roms, _roms.Length + 1);
            _roms[_roms.Length - 1] = _rom;
        }

        private void Replace (int first, int second)
        {
            ROM temp;
            temp = _roms[first];
            _roms[first] = _roms[second];
            _roms[second] = temp;
        }

        public void Remove (int _pos)
        {
            for (int i = _pos; i < _roms.Length - 1; i++)
            {
                Replace(i, i + 1);
            }
            Array.Resize(ref _roms, _roms.Length - 1);
        }
    }
}
