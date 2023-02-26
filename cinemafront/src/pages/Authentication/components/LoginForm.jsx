import { Box, Button, TextField } from "@mui/material";
import { useForm } from "react-hook-form";
import { Login } from "../../../api/AuthEndpoints";

const LoginForm = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    const dataToSend = {
      email: data.Email,
      password: data.Password,
    };

    Login(dataToSend).then((res) => {
      console.log("login");
      console.log(res);
    });
  };

  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        width: "100%",
        height: "100%",
      }}
    >
      <form noValidate autoComplete="off" onSubmit={handleSubmit(submit)}>
        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1, mt: 1 }}
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

export default LoginForm;
