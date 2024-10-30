import React, { useState } from 'react';
import { TextField, Button, Typography, Box, Container, Select, MenuItem, FormControl, InputLabel } from '@mui/material';
// import './CreateCourseForm.css'; // Import the CSS file

const CreateCourseForm = () => {
    const [formData, setFormData] = useState({
        courseName: '',
        description: '',
        courseCode: '',
        maxCapacity: 0,
        credits: 0,
        departmentId: 'ECS' // Default department
    });

    const handleChange = (e) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        // Send formData to backend for processing
        console.log(formData);
        // Clear form after submission
        setFormData({
            courseName: '',
            description: '',
            courseCode: '',
            maxCapacity: 0,
            credits: 0,
            departmentId: 'ECS' // Reset to default department
        });
    };

    return (
        <Container maxWidth="sm">
            <Typography variant="h4" component="h2" gutterBottom>
                Create Course
            </Typography>
            <form onSubmit={handleSubmit}>
                <TextField
                    fullWidth
                    label="Course Name"
                    name="courseName"
                    value={formData.courseName}
                    onChange={handleChange}
                    required
                    margin="normal"
                />
                <TextField
                    fullWidth
                    label="Description"
                    name="description"
                    value={formData.description}
                    onChange={handleChange}
                    required
                    multiline
                    rows={4}
                    margin="normal"
                />
                <TextField
                    fullWidth
                    label="Course Code"
                    name="courseCode"
                    value={formData.courseCode}
                    onChange={handleChange}
                    required
                    margin="normal"
                />
                <TextField
                    fullWidth
                    label="Max Capacity"
                    name="maxCapacity"
                    value={formData.maxCapacity}
                    onChange={handleChange}
                    required
                    type="number"
                    margin="normal"
                />
                <TextField
                    fullWidth
                    label="Credits"
                    name="credits"
                    value={formData.credits}
                    onChange={handleChange}
                    required
                    type="number"
                    margin="normal"
                />
                <FormControl fullWidth margin="normal">
                    <InputLabel>Department</InputLabel>
                    <Select
                        name="departmentId"
                        value={formData.departmentId}
                        onChange={handleChange}
                        required
                    >
                        <MenuItem value="ECS">ECS</MenuItem>
                        <MenuItem value="MATH">MATH</MenuItem>
                        <MenuItem value="PHY">PHY</MenuItem>
                        <MenuItem value="BIO">BIO</MenuItem>
                    </Select>
                </FormControl>
                <Box mt={2}>
                    <Button type="submit" variant="contained" color="primary">
                        Create Course
                    </Button>
                </Box>
            </form>
        </Container>
    );
};

export default CreateCourseForm;
