import { Button, Divider, Grid, List, Typography } from "@mui/material";
import { useEffect } from "react";
import { useState } from "react";
import { format, zonedTimeToUtc } from "date-fns-tz";
import { useNavigate } from "react-router-dom";

const Sessions = ({ sessions }) => {
  const [groupedSessions, setGroupedSessions] = useState({});
  const navigate = useNavigate();

  useEffect(() => {
    setGroupedSessions(groupSessionsByDate(sessions));
  }, [sessions]);

  function groupSessionsByDate(sessions) {
    return sessions.reduce((acc, session) => {
      const date = session.sessionStart.slice(0, 10);
      if (!acc[date]) {
        acc[date] = [];
      }
      acc[date].push(session);
      return acc;
    }, {});
  }

  console.log(sessions)
  return (
    <div>
      {sessions.length == 0 && <Typography>No sessions are currently available</Typography>}
      {Object.entries(groupedSessions).map(([date, sessions]) => (
        <div key={date}>
          <Typography variant="h6">
            {format(zonedTimeToUtc(new Date(date)), "EEEE dd")}
          </Typography>
          <Divider sx={{ marginBottom: ".5rem" }} />
          <Grid container spacing={2}>
            {sessions.map((session) => (
              <>
                <Grid item key={session.id} lg={1}>
                  <Button
                    variant="contained"
                    onClick={() => {
                      navigate(`session/${session.id}`);
                    }}
                  >
                    <Typography sx={{ color: "white" }}>
                      {format(
                        zonedTimeToUtc(new Date(session?.sessionStart)),
                        "p"
                      )}
                    </Typography>
                  </Button>
                </Grid>
              </>
            ))}
          </Grid>
        </div>
      ))}
    </div>
  );
};

export default Sessions;
