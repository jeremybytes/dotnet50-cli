using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace person_api
{
    public class CSVPeopleProvider : IPeopleProvider
    {
        private List<string> FileData { get; set; }

        public CSVPeopleProvider()
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "People.txt";
            LoadFile(filePath);
        }

        public void LoadFile(string filePath)
        {
            FileData = new List<string>();
            using var reader = new StreamReader(filePath);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                FileData.Add(line);
            }
        }

        public List<Person> GetPeople()
        {
            var people = ParseString(FileData);
            return people;
        }

        public Person GetPerson(int id)
        {
            var people = GetPeople();
            return people?.FirstOrDefault(p => p.Id == id);
        }

        private List<Person> ParseString(List<string> lines)
        {
            var people = new List<Person>();

            foreach (string line in lines)
            {
                try
                {
                    var elems = line.Split(',');
                    var per = new Person()
                    {
                        Id = Int32.Parse(elems[0]),
                        GivenName = elems[1],
                        FamilyName = elems[2],
                        StartDate = DateTime.Parse(elems[3]),
                        Rating = Int32.Parse(elems[4]),
                        FormatString = elems[5],
                    };
                    people.Add(per);
                }
                catch (Exception)
                {
                    // Skip the bad record, log it, and move to the next record
                    // log.write("Unable to parse record", per);
                }
            }
            return people;
        }
    }
}
