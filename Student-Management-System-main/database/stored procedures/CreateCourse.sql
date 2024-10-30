CREATE PROCEDURE CreateCourse 
    @courseName VARCHAR(100),
    @courseDescription VARCHAR(1023),
    @courseCode VARCHAR(10),
    @maxCapacity INT,
    @departmentId INT,
    @credits INT
AS
BEGIN
    INSERT INTO Courses (courseName, courseDescription, courseCode, maxCapacity, departmentId, credits)
    VALUES (@courseName, @courseDescription, @courseCode, @maxCapacity, @departmentId, @credits);
END;
GO