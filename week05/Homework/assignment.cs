

public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Getter method so derived classes can use the name
    public string GetStudentName()
    {
        return _studentName;
    }

    public string GetSummary()
    {
        return _studentName + " - " + _topic;
    }
}
