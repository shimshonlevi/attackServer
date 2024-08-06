using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace attackServer1
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {

            string result = await GetDataAsync();
            Console.WriteLine(result);
          

            string FileResult = "C:\\Users\\User\\source\\repos\\attackServer1\\FileExemple.txt";
            string content = await ReadFileAsync(FileResult);
            Console.WriteLine(content);
            

            Task<string> TaskA = GetDataFromServicAAsync();
            Task<string> TaskB = GetDataFromServicBAsync();

            await Task.WhenAll(TaskA, TaskB);

            Console.WriteLine(TaskA.Result);
            Console.WriteLine(TaskB.Result);
            Console.ReadLine();

        }
        public static async Task<string> GetDataAsync()
        {
            await Task.Delay(2000);
            return "Recvice Data";
        }

        public static async Task<string> ReadFileAsync(string filePath)
        {
            string result = await Task.Run(() => File.ReadAllText(filePath));
            return result;
        }

        public static async Task<string> GetDataFromServicAAsync()
        {
            await Task.Delay(1000);
            return "Data Result A";

        }
        public static async Task<string> GetDataFromServicBAsync()
        {
            await Task.Delay(1000);
            return "Data Result A";
        }
    }
}
