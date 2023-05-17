import * as React from "react";
import Box from "@mui/material/Box";
import { Button, Grid, Paper, Typography } from "@mui/material";
import { useState } from "react";
import { CreateBookingRequest } from "../../api/BookingEndpoints";
import { toast } from "react-toastify";

export default function SessionSeats({ session, user, getSession }) {
  const rows = {};
  const [selectedSeats, setSelectedSeats] = useState([]);
  console.log(user);

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
  session.room?.seats?.forEach((seat) => {
    if (!rows[seat.row]) {
      rows[seat.row] = [];
    }
    rows[seat.row].push(seat);
  });

  const onSubmit = () => {
    var data = {
      userId: user.Id,
      sessionId: session.id,
      reservedSeats: selectedSeats,
    };
    CreateBookingRequest(data)
      .then((res) => {
        console.log(res);
        getSession();
        setSelectedSeats([]);
        toast.success("Your seats have been reserved.");
      })
      .catch((err) => {
        toast.error("There is an error in reserving your seats.");
      });
  };

  const onCancel = () => {
    setSelectedSeats([]);
  };

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
            {rows[row]
              .sort((a, b) => a.number - b.number) // Sort seats based on their number
              .map((seat, index) => {
                const isReserved = session.reservedSeats.some(
                  (reservedSeat) => reservedSeat.seat.id === seat.id
                );
                return (
                  <Grid key={index} item>
                    <Paper
                      sx={{
                        "&:hover": {
                          color: !isReserved && "black",
                          backgroundColor: isReserved ? "#dbdee1" : "#A899EB",
                        },
                        color: isReserved ? "black" : "white",
                        width: "40px",
                        minWidth: "40px",
                        height: "40px",
                        backgroundColor: selectedSeats.includes(seat.id)
                          ? "#bc0000" // color when seat is selected
                          : isReserved
                          ? "#dbdee1"
                          : "#00bc00", // red if reserved, default color if not
                        display: "flex",
                        justifyContent: "center",
                        alignItems: "center",
                        cursor: isReserved ? "default" : "pointer",
                      }}
                      onClick={() => !isReserved && onSelectSeat(seat.id)} // disable onClick if reserved
                      component={Button}
                    >
                      {seat.row + seat.number}
                    </Paper>
                  </Grid>
                );
              })}
          </Grid>
        ))}
        {selectedSeats.length > 0 && (
          <Grid
            item
            xs={12}
            sx={{
              width: "100%",
              display: "flex",
              justifyContent: "flex-end",
              alignItems: "center",
            }}
          >
            <Button variant="outlined" sx={{ mr: "1rem" }} onClick={onCancel}>
              Cancel
            </Button>
            <Button
              variant="contained"
              onClick={onSubmit}
              disabled={!user.IsLoggedIn}
            >
              Reserve Seats
            </Button>
          </Grid>
        )}
        {isMaxReached && ( // Render message when maximum seats reached
          <Typography variant="subtitle1" sx={{ margin: "10px", color: "red" }}>
            Maximum seats reached (4 seats).
          </Typography>
        )}
        {!user.IsLoggedIn && ( // Render message when maximum seats reached
          <Typography variant="subtitle1" sx={{ margin: "10px", color: "red" }}>
            You have to be logged-in to reserve seats.
          </Typography>
        )}
      </Grid>
    </Box>
  );
}
