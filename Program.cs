using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// using linq.features;
using Cars;

namespace linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile(@"fuel.csv");
            var query = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016).OrderByDescending(c => c.Combined).ThenBy(c => c.Name).Take(10);

            foreach(var car in query){
                Console.WriteLine($"{car.Manufacturer} : {car.Name} : {car.Combined}");
            }
        }

        private static List<Car> ProcessFile(string path) {

            return File.ReadAllLines(path)
            .Skip(1)
            .Where(line => line.Length > 1)
            .ToCar()
            .ToList();
        }



        // private void runLinqFeatures() {
        //     Employee[] devs = new Employee[] {
        //         new Employee(){Id = 1, Name = "Scott"},
        //         new Employee(){Id = 2, Name = "Chris"}
        //     };

        //     IEnumerable<Employee> sales = new List<Employee>(){
        //         new Employee(){Id = 3, Name = "Alex"}
        //     };

        //     Console.WriteLine($"count: {sales.Count()}");

        //     foreach(var person in sales) {
        //         Console.WriteLine($"{person.Name} : {person.Id}");
        //     }
        // }

        // private void executelinqvsnonlinqexample() {
        //     var path = @"../..//Desktop/";
        //     showLargeFilesWithoutLinq(path);
        //     Console.WriteLine("****");
        //     showLargeFilesWithtLinq(path);
        // }

        // private static void showLargeFilesWithtLinq(string path)
        // {
        //     var query = from file in new DirectoryInfo(path).GetFiles() 
        //                 orderby file.Length descending
        //                 select file;

        //     foreach(var file in query.Take(5)){
        //         Console.WriteLine($"{file.Name, -20} : {file.Length, 10:N0}");
        //     }
        // }

        // private static void showLargeFilesWithoutLinq(string path)
        // {
        //     DirectoryInfo di = new DirectoryInfo(path);
        //     var files = di.GetFiles();

        //     Array.Sort(files, new FileInfoComparer());
        //     // foreach(var file in files) {
        //     foreach(int i in Enumerable.Range(0, 5)){
        //         var file = files[i];
        //         Console.WriteLine($"{file.Name, -20} : {file.Length, 10:N0}");
        //     }
        // }

        // private class FileInfoComparer : IComparer<FileInfo> {
        //     public int Compare(FileInfo x, FileInfo y)
        //     {
        //         return y.Length.CompareTo(x.Length);
        //     }
        // }
    }

    public static class CarExtensions {
        public static IEnumerable<Car> ToCar(this IEnumerable<string> source) {
            foreach(var line in source) {
                var columns = line.Split(',');

                yield return new Car {
                    Year = int.Parse(columns[0]),
                    Manufacturer = columns[1],
                    Name = columns[2],
                    Displacement = double.Parse(columns[3]),
                    Cylinders = int.Parse(columns[4]),
                    City = int.Parse(columns[5]),
                    Highway = int.Parse(columns[6]),
                    Combined = int.Parse(columns[7])
                };
            }
        }
    }
}