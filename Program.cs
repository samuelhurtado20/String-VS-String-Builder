// See https://aka.ms/new-console-template for more information
using StringVSstringBuilder;
using Newtonsoft.Json;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

using StreamReader r = new StreamReader(@".\people.json");
People person = new People();
string json = r.ReadToEnd();

List<People> people = JsonConvert.DeserializeObject<List<People>>(json) ?? new();

int i = 0;

while (i < 10)
{
    if (i > 0) people.AddRange(people);

    Stopwatch timeMeasure = new();

    #region TEST Append With String. example: fullname += person.FirstName + " " + person.LastName + ", ";
    //TestAppendWithString(timeMeasure, people);
    #endregion

    #region TEST Append With String format. example: fullname = String.Format($"{0} {1} {2}", fullname, person.FirstName, person.LastName);
    //TestAppendWithStringFormat(timeMeasure, people);
    #endregion

    #region TEST Append With String Interpolation. example: fullname = $"{fullname} {person.FirstName} {person.LastName}, ";
    //TestAppendWithStringInterpolation(timeMeasure, people);
    #endregion

    #region TEST Append With String Builder. example: fullname.AppendLine(person.FirstName).Append(person.LastName).Append(", ");
    TestAppendWithStringBuilder(timeMeasure, people);
    #endregion

    i++;
}

Console.WriteLine("Stop");

void TestAppendWithString(Stopwatch timeMeasure, List<People> people)
{
    timeMeasure.Start();
    person.AppendWithString(people);
    timeMeasure.Stop();
    Console.WriteLine($"TEST Append With String. Elements: {people.Count}. Time: {timeMeasure.Elapsed.TotalMilliseconds} ms");
}

void TestAppendWithStringFormat(Stopwatch timeMeasure, List<People> people)
{
    timeMeasure.Start();
    person.AppendWithStringFormat(people);
    timeMeasure.Stop();
    Console.WriteLine($"TEST Append With String format. Elements: {people.Count}. Time: {timeMeasure.Elapsed.TotalMilliseconds} ms");
}

void TestAppendWithStringInterpolation(Stopwatch timeMeasure, List<People> people)
{
    timeMeasure.Start();
    person.AppendWithStringInterpolation(people);
    timeMeasure.Stop();
    Console.WriteLine($"TEST Append With String Interpolation. Elements: {people.Count}. Time: {timeMeasure.Elapsed.TotalMilliseconds} ms");
}

void TestAppendWithStringBuilder(Stopwatch timeMeasure, List<People> people)
{
    timeMeasure.Start();
    person.AppendWithStringBuilder(people);
    timeMeasure.Stop();
    Console.WriteLine($"TEST Append With String Builder. Elements: {people.Count}. Time: {timeMeasure.Elapsed.TotalMilliseconds} ms");
}