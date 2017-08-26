using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model
{
    public static class FileOperations
    {
        public static void Open<T>(ref List<T> a, string filename)
        {
            string path = Application.StartupPath + "\\" + filename + ".bin";
            if (!File.Exists(path))
                return;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path,
                                      FileMode.Open,
                                      FileAccess.Read,
                                      FileShare.Read);
            a = new List<T>();
            a = (List<T>)formatter.Deserialize(stream);
            stream.Close(); 
        }

        public static void Save<T>(ref List<T> a, string filename)
        {
            string path = Application.StartupPath + "\\" + filename + ".bin";
            if (File.Exists(path))
                File.Delete(path);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, a);
            stream.Close();
        }
    }
}
