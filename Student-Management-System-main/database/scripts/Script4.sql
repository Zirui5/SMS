USE StudentManagementSystem;
GO

CREATE TABLE CurrentCourseEnrollment (
    id INT PRIMARY KEY,
    courseId INT,
    enrollmentCount INT,
    CONSTRAINT FK_CurrentCourseEnrollment_Courses FOREIGN KEY (courseId) REFERENCES Courses(courseId)
);
GO

CREATE TABLE StudentCourses (
    studentId INT,
    courseId INT,
    CONSTRAINT PK_StudentCourses PRIMARY KEY (studentId, courseId),
    CONSTRAINT FK_StudentCourses_Students FOREIGN KEY (studentId) REFERENCES Students(studentId),
    CONSTRAINT FK_StudentCourses_Courses FOREIGN KEY (courseId) REFERENCES Courses(courseId)
);
GO

CREATE TABLE TeacherCourses (
    teacherId INT,
    courseId INT,
    CONSTRAINT PK_TeacherCourses PRIMARY KEY (teacherId, courseId),
    CONSTRAINT FK_TeacherCourses_Teachers FOREIGN KEY (teacherId) REFERENCES Teachers(teacherId),
    CONSTRAINT FK_TeacherCourses_Courses FOREIGN KEY (courseId) REFERENCES Courses(courseId)
);
GO
