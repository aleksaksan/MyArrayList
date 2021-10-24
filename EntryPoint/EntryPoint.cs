using System;
using MyArrayList;

namespace EntryPoint
{
    class EntryPoint
    {
        
        static void Main(string[] args)
        {
            ArrayList<int> arr = new ArrayList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
            //Console.WriteLine(arr.Length);
            arr.AddFirst(new ArrayList<int>(new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, }));
            arr.RemoveFirstMultiple(13);
            ////arr.AddLast(1);
            ////arr.AddLast(2);
            //arr.Print();
            //Console.ReadKey();
            //arr.AddFirst(3);
            //arr.Print();
            //arr.AddAt(2, 4);
            //arr.Print();
            //arr.RemoveLast();
            //arr.Print();
            //arr.RemoveFirst();
            //arr.Print();
            //Console.ReadKey();
            Type t = arr.GetType();
            foreach (var method in t.GetMethods())
            {
                Console.WriteLine(method.Name);
            }

        }
    }
}
