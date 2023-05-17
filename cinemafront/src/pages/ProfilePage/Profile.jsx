import { useEffect, useState } from "react";
import { GetUserByUsername } from "../../api/AuthEndpoints";
import { useParams } from "react-router";
import { Box, Container } from "@mui/system";
import { Avatar, Grid, Paper, Tab, Tabs, Typography } from "@mui/material";
import UserBookings from "./UserBookings";

const Profile = () => {
  const [currentUser, setCurrentUser] = useState([]);
  const params = useParams();
  const getUser = () => {
    GetUserByUsername(params.username).then((res) => {
      setCurrentUser(res.data);
    });
  };

  useEffect(() => {
    getUser();
  }, []);

  const [selectedTab, setSelectedTab] = useState(0);

  const handleTabChange = (event, newValue) => {
    setSelectedTab(newValue);
  };

  const TabPanel = ({ children, value, index }) => {
    return (
      <div role="tabpanel" hidden={value !== index} id={`tabpanel-${index}`}>
        {value === index && <Box p={3}>{children}</Box>}
      </div>
    );
  };
  
  return (
    <Container maxWidth="md" sx={{ marginTop: 4 }}>
      <Paper elevation={3} sx={{ padding: 4 }}>
        <Grid container spacing={4} alignItems="center" justify="center">
          <Grid item>
            <Avatar
              alt={currentUser.userName}
              src={currentUser.profileImageSrc}
              sx={{
                width: 120,
                height: 120,
                marginBottom: 2,
              }}
            />
          </Grid>
          <Grid item>
            <Typography variant="h4" component="h1">
              {currentUser.firstName} {currentUser.lastName}
            </Typography>
            <Typography variant="h6" component="h2" color="textSecondary">
              {currentUser.userName}
            </Typography>
            <Typography variant="body1" component="p" color="textSecondary">
              Email: {currentUser.email}
            </Typography>
            <Typography variant="body1" component="p" color="textSecondary">
              Phone: {currentUser.phoneNumber}
            </Typography>
          </Grid>
        </Grid>
        <Tabs
          value={selectedTab}
          onChange={handleTabChange}
          centered
          variant="fullWidth"
        >
          <Tab label="Upcoming Bookings" />
          <Tab label="Reviews" />
        </Tabs>
        <TabPanel value={selectedTab} index={0}>
          <UserBookings user={currentUser} />
        </TabPanel>
        <TabPanel value={selectedTab} index={1}></TabPanel>
      </Paper>
    </Container>
  );
};

export default Profile;
