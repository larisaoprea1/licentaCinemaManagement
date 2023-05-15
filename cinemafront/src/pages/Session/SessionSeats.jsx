import * as React from "react";
import Box from "@mui/material/Box";
import { Button, Grid, Paper, Typography } from "@mui/material";
import { useState } from "react";

export default function SessionSeats({ selectedRoom }) {
  const rows = {};
  const [selectedSeats, setSelectedSeats] = useState([]);

  console.log(selectedSeats);

  const onSelectSeat = (id) => {
    if (selectedSeats.includes(id)) {
      setSelectedSeats((prevArray) =>
        prevArray.filter((seatId) => seatId !== id)
      );
    } else {
      if (selectedSeats.length < 4) {
        // Limit the maximum to 4 selected seats
        setSelectedSeats((prevArray) => [...prevArray, id]);
      }
    }
  };

  const isMaxReached = selectedSeats.length === 4;
  selectedRoom.seats?.forEach((seat) => {
    if (!rows[seat.row]) {
      rows[seat.row] = [];
    }
    rows[seat.row].push(seat);
  });

  return (
    <Box>
      <Grid
        container
        spacing={2}
        sx={{
          display: "flex",
          justifyContent: "center",
          width: { lg: "100%" },
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
                    "&:hover": {
                      color: "black",
                      backgroundColor: "#A899EB",
                    },
                    color: "white",
                    width: "40px",
                    minWidth: "40px",
                    height: "40px",
                    backgroundColor: selectedSeats.includes(seat.id)
                      ? "#bc0000" // color when seat is selected
                      : "#00bc00", // default color
                    display: "flex",
                    justifyContent: "center",
                    alignItems: "center",
                    cursor: "pointer",
                  }}
                  onClick={() => onSelectSeat(seat.id)}
                  component={Button}
                >
                  {seat.row + seat.number}
                </Paper>
              </Grid>
            ))}
          </Grid>
        ))}
        {isMaxReached && ( // Render message when maximum seats reached
          <Typography variant="subtitle1" sx={{ margin: "10px", color: "red" }}>
            Maximum seats reached (4 seats).
          </Typography>
        )}
      </Grid>
    </Box>
  );
}
