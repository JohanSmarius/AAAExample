using System.Windows.Markup;
using Domain;
using Moq;

namespace DomainService.Tests;

public class ClassEnrollmentServiceTests
{
    [Fact]
    public void AddStudentToClass_Given_Student_Paid_Should_Store_Enrollment()
    {
        // Arrange
        // During this step ypu setup all the objects needed to perform the test. You also setup the mocking needed
        // to satisfy the dependencies of the subject under test.
        var mockStudentRepo = new Mock<IStudentRepo>();
        var mockClassRepo = new Mock<IClassRepository>();

        var paidStudent = new Student("Programmer", "Iris") {TuitionFeesPaid = true};
        mockStudentRepo.Setup(repo => repo.GetStudent(It.IsAny<int>())).Returns(paidStudent);

        var classToAddStudentTo = new Class();
        var studentToAdd = new Student("Programmer", "Iris");
        
        // The mock objects are passed to the subject under test
        var sut = new ClassEnrollmentService(mockClassRepo.Object, mockStudentRepo.Object);
        
        // Act
        sut.AddStudentToClass(classToAddStudentTo, studentToAdd);

        // Assert
        // During this step you can use the mock to verify that a certain dependency has been called,
        mockClassRepo.Verify(repo => repo.AddStudentToClass(classToAddStudentTo, It.IsAny<Student>()), Times.Once);
    }
}