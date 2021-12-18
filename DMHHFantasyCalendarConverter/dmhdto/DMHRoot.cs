using System.Xml.Serialization;

namespace DMHHFantasyCalendarConverter.dmhdto;

[XmlRoot("root")]
public class DMHRoot
{
    [XmlElement("calendar")] public List<DMHCalendar> Calendars { get; set; } = new List<DMHCalendar>();

    [XmlAttribute("noNamespaceSchemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string NamespaceLocation = "calendar.xsd";
}