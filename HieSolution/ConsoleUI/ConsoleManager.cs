using System;
namespace ConsoleUI
{
    public static class ConsoleManager
    {
        public static void Print<T>(T value)
        {
            T temp;
            temp = value;
            Console.WriteLine(temp);
        }
        public static void CreateBorder(int width, int height)
        {
            for (int i = 0; i < width; i++)
            {
                System.Console.Write("*");
            }
            for (int k = 0; k < height; k++)
            {
                Print("_");
            }
        }
        public static void CreateStatusBorder(int width, string windowname, string[] values = null)
        {
            Console.SetCursorPosition(6, 6);
            for (int i = 0; i < width; i++)
            {
                System.Console.Write("*");
            }
            Print(windowname);
            if (values != null)
                for (int k = 0; k < values.Length; k++)
                {

                    Print("-" + values[k]);
                }
            else
                for (int k = 0; k < 2; k++)
                {

                    Print("-");
                }
        }
        public static void CreateMenu<T>(T[] items)
        {
            int count = 0;
            foreach (T item in items)
            {
                count++;
                Print(count + "-" + item);
            }
        }
    }
    public class ConsoleControl
    {
        private string _name;
        private string _value;
        public ConsoleControl(string name,string value)
        {
            _name = name;
            _value = value;
        }
        public string Value { get { return _value; } set { value = _value; } }
        public virtual void Show() { Console.WriteLine(_name+":"+_value); }
    }
    public class ConsoleLabel:ConsoleControl
    {
       public ConsoleLabel(string name, string value) : base(name,value)
        {
         
        }
        public override void Show()
        {
            base.Show();
        }
    }
}

