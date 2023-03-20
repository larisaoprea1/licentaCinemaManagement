import { Container } from "@mui/material";
import { Box } from "@mui/system";
import { Outlet } from "react-router-dom";
import CustomDrawer from "./Drawer/CustomDrawer";

const AdminPanel = () => {
  return (
    <Box>
      <Container maxWidth="md">
        <CustomDrawer />
        <Outlet />
      </Container>
    </Box>
  );
};
export default AdminPanel;
