CREATE PROCEDURE DeleteClass
    @classId INT
AS
BEGIN

    IF EXISTS (SELECT 1 FROM Class WHERE classId = @classId)
    BEGIN
        DELETE FROM Class WHERE classId = @classId;
    END
END;
GO
