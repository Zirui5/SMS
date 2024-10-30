CREATE PROCEDURE GetCourseDetails
    @courseId INT
AS
BEGIN
    SELECT courseId, courseName, courseDescription, courseCode, maxCapacity, departmentId, credits
    FROM Courses
    WHERE courseId = @courseId;
END;
GO
