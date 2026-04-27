using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;





namespace serializachia

{
    public class Movie
    {
        private string _name;
        private int _duration;
        private int[] _reviews;
        public string Name => _name;
        public int Duration => _duration;
        public double Review
        {
            get
            {
                if (_reviews.Length == 0) return 0;
                return _reviews.Average();
               
            }
        }

        public Movie(string name, int duration)
        {
            _name = name;
            _duration = duration;
            _reviews = new int[0];
        }

        public void Add(int och)
        {
            Array.Resize(ref _reviews, _reviews.Length + 1);
            _reviews[_reviews.Length - 1] = och;
        }
        private bool CompareMovies(Movie movie1, Movie movie2)
        {
            return movie1.Name == movie2.Name &&
                   movie1.Duration == movie2.Duration &&
                   movie1.Review == movie2.Review;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Movie movie = new Movie("Начало", 148);
            movie.Add(9);
            movie.Add(10);
            movie.Add(8);

            var temp = new
            {
                MovieType = movie.GetType().Name,
                movie.Name,
                movie.Duration,
                movie.Review,
            };

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filepath = Path.Combine(folderPath, "Test", "example.json");

            string json = JsonConvert.SerializeObject(temp);
            File.WriteAllText(filepath, json);

            string content = File.ReadAllText(filepath);
            var contentJson = JsonConvert.DeserializeObject<dynamic>(content);



            Movie movie2 = new Movie("Побег из Шоушенка", 142);
            movie2.Add(10);
            movie2.Add(10);
            movie2.Add(9);
            movie2.Add(10);

            var temp2 = new
            {
                MovieType = movie2.GetType().Name,
                movie2.Name,
                movie2.Duration,
                movie2.Review,
            };

            string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filepath2 = Path.Combine(folderPath2, "Test", "example2.json");

            string json2 = JsonConvert.SerializeObject(temp2);
            File.WriteAllText(filepath2, json2);

            string content2 = File.ReadAllText(filepath2);
            var contentJson2 = JsonConvert.DeserializeObject<dynamic>(content2);

            // Сравнение фильмов
            bool result = CompareMovies(movie, movie2);
            Console.WriteLine($"Фильмы одинаковые? {result}");
        }

        private static bool CompareMovies(Movie movie1, Movie movie2)
        {
            return movie1.Name == movie2.Name &&
                   movie1.Duration == movie2.Duration &&
                   movie1.Review == movie2.Review; 
        }


        //            //крч есть:
        //            //File - стат. методы 
        //            //FileInfo - нестат методы (необходим объект)
        //            //Directory - стат. методы
        //            //DirectoryInfo - нестат методы

        //            //РЕКОМЕНДАЦИЯ только стат методы для кр\лаб
        //            //Относительный путь  - (справа от квартиры соседа) 
        //            //относительно файла с кодом 
        //            //"dataset/data.txt" - где-то там же но не там
        //            //"data.txt" - где-то тут


        //            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //            string filePath = Path.Combine(folderPath, "Test", "example.txt");
        //            //Console.WriteLine(folderPath);

        //            //string



        //            // проверка на наличие папки
        //            string folderPath1 = Path.Combine(folderPath, "Test");
        //            string filePath1 = Path.Combine(folderPath1, "example.txt");


        //            string folderPath1Check = Path.GetDirectoryName(filePath1);
        //            string fileNameCheck = Path.GetFileName(filePath1);
        //            string fileextcheck = Path.GetExtension(filePath1);


        //            //string filePath1 = Path.Combine(folderPath1, "example.txt");
        //            if (!Directory.Exists(folderPath1))
        //            {
        //                Directory.CreateDirectory(folderPath1);
        //            }



        //            // проверка на наличие файла
        //            if (!File.Exists(filePath))
        //            {
        //                File.Create(filePath).Close();

        //            }



        //            File.WriteAllText(filePath, "Куру-куру!");
        //            File.WriteAllLines(filePath, new string[] { "Тутти", "Патутти", "Фрутти" });
        //            //если нету файла - создает и записывает
        //            //если он был - записывает


        //            File.WriteAllText(filePath, "");
        //            File.AppendAllLines(filePath, new string[] { "Кактус", "Глаголит", "Истину\r" });
        //            File.AppendAllText(filePath, "Прислушайтесь\r");
        //            File.AppendAllText(filePath1, "      _  _\r\n  _  / \\/ \\  _\r\n / \\/  .  .\\/ \\\r\n \\.  .  .  .  /\r\n  \\  .  .  . /\r\n   \\  .  .  /\r\n    \\  .  /\r\n     |||||\r\n     |||||\r\n");

        //            string content = File.ReadAllText(filePath);
        //            string[] lines = File.ReadAllLines(filePath);
        //            foreach (string line in lines) { Console.WriteLine(line); }

        //            File.Delete(filePath);
        //        }
    }

        //private bool CompareMovies(Movie movie1, Movie movie2)
        //{
        //    return movie1.Name == movie2.Name &&
        //           movie1.Duration == movie2.Duration &&
        //           movie1.Review==movie2.Review;
        //}
    }
