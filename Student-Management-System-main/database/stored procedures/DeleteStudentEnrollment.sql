CREATE PROCEDURE DeleteStudentEnrollment
    @studentId INT,
    @courseId INT
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS (
        SELECT 1 
        FROM StudentCourses 
        WHERE studentId = @studentId AND courseId = @courseId
    )
    BEGIN
        RAISERROR('No enrollment record exists for this student in the specified course.', 16, 1);
        RETURN;
    END

    DELETE FROM StudentCourses 
    WHERE studentId = @studentId AND courseId = @courseId;

    UPDATE CurrentCourseEnrollment
    SET enrollmentCount = enrollmentCount - 1
    WHERE courseId = @courseId;

    UPDATE CurrentCourseEnrollment
    SET enrollmentCount = 0
    WHERE courseId = @courseId AND enrollmentCount < 0;

END;
GO
