import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { GetBookingById } from "../../api/BookingEndpoints";
import { Box, Grid, Typography } from "@mui/material";
import QRCode from "react-qr-code";

const Booking = () => {
  const [booking, setBooking] = useState([]);
  const params = useParams();

  const getBooking = () => {
    GetBookingById(params.id).then((res) => {
      setBooking(res.data);
    });
  };

  useEffect(() => {
    getBooking();
  }, []);

  console.log(booking);

  return (
    <Box
      sx={{
        padding: 2,
        backgroundColor: "#F5F5F5",
        minHeight: "100%",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Box
        sx={{
          backgroundColor: "#FFFFFF",
          padding: "24px",
          borderRadius: "8px",
          boxShadow: "0 4px 8px rgba(0, 0, 0, 0.1)",
          width: "100%",
        }}
      >
        <Grid container spacing={2}>
          <Grid item xs={12} lg={4} sx={{display:"flex", justifyContent:"center", flexDirection:"column", alignItems:"center"}}>
            {booking.id && <QRCode value={booking.id} size={400}/>}
          </Grid>
          <Grid item xs={12} lg={8}>
            <Typography variant="h6" sx={{ marginTop: 2 }}>
              Movie: {booking.session?.movie?.name}
            </Typography>
            <Typography variant="h6" sx={{ marginTop: 2 }}>
              Format: {booking.session?.movie?.format}
            </Typography>
            <Typography variant="h6" sx={{ marginTop: 2 }}>
              Reserved Seats:
            </Typography>
            {booking.reservedSeats?.map((reservedSeat) => (
              <Typography
                key={reservedSeat.id}
                sx={{
                  border: "1px solid #ddd",
                  borderRadius: "4px",
                  padding: "8px",
                  margin: "4px 0",
                }}
              >
                Row: {reservedSeat.seat?.row}, Number:{" "}
                {reservedSeat.seat?.number}
              </Typography>
            ))}
            <Typography variant="h6" sx={{ marginTop: 2 }}>
              Session Start Time:
            </Typography>
            <Typography>{booking.session?.sessionStart}</Typography>
            <Typography variant="h6" sx={{ marginTop: 2 }}>
              Room: {booking.session?.room?.name}
            </Typography>
          </Grid>
        </Grid>
      </Box>
    </Box>
  );
};

export default Booking;
