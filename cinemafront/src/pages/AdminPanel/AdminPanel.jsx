import { Button, Container, Paper, Typography } from "@mui/material";
import { Box } from "@mui/system";
import { useState } from "react";
import { Outlet } from "react-router-dom";
import CustomDrawer from "./Drawer/CustomDrawer";

const AdminPanel = () => {
  const [open, setOpen] = useState(false);
  const toggleDrawer = (newOpen) => () => {
    setOpen(newOpen);
  };

  return (
    <Box sx={{ display: "flex", flexDirection: "row" }}>
      <CustomDrawer open={open} setOpen={setOpen} toggleDrawer={toggleDrawer} />
      <Box sx={{ display: "flex", flexDirection: "column", width: "100%" }}>
        <Box
          component={Paper}
          elevation={1}
          sx={{
            display: "flex",
            width: "100%",
            justifyContent: { lg: "center", xs: "flex-start" },
            height: "50px",
            alignItems: "center",
          }}
        >
          <Button
            onClick={toggleDrawer(true)}
            sx={{ display: { xs: "block", lg: "none" } }}
          >
            Open Menu
          </Button>
          <Typography
            sx={{ display: { xs: "none", lg: "block" }, fontSize: "20px" }}
          >
            Cinema Management Admin Panel
          </Typography>
        </Box>
        <Container maxWidth="lg">
          <Outlet />
        </Container>
      </Box>
    </Box>
  );
};
export default AdminPanel;
