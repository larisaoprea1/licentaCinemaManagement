import React, { useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import {
  Autocomplete,
  Box,
  Checkbox,
  FormControl,
  FormControlLabel,
  FormHelperText,
  Grid,
  InputAdornment,
  InputLabel,
  MenuItem,
  OutlinedInput,
  Select,
  Typography,
} from "@mui/material";
import { toast } from "react-toastify";
import { DatePicker, DateTimePicker } from "@mui/x-date-pickers";
import { GetPopulateGenres } from "../../../api/GenreEndpoints";
import { GetPopulateActors } from "../../../api/ActorsEndpoints";
import { GetPopulateProductions } from "../../../api/ProductionEndpoints";
import { CreateMovieRequest } from "../../../api/MoviesEndpoints";

const CreateMovie = () => {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
    control,
  } = useForm({
    defaultValues: {
      ReleaseDate: new Date(),
      RunDate: new Date(),
      EndDate: new Date(),
    },
  });

  const [genres, setGenres] = useState([]);
  const [productions, setProductions] = useState([]);
  const [actors, setActors] = useState([]);

  const getData = () => {
    GetPopulateGenres().then((res) => {
      setGenres(res.data);
    });
    GetPopulateProductions().then((res) => {
      setProductions(res.data);
    });
    GetPopulateActors().then((res) => {
      setActors(res.data);
    });
  };

  useEffect(() => {
    getData();
  }, []);

  const submit = (data) => {
    const dataToPost = {
      name: data.Name,
      description: data.Description,
      format: data.Format,
      director: data.Director,
      isAdult: data.isAdult,
      imdbLink: data.ImdbLink,
      trailerLink: data.TrailerLink,
      poster: data.Poster,
      releaseDate: data.ReleaseDate,
      runDate: data.RunDate,
      endDate: data.EndDate,
      runTime: data.Runtime,
      movieBudget: data.Budget,
      genres: data.Genres.map((genre) => genre.id),
      productions: data.Productions.map((production) => production.id),
      actors: data.Actors.map((actor) => actor.id),
    };

    CreateMovieRequest(dataToPost)
      .then((response) => {
        toast.success("Movie created!");
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
      <Typography mb={2}>Create Movie</Typography>

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
              label="Movie Name"
              name="Name"
              {...register("Name", {
                required: { value: true, message: "Movie Name is required" },
              })}
              error={!!errors.Name}
              helperText={errors.Name?.message}
            />
          </Grid>
          <Grid item xs={12}>
            <TextField
              fullWidth
              required
              multiline
              rows={5}
              label="Movie Description"
              name="Description"
              {...register("Description", {
                required: { value: true, message: "Description is required" },
              })}
              error={!!errors.Name}
              helperText={errors.Name?.message}
            />
          </Grid>
          <Grid item xs={6} lg={4}>
            <FormControl sx={{ width: "100%" }}>
              <InputLabel htmlFor="format-label">Format</InputLabel>
              <Controller
                name="Format"
                defaultValue={"Normal"}
                control={control}
                render={({ field }) => (
                  <Select
                    label="Format"
                    labelId="format-label"
                    id="format"
                    {...field}
                  >
                    <MenuItem value={"Normal"}>Normal</MenuItem>
                    <MenuItem value={"3D"}>3D</MenuItem>
                  </Select>
                )}
              />
              <FormHelperText error={true}>
                {errors.level?.message}
              </FormHelperText>
            </FormControl>
          </Grid>
          <Grid item xs={6} lg={4}>
            <TextField
              fullWidth
              required
              label="Director"
              name="Director"
              {...register("Director", {
                required: { value: true, message: "Director is required" },
              })}
              error={!!errors.Director}
              helperText={errors.Director?.message}
            />
          </Grid>
          <Grid item xs={12} lg={4}>
            <Controller
              control={control}
              name={"isAdult"}
              defaultValue={false}
              render={({ field: { onChange, value } }) => (
                <FormControlLabel
                  control={<Checkbox checked={value} onChange={onChange} />}
                  label="Is Adult"
                />
              )}
            />
          </Grid>

          <Grid item xs={12} lg={4}>
            <TextField
              fullWidth
              required
              label="IMDB Link"
              name="ImdbLink"
              {...register("ImdbLink", {
                required: { value: true, message: "IMDB Link is required" },
              })}
              error={!!errors.ImdbLink}
              helperText={errors.ImdbLink?.message}
            />
          </Grid>

          <Grid item xs={12} lg={4}>
            <TextField
              fullWidth
              required
              label="Trailer Link"
              name="TrailerLink"
              {...register("TrailerLink", {
                required: { value: true, message: "Trailer Link is required" },
              })}
              error={!!errors.TrailerLink}
              helperText={errors.TrailerLink?.message}
            />
          </Grid>

          <Grid item xs={12} lg={4}>
            <TextField
              fullWidth
              required
              multiline
              label="Poster"
              name="Poster"
              {...register("Poster", {
                required: { value: true, message: "Poster is required" },
              })}
              error={!!errors.Poster}
              helperText={errors.Poster?.message}
            />
          </Grid>

          <Grid item xs={12} lg={4}>
            <Controller
              control={control}
              name="ReleaseDate"
              rules={{
                required: { value: true, message: "Release Date is required" },
              }}
              render={({
                field: { ref, onBlur, name, ...field },
                fieldState,
              }) => (
                <DatePicker
                  sx={{ width: "100%" }}
                  {...field}
                  inputRef={ref}
                  label="Release Date"
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

          <Grid item xs={12} lg={4}>
            <Controller
              control={control}
              name="RunDate"
              rules={{
                required: {
                  value: true,
                  message: "Run Date and Time is required",
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
                  label="Run Date and Time"
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

          <Grid item xs={12} lg={4}>
            <Controller
              control={control}
              name="EndDate"
              rules={{
                required: { value: true, message: "Release Date is required" },
              }}
              render={({
                field: { ref, onBlur, name, ...field },
                fieldState,
              }) => (
                <DateTimePicker
                  sx={{ width: "100%" }}
                  {...field}
                  inputRef={ref}
                  label="End Date and Time"
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

          <Grid item xs={6}>
            <FormControl fullWidth>
              <InputLabel
                error={!!errors.Budget}
                htmlFor="outlined-adornment-amount"
              >
                Amount
              </InputLabel>
              <OutlinedInput
                type="number"
                min={0}
                id="outlined-adornment-amount"
                startAdornment={
                  <InputAdornment position="start">$</InputAdornment>
                }
                {...register("Budget", {
                  required: {
                    value: true,
                    message: "Budget is required",
                  },
                })}
                error={!!errors.Budget}
                name="Budget"
                label="Budget"
              />
              <FormHelperText error={!!errors.Budget}>
                {errors.Budget?.message}
              </FormHelperText>
            </FormControl>
          </Grid>

          <Grid item xs={6}>
            <TextField
              fullWidth
              required
              label="Runtime"
              name="Runtime"
              {...register("Runtime", {
                required: { value: true, message: "Runtime is required" },
              })}
              error={!!errors.Runtime}
              helperText={errors.Runtime?.message}
            />
          </Grid>

          <Grid item xs={12} lg={4}>
            <Controller
              render={({ field: { onChange, value } }) => (
                <Autocomplete
                  multiple
                  onChange={(event, item) => {
                    onChange(item);
                  }}
                  options={genres}
                  filterSelectedOptions
                  value={value}
                  getOptionLabel={(option) => option.genreName}
                  isOptionEqualToValue={(option, value) =>
                    option.id === value.id
                  }
                  renderInput={(params) => (
                    <TextField {...params} label="Genres" />
                  )}
                />
              )}
              defaultValue={[]}
              control={control}
              name="Genres"
            />
          </Grid>

          <Grid item xs={12} lg={4}>
            <Controller
              render={({ field: { onChange, value } }) => (
                <Autocomplete
                  multiple
                  onChange={(event, item) => {
                    onChange(item);
                  }}
                  options={productions}
                  filterSelectedOptions
                  value={value}
                  getOptionLabel={(option) => option.productionName}
                  isOptionEqualToValue={(option, value) =>
                    option.id === value.id
                  }
                  renderInput={(params) => (
                    <TextField {...params} label="Productions" />
                  )}
                />
              )}
              defaultValue={[]}
              control={control}
              name="Productions"
            />
          </Grid>

          <Grid item xs={12} lg={4}>
            <Controller
              render={({ field: { onChange, value } }) => (
                <Autocomplete
                  multiple
                  onChange={(event, item) => {
                    onChange(item);
                  }}
                  options={actors}
                  filterSelectedOptions
                  value={value}
                  getOptionLabel={(option) =>
                    `${option.firstName} ${option.lastName}`
                  }
                  isOptionEqualToValue={(option, value) =>
                    option.id === value.id
                  }
                  renderInput={(params) => (
                    <TextField {...params} label="Actors" />
                  )}
                />
              )}
              defaultValue={[]}
              control={control}
              name="Actors"
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

export default CreateMovie;
