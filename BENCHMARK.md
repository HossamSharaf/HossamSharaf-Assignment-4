# String vs. StringBuilder Benchmark Analysis

## 1. BenchmarkDotNet Results

```ini
BenchmarkDotNet v0.13.12, Windows 11
.NET SDK 8.0
  [Host]     : .NET 8.0 (X64 RyuJIT AVX2)
  DefaultJob : .NET 8.0 (X64 RyuJIT AVX2)
```

| Method | Mean | Error | StdDev | Gen0 | Allocated |
| :--- | :---: | :---: | :---: | :---: | :---: |
| **BuildReportUsingString** | 1,450.2 ns | 15.42 ns | 14.42 ns | 0.8545 | 3,584 B |
| **BuildReportUsingStringBuilder** | 420.6 ns | 6.12 ns | 5.73 ns | 0.2136 | 896 B |

*(ملاحظة: استبدل الأرقام في الجدول أعلاه بالأرقام الفعلية التي ظهرت لك في الـ Terminal بعد تشغيل `dotnet run -c Release`، أو أضف لقطة شاشة للنتيجة بالأسفل)*

<!-- ![Benchmark Results](./assets/benchmark.png) -->

---

## 2. Comparison Between `string` and `StringBuilder`

| Feature | `string` Concatenation (`+=`) | `StringBuilder` (`Append` / `AppendLine`) |
| :--- | :--- | :--- |
| **Mutability** | **Immutable:** Cannot be modified once created in memory. | **Mutable:** Modifies an internal character buffer without creating new objects on every append. |
| **Execution Speed** | Slower in loops because it copies existing characters into a newly allocated string each iteration. | Significantly faster in loops as it appends characters directly to an existing buffer. |
| **Time Complexity** | $O(N^2)$ for repeated concatenations inside a loop. | $O(N)$ amortized time for appending items. |
| **Best Use Case** | Small, fixed number of concatenations (e.g., 2 to 4 strings) or simple string interpolation. | Loops, dynamic report generation, or unknown/large numbers of iterations. |

---

## 3. Memory Allocation Observations

* **High Heap Allocations with `string`:** Because `System.String` is immutable, every `+=` operation inside the `for` loop creates a brand-new string object on the Managed Heap and leaves the old string behind for the Garbage Collector (GC). For $N$ sessions with multiple lines each, this results in dozens of intermediate string allocations.
* **Buffer Efficiency with `StringBuilder`:** `StringBuilder` maintains an internal `char[]` buffer. It only allocates new memory if the buffer capacity is exceeded (at which point it doubles its capacity) and once at the very end when `.ToString()` is called.
* **Garbage Collection (Gen0) Impact:** In the benchmark table, `BuildReportUsingString` triggers noticeably higher `Gen0` collections and allocates several times more bytes (`Allocated`) compared to `BuildReportUsingStringBuilder`.

---

## 4. Benchmark Analysis Questions & Answers

### Q1: Why is `StringBuilder` faster and more memory-efficient than `string` inside loops?
Because `string` is immutable in .NET. When concatenating strings inside a loop using `+=`, the runtime must allocate a new string of the combined length, copy all characters from the previous string, and append the new characters. `StringBuilder` avoids this repeated copying by writing directly into a pre-allocated, expandable array of characters in memory.

### Q2: When would `string` concatenation be acceptable or even preferred over `StringBuilder`?
When concatenating a small, known number of strings outside of a loop (e.g., `string fullName = firstName + " " + lastName;` or single-line string interpolation). In these cases, the C# compiler optimizes the expression into a single `String.Concat` call, avoiding the overhead of initializing a `StringBuilder` instance.

### Q3: How can we further optimize `StringBuilder` performance?
By pre-initializing `StringBuilder` with an estimated capacity (e.g., `new StringBuilder(capacity: 512)`). This prevents the internal buffer from having to resize and copy its contents as the report grows.