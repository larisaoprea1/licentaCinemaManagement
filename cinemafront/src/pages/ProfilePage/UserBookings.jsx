import { useEffect, useState } from "react";
import { GetBookingsForUser } from "../../api/BookingEndpoints";
import { Box } from "@mui/system";
import {
  Divider,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
  Paper,
  Typography,
} from "@mui/material";
import { format, zonedTimeToUtc } from "date-fns-tz";
import QRCode from "react-qr-code";
import { useNavigate } from "react-router-dom";

const UserBookings = ({ user }) => {
  const [bookings, setBookings] = useState([]);
  const navigate = useNavigate();
  const getBookings = () => {
    GetBookingsForUser(user.id).then((res) => {
      setBookings(res.data);
    });
  };
  console.log(bookings);
  useEffect(() => {
    if (user.id) {
      getBookings();
    }
  }, [user]);

  return (
    <List>
      {bookings.map((booking, index) => (
        <>
          <ListItem
            key={index}
            alignItems="flex-start"
            sx={{
              "&:hover": {
                border: "1px solid black",
              },
              cursor: "pointer",
            }}
            onClick={() => navigate(`/booking/${booking.id}`)}
          >
            <ListItemAvatar>
              <QRCode size={50} value={booking?.id}></QRCode>
            </ListItemAvatar>
            <ListItemText
              primary={booking.session?.movie?.name}
              secondary={
                <Box sx={{ marginTop: "0.2rem" }}>
                  <Typography
                    component="span"
                    variant="body2"
                    color="textPrimary"
                  >
                    {format(
                      zonedTimeToUtc(new Date(booking.session?.sessionStart)),
                      "EEEE dd p"
                    )}
                  </Typography>
                  <Typography
                    component="span"
                    variant="body2"
                    color="textPrimary"
                  >
                    {` — Seats: `}
                    {booking.reservedSeats?.map((reservedSeat) => {
                      return ` ${reservedSeat.seat?.row}${reservedSeat.seat?.number} `;
                    })}
                  </Typography>
                </Box>
              }
            />
          </ListItem>
          <Divider />{" "}
        </>
      ))}
    </List>
  );
};

export default UserBookings;
