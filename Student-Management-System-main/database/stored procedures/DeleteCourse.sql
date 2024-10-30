CREATE PROCEDURE DeleteCourse
    @courseId INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Courses WHERE courseId = @courseId)
    BEGIN
        DELETE FROM Courses WHERE courseId = @courseId;
    END
END;
GO
