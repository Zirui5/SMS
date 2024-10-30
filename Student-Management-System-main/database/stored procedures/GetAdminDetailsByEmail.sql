CREATE PROCEDURE GetAdminDetailsByEmail
    @Email VARCHAR(100)
AS
BEGIN
    -- Select and return all user details where the email matches the input parameter
    SELECT 
        adminId as userId,
        userName,
        firstName,
        lastName,
        userPassword as password,
        emailID,
        contact,
        userType
    FROM 
        Admins
    WHERE 
        emailID = @Email;
END