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
        public static void SaveGrainStruct(int[][] field, int[][] structureField, string path)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (structureField[i][j] == 1)
                        sb.Append($"{i},");
                    else
                        sb.Append("0,");

                }
                sb.Append("\n");
            }

            using var sw = new StreamWriter(path);
            sw.Write(sb.ToString());
        }
    }
}
