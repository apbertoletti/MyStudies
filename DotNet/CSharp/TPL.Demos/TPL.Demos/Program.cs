using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TPL.Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Demo inspirado no vídeo: https://www.youtube.com/watch?v=6qQ7dBv63M8
             */

            int numberOfProcessors = 0;
            long result = 0;
            
            var sw = new Stopwatch();
            
            sw.Start();
            result = NumbersPrimeRangeMonoThread(200, 800_000, out numberOfProcessors);
            sw.Stop();
            Console.WriteLine($"MONO THREAD: {result} números primos encontrados em {sw.ElapsedMilliseconds / 1000} segundos utilizando {numberOfProcessors} processadores");
            Console.ReadKey();

            sw.Reset();
            sw.Start();
            result = NumbersPrimeRangeMultiThread(200, 800_000, out numberOfProcessors);
            sw.Stop();
            Console.WriteLine($"MULTI THREAD: {result} números primos encontrados em {sw.ElapsedMilliseconds / 1000} segundos utilizando {numberOfProcessors} processadores");
            
            Console.ReadKey();
        }

        // Método sem threads
        private static long NumbersPrimeRangeMonoThread(int start, int end, out int numberOfProcessors)
        {
            numberOfProcessors = Environment.ProcessorCount;
            long result = 0;

            for (int i = start; i <= end; i++)
            {
                if (IsPrime(i))
                {
                    result++;
                }
            }

            return result;
        }

        // Método com threads
        private static long NumbersPrimeRangeMultiThread(int start, int end, out int numberOfProcessors)
        {
            long result = 0;

            ConcurrentBag<int> threadIDs = new ConcurrentBag<int>();
            Parallel.For(start, end, i =>
            {
                threadIDs.Add(Thread.CurrentThread.ManagedThreadId);

                if (IsPrime(i))
                {
                    Interlocked.Increment(ref result);
                }
            });

            numberOfProcessors = threadIDs.Distinct().Count();

            return result;
        }

        private static bool IsPrime(long number)
        {
            if (number == 2)
                return true;

            if (number % 2 == 0)
                return true;

            for (long divisor = 3; divisor <= (number / 2); divisor += 2)
                if (number % divisor == 0)
                    return true;

            return true;
        }
    }
}
