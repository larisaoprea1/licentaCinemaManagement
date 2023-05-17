import * as React from "react";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";
import { Grid, Paper } from "@mui/material";

const style = {
  position: "absolute",
  top: "50%",
  left: "50%",
  transform: "translate(-50%, -50%)",
  width: "90%",
  bgcolor: "background.paper",
  border: "2px solid #000",
  boxShadow: 24,
  p: 4,
  overflow: "auto",
};

export default function SeatsModal({ open, setOpen, selectedRoom }) {
  const handleClose = () => setOpen(false);

  const rows = {};

  // Separate the cinema data by row
  selectedRoom.seats?.forEach((seat) => {
    if (!rows[seat.row]) {
      rows[seat.row] = [];
    }
    rows[seat.row].push(seat);
  });

  return (
    <div>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <Grid
            container
            spacing={2}
            sx={{
              display: "flex",
              justifyContent: "center",
              width: { lg: "100%", xs: "800px" },
            }}
          >
            {Object.keys(rows).map((row, index) => (
              <Grid
                key={index}
                container
                item
                spacing={2}
                alignItems="center"
                sx={{
                  display: "flex",
                  justifyContent: "center",
                  width: "100%",
                }}
              >
                {rows[row].map((seat, index) => (
                  <Grid key={index} item>
                    <Paper
                      sx={{
                        width: "40px",
                        height: "40px",
                        backgroundColor: "#f1f1f1",
                        display: "flex",
                        justifyContent: "center",
                        alignItems: "center",
                      }}
                    >
                      {seat.row + seat.number}
                    </Paper>
                  </Grid>
                ))}
              </Grid>
            ))}
          </Grid>
        </Box>
      </Modal>
    </div>
  );
}
