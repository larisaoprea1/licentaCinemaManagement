import { Box, Button, TextField } from "@mui/material";
import { useForm } from "react-hook-form";
import { Login } from "../../../api/AuthEndpoints";
import { useUser } from "../../../context/useUser";
import jwt_decode from "jwt-decode";
import { useNavigate } from "react-router-dom";

const LoginForm = () => {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const{setUser, user, setToken} = useUser();
  const history = useNavigate()

  const submit = (data) => {
    const dataToSend = {
      email: data.Email,
      password: data.Password,
    };

    Login(dataToSend).then((res) => {
      console.log(res);
      setToken(res.data.token)
      setUser(jwt_decode(res.data.token))
      history("/")
      localStorage.setItem('jwt', res.data.token)
    }).catch(()=>{
      console.log("error")
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
