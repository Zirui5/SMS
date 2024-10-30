CREATE PROCEDURE UpdateClass
    @classId INT,
    @className VARCHAR(255),
    @classTerm VARCHAR(255),
    @classDescription VARCHAR(1023),
    @teacherId INT,
    @location VARCHAR(255),
    @startTime DATETIME,
    @endTime DATETIME
AS
BEGIN
    UPDATE Class
    SET className = @className,
        classTerm = @classTerm,
        classDescription = @classDescription,
        teacherId = @teacherId,
        location = @location,
        startTime = @startTime,
        endTime = @endTime
    WHERE classId = @classId;
END;
GO
