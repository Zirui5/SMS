USE StudentManagementSystem;
GO

CREATE TABLE Departments (
    departmentId INT IDENTITY(1,1) PRIMARY KEY,
    department VARCHAR(10)
);

INSERT INTO Departments (department) VALUES ('ECS');
INSERT INTO Departments (department) VALUES ('MATH');
INSERT INTO Departments (department) VALUES ('PHY');
GO

CREATE TABLE Courses (
    courseId INT PRIMARY KEY IDENTITY(1,1),
    courseName VARCHAR(100),
    courseDescription VARCHAR(1023),
    courseCode VARCHAR(10),
    maxCapacity INT,
    departmentId INT,
    credits INT,
    CONSTRAINT FK_Courses_Departments FOREIGN KEY (departmentId) REFERENCES Departments(departmentId)
);
GO