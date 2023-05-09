import React from "react";
import { Controller, useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Autocomplete, Box, Grid, Typography } from "@mui/material";
import { CreateGenreRequest } from "../../../api/GenreEndpoints";
import { toast } from "react-toastify";
import { CreateCinemaRequest } from "../../../api/CinemasEndpoints";
import { countries } from "../../../utils/countries";

const CreateCinema = () => {
  const {
    register,
    handleSubmit,
    reset,
    control,
    formState: { errors },
  } = useForm({
    defaultValues: {
      Country: {code: '', label: '', phone: ''},
    },
  });

  const submit = (data) => {
    const dataToPost = {
      name: data.Name,
      address: data.Address,
      city: data.City,
      zipcode: data.Zipcode,
      country: data.Country.label,
    };
    console.log(data);
    CreateCinemaRequest(dataToPost)
      .then((response) => {
        toast.success("Cinema created!");
        reset();
      })
      .catch((err) => console.log(err));
  };

  return (
    <Box
      sx={{ width: "100%", mt: 3 }}
      display="flex"
      justifyContent="center"
      alignItems="center"
      flexDirection="column"
    >
      <Typography mb={2}>Create Cinema</Typography>
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
              label="Cinema Name"
              name="Name"
              {...register("Name", {
                required: { value: true, message: "Cinema Name is required" },
                maxLength: { value: 50, message: "Name is too long" },
              })}
              error={!!errors.Name}
              helperText={errors.Name?.message}
            />
          </Grid>

          <Grid item xs={12}>
            <TextField
              fullWidth
              required
              sx={{ marginBottom: 1 }}
              label="Address"
              name="Address"
              {...register("Address", {
                required: { value: true, message: "Address is required" },
              })}
              error={!!errors.Address}
              helperText={errors.Address?.message}
            />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              required
              sx={{ marginBottom: 1 }}
              label="City"
              name="City"
              {...register("City", {
                required: { value: true, message: "City is required" },
              })}
              error={!!errors.City}
              helperText={errors.City?.message}
            />
          </Grid>

          <Grid item xs={12} md={6}>
            <TextField
              fullWidth
              required
              sx={{ marginBottom: 1 }}
              label="Zipcode"
              name="Zipcode"
              {...register("Zipcode", {
                required: { value: true, message: "Zipcode is required" },
              })}
              error={!!errors.Zipcode}
              helperText={errors.Zipcode?.message}
            />
          </Grid>

          <Grid item xs={12}>
            <Controller
              render={({ field: { onChange, value } }) => (
                <Autocomplete
                  options={countries}
                  onChange={(event, item) => {
                    onChange(item);
                  }}
                  required
                  autoHighlight
                  value={value}
                  getOptionLabel={(option) => option.label}
                  renderOption={(props, option) => (
                    <Box
                      component="li"
                      sx={{ "& > img": { mr: 2, flexShrink: 0 } }}
                      {...props}
                    >
                      <img
                        loading="lazy"
                        width="20"
                        src={`https://flagcdn.com/w20/${option.code.toLowerCase()}.png`}
                        srcSet={`https://flagcdn.com/w40/${option.code.toLowerCase()}.png 2x`}
                        alt=""
                      />
                      {option.label} ({option.code})
                    </Box>
                  )}
                  renderInput={(params) => (
                    <TextField
                      {...params}
                      label="Choose a country"
                      inputProps={{
                        ...params.inputProps,
                        autoComplete: "new-password", // disable autocomplete and autofill
                      }}
                    />
                  )}
                />
              )}
              defaultValue={{code: '', label: '', phone: ''}}
              control={control}
              name="Country"
            />
          </Grid>
          <Grid item lg={12}>
            {" "}
            <Button onClick={() => reset()}>Reset</Button>
            <Button type="submit" variant="contained">
              Submit
            </Button>
          </Grid>
        </Grid>
      </form>
    </Box>
  );
};

export default CreateCinema;
