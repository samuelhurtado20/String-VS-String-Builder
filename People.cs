using Newtonsoft.Json;
using System.Text;

namespace StringVSstringBuilder
{
    internal class People
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullNameWithString { get; set; }
        public StringBuilder? FullNameWithStringBuilder { get; set; }

        public IEnumerable<People> GetAll()
        {
            using StreamReader r = new StreamReader("@people.json");
            People person = new People();
            string json = r.ReadToEnd();

            List<People> people = JsonConvert.DeserializeObject<List<People>>(json) ?? new();
            return people;
        }

        public string AppendWithString(IEnumerable<People> people)
        {
            string fullname = string.Empty;
            foreach (var person in people)
            {
                fullname += person.FirstName + " " + person.LastName + ", ";
            }
            return fullname;
        }

        public string AppendWithStringFormat(IEnumerable<People> people)
        {
            string fullname = string.Empty;
            foreach (var person in people)
            {
                fullname = String.Format($"{0} {1} {2}", fullname, person.FirstName, person.LastName);
            } 
            return fullname;
        }

        public string AppendWithStringInterpolation(IEnumerable<People> people)
        {
            string fullname = string.Empty;
            foreach (var person in people)
            {
                fullname = $"{fullname} {person.FirstName} {person.LastName}, ";
            }
            return fullname;
        }

        public string AppendWithStringBuilder(IEnumerable<People> people)
        {
            StringBuilder fullname = new();
            foreach (var person in people)
            {
                fullname.AppendLine(person.FirstName).Append(person.LastName).Append(", ");
            }
            return fullname.ToString();
        }
    }
}
