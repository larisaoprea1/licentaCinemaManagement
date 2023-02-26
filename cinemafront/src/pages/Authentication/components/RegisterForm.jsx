import { Box, Button, TextField } from "@mui/material";
import { useForm } from "react-hook-form";
import { Register } from "../../../api/AuthEndpoints";

const RegisterForm = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    const dataToSend = {
      userName: data.Username,
      firstName: data.FirstName,
      lastName: data.LastName,
      email: data.Email,
      phoneNumber: data.PhoneNumber,
      profileImageSrc: data.ProfileImage,
      password: data.Password,
    };

    Register(dataToSend).then((res) => {
      console.log("register");
      console.log(res);
    });
  };

  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        height: "100%",
      }}
    >
      <form noValidate autoComplete="off" onSubmit={handleSubmit(submit)}>
        <TextField
          fullWidth
          required
          label="Username"
          name="Username"
          id="fullWidth outlined-multiline-static"
          {...register("Username", {
            required: { value: true, message: "Username is required" },
          })}
          error={!!errors.Username}
          helperText={errors.Username?.message}
        />

        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1, mt: 1 }}
          label="Last Name"
          name="LastName"
          id="fullWidth outlined-multiline-static"
          {...register("LastName", {
            required: { value: true, message: "Last name is required" },
          })}
          error={!!errors.LastName}
          helperText={errors.LastName?.message}
        />
        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1 }}
          label="First Name"
          name="FirstName"
          id="fullWidth outlined-multiline-static"
          {...register("FirstName", {
            required: { value: true, message: "First name is required" },
          })}
          error={!!errors.FirstName}
          helperText={errors.FirstName?.message}
        />
        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1 }}
          label="Email"
          name="Email"
          id="fullWidth outlined-multiline-static"
          {...register("Email", {
            required: { value: true, message: "Email is required" },
          })}
          error={!!errors.Email}
          helperText={errors.Email?.message}
        />
        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1 }}
          label="Profile image"
          name="ProfileImage"
          id="fullWidth outlined-multiline-static"
          {...register("ProfileImage", {
            required: { value: true, message: "Profile image is required" },
          })}
          error={!!errors.ProfileImage}
          helperText={errors.ProfileImage?.message}
        />
        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1 }}
          label="Phone number"
          name="PhoneNumber"
          id="fullWidth outlined-multiline-static"
          {...register("PhoneNumber", {
            required: { value: true, message: "Phone number is required" },
          })}
          error={!!errors.PhoneNumber}
          helperText={errors.PhoneNumber?.message}
        />
        <TextField
          fullWidth
          required
          type="password"
          sx={{ marginBottom: 1 }}
          label="Password"
          name="Password"
          id="fullWidth outlined-multiline-static"
          {...register("Password", {
            required: { value: true, message: "Password is required" },
          })}
          error={!!errors.Password}
          helperText={errors.Password?.message}
        />
        <Box sx={{ width: "100%", display: "flex", justifyContent: "center" }}>
          {" "}
          <Button type="submit" variant="contained">
            Submit
          </Button>
        </Box>
      </form>
    </Box>
  );
};

export default RegisterForm;
