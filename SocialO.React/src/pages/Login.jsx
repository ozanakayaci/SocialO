import { TextField, Button, LinearProgress } from "@mui/material";

import { Link, useNavigate } from "react-router-dom";

import { Formik, Form } from "formik";

import * as yup from "yup";

import { toast } from "react-toastify";

import { useDispatch, useSelector } from "react-redux";
import { login } from "../redux/socialo/socialoSlice";

const loginValidation = yup.object({
  usename: yup
    .string()
    .required("Required Field")
    .min(3, "Username must be at least 3 characters")
    .test("is-email", "Invalid email", (value) => {
      if (value) {
        return value.includes("@")
          ? yup.string().email().isValidSync(value)
          : true;
      }
      return true;
    }),
  password: yup.string().required("Password is Required").min(8),
});

function Login() {
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const pending = useSelector((state) => state.socialo.pending);

  const handleLogin = async (values) => {
    const response = await dispatch(
      login(
        JSON.stringify({
          username: values.usename,
          password: values.password,
        })
      )
    );
    if (response.payload["authToken"] !== undefined) {
      toast("Login successful..", {
        position: "bottom-center",
        autoClose: 5000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
        theme: "light",
      });
      navigate("/home");
    } else {
      toast.error(response.payload.response.data.message, {
        position: "bottom-center",
        autoClose: 5000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
        progress: undefined,
        theme: "light",
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
          Sign in to your account
        </h2>
      </div>
      <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
        <Formik
          initialValues={{ usename: "", password: "" }}
          onSubmit={(values) => {
            handleLogin(values);
          }}
          validationSchema={loginValidation}
        >
          {({ values, handleChange, handleBlur, errors, touched }) => (
            <Form className="space-y-6">
              <div>
                <div className="mt-2">
                  <TextField
                    InputProps={{ sx: { borderRadius: 3 } }}
                    id="email"
                    name="email"
                    label="Username or email"
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
                <Button
                  type="submit"
                  className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
                  variant="contained"
                >
                  Sign in
                </Button>
                {pending && (
                  <LinearProgress
                    className="absolute"
                    sx={{
                      marginTop: "-6px",
                      height: "6px",
                      borderBottomLeftRadius: "3px",
                      borderBottomRightRadius: "3px",
                    }}
                  />
                )}
              </div>
            </Form>
          )}
        </Formik>
        <p className="mt-10 text-center text-sm text-gray-500">
          Not a member?{" "}
          <Link
            to="/register"
            className="font-semibold leading-6 text-indigo-600 hover:text-indigo-500"
          >
            Create account
          </Link>
        </p>
      </div>
    </div>
  );
}

export default Login;
