internal class Student : IComparable<Student>
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int GroupId { get; set; }

    int IComparable<Student>.CompareTo(Student? other)
    {
        return this.StudentId.CompareTo(other.StudentId);
    }
}