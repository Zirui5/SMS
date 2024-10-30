USE StudentManagementSystem;
GO

CREATE TABLE Class (
    classId INT PRIMARY KEY IDENTITY(1,1),  
    className VARCHAR(255),
    classTerm VARCHAR(255),
    classDescription VARCHAR(1023),
    teacherId INT,
    location VARCHAR(255),
    startTime datetime,
    endTime datetime,
    CONSTRAINT FK_Class_Teachers FOREIGN KEY (teacherId) REFERENCES Teachers(teacherId)
);
GO