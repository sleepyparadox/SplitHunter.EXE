using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SplitHunter.EXE.Data
{
    public class Splits : List<Split>
    {
        public static string DefaultSplitsDirectory
        {
            //Windows is the slash exception, use forward slash where possible
            get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("\\", "//") + @"/SplitHunter.EXE"; }
        }

        public string FullPath;
        public bool Dirty;

        public string Name { get { return PathToName(FullPath); } }

        public static Splits NewEmpty()
        {
            var splits = new Splits();

            if (!Directory.Exists(DefaultSplitsDirectory))
                Directory.CreateDirectory(DefaultSplitsDirectory);

            splits.FullPath = DefaultSplitsDirectory + "/New Run@" + DateTime.Now.ToFileFriendlyString() + ".csv";

            splits.Dirty = true;
            return splits;
        }

        public static Splits CloneExisting(string parentPath)
        {
            var splits = Open(parentPath);

            var fileInfo = new FileInfo(parentPath);
            var newFileName = fileInfo.Name;

            //If already timestamped, remove it from name
            if (fileInfo.Name.Contains("@"))
            {
                var lastAt = fileInfo.Name.LastIndexOf('@');
                newFileName = fileInfo.Name.Substring(0, lastAt);
            }

            newFileName += '@' + DateTime.Now.ToFileFriendlyString() + ".txt";

            splits.FullPath = fileInfo.Directory + "/" + newFileName;

            splits.Dirty = true;
            return splits;
        }

        public static Splits Open(string path)
        {
            var lines = File.ReadAllLines(path);

            var splits = FromLines(lines);
            splits.FullPath = path;

            return splits;
        }

        public void Save()
        {
            File.WriteAllLines(FullPath, ToLines());
            Dirty = false;
        }

        private Splits()
        {
            //Use Splits.NewEmpty() instead
        }

        static Splits FromLines(IEnumerable<string> lines)
        {
            var splits = new Splits();
            foreach(var line in lines)
            {
                if(string.IsNullOrEmpty(line)
                    || line.Length >= 2 && line.Substring(0, 2) == "//")
                {
                    continue;
                }

                var cells = line.Split(',');
                var split = new Split();
                split.Name = cells[0];

                TimeSpan parsedCell;
                if (cells.Length >= 2 && TimeSpan.TryParse(cells[1], out parsedCell))
                {
                    split.Best = parsedCell;
                }

                if (cells.Length >= 3 && TimeSpan.TryParse(cells[2], out parsedCell))
                {
                    split.Current = parsedCell;
                }
                splits.Add(split);
            }
            return splits;
        }

        List<string> ToLines()
        {
            var lines = new List<string>();

            foreach(var split in this)
            {
                var csvRow = new StringBuilder();
                csvRow.Append(split.Name);

                csvRow.Append(',');
                if (split.Best.HasValue)
                {
                    csvRow.Append(split.Best.Value);
                }

                csvRow.Append(',');
                if (split.Current.HasValue)
                {
                    csvRow.Append(split.Current.Value);
                }

                lines.Add(csvRow.ToString());
            }

            return lines;
        }

        static string PathToName(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return path;
            }
            else
            {
                int lastSlashIndex = path.LastIndexOf('/');
                int lastDotIndex = path.LastIndexOf('.');

                //Return "MyRun@Today" from "SpeedRuns/MyRun@Today.csv", supports extensionless
                var nameStart = lastSlashIndex + 1; //No slash starts at 0
                var nameLength = path.Length - nameStart;
                if (lastDotIndex > nameStart)
                {
                    nameLength -= path.Length - lastDotIndex;
                }

                return path.Substring(nameStart, nameLength);
            }
        }
    }
}
