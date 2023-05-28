import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { DeleteBooking, GetBookingById } from "../../api/BookingEndpoints";
import {
  Box,
  Container,
  Grid,
  IconButton,
  Menu,
  MenuItem,
  Typography,
} from "@mui/material";
import QRCode from "react-qr-code";
import { format, zonedTimeToUtc } from "date-fns-tz";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import { toast } from "react-toastify";

const Booking = () => {
  const [booking, setBooking] = useState([]);
  const params = useParams();
  const navigate = useNavigate();

  const getBooking = () => {
    GetBookingById(params.id).then((res) => {
      setBooking(res.data);
    });
  };

  useEffect(() => {
    getBooking();
  }, []);

  const [anchorEl, setAnchorEl] = useState(null);
  const open = Boolean(anchorEl);
  const handleClick = (event) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const handleDelete = () => {
    DeleteBooking(booking.id).then((res) => {
      toast.success("Booking canceled");
      handleClose();
      navigate("/");
    });
  };

  return (
    <Container maxWidth="xl" sx={{ marginTop: "1rem" }}>
      <Box sx={{ display: "flex", justifyContent: "space-between" }}>
        <Typography sx={{ fontSize: "3rem" }}>Movie reservation</Typography>
        <div>
          <IconButton
            aria-label="more"
            id="long-button"
            aria-controls={open ? "long-menu" : undefined}
            aria-expanded={open ? "true" : undefined}
            aria-haspopup="true"
            onClick={handleClick}
          >
            <MoreVertIcon />
          </IconButton>
          <Menu
            id="long-menu"
            MenuListProps={{
              "aria-labelledby": "long-button",
            }}
            anchorEl={anchorEl}
            open={open}
            onClose={handleClose}
          >
            <MenuItem key={"Delete"} onClick={handleDelete}>
              Cancel Booking
            </MenuItem>
          </Menu>
        </div>
      </Box>

      <Box
        sx={{
          padding: 2,
          // backgroundColor: "#F5F5F5",
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
            <Grid
              item
              xs={12}
              lg={4}
              sx={{
                display: "flex",
                justifyContent: "center",
                flexDirection: "column",
                alignItems: "center",
              }}
            >
              {booking.id && <QRCode value={booking.id} size={400} />}
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
              {booking && (
                <Typography>
                  {" "}
                  {format(
                    zonedTimeToUtc(
                      new Date(
                        booking?.session
                          ? booking.session.sessionStart
                          : 1317996123
                      )
                    ),
                    "EEEE dd p"
                  )}
                </Typography>
              )}
              <Typography variant="h6" sx={{ marginTop: 2 }}>
                Room: {booking.session?.room?.name}
              </Typography>
            </Grid>
          </Grid>
        </Box>
      </Box>
    </Container>
  );
};

export default Booking;
