CREATE PROCEDURE EditCourse
    @courseId INT,
    @courseName VARCHAR(100),
    @courseDescription VARCHAR(1023),
    @courseCode VARCHAR(10),
    @maxCapacity INT,
    @departmentId INT,
    @credits INT
AS
BEGIN
    UPDATE Courses
    SET courseName = @courseName,
        courseDescription = @courseDescription,
        courseCode = @courseCode,
        maxCapacity = @maxCapacity,
        departmentId = @departmentId,
        credits = @credits
    WHERE courseId = @courseId;
END;
GO
