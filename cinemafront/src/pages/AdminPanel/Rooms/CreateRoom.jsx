import React from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Grid, MenuItem, Typography, Divider } from "@mui/material";
import { toast } from "react-toastify";
import { CreateRoomRequest } from "../../../api/RoomsEndpoints";
import { GetPopulateCinemas } from "../../../api/CinemasEndpoints";
import { useState } from "react";
import { useEffect } from "react";
import RowInput from "./RowInput";

const CreateRoom = () => {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const [cinemas, setCinemas] = useState([]);
  const [rows, setRows] = useState([{ row: "A", number: 0 }]);

  const submit = (data) => {
    const newRows = rows.flatMap(({ row, number }) =>
      Array.from({ length: number }, (_, index) => ({
        row,
        number: index + 1,
      }))
    );

    const dataToPost = {
      name: data.Name,
      cinemaId: data.Cinema,
      seats: newRows,
    };

    CreateRoomRequest(dataToPost)
      .then((response) => {
        toast.success("Room created!");
        resetForm()
      })
      .catch((err) => console.log(err));
  };

  const getCinemas = () => {
    GetPopulateCinemas().then((res) => {
      setCinemas(res.data);
    });
  };

  function handleNewRow(row) {
    console.log("New row added:", row);
  }

  function handleRemoveRow(row) {
    console.log("Row removed:", row);
  }

  const resetForm = () => {
    reset();
    removeAll();
  };

  function removeAll() {
    setRows([{ row: "A", number: 0 }]);
  }

  useEffect(() => {
    getCinemas();
  }, []);

  return (
    <Box
      sx={{ width: "100%", mt: 3 }}
      display="flex"
      justifyContent="center"
      alignItems="center"
      flexDirection="column"
    >
      <Typography mb={2}>Create Room</Typography>
      <form
        noValidate
        autoComplete="off"
        style={{ marginBottom: 20, width: "100%" }}
        onSubmit={handleSubmit(submit)}
      >
        <Grid container spacing={2}>
          <Grid item xs={12}>
            <TextField
              fullWidth
              required
              sx={{ marginBottom: 1 }}
              label="Room Name"
              name="Name"
              {...register("Name", {
                required: { value: true, message: "Name is required" },
                maxLength: { value: 50, message: "Name is too long" },
              })}
              error={!!errors.Name}
              helperText={errors.Name?.message}
            />
          </Grid>

          <Grid item xs={12}>
            <TextField
              select
              fullWidth
              label="Select Cinema"
              defaultValue=""
              inputProps={register("Cinema", {
                required: "Please enter Cinema",
              })}
              error={errors.Cinema}
              helperText={errors.Cinema?.message}
            >
              {cinemas.map((option) => (
                <MenuItem key={option.id} value={option.id}>
                  {option.name}
                </MenuItem>
              ))}
            </TextField>
          </Grid>

          <Grid item xs={12} sx={{ justifyContent: "center", display: "flex" }}>
            <Typography sx={{ fontWeight: "bold" }}>Room Seats</Typography>
          </Grid>

          <Grid item xs={12} sx={{ width: "100%" }}>
            <RowInput
              onAddRow={handleNewRow}
              rows={rows}
              setRows={setRows}
              onRemoveRow={handleRemoveRow}
            />
          </Grid>
          <Divider />
          <Grid item xs={12}>
            <Button type="submit" variant="contained">
              Submit
            </Button>
          </Grid>
        </Grid>
      </form>
    </Box>
  );
};

export default CreateRoom;
