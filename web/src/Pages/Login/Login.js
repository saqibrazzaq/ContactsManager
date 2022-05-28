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
  userName: Yup.string().required("Username is required"),
  password: Yup.string().required("Password is required."),
});

function Login() {
  const { auth, setAuth } = useAuth();

  const navigate = useNavigate();
  const location = useLocation();
  const from = location.state?.from?.pathname || "/";

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
      // console.log(values);
      authenticateUser(values);
      navigate(from, { replace: true });
    },
  });

  // Authenticate user
  function authenticateUser(values) {
    AuthenticationService.login(values)
      .then((res) => {
        // console.log(res);
        setError("");
        const user = values.userName;
        const password = values.password;
        const accessToken = res?.data?.accessToken;
        const refreshToken = res?.data?.refreshToken;
        const roles = res?.data?.roles;
        setAuth({
          user,
          password,
          roles,
          accessToken,
          refreshToken
        });
        // console.log(roles);
        // console.log(auth);
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
