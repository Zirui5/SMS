import React, { useState } from 'react';
import { Grid, Card, CardContent, Typography, Button, List, ListItem, TextField } from '@mui/material';

const ProfessorDashboard = () => {
    const [courses, setCourses] = useState([
        // Sample data structure for courses
        {
            courseName: 'Course 1',
            description: 'Description for Course 1',
            content: [
                { title: 'PDF 1', url: 'https://example.com/pdf1.pdf' },
                { title: 'PDF 2', url: 'https://example.com/pdf2.pdf' }
            ]
        },
        // Additional courses...
    ]);

    const [selectedCourse, setSelectedCourse] = useState(null);

    const handleViewDetails = (courseIndex) => {
        setSelectedCourse(courses[courseIndex]);
    };

    const handleBackToList = () => {
        setSelectedCourse(null);
    };

    const handleAddContent = (newContent) => {
        if (selectedCourse) {
            const updatedCourse = {
                ...selectedCourse,
                content: [...selectedCourse.content, newContent]
            };
            const updatedCourses = courses.map(course =>
                course.courseName === selectedCourse.courseName ? updatedCourse : course
            );
            setCourses(updatedCourses);
            setSelectedCourse(updatedCourse);
        }
    };

    const handleEditCourse = (name, description) => {
        if (selectedCourse) {
            const updatedCourse = {
                ...selectedCourse,
                courseName: name,
                description: description
            };
            const updatedCourses = courses.map(course =>
                course.courseName === selectedCourse.courseName ? updatedCourse : course
            );
            setCourses(updatedCourses);
            setSelectedCourse(updatedCourse);
        }
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
                                        Edit Details
                                    </Button>
                                </CardContent>
                            </Card>
                        </Grid>
                    ))}
                </Grid>
            ) : (
                <div>
                    <Button variant="outlined" color="primary" onClick={handleBackToList} style={{ marginBottom: '20px' }}>
                        Back to List
                    </Button>
                    <TextField
                        label="Course Name"
                        value={selectedCourse.courseName}
                        onChange={(e) => handleEditCourse(e.target.value, selectedCourse.description)}
                        margin="normal"
                        fullWidth
                    />
                    <TextField
                        label="Description"
                        value={selectedCourse.description}
                        onChange={(e) => handleEditCourse(selectedCourse.courseName, e.target.value)}
                        margin="normal"
                        fullWidth
                        multiline
                    />
                    <Typography variant="h6" style={{ marginTop: '20px' }}>
                        Course Content
                    </Typography>
                    <List>
                        {selectedCourse.content.map((item, index) => (
                            <ListItem key={index}>
                                <TextField
                                    value={item.title}
                                    margin="normal"
                                    fullWidth
                                />
                            </ListItem>
                        ))}
                        <Button onClick={() => handleAddContent({ title: 'New PDF', url: 'https://example.com/newpdf.pdf' })}>
                            Add Content
                        </Button>
                    </List>
                </div>
            )}
        </div>
    );
};

export default ProfessorDashboard;
