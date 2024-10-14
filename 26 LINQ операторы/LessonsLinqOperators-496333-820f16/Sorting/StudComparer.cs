
internal class StudComparer : IComparer<Student>
{
    int IComparer<Student>.Compare(Student? x, Student? y)
    {
        return x.Name.CompareTo(y.Name);
    }
}