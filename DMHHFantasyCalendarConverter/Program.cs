using System.Text;
using System.Xml;
using System.Xml.Serialization;
using DMHHFantasyCalendarConverter.dmhdto;
using DMHHFantasyCalendarConverter.helper;
using Newtonsoft.Json.Linq;

if (args.Length == 0)
{
    Console.WriteLine("no arguments received - needs json file to convert");
    return;
}

string filename = args[0];

if (!File.Exists(filename))
{
    Console.WriteLine("given filename does not exist - needs json file to convert");
    return;
}

dynamic jsonCalendarData = JObject.Parse(File.ReadAllText(filename, Encoding.UTF8));

DMHRoot root = new DMHRoot();

DMHCalendar dmhCalendar = new DMHCalendar();
root.Calendars.Add(dmhCalendar);

dmhCalendar.Name = jsonCalendarData.name;

dmhCalendar.WeekLength = jsonCalendarData.static_data.year_data.global_week.Count;

foreach (dynamic timespan in jsonCalendarData.static_data.year_data.timespans)
{
    if (timespan.type.ToString().Equals("month"))
    {
        dmhCalendar.Months.Add(new DMHMonth { Name = timespan.name, Days = timespan.length });
    }
}

foreach (dynamic calendarEvent in jsonCalendarData.events)
{
    string name = calendarEvent.name.Value;
    string? month = null;
    string? day = null;
    foreach (dynamic condition in calendarEvent.data.conditions)
    {
        if (condition[0].ToString().Equals("Month"))
        {
            month = condition[2][0].ToString();
        }

        if (condition[0].ToString().Equals("Day"))
        {
            day = condition[2][0].ToString();
        }
    }

    if (month != null && day != null)
    {
        dmhCalendar.Months[int.Parse(month)].SpecialDays.Add(new DMHSpecialDay { Name = name, Day = int.Parse(day) });
    }
}

XmlSerializer serializer = new XmlSerializer(typeof(DMHRoot));

using StringWriter writer = new Utf8StringWriter();
XmlWriter xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings { Indent = true });
serializer.Serialize(xmlWriter, root);
File.WriteAllText(Path.Combine(Path.GetDirectoryName(filename), Path.GetFileNameWithoutExtension(filename) + ".xml"), writer.ToString(),
                  Encoding.UTF8);
Console.Read();