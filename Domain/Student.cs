namespace Domain;

public class Student
{
    public Student(string lastName, string firstName)
    {
        LastName = lastName;
        FirstName = firstName;
    }

    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public bool TuitionFeesPaid { get; set; }
}