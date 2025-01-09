
namespace Task2
{
    public class CountByte
    {
        private long _totalSizeDirFile;

        public void CountByteWrite(string path)
        {
            try
            {
                CountByteSize(path);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }

            string[] nameDir = path.Split('\\');
            Console.WriteLine($"Количесвто байт в папке {nameDir[nameDir.Length - 1]}: {_totalSizeDirFile}");
            _totalSizeDirFile = 0;
        }

        private void CountByteSize(string path)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (dirInfo.Exists)
            {
                DirectoryInfo[] dirInfoArray = dirInfo.GetDirectories();
                FileInfo[] fileInfoArray = dirInfo.GetFiles();

                foreach (FileInfo fInfo in fileInfoArray)
                {
                    _totalSizeDirFile += fInfo.Length;
                }

                foreach (DirectoryInfo dInfo in dirInfoArray)
                {
                    CountByteSize(dInfo.FullName);
                }
            }
        }
    }
}
