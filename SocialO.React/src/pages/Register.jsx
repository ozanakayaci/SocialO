import { TextField, Button } from "@mui/material";

import { Link, useNavigate } from "react-router-dom";

import { Formik, Form } from "formik";

import * as yup from "yup";

import axios from "axios";

import { toast } from "react-toastify";

const loginValidation = yup.object({
  usename: yup
    .string()
    .required("Username is Required")
    .min(3, "Username must be at least 3 characters")
    .test(
      "Unique Username",
      "Username already in use", // <- key, message
      function (value) {
        return new Promise((resolve) => {
          axios
            .get(`http://localhost:5211/api/Login/Available?input=${value}`, {
              headers: {
                Authorization: localStorage.getItem("token"),
              },
            })
            .then((response) => {
              resolve(response.data);
            })
            .catch(() => {
              resolve(false);
            });
        });
      }
    ),
  email: yup
    .string()
    .email()
    .required("Email is Required")
    .test(
      "Unique Email",
      "Email already in use", // <- key, message
      function (value) {
        return new Promise((resolve) => {
          axios
            .get(`http://localhost:5211/api/Login/Available?input=${value}`, {
              headers: {
                Authorization: localStorage.getItem("token"),
              },
            })
            .then((response) => {
              resolve(response.data);
            })
            .catch(() => {
              resolve(false);
            });
        });
      }
    ),
  password: yup.string().required("Password is Required").min(8),
  passwordConfirmation: yup
    .string()
    .oneOf([yup.ref("password"), null], "Passwords must match")
    .required("Confirm your password"),
});

async function registerUser(credentials) {
  return axios
    .post("http://localhost:5211/api/Login/SignUp", credentials, {
      headers: {
        "Content-Type": "application/json",
      },
    })
    .then((response) => {
      return response;
    })
    .catch((error) => {
      return error;
    });
}

function Register() {
  const navigate = useNavigate();

  const handleRegister = async (values) => {
    const response = await registerUser(
      JSON.stringify({
        username: values.usename,
        email: values.email,
        password: values.password,
        repassword: values.passwordConfirmation,
      })
    );
    if (response.status === 200) {
      toast.success("Register Success", {
        position: "bottom-center",
        autoClose: 5000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
      });
      navigate("/login");
    } else {
      toast.error(response.response.data.message, {
        position: "top-left",
        autoClose: 5000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
      });
    }
  };

  return (
    <div className="flex min-h-full flex-1 flex-col justify-center px-6 py-12 lg:px-8">
      <div className="sm:mx-auto sm:w-full sm:max-w-sm">
        <img
          className="mx-auto h-10 w-auto"
          src="../../public/logo.png"
          alt="Your Company"
        />
        <h2 className="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">
          Create and account
        </h2>
      </div>
      <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
        <Formik
          initialValues={{
            usename: "",
            email: "",
            password: "",
            passwordConfirmation: "",
          }}
          onSubmit={(values) => {
            handleRegister(values);
          }}
          validationSchema={loginValidation}
        >
          {({ values, handleChange, handleBlur, errors, touched }) => (
            <Form className="space-y-6">
              <div>
                <div className="mt-2">
                  <TextField
                    InputProps={{ sx: { borderRadius: 3 } }}
                    id="username"
                    name="username"
                    label="Username"
                    className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm  placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    onChange={handleChange("usename")}
                    onBlur={handleBlur("usename")}
                    value={values.usename}
                    error={touched.usename && Boolean(errors.usename)}
                    helperText={touched.usename && errors.usename}
                  />
                </div>
              </div>
              <div>
                <div className="mt-2">
                  <TextField
                    InputProps={{ sx: { borderRadius: 3 } }}
                    id="email"
                    name="email"
                    label="Email"
                    className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm  placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    onChange={handleChange("email")}
                    onBlur={handleBlur("email")}
                    value={values.email}
                    error={touched.email && Boolean(errors.email)}
                    helperText={touched.email && errors.email}
                  />
                </div>
              </div>
              <div>
                <div className="mt-2">
                  <TextField
                    InputProps={{ sx: { borderRadius: 3 } }}
                    id="password"
                    name="password"
                    label="Password"
                    type="password"
                    className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm  placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    onChange={handleChange("password")}
                    onBlur={handleBlur("password")}
                    value={values.password}
                    error={touched.password && Boolean(errors.password)}
                    helperText={touched.password && errors.password}
                  />
                </div>
              </div>
              <div>
                <div className="mt-2">
                  <TextField
                    InputProps={{ sx: { borderRadius: 3 } }}
                    id="rePassword"
                    name="rePassword"
                    type="password"
                    label="Confirm Password"
                    className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm  placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                    onChange={handleChange("passwordConfirmation")}
                    onBlur={handleBlur("passwordConfirmation")}
                    value={values.passwordConfirmation}
                    error={
                      touched.passwordConfirmation &&
                      Boolean(errors.passwordConfirmation)
                    }
                    helperText={
                      touched.passwordConfirmation &&
                      errors.passwordConfirmation
                    }
                  />
                </div>
              </div>
              <div>
                <Button
                  type="submit"
                  className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                  variant="contained"
                >
                  Sign up
                </Button>
              </div>
            </Form>
          )}
        </Formik>
        <p className="mt-10 text-center text-sm text-gray-500">
          Already have an account?{" "}
          <Link
            to="/login"
            className="font-semibold leading-6 text-indigo-600 hover:text-indigo-500"
          >
            Login
          </Link>
        </p>
      </div>
    </div>
  );
}

export default Register;
