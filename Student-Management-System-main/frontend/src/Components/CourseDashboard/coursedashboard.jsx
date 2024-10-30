import React, { useState } from 'react';
import { Grid, Card, CardContent, Typography, Button, List, ListItem, ListItemText } from '@mui/material';

const StudentDashboard = () => {
  // Placeholder data for courses
  const [courses] = useState([
    {
      courseName: 'Course 1',
      description: 'Description for Course 1',
      content: [
        { title: 'PDF 1', url: 'https://example.com/pdf1.pdf' },
        { title: 'PDF 2', url: 'https://example.com/pdf2.pdf' }
      ]
    },
    {
      courseName: 'Course 2',
      description: 'Description for Course 2',
      content: [
        { title: 'PDF 3', url: 'https://example.com/pdf3.pdf' },
        { title: 'PDF 4', url: 'https://example.com/pdf4.pdf' }
      ]
    },
    {
      courseName: 'Course 3',
      description: 'Description for Course 3',
      content: [
        { title: 'PDF 5', url: 'https://example.com/pdf5.pdf' },
        { title: 'PDF 6', url: 'https://example.com/pdf6.pdf' }
      ]
    }
  ]);

  const [selectedCourse, setSelectedCourse] = useState(null);

  const handleViewDetails = (courseIndex) => {
    // Settingthe selected course when a tile is clicked
    setSelectedCourse(courses[courseIndex]);
  };

  const handleBackToList = () => {
    // Clearing the selected course when "Back to List" button is clicked
    setSelectedCourse(null);
  };

  return (
    <div>
      {!selectedCourse ? (
        <Grid container spacing={3}>
          {courses.map((course, index) => (
            <Grid item key={index} xs={12} sm={6} md={4}>
              <Card elevation={3}>
                <CardContent>
                  <Typography variant="h6" gutterBottom>
                    {course.courseName}
                  </Typography>
                  <Typography variant="body1">
                    {course.description}
                  </Typography>
                  <Button variant="contained" color="primary" style={{ marginTop: '10px' }} onClick={() => handleViewDetails(index)}>
                    View Details
                  </Button>
                </CardContent>
              </Card>
            </Grid>
          ))}
        </Grid>
      ) : (
        <div>
          <Button variant="outlined" color="primary" onClick={handleBackToList} style={{ marginBottom: '20px'}}>
            Back to List
          </Button>
          <Typography variant="h6" gutterBottom>
            {selectedCourse.courseName}
          </Typography>
          <Typography variant="body1">
            {selectedCourse.description}
          </Typography>
          <Typography variant="h6" style={{ marginTop: '20px' }}>
            Course Content
          </Typography>
          <List>
            {selectedCourse.content.map((item, index) => (
              <ListItem key={index} button component="a" href={item.url} target="_blank">
                <ListItemText primary={item.title} />
              </ListItem>
            ))}
          </List>
        </div>
      )}
    </div>
  );
};
export default StudentDashboard;
