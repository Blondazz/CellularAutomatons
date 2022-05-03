using System.IO;
using System.Text;

namespace CellularAutomatons.IO
{
    public static class TxtSaver
    {
        public static void SaveGrain(int[][] field, string path)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var row in field)
            {
                foreach (var i in row)
                {
                    sb.Append($"{i},");
                }
                sb.Append("\n");
            }

            using var sw = new StreamWriter(path);
            sw.Write(sb.ToString());
        }
    }
}
