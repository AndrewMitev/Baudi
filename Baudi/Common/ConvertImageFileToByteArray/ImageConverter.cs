namespace ConvertImageFileToByteArray
{
    using System.IO;

    public static class ImageConverter
    {
        static void Main()
        {
            var filePath = "../../audi log.jpg";

            var result = ConvertFileToByte(filePath);

           // Console.WriteLine(string.Join(" ", result));
             ConvertByteToFile("../../new.jpeg", result);
        }

        public static byte[] ConvertFileToByte(string filename)
        {
            var bytes = File.ReadAllBytes(filename);
            return bytes;
        }

        public static void ConvertByteToFile(string path, byte[] bytes)
        {
            File.WriteAllBytes(path, bytes);
        }
    }
}
