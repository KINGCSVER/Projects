import React, { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import {
  toggleSignUp,
  togglePasswordVisibility,
  signUp,
  signIn,
  selectAuth,
} from "../../store/authSlice";
import "./Auth.css";
import signUpUser from "../../models/login";
import signInUser from "../../models/register";
import "@fortawesome/fontawesome-free/css/all.min.css";

export default function Authentication() {
  const [user, setUser] = useState(new signUpUser());
  const [login, setLogin] = useState(new signInUser());
  const dispatch = useDispatch();
  const { isSignUp, showPassword, errors } = useSelector(selectAuth);

  const handleChange = (e, type) => {
    const { name, value } = e.target;
    if (type === "signup") {
      setUser((prev) => ({ ...prev, [name]: value }));
    } else if (type === "signin") {
      setLogin((prev) => ({ ...prev, [name]: value }));
    }
  };

  return (
    <div className="login-body">
      <div className={`container ${isSignUp ? "active" : ""}`}>
        <div className={`panel sign-up ${isSignUp ? "active" : ""}`}>
          <div className="container-form">
            <h1 className="text-5xl font-bold">Create Account</h1>
            <div className="social-icons">
              <button type="button" className="icon">
                <i className="fa-brands fa-google-plus-g"></i>
              </button>
              <button type="button" className="icon">
                <i className="fa-brands fa-facebook-f"></i>
              </button>
              <button type="button" className="icon">
                <i className="fa-brands fa-github"></i>
              </button>
              <button type="button" className="icon">
                <i className="fa-brands fa-linkedin-in"></i>
              </button>
            </div>
            <span className="text-lg">or use your email for registration</span>
            <input
              type="text"
              name="UserName"
              value={user.UserName}
              onChange={(e) => handleChange(e, "signup")}
              placeholder="User name"
              className="input-large"
            />
            <input
              type="email"
              name="Email"
              value={user.Email}
              onChange={(e) => handleChange(e, "signup")}
              placeholder="Email"
              className="input-large"
            />
            {errors.emailError.hasError && (
              <div className="text-red-500">{errors.emailError.message}</div>
            )}
            <div className="password-container">
              <input
                type={showPassword ? "text" : "password"}
                name="Password"
                value={user.Password}
                onChange={(e) => handleChange(e, "signup")}
                placeholder="Password"
                className="input-large"
              />
              <button
                type="button"
                className="password-toggle"
                onClick={() => dispatch(togglePasswordVisibility())}
              >
                <i
                  className={`fa ${showPassword ? "fa-eye-slash" : "fa-eye"}`}
                ></i>
              </button>
            </div>
            <div className="password-container">
              <input
                type={showPassword ? "text" : "password"}
                name="ConfirmPassword"
                value={user.ConfirmPassword}
                onChange={(e) => handleChange(e, "signup")}
                placeholder="Confirm Password"
                className="input-large"
              />
              <button
                type="button"
                className="password-toggle"
                onClick={() => dispatch(togglePasswordVisibility())}
              >
                <i
                  className={`fa ${showPassword ? "fa-eye-slash" : "fa-eye"}`}
                ></i>
              </button>
            </div>
            {errors.passwordError.hasError && (
              <div className="text-red-500">{errors.passwordError.message}</div>
            )}
            <button
              onClick={() => dispatch(signUp(user))}
              className="button-primary text-lg py-3 px-6"
            >
              Sign Up
            </button>
          </div>
        </div>
        <div className={`panel sign-in ${!isSignUp ? "active" : ""}`}>
          <div className="container-form">
            <h1 className="text-5xl font-bold">Sign In</h1>
            <div className="social-icons">
              <button type="button" className="icon">
                <i className="fa-brands fa-google-plus-g"></i>
              </button>
              <button type="button" className="icon">
                <i className="fa-brands fa-facebook-f"></i>
              </button>
              <button type="button" className="icon">
                <i className="fa-brands fa-github"></i>
              </button>
              <button type="button" className="icon">
                <i className="fa-brands fa-linkedin-in"></i>
              </button>
            </div>
            <span className="text-lg">or use your email and password</span>
            <input
              type="email"
              name="Email"
              value={login.Email}
              onChange={(e) => handleChange(e, "signin")}
              placeholder="Email"
              className="input-large"
            />
            {errors.emailError.hasError && (
              <div className="text-red-500">{errors.emailError.message}</div>
            )}
            <div className="password-container">
              <input
                type={showPassword ? "text" : "password"}
                name="Password"
                value={login.Password}
                onChange={(e) => handleChange(e, "signin")}
                placeholder="Password"
                className="input-large"
              />
              <button
                type="button"
                className="password-toggle"
                onClick={() => dispatch(togglePasswordVisibility())}
              >
                <i
                  className={`fa ${showPassword ? "fa-eye-slash" : "fa-eye"}`}
                ></i>
              </button>
            </div>
            {errors.passwordError.hasError && (
              <div className="text-red-500">{errors.passwordError.message}</div>
            )}
            <button type="button" className="link-primary text-lg">
              Forgot Your Password?
            </button>
            <button
              onClick={() => dispatch(signIn(login))}
              className="button-primary text-lg py-3 px-6"
            >
              Sign In
            </button>
          </div>
        </div>
        <div className="toggle-container">
          <div className="toggle">
            <div className="toggle-panel toggle-left">
              <h1 className="text-5xl font-bold">Welcome Back!</h1>
              <p className="text-lg">
                Enter your personal details to use all of site features
              </p>
              <button
                className="hiddenBtn text-lg"
                onClick={() => dispatch(toggleSignUp())}
              >
                Sign In
              </button>
            </div>
            <div className="toggle-panel toggle-right">
              <h1 className="text-5xl font-bold">Hello, Friend!</h1>
              <p className="text-lg">
                Register with your personal details to use all of site features
              </p>
              <button
                className="hiddenBtn text-lg"
                onClick={() => dispatch(toggleSignUp())}
              >
                Sign Up
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
