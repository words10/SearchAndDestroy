using SearchAndDestroy.Algorithms;

namespace Program
{
    public class Program
    {
        public static int[] nums;
        public static void Input()
        {
            Console.WriteLine("Number of elements (N):");
            int n = int.Parse(Console.ReadLine());
            nums = new int[n];
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                nums[i] = rand.Next(4096);
        }
        public static void Compare(int[] arr)
        {
            Console.WriteLine("------------------\nFinding the median\n-------------------");
            for(int i = 0; i < 4; i++)
            {
                int[] a = (int[])arr.Clone();
                var watch = System.Diagnostics.Stopwatch.StartNew();
                switch (i)
                {
                    case 0:
                        Search.QucikSelect(a);
                        Console.Write("QuickSelect: ");
                        break;
                    case 1:
                        Console.Write("ShellSort: ");
                        Search.ShellSort(a);
                        Search.Median(a);
                        break;
                    case 2:
                        Console.Write("QuickSort: ");
                        Search.QuickSort(a, 0, a.Length-1);
                        Search.Median(a);
                        break;
                    case 3:
                        Console.Write("HeapSort: ");
                        Search.HeapSort(a);
                        Search.Median(a);
                        break;
                    default:
                        break;
                }
                watch.Stop();
                Console.WriteLine($"{watch.ElapsedMilliseconds} ms");
            }
        }
        public static void Main(string[] args)
        {
            Input();
            Compare(nums);
        }
    }
}