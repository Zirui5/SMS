/* import React, { useState } from 'react';
import { TextField, Button, Typography, Box, Container } from '@mui/material';
import PersonAddRoundedIcon from '@mui/icons-material/PersonAddRounded';
import './AddStudent.css';

const AddStudentForm = () => {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        email: '',
        age: ''
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
        // You can use fetch or Axios for this
        console.log(formData);
        // Clear form after submission
        setFormData({
            firstName: '',
            lastName: '',
            email: '',
            age: ''
        });
    };

    return (
        <Container maxWidth="sm">
            <Typography variant="h4" component="h2" gutterBottom>
                Add Student <PersonAddRoundedIcon />
            </Typography>
            <form onSubmit={handleSubmit}>
                <TextField
                    fullWidth
                    label="First Name"
                    name="firstName"
                    value={formData.firstName}
                    onChange={handleChange}
                    required
                    margin="normal"
                />
                <TextField
                    fullWidth
                    label="Last Name"
                    name="lastName"
                    value={formData.lastName}
                    onChange={handleChange}
                    required
                    margin="normal"
                />
                <TextField
                    fullWidth
                    label="Email"
                    name="email"
                    value={formData.email}
                    onChange={handleChange}
                    required
                    type="email"
                    margin="normal"
                />
                <TextField
                    fullWidth
                    label="Age"
                    name="age"
                    value={formData.age}
                    onChange={handleChange}
                    required
                    type="number"
                    margin="normal"
                />
                <Box mt={2}>
                    <Button type="submit" variant="contained" color="primary">
                        Add Student to System
                    </Button>
                </Box>
            </form>
        </Container>
    );
};

export default AddStudentForm;
 */
import React, { useState } from 'react';
import { TextField, Button, Typography, Box, Container, Grid } from '@mui/material';
import PersonAddRoundedIcon from '@mui/icons-material/PersonAddRounded';
import './AddStudent.css';

const AddStudentForm = () => {
    const [formData, setFormData] = useState({
        firstName: '',
        lastName: '',
        email: '',
        age: ''
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
        // You can use fetch or Axios for this
        console.log(formData);
        // Clear form after submission
        setFormData({
            firstName: '',
            lastName: '',
            email: '',
            age: ''
        });
    };

    return (
        <Container component="main" maxWidth="sm">
            <Typography variant="h4" component="h2" gutterBottom>
                <PersonAddRoundedIcon sx={{ mr: 1 }} /> Add Student
            </Typography>
            <form onSubmit={handleSubmit}>
                <Grid container spacing={2}>
                    <Grid item xs={12} sm={6}>
                        <TextField
                            fullWidth
                            label="First Name"
                            name="firstName"
                            value={formData.firstName}
                            onChange={handleChange}
                            required
                            margin="normal"
                        />
                    </Grid>
                    <Grid item xs={12} sm={6}>
                        <TextField
                            fullWidth
                            label="Last Name"
                            name="lastName"
                            value={formData.lastName}
                            onChange={handleChange}
                            required
                            margin="normal"
                        />
                    </Grid>
                </Grid>
                <TextField
                    fullWidth
                    label="Email"
                    name="email"
                    value={formData.email}
                    onChange={handleChange}
                    required
                    type="email"
                    margin="normal"
                />
                <TextField
                    fullWidth
                    label="Age"
                    name="age"
                    value={formData.age}
                    onChange={handleChange}
                    required
                    type="number"
                    margin="normal"
                />
                <Box mt={2}>
                    <Button type="submit" variant="contained" color="primary">
                        Add Student to System
                    </Button>
                </Box>
            </form>
        </Container>
        
    );
};

export default AddStudentForm;
