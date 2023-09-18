using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2ServSide
{
    internal class VideoGame : IComparable<VideoGame>
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NASales { get; set; }
        public double EUSales { get; set; }
        public double JPSales { get; set; }
        public double OtherSales { get; set; }
        public double GlobalSales { get; set; }

        public VideoGame(string name, string platform, int year, string genre, string publisher, double nASales, double eUSales, double jPSales, double otherSales, double globalSales)
        {
            Name = name;
            Platform = platform;
            Year = year;
            Genre = genre;
            Publisher = publisher;
            NASales = nASales;
            EUSales = eUSales;
            JPSales = jPSales;
            OtherSales = otherSales;
            GlobalSales = globalSales;
        }

        public override string ToString()
        {
            string info = "";
            info = (this.Name + ", " + this.Platform + ", " + this.Year + ", " + this.Genre + ", " + this.Publisher + ", " + this.NASales + ", " + this.EUSales + ", " + this.JPSales + ", " + this.OtherSales + ", " + this.GlobalSales);
            return info;
        }

        public int CompareTo(VideoGame? other)
        {
            return string.Compare(this.Name, other.Name);
        }
    }
}
