CREATE PROCEDURE InsertAdminUser
    @userName VARCHAR(100),
    @firstName VARCHAR(100),
    @lastName VARCHAR(100),
    @userPassword VARCHAR(50),
    @emailID VARCHAR(100),
    @contact VARCHAR(20),
    @userType INT
AS
BEGIN
    -- Insert the data into the Admins table
    INSERT INTO Admins (userName, firstName, lastName, userPassword, emailID, contact, userType)
    VALUES (@userName, @firstName, @lastName, @userPassword, @emailID, @contact, @userType);
    
END;
GO