using System.Xml.Serialization;

namespace DMHHFantasyCalendarConverter.dmhdto;

public class DMHMonth
{
    [XmlAttribute("name")] public string Name { get; set; }
    [XmlAttribute("days")] public int Days { get; set; }
    [XmlElement("specialday")] public List<DMHSpecialDay> SpecialDays { get; set; } = new List<DMHSpecialDay>();
}