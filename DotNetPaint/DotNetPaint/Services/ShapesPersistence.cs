using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DotNetPaint.Common;

namespace DotNetPaint.Services
{
    public static class ShapesPersistence
    {
        public static void SaveToFile(string filePath, IEnumerable<IShape>  shapes)
        {
            using (var fileStream = File.OpenWrite(filePath))
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, shapes);
            }
        }

        public static IList<IShape> LoadFromFile(string filePath)
        {
            using (var fileStream = File.OpenRead(filePath))
            {
                var binaryFormatter = new BinaryFormatter();
                return (IList<IShape>)binaryFormatter.Deserialize(fileStream);
            }
        }
    }
}