# SearchAndDestroy

A simple benchmarking application built to measure and compare the performance of different ways to find the **median** of an array of $N$ integers.

This repository contains the source code created as an assignment for the **Algorithms** course, to empirically verify time complexities and observe how theoretical efficiencies translate to practical runtime execution.

---

## 🚀 Features

* **Side-by-Side Comparison:** Evaluates a selection algorithm and three sorting algorithms on the same random integer dataset.
* **Configurable Input Size ($N$):** The array size is entered at runtime, so you can see how each approach scales.
* **Precise Benchmarking:** Uses C#'s `System.Diagnostics.Stopwatch` for execution time tracking.

---

## 📊 Implemented Algorithms

| Algorithm | Approach | Average Time Complexity | Worst Case |
| :--- | :--- | :--- | :--- |
| **Quickselect** | Selects the middle element directly, no full sort | $\mathcal{O}(n)$ | $\mathcal{O}(n^2)$ |
| **Quick Sort** | Sort, then take the median | $\mathcal{O}(n \log n)$ | $\mathcal{O}(n^2)$ |
| **Heap Sort** | Sort, then take the median | $\mathcal{O}(n \log n)$ | $\mathcal{O}(n \log n)$ |
| **Shell Sort** | Sort, then take the median | depends on gap sequence | $\mathcal{O}(n^2)$ |

### Implementation details

* **Quickselect** is iterative and uses a Lomuto partition with the last element as the pivot. It narrows the range until the pivot lands at index `n/2`.
* **Quick Sort** reuses the exact same `Partition` function as Quickselect, so the comparison isolates one difference: recursing into one side versus both.
* **Heap Sort** builds a max-heap and repeatedly extracts the maximum.
* **Shell Sort** uses Shell's original gap sequence: `n/2`, `n/4`, ..., `1`.
* **Median** for the sorted algorithms: the middle element for odd $N$, or the average of the two middle elements for even $N$.

---

## ⚙️ How It Works

1. The program asks for the number of elements, $N$.
2. It fills an array of size $N$ with random integers in the range `0-4095`.
3. It runs each of the four algorithms and times it with `Stopwatch`.
4. It prints the elapsed time of each algorithm in milliseconds.

Example output:

```
Number of elements (N):
1000000
------------------
Finding the median
-------------------
QuickSelect: <time> ms
ShellSort: <time> ms
QuickSort: <time> ms
HeapSort: <time> ms
```

---

## 🛠️ Getting Started

### Prerequisites

* [.NET SDK 6.0](https://dotnet.microsoft.com/) or higher.

### Running the Application

1. **Clone the repository:**
   ```bash
   git clone https://github.com/words10/SearchAndDestoy
   cd SearchAndDestoy
   ```

2. **Compile and run:**
   ```bash
   dotnet build --configuration Release
   dotnet run -c Release
   ```

Use the Release configuration. Debug builds are unoptimized and skew the timings.

---

## 📈 Results

Fill in after running on your machine.

| N | Quickselect (ms) | Shell Sort (ms) | Quick Sort (ms) | Heap Sort (ms) |
| :--- | :--- | :--- | :--- | :--- |
| 10,000 | 0 | 1 | 1 | 2 |
| 100,000 | 2 | 20 | 13 | 26 |
| 1,000,000 | 11 | 263 | 281 | 327 |

**Test machine:** AMD Ryzen 5 7535U, 16 GB RAM, Fedora Linux 44, .NET SDK 10.0.113

---

## 📁 Project Structure

```
SearchAndDestroy/
├── Algorithms/
│   └── Search.cs              # Quickselect, sorts, Median, plus unused Linear/Binary search
├── Program.cs                 # Input handling and benchmark loop
├── SearchAndDestroy.csproj
└── README.md
```

---

## 📝 License

This repository is maintained for educational purposes as part of university coursework.

---

## Notes

* Input values are random integers in `0-4095`, so for large $N$ the array contains many duplicates. This hurts the last-element-pivot partition used by Quickselect and Quick Sort.
* This whole repo is basically a continuation of my previous such project.
* Also Metallica reference.
