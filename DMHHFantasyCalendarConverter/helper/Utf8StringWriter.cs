using System.Text;

namespace DMHHFantasyCalendarConverter.helper;

public class Utf8StringWriter : StringWriter
{
    public override Encoding Encoding
    {
        get
        {
            return Encoding.UTF8;
        }
    }
}