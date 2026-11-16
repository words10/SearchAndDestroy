namespace SearchAndDestroy.Algorithms
{
    public class Search
    {
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static int Linear(int[] arr, int x)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == x)
                    return i;
            return -1;
        }

        public static int Partition(int[] arr, int l, int r) 
        {
            int pivot = arr[r];
            int i = l - 1;
            for(int j = l; j < r; j++)
            {
                if(arr[j] < pivot)
                {
                    i++;
                    Swap(ref arr[i], ref arr[j]);
                }
            }
            Swap(ref arr[i+1], ref arr[r]);
            return i + 1;
        }
        public static int QucikSelect(int[] arr) 
        {
            int n = arr.Length;
            int k = n/2, l = 0, r = n-1;
            while(l < r)
            {
                int pivot = Partition(arr, l , r);
                if(pivot == k)
                    break;
                else if(pivot < k)
                    l = pivot + 1;
                else
                    r = pivot - 1;
            }
            return arr[k];
        }
        public static double Median(int[] arr)
        {
            int n = arr.Length;
            int k = n / 2;
            if(n % 2 == 0)
                return (arr[k] + arr[k-1]) / 2.0;
            return arr[k];
        }
        public static int BinarySearch(int[] arr, int x)
        {
            int left = 0, right = arr.Length - 1;
            while(left <= right)
            {
                int mid = (left + right)/2;
                if(arr[mid] == x)
                    return mid;
                if(arr[mid] < x)
                    left = mid + 1;
                else
                    right = mid;
            }
            return -1;
        }
         public static void ShellSort(int[] arr)
        {
            int n = arr.Length;
            for(int gap = n/2; gap > 0; gap /=2)
            {
                for(int i = gap; i < n; i++)
                {
                    int k = arr[i];
                    int j = i;
                    while (j >= gap && arr[j - gap] > k)
                    {
                        arr[j] = arr[j - gap];
                        j-=gap;
                    }
                    arr[j] = k;
                }
            }
        }
        public static void HeapSort(int[] arr)
        {
            int n = arr.Length;
            for(int i = n/2-1; i>=0; i--)
                Heapify(arr,n,i);
            
            for(int i = n-1; i > 0; i--)
            {
                Swap(ref arr[0], ref arr[i]);
                Heapify(arr, i, 0);
            }
        }
        private static void Heapify(int[] arr, int n, int i)
        {
            int max = i;
            int left = 2*i + 1;
            int right = 2*i + 2;

            if(left < n && arr[left] > arr[max])
                max = left;
            if(right < n && arr[right] > arr[max])
                max = right;
            
            if(max != i) {
                Swap(ref arr[i], ref arr[max]);
                Heapify(arr, n, max);
            }
        }
        public static void QuickSort(int[] arr, int left, int right)
        {
            if(left < right)
            {
                int mid = Partition(arr, left, right);

                QuickSort(arr, left, mid - 1);
                QuickSort(arr, mid + 1, right);
            }
        }
    }
}
