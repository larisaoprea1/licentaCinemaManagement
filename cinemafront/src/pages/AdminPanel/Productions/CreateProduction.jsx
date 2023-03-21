import React from "react";
import { useForm } from "react-hook-form";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";
import { Box, Typography } from "@mui/material";
import { CreateProductionRequest } from "../../../api/ProductionEndpoints";
import { toast } from "react-toastify";

const CreateProduction = () => {
  const {
    register,
    handleSubmit,
    reset,
    formState: { errors },
  } = useForm();

  const submit = (data) => {
    const dataToPost = {
      productionName: data.Name,
      description: data.Description
    };

    CreateProductionRequest(dataToPost)
      .then((response) => {
        toast.success("Production created!")
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
      <Typography mb={2}>
        Create Production
      </Typography>
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
          label="Production Name"
          name="Name"
          {...register("Name", {
            required: { value: true, message: "Genre Name is required" },
            maxLength: { value: 50, message: "Name is too long" },
          })}
          error={!!errors.Name}
          helperText={errors.Name?.message}
        />
        <TextField
          fullWidth
          required
          sx={{ marginBottom: 1 }}
          label="Description"
          name="Description"
          {...register("Description", {
            required: { value: true, message: "Description is required" },
          })}
          error={!!errors.Description}
          helperText={errors.Description?.message}
        />
        <Button onClick={() => reset()}>Reset</Button>
        <Button type="submit" variant="contained">
          Submit
        </Button>
      </form>
    </Box>
  );
};

export default CreateProduction;
