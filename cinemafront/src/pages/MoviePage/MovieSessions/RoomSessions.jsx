import * as React from "react";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";
import { Divider, Grid, Paper } from "@mui/material";
import { GetSessionsByRoomId } from "../../../api/SessionsEndpoints";
import { useEffect } from "react";
import { useState } from "react";
import { format, zonedTimeToUtc } from "date-fns-tz";
import { useNavigate } from "react-router-dom";

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: "50%",
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
  overflow: "auto",
};

export default function RoomSessions({ selectedRoom }) {
  const [sessions, setSessions] = useState([]);
  const [groupedSessions, setGroupedSessions] = useState({});
  const navigate = useNavigate();
  console.log(selectedRoom);
  useEffect(() => {
    setGroupedSessions(groupSessionsByDate(sessions));
  }, [sessions, selectedRoom]);

  function groupSessionsByDate(sessions) {
    if (sessions) {
      return sessions.reduce((acc, session) => {
        const date = session.sessionStart.slice(0, 10);
        if (!acc[date]) {
          acc[date] = [];
        }
        acc[date].push(session);
        return acc;
      }, {});
    }
  }

  const getSessions = () => {
    GetSessionsByRoomId(selectedRoom).then((res) => {
      setSessions(res.data);
    });
  };

  useEffect(() => {
    if (selectedRoom) {
      getSessions();
    }
  }, [selectedRoom]);

  return (
    <div>
      {Object.entries(groupedSessions).map(([date, sessions]) => (
        <div key={date}>
          <Typography variant="h6">
            {format(zonedTimeToUtc(new Date(date)), "EEEE dd")}
          </Typography>
          <Divider sx={{ marginBottom: ".5rem" }} />
          <Grid container spacing={2}>
            {sessions.map((session) => (
              <>
                <Grid item key={session.id} lg={3}>
                  <Button
                    variant="contained"
                    onClick={() => {
                      navigate(
                        `/movie/${session.movieId}/session/${session.id}`
                      );
                    }}
                  >
                    <Typography sx={{ color: "white" }}>
                      {format(
                        zonedTimeToUtc(new Date(session?.sessionStart)),
                        "p"
                      )}{" "}
                      -{" "}
                      {format(
                        zonedTimeToUtc(new Date(session?.sessionEnd)),
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
}
