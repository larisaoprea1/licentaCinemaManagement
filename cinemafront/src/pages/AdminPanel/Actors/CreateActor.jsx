import React, { useState } from "react";
import { Controller, useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Typography } from "@mui/material";
import { DatePicker } from "@mui/x-date-pickers";
import { CreateActorRequest } from "../../../api/ActorsEndpoints";
import { toast } from "react-toastify";

const CreateActor = () => {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
    control,
  } = useForm({
    defaultValues: {
      Date: new Date(),
    },
  });


  const submit = (data) => {
    const dataToPost = {
      firstName: data.FirstName,
      lastName: data.LastName,
      information: data.Information,
      nationality: data.Nationality,
      pictureSrc: data.Picture,
      birthday: data.Date,
    };

    CreateActorRequest(dataToPost)
      .then((response) => {
        toast.success("Actor created!")

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
      <Typography mb={2}>Create Actor</Typography>
      <form
        noValidate
        autoComplete="off"
        style={{ marginBottom: 20 }}
        onSubmit={handleSubmit(submit)}
      >
        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1 }}
          label="First Name"
          name="FirstName"
          {...register("FirstName", {
            required: { value: true, message: "First Name is required" },
          })}
          error={!!errors.FirstName}
          helperText={errors.FirstName?.message}
        />

        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1 }}
          label="Last Name"
          name="LastName"
          {...register("LastName", {
            required: { value: true, message: "Last Name is required" },
          })}
          error={!!errors.LastName}
          helperText={errors.LastName?.message}
        />

        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1 }}
          multiline={true}
          rows={6}
          label="Information"
          name="Information"
          {...register("Information", {
            required: { value: true, message: "Information is required" },
          })}
          error={!!errors.Information}
          helperText={errors.Information?.message}
        />

        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1 }}
          label="Nationality"
          name="Nationality"
          {...register("Nationality", {
            required: { value: true, message: "Nationality is required" },
          })}
          error={!!errors.Nationality}
          helperText={errors.Nationality?.message}
        />

        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1 }}
          label="Picture Link"
          name="Picture"
          {...register("Picture", {
            required: { value: true, message: "Picture is required" },
          })}
          error={!!errors.Picture}
          helperText={errors.Picture?.message}
        />

        <Controller
          control={control}
          name="Date"
          rules={{
            required: { value: true, message: "Date is required" },
          }}
          render={({ field: { ref, onBlur, name, ...field }, fieldState }) => (
            <DatePicker
              sx={{ width: "100%" }}
              {...field}
              inputRef={ref}
              label="Birthday"
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

        <Box sx={{ mt: "10px" }}>
          <Button onClick={() => reset()}>Reset</Button>
          <Button type="submit" variant="contained">
            Submit
          </Button>
        </Box>
      </form>
    </Box>
  );
};

export default CreateActor;
