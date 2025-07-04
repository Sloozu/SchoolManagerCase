using SchoolManager.Models;
using SchoolManager.Models.Db;
using SchoolManager.Models.Diff;
using SchoolManager.Services;

namespace SchoolManager.Tests;

/**
 * These tests are meant to test the PupilClassManager class.
 */
public class PupilClassManagerTests
{
    [Fact]
    public void Assign_New_Pupils_To_Classes()
    {
        // Arrange
        State initialState = new State()
        {
            Pupils = new List<Pupil>() {
                new Pupil() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                },
                new Pupil() {
                    Id = 2,
                    Name = "Portauw Pieter"
                },
                new Pupil() {
                    Id = 3,
                    Name = "Maekelbergh Thibault",
                },
                new Pupil() {
                    Id = 4,
                    Name = "Petrescu Adrian-Mihai"
                },
                new Pupil() {
                    Id = 5,
                    Name = "De Vos Andres"
                },
                new Pupil() {
                    Id = 6,
                    Name = "Demaecker Caro",
                },
                new Pupil() {
                    Id = 7,
                    Name = "Goderis Jonas"
                },
                new Pupil() {
                    Id = 8,
                    Name = "Huyghe Lowie"
                },
                new Pupil () {
                    Id = 9,
                    Name = "Cornille Lukas"
                },
                new Pupil () {
                    Id = 10,
                    Name = "Nanescu Maria"
                },
                new Pupil () {
                    Id = 11,
                    Name = "Lasseel Siem"
                },
                new Pupil() {
                    Id = 12,
                    Name = "Spanhove Stijn"
                },
                new Pupil() {
                    Id = 13,
                    Name = "Verween Stijn"
                },
                new Pupil() {
                    Id = 14,
                    Name = "Dekiere Thomas"
                },
                new Pupil() {
                    Id = 15,
                    Name = "Akin Özgür"
                }
            },
            Classes = new List<Class>() {
                new Class() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 5,
                },
                new Class() {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 20,
                }
            }
        };
        Request incomingRequest = new Request()
        {
            Assignments = new List<Assignment>() {
                new Assignment() {
                    PupilId = 1,
                    ClassId = 1
                },
                new Assignment() {
                    PupilId = 2,
                    ClassId = 1
                },
                new Assignment() {
                    PupilId = 3,
                    ClassId = 1
                },
                new Assignment() {
                    PupilId = 4,
                    ClassId = 1
                },
                new Assignment() {
                    PupilId = 5,
                    ClassId = 1
                },
                new Assignment() {
                    PupilId = 6,
                    ClassId = 2
                },
                new Assignment() {
                    PupilId = 7,
                    ClassId = 2
                },
                new Assignment() {
                    PupilId = 8,
                    ClassId = 2
                },
                new Assignment() {
                    PupilId = 9,
                    ClassId = 2
                },
                new Assignment() {
                    PupilId = 10,
                    ClassId = 2
                },
                new Assignment() {
                    PupilId = 11,
                    ClassId = 2
                },
                new Assignment() {
                    PupilId = 12,
                    ClassId = 2
                },
                new Assignment() {
                    PupilId = 13,
                    ClassId = 2
                },
                new Assignment() {
                    PupilId = 14,
                    ClassId = 2
                },
                new Assignment() {
                    PupilId = 15,
                    ClassId = 2
                }
            }
        };

        // Act
        State newState = PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest);
        var diff = PupilClassManager.Diff(initialState, newState);

        // Assert
        State expectedState = new State()
        {
            Pupils = new List<Pupil>()
            {
                new Pupil() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 5
                },
                new Pupil() {
                    Id = 2,
                    Name = "Portauw Pieter",
                    ClassName = "First grade",
                    FollowUpNumber = 4
                },
                new Pupil() {
                    Id = 3,
                    Name = "Maekelbergh Thibault",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new Pupil() {
                    Id = 4,
                    Name = "Petrescu Adrian-Mihai",
                    ClassName = "First grade",
                    FollowUpNumber = 3
                },
                new Pupil() {
                    Id = 5,
                    Name = "De Vos Andres",
                    ClassName = "First grade",
                    FollowUpNumber = 1
                },
                new Pupil() {
                    Id = 6,
                    Name = "Demaecker Caro",
                    ClassName = "Second grade",
                    FollowUpNumber = 4
                },
                new Pupil() {
                    Id = 7,
                    Name = "Goderis Jonas",
                    ClassName = "Second grade",
                    FollowUpNumber = 5
                },
                new Pupil() {
                    Id = 8,
                    Name = "Huyghe Lowie",
                    ClassName = "Second grade",
                    FollowUpNumber = 6
                },
                new Pupil() {
                    Id = 9,
                    Name = "Cornille Lukas",
                    ClassName = "Second grade",
                    FollowUpNumber = 2
                },
                new Pupil() {
                    Id = 10,
                    Name = "Nanescu Maria",
                    ClassName = "Second grade",
                    FollowUpNumber = 8
                },
                new Pupil() {
                    Id = 11,
                    Name = "Lasseel Siem",
                    ClassName = "Second grade",
                    FollowUpNumber = 7
                },
                new Pupil() {
                    Id = 12,
                    Name = "Spanhove Stijn",
                    ClassName = "Second grade",
                    FollowUpNumber = 9
                },
                new Pupil() {
                    Id = 13,
                    Name = "Verween Stijn",
                    ClassName = "Second grade",
                    FollowUpNumber = 10
                },
                new Pupil() {
                    Id = 14,
                    Name = "Dekiere Thomas",
                    ClassName = "Second grade",
                    FollowUpNumber = 3
                },
                new Pupil() {
                    Id = 15,
                    Name = "Akin Özgür",
                    ClassName = "Second grade",
                    FollowUpNumber = 1
                }
            },
            Classes = new List<Class>()
            {
                new Class() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 5,
                    AmountOfPupils = 5
                },
                new Class() {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 20,
                    AmountOfPupils = 10
                }
            }
        };
        var expectedDiff = (
            new List<UpdatedPupil> {
                new UpdatedPupil() { PupilId = 1, ClassName = "First grade", FollowUpNumber = 5 },
                new UpdatedPupil() { PupilId = 2, ClassName = "First grade", FollowUpNumber = 4 },
                new UpdatedPupil() { PupilId = 3, ClassName = "First grade", FollowUpNumber = 2 },
                new UpdatedPupil() { PupilId = 4, ClassName = "First grade", FollowUpNumber = 3 },
                new UpdatedPupil() { PupilId = 5, ClassName = "First grade", FollowUpNumber = 1 },
                new UpdatedPupil() { PupilId = 6, ClassName = "Second grade", FollowUpNumber = 4 },
                new UpdatedPupil() { PupilId = 7, ClassName = "Second grade", FollowUpNumber = 5 },
                new UpdatedPupil() { PupilId = 8, ClassName = "Second grade", FollowUpNumber = 6 },
                new UpdatedPupil() { PupilId = 9, ClassName = "Second grade", FollowUpNumber = 2 },
                new UpdatedPupil() { PupilId = 10, ClassName = "Second grade", FollowUpNumber = 8 },
                new UpdatedPupil() { PupilId = 11, ClassName = "Second grade", FollowUpNumber = 7 },
                new UpdatedPupil() { PupilId = 12, ClassName = "Second grade", FollowUpNumber = 9 },
                new UpdatedPupil() { PupilId = 13, ClassName = "Second grade", FollowUpNumber = 10 },
                new UpdatedPupil() { PupilId = 14, ClassName = "Second grade", FollowUpNumber = 3 },
                new UpdatedPupil() { PupilId = 15, ClassName = "Second grade", FollowUpNumber = 1 }
            },
            new List<UpdatedClass> {
                new UpdatedClass() { ClassId = 1, AmountOfPupils = 5 },
                new UpdatedClass() { ClassId = 2, AmountOfPupils = 10 }
            }
        );

        Assert.Equivalent(expectedState, newState, strict: true);
        Assert.Equal(5, newState.Classes[0].AmountOfPupils);
        Assert.Equal(10, newState.Classes[1].AmountOfPupils);
        Assert.Equal(5, newState.Pupils.First(p => p.Name == "Vermaercke Tim").FollowUpNumber);
        Assert.Equal(5, newState.Pupils.First(p => p.Name == "Goderis Jonas").FollowUpNumber);
        Assert.Equivalent(expectedDiff, diff, strict: true);
    }

    [Fact]
    public void Move_Some_Pupils_From_One_Class_To_Another()
    {
        // Arrange
        State initialState = new State()
        {
            Pupils = new List<Pupil>()
            {
                new Pupil() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new Pupil() {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "First grade",
                    FollowUpNumber = 1
                }
            },
            Classes = new List<Class>()
            {
                new Class() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 2
                },
                new Class() {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 1,
                    AmountOfPupils = 0
                }
            }
        };
        Request incomingRequest = new Request()
        {
            Assignments = new List<Assignment>()
            {
                new Assignment() {
                    PupilId = 1,
                    ClassId = 2
                }
            }
        };

        // Act
        State newState = PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest);
        var diff = PupilClassManager.Diff(initialState, newState);

        // Assert
        State expectedState = new State()
        {
            Pupils = new List<Pupil>() {
                new Pupil()
                {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "Second grade",
                    FollowUpNumber = 1
                },
                new Pupil()
                {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "First grade",
                    FollowUpNumber = 1
                }
            },
            Classes = new List<Class>() {
                new Class()
                {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",

                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 1
                },
                new Class()
                {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 1,
                    AmountOfPupils = 1
                }
            }
        };
        var expectedDiff = (
            new List<UpdatedPupil> {
                new UpdatedPupil() { PupilId = 1, ClassName = "Second grade", FollowUpNumber = 1 }
            },
            new List<UpdatedClass> {
                new UpdatedClass() { ClassId = 1, AmountOfPupils = 1 },
                new UpdatedClass() { ClassId = 2, AmountOfPupils = 1 }
            }
        );

        Assert.Equivalent(expectedState, newState, strict: true);
        Assert.Equal(1, newState.Classes[0].AmountOfPupils);
        Assert.Equal(1, newState.Classes[1].AmountOfPupils);
        Assert.Equal(1, newState.Pupils.First(p => p.Name == "Vermaercke Tim").FollowUpNumber);
        Assert.Equal(1, newState.Pupils.First(p => p.Name == "Goderis Jonas").FollowUpNumber);
        Assert.Equivalent(expectedDiff, diff, strict: true);
    }

    [Fact]
    public void Assigning_Pupil_To_A_Non_Existing_Class_Should_Fail()
    {
        State initialState = new State()
        {
            Pupils = new List<Pupil>()
            {
                new Pupil() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new Pupil() {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "First grade",
                    FollowUpNumber = 1
                }
            },
            Classes = new List<Class>()
            {
                new Class() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 2
                },
            }
        };
        Request incomingRequest = new Request()
        {
            Assignments = new List<Assignment>()
            {
                new Assignment() {
                    PupilId = 1,
                    ClassId = 2 // This class does not exist
                }
            }
        };

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest));
        Assert.Equal("Class with id 2 does not exist.", ex.Message);
    }

    [Fact]
    public void Assigning_Non_Existing_Pupil_To_A_Class_Should_Fail()
    {
        State initialState = new State()
        {
            Pupils = new List<Pupil>()
            {
                new Pupil() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new Pupil() {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "First grade",
                    FollowUpNumber = 1
                }
            },
            Classes = new List<Class>()
            {
                new Class() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 3
                },
            }
        };
        Request incomingRequest = new Request()
        {
            Assignments = new List<Assignment>()
            {
                new Assignment() {
                    PupilId = 3,// This pupil does not exist
                    ClassId = 1
                }
            }
        };

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest));
        Assert.Equal("Pupil with id 3 does not exist.", ex.Message);
    }

    [Fact]
    public void Assigning_The_Same_Pupil_To_Multiple_Classes_Should_Fail()
    {
        State initialState = new State()
        {
            Pupils = new List<Pupil>()
            {
                new Pupil() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new Pupil() {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "First grade",
                    FollowUpNumber = 1
                }
            },
            Classes = new List<Class>()
            {
                new Class() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 2
                },
                new Class() {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 1,
                    AmountOfPupils = 0
                }
            }
        };
        Request incomingRequest = new Request()
        {
            Assignments = new List<Assignment>()
            {
                new Assignment() {
                    PupilId = 1,
                    ClassId = 1
                },
                new Assignment() {
                    PupilId = 1,
                    ClassId = 2
                }
            }
        };

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest));
        Assert.Equal("Duplicate pupil IDs provided.", ex.Message);
    }

    [Fact]
    public void When_A_Pupil_Is_Not_Assigned_To_A_Class_It_Should_Fail()
    {
        State initialState = new State()
        {
            Pupils = new List<Pupil>()
            {
                new Pupil() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new Pupil() {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "", // This pupil is not assigned to a class
                    FollowUpNumber = 1
                }
            },
            Classes = new List<Class>()
            {
                new Class() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 2
                },
                new Class() {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 1,
                    AmountOfPupils = 0
                }
            }
        };
        Request incomingRequest = new Request()
        {
            Assignments = new List<Assignment>()
            {
                new Assignment() {
                    PupilId = 1,
                    ClassId = 1
                },
            }
        };

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest));
        Assert.Equal("Pupil with id 2 is not assigned to a class.", ex.Message);
    }

    [Fact]
    public void When_The_Amount_Of_Pupils_In_A_Class_Exceeds_The_Maximum_Amount_It_Should_Fail()
    {
        State initialState = new State()
        {
            Pupils = new List<Pupil>()
            {
                new Pupil() {
                    Id = 1,
                    Name = "Vermaercke Tim",
                    ClassName = "First grade",
                    FollowUpNumber = 2
                },
                new Pupil() {
                    Id = 2,
                    Name = "Goderis Jonas",
                    ClassName = "Second grade",
                    FollowUpNumber = 1
                }
            },
            Classes = new List<Class>()
            {
                new Class() {
                    Id = 1,
                    ClassName = "First grade",
                    TeacherName = "Mr. Lemaire Jeroen",
                    MaxAmountOfPupils = 1,
                    AmountOfPupils = 1
                },
                new Class() {
                    Id = 2,
                    ClassName = "Second grade",
                    TeacherName = "Mr. Verbist Frank",
                    MaxAmountOfPupils = 2,
                    AmountOfPupils = 0
                }
            }
        };
        Request incomingRequest = new Request()
        {
            Assignments = new List<Assignment>()
            {
                new Assignment() {
                    PupilId = 2,
                    ClassId = 1
                },
            }
        };

        // Act & Assert
        var ex = Assert.Throws<Exception>(() => PupilClassManager.UpdatePupilClassDivision(initialState, incomingRequest));
        Assert.Equal("Class First grade has too many pupils assigned.", ex.Message);
    }
}
