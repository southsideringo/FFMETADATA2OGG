using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;


namespace FFMETADATA2OGG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Path: ");
            string path = Console.ReadLine();
            
            string[] fileArray = Directory.GetFiles(path, "*chapters.txt");

            /*foreach (string textfile in fileArray)
            {
                Console.WriteLine(textfile);
            }*/
            
            foreach (string testfile in fileArray)
            {
                List<string> testfileContent = new List<string>();

                string line = "";
                int count = 0;
            
                System.IO.StreamReader file = new System.IO.StreamReader(testfile);
                string pattern = "(?m)^START.*";
         
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (line.Length > 0)
                    {
                        Match match = Regex.Match(line, pattern);

                        if (match.Success)
                        {
                            
                            testfileContent.Add(line);
                            //Console.WriteLine(line);
                        
                        }
                    }
                count = count + 1;
                }

                List<string> newList = new List<string>();
                int i = 1;
                foreach (string aline in testfileContent)
                {
                    string pattern2 = ".*START=(\\d+)";
                    string replacement = "$1";
                    Regex rgx = new Regex(pattern2);
                    string result = rgx.Replace(aline, replacement);
                    int span = Int32.Parse(result);
                    span = span / 90000;
                    TimeSpan interval;
                    interval = TimeSpan.FromSeconds(span);
                
                    string fin_interval = interval.ToString(format: "hh\\:mm\\:ss\\.fff");
                    newList.Add($"CHAPTER0{i}={fin_interval}");
                    newList.Add($"CHAPTER0{i}NAME=Chapter {i}");
                    i++;
                }
                string new_file = testfile.Replace(".txt",".ogg.txt");
            
                File.WriteAllLines(new_file, newList, Encoding.UTF8);
            }
            

        }
    }
}
