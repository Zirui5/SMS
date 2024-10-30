CREATE PROCEDURE GetCourseForTeacherDashboard
    @teacherId INT
AS
BEGIN
    SELECT 
        c.courseId, 
        c.courseName, 
        c.courseDescription, 
        c.courseCode, 
        c.maxCapacity, 
        c.departmentId, 
        c.credits,
        coalesce(e.enrollmentCount, 0) AS enrollmentCount,
        t.firstName + ' ' + t.lastName AS teacherName,
        t.emailID,
        t.contact,
        t.department,
        t.officeLocation
    FROM Courses c
    LEFT JOIN CurrentCourseEnrollment e ON c.courseId = e.courseId
    INNER JOIN TeacherCourses tc ON c.courseId = tc.courseId
    INNER JOIN Teachers t ON tc.teacherId = t.teacherId
    WHERE t.teacherId = @TeacherId;
END;
GO
