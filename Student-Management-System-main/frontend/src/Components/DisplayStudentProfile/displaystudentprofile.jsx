import React, { useState } from 'react';
import { Typography, TextField, Button, Box, Grid, Container } from '@mui/material';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';

const DisplayStudentProfile = () => {
  const [userData, setUserData] = useState({
    username: '',
    firstName: '',
    lastName: '',
    email: '',
    contactNumber: ''
  });

  const [isEditing, setIsEditing] = useState({
    username: false,
    firstName: false,
    lastName: false,
    email: false,
    contactNumber: false
  });

  const handleEdit = (field) => {
    setIsEditing((prevState) => ({
      ...prevState,
      [field]: true
    }));
  };

  const handleChange = (e, field) => {
    const { value } = e.target;
    setUserData((prevState) => ({
      ...prevState,
      [field]: value
    }));
  };

  return (
    <Container component="main" maxWidth="sm">
      <Box mt={5} mb={3} display="flex" flexDirection="column" alignItems="center">
        <LockOutlinedIcon style={{ fontSize: 48 }} />
        <Typography variant="h4" gutterBottom>
          Student Profile
        </Typography>
      </Box>
      <form onSubmit={(e) => e.preventDefault()}>
        <Grid container spacing={2}>
          <Grid item xs={12} md={6}>
            <TextField
              label="Username"
              fullWidth
              value={userData.username}
              onChange={(e) => handleChange(e, 'username')}
              disabled={!isEditing.username}
            />
            <Button onClick={() => handleEdit('username')} variant="outlined">
              Edit
            </Button>
          </Grid>
          <Grid item xs={12} md={6}>
            <TextField
              label="First Name"
              fullWidth
              value={userData.firstName}
              onChange={(e) => handleChange(e, 'firstName')}
              disabled={!isEditing.firstName}
            />
            <Button onClick={() => handleEdit('firstName')} variant="outlined">
              Edit
            </Button>
          </Grid>
          <Grid item xs={12} md={6}>
            <TextField
              label="Last Name"
              fullWidth
              value={userData.lastName}
              onChange={(e) => handleChange(e, 'lastName')}
              disabled={!isEditing.lastName}
            />
            <Button onClick={() => handleEdit('lastName')} variant="outlined">
              Edit
            </Button>
          </Grid>
          <Grid item xs={12} md={6}>
            <TextField
              label="Email"
              fullWidth
              value={userData.email}
              onChange={(e) => handleChange(e, 'email')}
              disabled={!isEditing.email}
            />
            <Button onClick={() => handleEdit('email')} variant="outlined">
              Edit
            </Button>
          </Grid>
          <Grid item xs={12} md={6}>
            <TextField
              label="Contact Number"
              fullWidth
              value={userData.contactNumber}
              onChange={(e) => handleChange(e, 'contactNumber')}
              disabled={!isEditing.contactNumber}
            />
            <Button onClick={() => handleEdit('contactNumber')} variant="outlined">
              Edit
            </Button>
          </Grid>
        </Grid>
      </form>
    </Container>
  );
};

export default DisplayStudentProfile;
