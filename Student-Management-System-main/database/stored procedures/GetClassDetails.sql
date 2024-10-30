CREATE PROCEDURE GetClassDetails
    @classId INT
AS
BEGIN
    SELECT classId, className, classTerm, classDescription, teacherId, location, startTime, endTime
    FROM Class
    WHERE classId = @classId;
END;
GO
