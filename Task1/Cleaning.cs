
namespace Task1
{
    public class Cleaning
    {
        private string _path;
        private DirectoryInfo _dirInfo;
        private FileInfo _fileInfo;
        private DirectoryInfo[] _dirInfoArray;
        private FileInfo[] _fileInfoArray;
        private const int _timerMinuts = 30;


        public void Clean(string path)
        {
            _path = path;
            while (true)
            {
                _dirInfo = new DirectoryInfo(_path);
                if (!_dirInfo.Exists)
                {
                    Console.WriteLine("Такого пути не существует. Введите корректный путь до папки:");
                    _path = Console.ReadLine();
                }
                else
                {
                    break;
                }
            }
            _dirInfoArray = _dirInfo.GetDirectories();
            _fileInfoArray = _dirInfo.GetFiles();
            try
            {
                DirFileDelete(_dirInfoArray);
                DirFileDelete(_fileInfoArray);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }

        }

        private void DirFileDelete<T>(T[] array) where T : FileSystemInfo
        {
            foreach (T dirFileInfo in array)
            {
                string path = $"{_path}\\{dirFileInfo.Name}";
                int timeMinut = (int)(DateTime.Now - File.GetLastWriteTime(path)).TotalMinutes;
                if (timeMinut > _timerMinuts && dirFileInfo is DirectoryInfo)
                {
                    DirectoryInfo directoryInfo = dirFileInfo as DirectoryInfo;
                    directoryInfo.Delete(true);
                    Console.WriteLine($"Директория {directoryInfo.Name} удалена");
                }
                else if (timeMinut > _timerMinuts && dirFileInfo is FileInfo)
                {
                    FileInfo fileInfo = dirFileInfo as FileInfo;
                    fileInfo.Delete();
                    Console.WriteLine($"Файл {fileInfo.Name} удален");
                }
            }
        }
    }
}
