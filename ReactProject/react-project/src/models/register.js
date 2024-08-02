class RegisterUser {
  constructor(userName = "", email = "", password = "", confirmPassword = "") {
    this.UserName = userName;
    this.Email = email;
    this.Password = password;
    this.ConfirmPassword = confirmPassword;
  }
}

export default RegisterUser;
