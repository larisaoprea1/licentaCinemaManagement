import { Box } from "@mui/material";
import LoginForm from "./components/LoginForm";

const LoginPage = () => {
  return (
    <Box sx={{ height: "calc(100vh - 68.5px)" }}>
      <LoginForm />
    </Box>
  );
};
export default LoginPage;
