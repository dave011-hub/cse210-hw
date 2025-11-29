

public class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    public string GetWritingInformation()
    {
        // Uses getter method from base class since _studentName is private
        string studentName = GetStudentName();
        return $"{_title} by {studentName}";
    }
}
