import * as React from "react";
import Box from "@mui/material/Box";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import Modal from "@mui/material/Modal";
import { Grid, MenuItem, Paper, TextField } from "@mui/material";
import { GetPopulateCinemas } from "../../../api/CinemasEndpoints";
import { useState } from "react";
import { useEffect } from "react";
import { Controller, useForm } from "react-hook-form";
import { GetRoomsByCinemaId } from "../../../api/RoomsEndpoints";
import { DateTimePicker } from "@mui/x-date-pickers";
import { CreateSessionRequest } from "../../../api/SessionsEndpoints";
import { toast } from "react-toastify";

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

export default function CreateSession({ open, setOpen, movieId }) {
  const handleClose = () => {
    reset();
    setOpen(false);
  };

  const {
    register,
    handleSubmit,
    reset,
    watch,
    setValue,
    control,
    formState: { errors },
  } = useForm({
    defaultValues: {
      Cinema: "",
      Room: "",
      SessionStart: new Date(),
      SessionEnd: new Date(),
    },
  });

  const [cinemas, setCinemas] = useState([]);
  const [rooms, setRooms] = useState([]);
  const selectedCinema = watch("Cinema");

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

  console.log(rooms);
  const submit = (data) => {
    const dataToPost = {
      sessionStart: data.SessionStart,
      sessionEnd: data.SessionEnd,
      movieId: movieId,
      roomId: data.Room,
    };

    CreateSessionRequest(dataToPost)
      .then((res) => {
        toast.success("Session created");
      })
      .catch((err) => {
        console.log(err);
        toast.error(err.response.data);
      });
  };

  return (
    <div>
      <Modal
        open={open}
        onClose={handleClose}
        aria-labelledby="modal-modal-title"
        aria-describedby="modal-modal-description"
      >
        <Box sx={style}>
          <form
            noValidate
            autoComplete="off"
            style={{ marginBottom: 20, width: "100%" }}
            onSubmit={handleSubmit(submit)}
          >
            <Grid container spacing={2}>
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
                  <MenuItem
                    value={""}
                    onClick={() => {
                      setValue("Cinema", "");
                      setRooms([]);
                    }}
                  >
                    NONE
                  </MenuItem>
                  {cinemas.map((option) => (
                    <MenuItem key={option.id} value={option.id}>
                      {option.name}
                    </MenuItem>
                  ))}
                </TextField>
              </Grid>

              <Grid item xs={12}>
                <TextField
                  select
                  fullWidth
                  label="Select Room"
                  defaultValue=""
                  inputProps={register("Room", {
                    required: "Please enter Room",
                  })}
                  error={errors.Room}
                  helperText={errors.Room?.message}
                >
                  <MenuItem value={""}>NONE</MenuItem>
                  {rooms.map((option) => (
                    <MenuItem key={option.id} value={option.id}>
                      {option.name}
                    </MenuItem>
                  ))}
                </TextField>
              </Grid>

              <Grid item xs={12} lg={6}>
                <Controller
                  control={control}
                  name="SessionStart"
                  rules={{
                    required: {
                      value: true,
                      message: "Session Start is required",
                    },
                  }}
                  render={({
                    field: { ref, onBlur, name, ...field },
                    fieldState,
                  }) => (
                    <DateTimePicker
                      sx={{ width: "100%" }}
                      {...field}
                      inputRef={ref}
                      label="Session Start"
                      renderInput={(inputProps) => (
                        <TextField
                          {...inputProps}
                          onBlur={onBlur}
                          name={name}
                          error={!!fieldState.error}
                          helperText={fieldState.error?.message}
                        />
                      )}
                    />
                  )}
                />
              </Grid>

              <Grid item xs={12} lg={6}>
                <Controller
                  control={control}
                  name="SessionEnd"
                  rules={{
                    required: {
                      value: true,
                      message: "Session End is required",
                    },
                  }}
                  render={({
                    field: { ref, onBlur, name, ...field },
                    fieldState,
                  }) => (
                    <DateTimePicker
                      sx={{ width: "100%" }}
                      {...field}
                      inputRef={ref}
                      label="Session End"
                      renderInput={(inputProps) => (
                        <TextField
                          {...inputProps}
                          onBlur={onBlur}
                          name={name}
                          error={!!fieldState.error}
                          helperText={fieldState.error?.message}
                        />
                      )}
                    />
                  )}
                />
              </Grid>

              <Grid item xs={12}>
                <Button type="submit" variant="contained">
                  Submit
                </Button>
              </Grid>
            </Grid>
          </form>
        </Box>
      </Modal>
    </div>
  );
}
