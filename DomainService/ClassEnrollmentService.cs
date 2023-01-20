using System.Data;
using Domain;

namespace DomainService;

public class ClassEnrollmentService
{
    private readonly IClassRepository _classRepository;
    private readonly IStudentRepo _studentRepo;

    public ClassEnrollmentService(IClassRepository classRepository, IStudentRepo studentRepo)
    {
        _classRepository = classRepository;
        _studentRepo = studentRepo;
    }

    public void AddStudentToClass(Class classToAddStudentTo, Student studentToAdd)
    {
        // Performs all kind of checks

        // Fetch the current status from the db to allow further checks
        var freshInformtion = _studentRepo.GetStudent(studentToAdd.Id);
        
        // Perform some more checks
        if (!freshInformtion.TuitionFeesPaid)
        {
            throw new DomainServiceException();
        }

        // Everything is ok, so add the student
        _classRepository.AddStudentToClass(classToAddStudentTo, freshInformtion);
    }
}