using Task1;
using Task2;

namespace Task3
{
    internal class CleaningSize
    {
        private CountByte _count;
        private Cleaning _cleaning;
        public void CleaningSizeWrite(string path)
        {
            _count = new CountByte();
            _cleaning = new Cleaning();

            Console.WriteLine("До очистки:");
            _count.CountByteWrite(path);

            _cleaning.Clean(path);

            Console.WriteLine("\nПосле очистки очистки");
            _count.CountByteWrite(path);
        }
    }
}
