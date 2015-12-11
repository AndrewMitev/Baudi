namespace ConvertImageFileToByteArray
{
    using System.IO;

    public class ImageConverter
    {
        static void Main()
        {
            var filePath = "../../audi log.jpg";

            var result = ConvertFileToByte(filePath);

           // Console.WriteLine(string.Join(" ", result));
             ConvertByteToFile("../../new.jpeg", result);
        }

        private static byte[] ConvertFileToByte(string filename)
        {
            var bytes = File.ReadAllBytes(filename);
            return bytes;
        }

        private static void ConvertByteToFile(string path, byte[] bytes)
        {
            File.WriteAllBytes(path, bytes);
        }
    }
}
