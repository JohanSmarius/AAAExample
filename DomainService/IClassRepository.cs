using Domain;

namespace DomainService;

public interface IClassRepository
{
    public void AddStudentToClass(Class classToAddStudentTo, Student student);
}