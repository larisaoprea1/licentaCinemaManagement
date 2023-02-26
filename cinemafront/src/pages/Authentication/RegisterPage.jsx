import { Box, Container } from "@mui/material";
import RegisterForm from "./components/RegisterForm";

const RegisterPage = () => {
  return (
    <Container sx={{ height: "calc(100vh - 68.5px)" }} maxWidth="sm">
      <RegisterForm />
    </Container>
  );
};
export default RegisterPage;
