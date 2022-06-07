import { Alert, Button, TextField, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { useFormik } from "formik";
import React, { useContext, useState } from "react";
import { Link, useNavigate, useLocation } from "react-router-dom";
import * as Yup from "yup";
import useAuth from "../../Hooks/useAuth";
import * as AuthenticationService from "../../Services/AuthenticationService";

// Formik validation schema
const validationSchema = Yup.object({
  email: Yup.string().required("Email is required"),
  password: Yup.string().required("Password is required."),
});

function Login() {
  const { auth, setAuth } = useAuth();

  const navigate = useNavigate();
  const location = useLocation();
  const from = "/";

  const [error, setError] = useState("");

  let userAuthentication = {
    email: "",
    password: "",
  };

  // Initialize form
  const formik = useFormik({
    initialValues: userAuthentication,
    validationSchema: validationSchema,
    onSubmit: (values) => {
       console.log('form submit' + values);
      authenticateUser(values);
      navigate(from, { replace: true });
    },
  });

  // Authenticate user
  const authenticateUser = (values) => {
    AuthenticationService.login(values)
      .then((res) => {
        console.log('authenticate api service response');
        console.log(res);
        setError("");
        const email = values.email;
        const password = values.password;
        const accessToken = res?.data?.accessToken;
        // const refreshToken = res?.data?.refreshToken;
        const roles = [res?.data?.role];
        setAuth({
          email,
          password,
          roles,
          accessToken,
          // refreshToken
        });
         console.log(roles);
         console.log(auth);
      })
      .catch((err) => setError("Invalid Email/password."));
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
            id="email"
            name="email"
            label="email"
            value={formik.values.email}
            onChange={formik.handleChange}
            error={formik.touched.email && Boolean(formik.errors.email)}
            helperText={formik.touched.email && formik.errors.email}
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
          <Button
            color="secondary"
            variant="contained"
            component={Link}
            to="/register"
            sx={{ ml: 1 }}
          >
            Create New Account
          </Button>
        </div>
      </Box>
    </>
  );
}

export default Login;
