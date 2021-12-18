using System.Xml.Serialization;

namespace DMHHFantasyCalendarConverter.dmhdto;

public class DMHSpecialDay
{
    [XmlAttribute("name")] public string Name { get; set; }
    [XmlAttribute("day")] public int Day { get; set; }
}