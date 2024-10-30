CREATE PROCEDURE CheckStudentExists 
    @Email VARCHAR(100)
AS
BEGIN
    -- Declare a variable to hold the existence check result
    DECLARE @Exists BIT

    -- Check if a user with the given email exists in the Admins table
    IF EXISTS(SELECT 1 FROM Students WHERE emailID = @Email)
        SET @Exists = 1 -- User exists
    ELSE
        SET @Exists = 0 -- User does not exist

    -- Return the result
    SELECT @Exists AS UserExists
END
