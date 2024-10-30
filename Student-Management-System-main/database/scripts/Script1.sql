CREATE DATABASE StudentManagementSystem
GO

USE StudentManagementSystem;
GO

/*Create student table*/
CREATE TABLE Students (
    studentId INT PRIMARY KEY IDENTITY(1,1),
    userName VARCHAR(100) NOT NULL,
    firstName VARCHAR(100) NOT NULL,
    lastName VARCHAR(100) NOT NULL,
    emailID VARCHAR(100) NOT NULL,
    contact VARCHAR(20),
    address VARCHAR(255),
    userPassword VARCHAR(50) NOT NULL,
    grade int,
    userType int
);
GO

/*Create Teacher table*/
CREATE TABLE Teachers (
    teacherId INT PRIMARY KEY IDENTITY(1,1),
    userName VARCHAR(100) NOT NULL,
    firstName VARCHAR(100) NOT NULL,
    lastName VARCHAR(100) NOT NULL,
    emailID VARCHAR(100) NOT NULL,
    contact VARCHAR(20),
    department VARCHAR(100),
    officeLocation VARCHAR(100),
    userPassword VARCHAR(50) NOT NULL,
    userType int
);
GO

/*Create Admins table*/
CREATE TABLE Admins (
    adminId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
    userName VARCHAR(100) NOT NULL,
    firstName VARCHAR(100) NOT NULL,
    lastName VARCHAR(100) NOT NULL,
    userPassword VARCHAR(50) NOT NULL,
    emailID VARCHAR(100),
    contact VARCHAR(20),
    userType int
);
GO

INSERT INTO Students (userName, firstName, lastName, emailID, contact, address, userPassword, grade, userType) VALUES
('john_doe', 'John', 'Doe', 'john.doe@example.com', '1234567890', '1234 Elm Street', 'pass123', 1, 2),
('jane_smith', 'Jane', 'Smith', 'jane.smith@example.com', '0987654321', '5678 Oak Street', 'pass456', 5, 2),
('alice_jones', 'Alice', 'Jones', 'alice.jones@example.com', '1122334455', '91011 Pine Avenue', 'pass789', 3, 2);
GO

INSERT INTO Teachers (userName, firstName, lastName, emailID, contact, department, officeLocation, userPassword, userType) VALUES
('robert_brown', 'Robert', 'Brown', 'robert.brown@example.com', '1223334444', 'Mathematics', 'Building A, Room 101', 'pass1234', 1),
('susan_white', 'Susan', 'White', 'susan.white@example.com', '5556667777', 'History', 'Building B, Room 202', 'pass5678', 1),
('michael_green', 'Michael', 'Green', 'michael.green@example.com', '8889990000', 'Science', 'Building C, Room 303', 'pass91011', 1);
GO

INSERT INTO Admins (userName, firstName, lastName, userPassword, emailID, contact, userType) VALUES
('lisa_gray', 'Lisa', 'Gray', 'pass1111', 'lisa.gray@example.com', '2123334444', 0),
('david_hall', 'David', 'Hall', 'pass2222', 'david.hall@example.com', '3234445555', 0),
('emily_clark', 'Emily', 'Clark', 'pass3333', 'emily.clark@example.com', '4345556666', 0);
GO


