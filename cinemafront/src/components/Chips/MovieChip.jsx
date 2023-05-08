import { Chip } from "@mui/material";
import * as React from "react";

export default function MovieChip(props) {
  console.log(props);
  return (
    <>
      <Chip
        color="primary"
        sx={{ mt: 0.2, mr: 0.2, ml: 0.4 }}
        key={props.id}
        label={props.name}
      />
    </>
  );
}
