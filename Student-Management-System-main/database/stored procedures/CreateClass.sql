CREATE PROCEDURE CreateClass
    @className VARCHAR(255),
    @classTerm VARCHAR(255),
    @classDescription VARCHAR(1023),
    @teacherId INT,
    @location VARCHAR(255),
    @startTime DATETIME,
    @endTime DATETIME
AS
BEGIN
    INSERT INTO Class (className, classTerm, classDescription, teacherId, location, startTime, endTime)
    VALUES (@className, @classTerm, @classDescription, @teacherId, @location, @startTime, @endTime);
END;
GO
