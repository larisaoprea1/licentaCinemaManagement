import React from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Grid, MenuItem, Typography } from "@mui/material";
import { toast } from "react-toastify";
import { CreateRoomRequest } from "../../../api/RoomsEndpoints";
import { GetPopulateCinemas } from "../../../api/CinemasEndpoints";
import { useState } from "react";
import { useEffect } from "react";

const CreateRoom = () => {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const [cinemas, setCinemas] = useState([]);

  const submit = (data) => {
    const dataToPost = {
      name: data.Name,
    };

    console.log(data)
    // CreateRoomRequest(dataToPost)
    //   .then((response) => {
    //     toast.success("Room created!");
    //     reset();
    //   })
    //   .catch((err) => console.log(err));
  };

  const getCinemas = () => {
    GetPopulateCinemas().then((res) => {
      setCinemas(res.data);
    });
  };

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
        style={{ marginBottom: 20 }}
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
              label="Select"
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
        </Grid>

        <Button onClick={() => reset()}>Reset</Button>
        <Button type="submit" variant="contained">
          Submit
        </Button>
      </form>
    </Box>
  );
};

export default CreateRoom;
