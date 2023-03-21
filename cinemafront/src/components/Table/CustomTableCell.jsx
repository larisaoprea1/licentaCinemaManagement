import { Input, TableCell } from "@mui/material";

export const CustomTableCell = ({ row, name, onChange }) => {
  const { isEditMode } = row;
  return (
    <TableCell align="left">
      {isEditMode ? (
        <Input
          value={row[name]}
          name={name}
          onChange={(e) => onChange(e, row)}
          sx={{width:"100%"}}
        />
      ) : (
        row[name]
      )}
    </TableCell>
  );
};
