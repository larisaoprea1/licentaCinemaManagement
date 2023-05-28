import { Cancel, Delete, DoneOutline, EditOutlined } from "@mui/icons-material";
import {
  IconButton,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
} from "@mui/material";
import { Box } from "@mui/system";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import { CustomTableCell } from "../../../components/Table/CustomTableCell";
import { CustomTablePagination } from "../../../components/Table/CustomTablePagination";
import {
  DeleteCinema,
  EditCinema,
  GetCinema,
  GetCinemas,
} from "../../../api/CinemasEndpoints";

const CinemaList = () => {
  const [rows, setRows] = useState([]);
  const [previous, setPrevious] = useState({});
  const [page, setPage] = useState(1);
  const [totalCount, setTotalCount] = useState(1);

  const getCinemas = () => {
    GetCinemas(page).then((res) => {
      setRows(res.data.data);
      setTotalCount(res.data.totalRecords);
    });
  };

  useEffect(() => {
    getCinemas();
  }, [page]);

  //table functions
  const onToggleEditMode = (id) => {
    setRows((state) => {
      return rows.map((row) => {
        if (row.id === id) {
          return { ...row, isEditMode: !row.isEditMode };
        }
        return row;
      });
    });
  };

  const onChange = (e, row) => {
    if (!previous[row.id]) {
      setPrevious((state) => ({ ...state, [row.id]: row }));
    }
    const value = e.target.value;
    const name = e.target.name;
    const { id } = row;
    const newRows = rows.map((row) => {
      if (row.id === id) {
        return { ...row, [name]: value };
      }
      return row;
    });
    setRows(newRows);
  };

  const onApproveClick = (row) => {
    const data = {
      name: row.name,
      address: row.address,
      city: row.city,
      zipcode: row.zipcode,
      country: row.country,
    };

    const isEmpty = Object.values(row).includes("");

    if (isEmpty) {
      toast.error("No empty field allowed!");
    } else {
      EditCinema(data, row.id).then(() => {
        toast.success("Cinema saved successfully!");
        onToggleEditMode(row.id);
      });
    }
  };

  const onRevert = (id) => {
    GetCinema(id).then((res) => {
      var newArr = rows;
      const index = newArr.findIndex((obj) => obj.id === id);
      res.data.isEditMode = true;
      newArr[index] = res.data;
      setRows(newArr);
      onToggleEditMode(id);
    });
  };

  const deleteCinema = (id) => {
    DeleteCinema(id).then(() => {
      toast.success("Cinema deleted successfully!");
      getCinemas();
    });
  };
  return (
    <Box sx={{ mt: 2, mb: 1 }}>
      <Paper>
        <TableContainer component={Paper}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell align="center" sx={{ width: "80px" }}>
                  Actions
                </TableCell>
                <TableCell align="left">Name</TableCell>
                <TableCell align="left">Address</TableCell>
                <TableCell align="left">City</TableCell>
                <TableCell align="left">Zipcode</TableCell>
                <TableCell align="left">Country</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {rows.map((row) => (
                <TableRow key={row.id}>
                  <TableCell sx={{ width: "80px" }}>
                    {row.isEditMode ? (
                      <>
                        <IconButton
                          aria-label="done"
                          onClick={() => {
                            onApproveClick(row);
                          }}
                        >
                          <DoneOutline />
                        </IconButton>
                        <IconButton
                          aria-label="revert"
                          onClick={() => onRevert(row.id)}
                        >
                          <Cancel />
                        </IconButton>
                      </>
                    ) : (
                      <>
                        <IconButton
                          aria-label="edit"
                          onClick={() => onToggleEditMode(row.id)}
                        >
                          <EditOutlined />
                        </IconButton>
                        <IconButton
                          aria-label="edit"
                          onClick={() => deleteCinema(row.id)}
                        >
                          <Delete />
                        </IconButton>
                      </>
                    )}
                  </TableCell>
                  <CustomTableCell {...{ row, name: "name", onChange }} />
                  <CustomTableCell {...{ row, name: "address", onChange }} />
                  <CustomTableCell {...{ row, name: "city", onChange }} />
                  <CustomTableCell {...{ row, name: "zipcode", onChange }} />
                  <CustomTableCell {...{ row, name: "country", onChange }} />
                </TableRow>
              ))}
            </TableBody>
            <CustomTablePagination
              page={page}
              setPage={setPage}
              count={totalCount}
            />
          </Table>
        </TableContainer>
      </Paper>
    </Box>
  );
};
export default CinemaList;
