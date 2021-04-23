using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_1
{
    public class FileProcessor
    {
        public IList<string> ReadFiles(IList<string> fileNames)
        {
            IList<string> text = new List<string>();

            lock (fileNames)
            {
                foreach (var path in fileNames)
                {
                    text.Add(File.ReadAllText(path));
                }
            }

            return text;
        }
    }
}
