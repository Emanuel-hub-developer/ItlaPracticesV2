

using ClassMap.APP.Entities;


//Employee
Employee employee = new Employee(
    name: "Robert",
    lastname: "Harris",
    dni: "G9988776",
    age: 33,
    email: "robert.harris@example.com",
    telephone: "555-789-0123",
    communityID: "EM1007",
    joinDate: DateTime.Parse("2016-07-01"),
    salary: 2900.00m,
    sns: "SNS008901",
    hireDate: DateTime.Parse("2016-07-01")
);
employee.ShowInfo();

// Student
Student student = new Student(
    name: "Emily",
    lastname: "Johnson",
    dni: "A1234567",
    age: 21,
    email: "emily.johnson@example.com",
    telephone: "555-123-4567",
    communityID: "ST1001",
    joinDate: DateTime.Parse("2022-08-15"),
    major: "Business Administration",
    currentSemester: 5
);
student.ShowInfo();

// ExStudent
ExStudent exStudent = new ExStudent(
    name: "Daniel",
    lastname: "Miller",
    dni: "B9876543",
    age: 27,
    email: "daniel.miller@example.com",
    telephone: "555-765-4321",
    communityID: "EX1002",
    joinDate: DateTime.Parse("2018-09-01"),
    graduationYear: DateTime.Parse("2022-06-01")
);
exStudent.ShowInfo();

// Administrative
Administrative admin = new Administrative(
    name: "Sarah",
    lastname: "Clark",
    dni: "C5566778",
    age: 42,
    email: "sarah.clark@example.com",
    telephone: "555-345-6789",
    communityID: "AD1003",
    joinDate: DateTime.Parse("2010-04-10"),
    salary: 2800.00m,
    sns: "SNS004321",
    hireDate: DateTime.Parse("2010-04-10"),
    area: "Finance",
    officeNumber: "B203"
);
admin.ShowInfo();

// Teacher
Teacher teacher = new Teacher(
    name: "Michael",
    lastname: "Anderson",
    dni: "D3344556",
    age: 39,
    email: "michael.anderson@example.com",
    telephone: "555-678-1234",
    communityID: "TE1004",
    joinDate: DateTime.Parse("2012-01-05"),
    salary: 3100.00m,
    sns: "SNS005678",
    hireDate: DateTime.Parse("2012-01-05"),
    educationLevel: "Master's Degree in Education"
);
teacher.ShowInfo();

// Teaching
Teaching teaching = new Teaching(
    name: "Olivia",
    lastname: "Wilson",
    dni: "E4433221",
    age: 36,
    email: "olivia.wilson@example.com",
    telephone: "555-234-5678",
    communityID: "TC1005",
    joinDate: DateTime.Parse("2015-09-01"),
    salary: 3300.00m,
    sns: "SNS006789",
    hireDate: DateTime.Parse("2015-09-01"),
    educationLevel: "PhD in Linguistics",
    certification: "TESOL Certified",
    teachingHours: 18
);
teaching.ShowInfo();

// Administrator
Administrator administrator = new Administrator(
    name: "James",
    lastname: "Walker",
    dni: "F1122334",
    age: 45,
    email: "james.walker@example.com",
    telephone: "555-456-7890",
    communityID: "AM1006",
    joinDate: DateTime.Parse("2009-03-20"),
    salary: 4200.00m,
    sns: "SNS007890",
    hireDate: DateTime.Parse("2009-03-20"),
    numberOfStaffSupervised: 12
);
administrator.ShowInfo();
