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

export default function SessionsModal({ open, setOpen, selectedRoom }) {
  const handleClose = () => setOpen(false);
  const [sessions, setSessions] = useState([]);
  const [groupedSessions, setGroupedSessions] = useState({});
  const navigate = useNavigate();

  useEffect(() => {
    setGroupedSessions(groupSessionsByDate(sessions));
  }, [sessions]);

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
    GetSessionsByRoomId(selectedRoom.id).then((res) => {
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
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
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
                      <Grid item key={session.id} lg={2}>
                        <Button
                          variant="contained"
                          onClick={() => {
                            navigate(`/movie/${session.movieId}/session/${session.id}`);
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
        </Box>
      </Modal>
    </div>
  );
}
