using Domain;

namespace DomainService;

public interface IStudentRepo
{
    public Student GetStudent(int id);
    
    
}