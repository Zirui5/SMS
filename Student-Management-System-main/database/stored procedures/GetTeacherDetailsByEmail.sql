CREATE PROCEDURE GetTeacherDetailsByEmail
    @Email VARCHAR(100)
AS
BEGIN
    -- Select and return all user details where the email matches the input parameter
    SELECT 
        teacherId as userId,
        userName,
        firstName,
        lastName,
        userPassword as password,
        emailID,
        contact,
        userType
    FROM 
        Teachers
    WHERE 
        emailID = @Email;
END