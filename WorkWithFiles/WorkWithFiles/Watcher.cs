using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;
using System.Threading;

namespace WorkWithFiles
{
    public class Watcher
    {
        public void Run()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = @"C:\Users\user\Desktop\Example";
                watcher.NotifyFilter = NotifyFilters.LastAccess
                                     | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;
                watcher.Filter = "*.txt";
                watcher.Created += OnChanged;
                watcher.EnableRaisingEvents = true;
                Console.WriteLine("Press 'q' to quit the sample.");
                while (Console.Read() != 'q') ;
            }
        }

        private async static void OnChanged(object source, FileSystemEventArgs e)
        {
            TextHandler tx = new TextHandler() { Path = e.FullPath };
            var dictionary = await tx.GetAlfaDictionary();

            Thread myThread = new Thread(AddInAlfabeticFile);
            myThread.Start(dictionary);
            string path1 = @"C:\Users\user\Desktop\Output.txt";
            using (StreamWriter sw1 = new StreamWriter(path1, true, Encoding.UTF8))
            {
                sw1.WriteLine($"File {e.Name} was created in {File.GetCreationTime($"{e.FullPath}").ToString()}");
                foreach (var item in dictionary)
                {
                    await sw1.WriteLineAsync($"{item.Key} - {item.Value.ToString()}");
                    Thread.Sleep(100);
                }
            }
        }

        public async static void AddInAlfabeticFile(object obj)
        {
            Dictionary<string, int> dictionary = (Dictionary<string, int>)obj;
            string path = @"C:\Users\user\source\repos\WorkWithFiles\Files\AlphabeticalWords.txt";
            using (StreamWriter sw1 = new StreamWriter(path, true, Encoding.UTF8))
            {
                foreach (var item in dictionary.OrderBy(KeyValuePair => KeyValuePair.Key))
                {
                    await sw1.WriteLineAsync($"{item.Key} - {item.Value.ToString()}");
                    Thread.Sleep(100);
                }
            }
        }
    }
}

