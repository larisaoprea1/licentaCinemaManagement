import {
  Box,
  Grid,
  MenuItem,
  Typography,
  FormControl,
  InputLabel,
  Select,
  Paper,
  TableContainer,
  Table,
  TableHead,
  TableRow,
  TableCell,
  TableBody,
  IconButton,
} from "@mui/material";
import { useEffect, useState } from "react";
import { GetPopulateCinemas } from "../../../api/CinemasEndpoints";
import {
  DeleteRoom,
  EditRoom,
  GetRoom,
  GetRoomsByCinemaId,
} from "../../../api/RoomsEndpoints";
import ChairIcon from "@mui/icons-material/Chair";
import { Cancel, Delete, DoneOutline, EditOutlined } from "@mui/icons-material";
import { CustomTableCell } from "../../../components/Table/CustomTableCell";
import { toast } from "react-toastify";
import SeatsModal from "./SeatsModal";

const RoomList = () => {
  const [cinemas, setCinemas] = useState([]);
  const [previous, setPrevious] = useState({});
  const [rooms, setRooms] = useState([]);
  const [selectedCinema, setSelectedCinema] = useState("");
  const [open, setOpen] = useState(false);
  const [selectedRoom, setSelectedRoom] = useState("");

  const getCinemas = () => {
    GetPopulateCinemas().then((res) => {
      setCinemas(res.data);
    });
  };

  const getRooms = () => {
    GetRoomsByCinemaId(selectedCinema).then((res) => {
      setRooms(res.data);
    });
  };

  useEffect(() => {
    getCinemas();
  }, []);

  useEffect(() => {
    if (selectedCinema) {
      getRooms();
    }
  }, [selectedCinema]);

  const handleChange = (event) => {
    setSelectedCinema(event.target.value);
  };

  const onToggleEditMode = (id) => {
    setRooms((state) => {
      return rooms.map((row) => {
        if (row.id === id) {
          return { ...row, isEditMode: !row.isEditMode };
        }
        return row;
      });
    });
  };

  const onChange = (e, row) => {
    if (!previous[row.id]) {
      setPrevious((state) => ({ ...state, [row.id]: row }));
    }
    const value = e.target.value;
    const name = e.target.name;
    const { id } = row;
    const newRows = rooms.map((row) => {
      if (row.id === id) {
        return { ...row, [name]: value };
      }
      return row;
    });
    setRooms(newRows);
  };

  const onApproveClick = (row) => {
    const data = {
      Name: row.name,
    };

    const isEmpty = Object.values(row).includes("");

    if (isEmpty) {
      toast.error("No empty field allowed!");
    } else {
      EditRoom(data, row.id).then(() => {
        toast.success("Room saved successfully!");
        onToggleEditMode(row.id);
      });
    }
  };

  const onRevert = (id) => {
    GetRoom(id).then((res) => {
      var newArr = rooms;
      const index = newArr.findIndex((obj) => obj.id === id);
      res.data.isEditMode = true;
      newArr[index] = res.data;
      setRooms(newArr);
      onToggleEditMode(id);
    });
  };

  const deleteRoom = (id) => {
    DeleteRoom(id).then(() => {
      toast.success("Room deleted successfully!");
      getRooms();
    });
  };

  const handleOpen = () => setOpen(true);

  return (
    <Box sx={{ mt: "2rem" }}>
      <Grid container spacing={2}>
        <Grid item xs={12} sx={{ width: "100%" }}>
          <FormControl fullWidth>
            <InputLabel id="demo-simple-select-standard-label">
              Select Cinema
            </InputLabel>
            <Select
              labelId="demo-simple-select-standard-label"
              id="demo-simple-select-standard"
              value={selectedCinema}
              onChange={handleChange}
              label="Select Cinema"
            >
              {cinemas.map((option) => (
                <MenuItem key={option.id} value={option.id}>
                  {option.name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>
        </Grid>

        <Grid item xs={12}>
          {selectedCinema && (
            <TableContainer component={Paper}>
              <Table>
                <TableHead>
                  <TableRow>
                    <TableCell align="center" sx={{ width: "80px" }}>
                      Actions
                    </TableCell>
                    <TableCell align="left">Name</TableCell>
                    <TableCell align="left">Cinema</TableCell>
                    <TableCell align="center">View Seats</TableCell>
                  </TableRow>
                </TableHead>
                <TableBody>
                  {rooms.map((row) => (
                    <TableRow key={row.id}>
                      <TableCell sx={{ width: "80px" }}>
                        {row.isEditMode ? (
                          <>
                            <IconButton
                              aria-label="done"
                              onClick={() => {
                                onApproveClick(row);
                              }}
                            >
                              <DoneOutline />
                            </IconButton>
                            <IconButton
                              aria-label="revert"
                              onClick={() => onRevert(row.id)}
                            >
                              <Cancel />
                            </IconButton>
                          </>
                        ) : (
                          <>
                            <IconButton
                              aria-label="edit"
                              onClick={() => onToggleEditMode(row.id)}
                            >
                              <EditOutlined />
                            </IconButton>
                            <IconButton
                              aria-label="edit"
                              onClick={() => deleteRoom(row.id)}
                            >
                              <Delete />
                            </IconButton>
                          </>
                        )}
                      </TableCell>
                      <CustomTableCell {...{ row, name: "name", onChange }} />
                      <TableCell>{row.cinema.name}</TableCell>
                      <TableCell align="center">
                        <IconButton
                          aria-label="edit"
                          onClick={() => {
                            handleOpen();
                            setSelectedRoom(row);
                          }}
                        >
                          <ChairIcon />
                        </IconButton>
                      </TableCell>
                    </TableRow>
                  ))}
                </TableBody>
              </Table>
            </TableContainer>
          )}
          {!selectedCinema && (
            <Typography sx={{ display: "flex", justifyContent: "center" }}>
              Please select a cinema
            </Typography>
          )}
        </Grid>
      </Grid>
      <SeatsModal open={open} setOpen={setOpen} selectedRoom={selectedRoom}/>
    </Box>
  );
};

export default RoomList;
