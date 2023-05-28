import { Outlet } from "react-router-dom";
import Header from "../../components/Header/Header";
import { Box } from "@mui/material";

const ProtectedRoute = () => {
  return (
    <Box>
      <Header />
      <Outlet />
    </Box>
  );
};

export default ProtectedRoute;
