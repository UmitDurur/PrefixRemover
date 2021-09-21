using System;
using System.IO;

namespace PrefixRemover
{
    class Program
    {
        static void Main(string[] args)
        {
            int temizlenensayi = 0;
            Console.WriteLine("İsmin standart kısmının başlangıcı (3 karakter tavsiyedir.): ");
            string newPrefix = Console.ReadLine();
            Console.Clear();

            int prefixLenght = newPrefix.Length;
            Console.WriteLine("{0}'a kadar silmek için 1:\r\n{0}'ı silmek için 2:", newPrefix);
            char process = Console.ReadKey().KeyChar;

            Console.Clear();

            DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            FileInfo[] files = directoryInfo.GetFiles("*.*");
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Name.Contains("PrefixRemover"))
                    continue;
                int kesilecek = process=='1'?files[i].Name.IndexOf(newPrefix):prefixLenght;
                if (kesilecek > 0)
                {
                    File.Move(files[i].FullName, files[i].DirectoryName + "\\" + files[i].Name.Substring(kesilecek));
                    temizlenensayi++;
                }
            }
            Console.WriteLine(temizlenensayi.ToString() + " tane isim etkilendi.");
            Console.ReadKey();
        }
    }
}
