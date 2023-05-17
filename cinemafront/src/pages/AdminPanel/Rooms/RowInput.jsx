import { useState } from "react";
import { Box, Typography, Grid } from "@mui/material";
import TextField from "@mui/material/TextField";
import Button from "@mui/material/Button";

function RowInput({ onAddRow, onRemoveRow, rows, setRows }) {
  function handleRowChange(index, key, value) {
    setRows(
      rows.map((row, i) => (i === index ? { ...row, [key]: value } : row))
    );
  }

  function handleAddRow() {
    const lastRow = rows[rows.length - 1];
    const newLetter = String.fromCharCode(lastRow.row.charCodeAt(0) + 1);
    const newRow = { row: newLetter, number: 0 };
    setRows([...rows, newRow]);
    onAddRow(newRow); // Call a callback function to notify the parent component of the new row
  }

  function handleRemoveRow() {
    if (rows.length > 1) {
      const removedRow = rows.pop();
      setRows([...rows]);
      onRemoveRow(removedRow);
    }
  }

  return (
    <Box sx={{ width: "100%" }}>
      <Grid container spacing={2}>
        {rows.map((row, index) => (
          <Grid item xs={6} key={row.row}>
            <Typography htmlFor={`row-${row.row}`}>Row {row.row}:</Typography>
            <TextField
              fullWidth
              id={`row-${row.row}`}
              type="number"
              value={row.number}
              InputProps={{
                inputProps: { min: 0 },
              }}
              onChange={(e) => handleRowChange(index, "number", e.target.value)}
            />
          </Grid>
        ))}
        <Grid item xs={12}>
          <Button onClick={handleAddRow} variant="contained">
            Add Row
          </Button>
          <Button
            onClick={handleRemoveRow}
            variant="outlined"
            sx={{ ml: "1rem" }}
          >
            Remove Row
          </Button>
        </Grid>
      </Grid>
    </Box>
  );
}

export default RowInput;
