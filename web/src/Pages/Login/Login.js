import { Alert, Button, TextField, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { useFormik } from "formik";
import React, { useState } from "react";
import * as Yup from "yup";
import * as AuthenticationService from "../../Services/AuthenticationService";

// Formik validation schema
const validationSchema = Yup.object({
  userName: Yup.string().required("Username is required"),
  password: Yup.string().required("Password is required."),
});

function Login() {
  const [error, setError] = useState("");

  let userAuthentication = {
    userName: "",
    password: "",
  };

  // Initialize form
  const formik = useFormik({
    initialValues: userAuthentication,
    validationSchema: validationSchema,
    onSubmit: (values) => {
      console.log(values);
      authenticateUser(values);
    },
  });

  // Authenticate user
  function authenticateUser(values) {
    AuthenticationService.login(values)
      .then((res) => {
        console.log(res);
        setError("");
      })
      .catch((err) => setError("Invalid Username/password."));
  }

  return (
    <>
      <Typography variant="h6">Login</Typography>

      {error && (
        <Alert sx={{ mt: 2, mb: 2 }} severity="error">
          {error}
        </Alert>
      )}

      <Box
        component="form"
        onSubmit={formik.handleSubmit}
        sx={{
          "& .MuiTextField-root": { m: 1, width: "25ch" },
        }}
      >
        <div>
          <TextField
            fullWidth
            id="userName"
            name="userName"
            label="userName"
            value={formik.values.email}
            onChange={formik.handleChange}
            error={formik.touched.userName && Boolean(formik.errors.userName)}
            helperText={formik.touched.userName && formik.errors.userName}
          />

          <TextField
            fullWidth
            id="password"
            name="password"
            label="Password"
            value={formik.values.password}
            onChange={formik.handleChange}
            error={formik.touched.password && Boolean(formik.errors.password)}
            helperText={formik.touched.password && formik.errors.password}
          />
        </div>

        <div>
          <Button color="primary" variant="contained" type="submit">
            Login
          </Button>
          
        </div>
      </Box>
    </>
  );
}

export default Login;
