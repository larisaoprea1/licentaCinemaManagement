import { useParams } from "react-router-dom";
import { GetSessionById } from "../../api/SessionsEndpoints";
import { useEffect, useState } from "react";
import { Box, Container, Grid, Paper, Typography } from "@mui/material";
import { format, zonedTimeToUtc } from "date-fns-tz";
import SessionSeats from "./SessionSeats";

const Session = () => {
  const params = useParams();
  const [session, setSession] = useState([]);
  console.log(session);

  const getSession = () => {
    GetSessionById(params.sessionId).then((res) => {
      setSession(res.data);
    });
  };

  useEffect(() => {
    getSession();
  }, []);
  return (
    <Container
      maxWidth="xl"
      sx={{
        marginTop: "2rem",
        marginBottom: "2rem",
        display: "flex",
        justifyContent: "center",
        flexDirection: "column",
      }}
    >
      <Grid
        container
        spacing={2}
        component={Paper}
        sx={{ marginBottom: "2rem", paddingBottom: "1rem" }}
      >
        <Grid item lg={2}>
          <Box
            sx={{
              width: 200,
            }}
            component="img"
            className="gameImg"
            src={session.movie?.poster}
          />
        </Grid>
        <Grid item xs={12} lg={10}>
          <Grid
            container
            spacing={2}
            sx={{ display: "flex", alignItems: "center" }}
          >
            <Grid item>
              <Typography sx={{ fontSize: "20px" }}>
                {session.movie?.name}
              </Typography>
              <Typography sx={{ fontSize: "20px" }}>
                {session.room?.name}
              </Typography>
              <Typography sx={{ fontSize: "20px" }}>
                {session?.sessionStart &&
                  format(
                    zonedTimeToUtc(new Date(session?.sessionStart)),
                    "dd EEEE p"
                  )}
              </Typography>
            </Grid>
            <Grid item></Grid>
          </Grid>
        </Grid>
      </Grid>
      <SessionSeats selectedRoom={session?.room ? session?.room : []} />
    </Container>
  );
};

export default Session;
