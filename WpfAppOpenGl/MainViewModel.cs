using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WpfAppOpenGl
{
    public class MainViewModel
    {
        public List<PointModel> Points { get; private set; }
        public List<SegmentModel> Lines { get; private set; }

        public MainViewModel()
        {
            LoadData(WindowFileTxt.filePath);
        }

        private void LoadData(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            int pointCount = int.Parse(lines[0]);

            Points = new List<PointModel>();
            for (int i = 1; i <= pointCount; i++)
            {
                var coordinates = lines[i].Split(' ');
                Points.Add(new PointModel(
                    double.Parse(coordinates[0].Replace(".", ",")),
                    double.Parse(coordinates[1].Replace(".", ",")),
                    double.Parse(coordinates[2].Replace(".", ",")),
                    double.Parse(coordinates[3].Replace(".", ","))
                ));
            }

            int lineCount = int.Parse(lines[pointCount + 1]);
            Lines = new List<SegmentModel>();
            for (int i = pointCount + 2; i < lines.Length; i++)
            {
                var indexes = lines[i].Split(' ');
                Lines.Add(new SegmentModel(
                    int.Parse(indexes[0]),
                    int.Parse(indexes[1])
                ));
            }
        }
        public void ReloadData()
        {
            LoadData(WindowFileTxt.filePath);
        }

    }
}
