CREATE PROCEDURE EnrollStudentInCourse
    @studentId INT,
    @courseId INT,
AS
BEGIN
    IF EXISTS (
        SELECT 1 
        FROM StudentCourses 
        WHERE studentId = @studentId AND courseId = @courseId
    )
    BEGIN
        RAISERROR('Student is already enrolled in this course.', 16, 1);
        RETURN;
    END

    DECLARE @CurrentEnrollment INT;
    DECLARE @MaxCapacity INT;
    SELECT @CurrentEnrollment = COUNT(*) FROM StudentCourses WHERE courseId = @courseId;
    SELECT @MaxCapacity = maxCapacity FROM Courses WHERE courseId = @courseId;

    IF @CurrentEnrollment >= @MaxCapacity
    BEGIN
        RAISERROR('This course has reached its maximum capacity.', 16, 1);
        RETURN;
    END

    INSERT INTO StudentCourses (studentId, courseId)
    VALUES (@studentId, @courseId);

    UPDATE CurrentCourseEnrollment
    SET enrollmentCount = enrollmentCount + 1
    WHERE courseId = @courseId;

END;
GO
