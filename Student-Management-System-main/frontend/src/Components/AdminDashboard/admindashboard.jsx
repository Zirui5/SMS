import React, { useState } from 'react';
import {Grid, Card, CardContent, Typography } from '@mui/material';

const AdminDashboard = () => {
  // placeholder
  const [courses] = useState([
    {
      courseTitle: 'Course 1',
      courseDescription: 'random desc',
      credits: 3,
      maxCapacity: 50,
      studentsEnrolled: 30
    },
    {
      courseTitle: 'random desc',
      credits: 4,
      maxCapacity: 40,
      studentsEnrolled: 20
    },
    {
      courseTitle: 'Course 3',
      courseDescription: 'random desc',
      credits: 2,
      maxCapacity: 60,
      studentsEnrolled: 45
    }
  ]);


  return (
    <Grid container spacing={3}>
      {courses.map((course, index) => (
        <Grid item key={index} xs={12} sm={6} md={4}>
          <Card elevation={3}>
            <CardContent>
              <Typography variant="h6" gutterBottom>
                {course.courseTitle}
              </Typography>
              <Typography variant="body1">
                <strong>Description :</strong> {course.courseDescription}
              </Typography>
              <Typography variant="body1">
                <strong>Credits :</strong> {course.credits}
              </Typography>
              <Typography variant="body1">
                <strong>Maximum Capacity of course:</strong> {course.maxCapacity}
              </Typography>
              <Typography variant="body1">
                <strong>Students Enrolled so far :</strong> {course.studentsEnrolled}
              </Typography>
            </CardContent>
          </Card>
        </Grid>
      ))}
    </Grid>
  );
};
export default AdminDashboard;
