using System.Xml.Serialization;

namespace DMHHFantasyCalendarConverter.dmhdto;

public class DMHCalendar
{
    [XmlAttribute("name")] public string Name { get; set; }
    [XmlAttribute("weeklength")] public int WeekLength { get; set; }
    [XmlElement("month")] public List<DMHMonth> Months { get; set; } = new List<DMHMonth>();
}