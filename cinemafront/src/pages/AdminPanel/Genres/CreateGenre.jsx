import React from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box } from "@mui/material";
import { CreateGenreRequest } from "../../../api/GenreEndpoints";

const CreateGenre = () => {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    const dataToPost = {
      genreName: data.Name,
    };

    CreateGenreRequest(dataToPost)
      .then((response) => {
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
    >
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
          label="Genre Name"
          name="Name"
          {...register("Name", {
            required: { value: true, message: "Name is required" },
            maxLength: { value: 50, message: "Name is too long" },
          })}
          error={!!errors.Name}
          helperText={errors.Content?.Name}
        />
        <Button onClick={() => reset()}>Reset</Button>
        <Button type="submit" variant="contained">
          Submit
        </Button>
      </form>
    </Box>
  );
};

export default CreateGenre;
