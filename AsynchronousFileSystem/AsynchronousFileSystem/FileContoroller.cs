using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchronousFileSystem
{
    public class FileContoroller
    {

        public IObservable<int> SaveUser(string path)
        {
            return Observable.Using(
             () => new StreamReader(new FileStream(path, FileMode.Open)),
             streamReader =>
             {
                 //int 값발행
                 var flag = streamReader.ReadToEnd();
                 if (flag.Split(',')[0].Equals("수학"))
                    return Observable.Never<int>().StartWith(Int32.Parse(flag.Split(',')[2]));             
                 else
                    return Observable.Never<int>().StartWith(Int32.Parse(flag.Split(',')[2]));
             }
            ).FirstAsync();
        }

        public void CreateFile(Studnet studnet)
        {
            string path = @"C:\temp\student.txt";

            if (!File.Exists(path))
                File.Create(path);
            else
                File.WriteAllText(path, studnet.ToString());
        }

        public void ExecuteFileSystem()
        {
           string[] FileNames = { @"c:\\temp\math.txt", @"c:\\temp\korean.txt" };

            var math = SaveUser(FileNames[0]);
            var korean = SaveUser(FileNames[1]);

            //var v = FileNames.ToObservable()
            //    .Select(path => SaveUser(path))
            //    .Zip(SaveUser=> Observable.Start(SaveUser),(user1, user2) => new Studnet(user1., score2);

            var merge = math.
                Zip(korean, (score1, score2) => new Studnet(score1, score2)).
                Take(2);

            using (merge.Subscribe(
                    x => CreateFile(x),
                    () => Console.WriteLine("Completed")))
            {

            }

        }
    }
}
