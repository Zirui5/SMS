CREATE PROCEDURE GetStudentDetailsByEmail
    @Email VARCHAR(100)
AS
BEGIN
    -- Select and return all user details where the email matches the input parameter
    SELECT 
        studentId as userId,
        userName,
        firstName,
        lastName,
        userPassword as password,
        emailID,
        contact,
        userType,
        grade,
    FROM 
        Students
    WHERE 
        emailID = @Email;
END