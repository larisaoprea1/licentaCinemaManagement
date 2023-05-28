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
import {
  DeleteGenre,
  EditGenre,
  GetGenre,
  GetGenres,
} from "../../../api/GenreEndpoints";
import { CustomTableCell } from "../../../components/Table/CustomTableCell";
import { CustomTablePagination } from "../../../components/Table/CustomTablePagination";

const GenreList = () => {
  const [rows, setRows] = useState([]);
  const [previous, setPrevious] = useState({});
  const [page, setPage] = useState(1);
  const [totalCount, setTotalCount] = useState(1);

  const getGenres = () => {
    GetGenres(page).then((res) => {
      setRows(res.data.data);
      setTotalCount(res.data.totalRecords);
    });
  };

  useEffect(() => {
    getGenres();
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
      genreName: row.genreName,
    };

    const isEmpty = Object.values(row).includes("");

    if (isEmpty) {
      toast.error("No empty field allowed!");
    } else {
      EditGenre(data, row.id).then(() => {
        toast.success("Genre saved successfully!");
        onToggleEditMode(row.id);
      });
    }
  };

  const onRevert = (id) => {
    GetGenre(id).then((res) => {
      var newArr = rows;
      const index = newArr.findIndex((obj) => obj.id === id);
      res.data.isEditMode = true;
      newArr[index] = res.data;
      setRows(newArr);
      onToggleEditMode(id);
    });
  };

  const deleteGenre = (id) => {
    DeleteGenre(id).then(() => {
      toast.success("Genre deleted successfully!");
      getGenres();
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
                <TableCell align="left">Genre Name</TableCell>
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
                          onClick={() => deleteGenre(row.id)}
                        >
                          <Delete />
                        </IconButton>
                      </>
                    )}
                  </TableCell>
                  <CustomTableCell {...{ row, name: "genreName", onChange }} />
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
export default GenreList;
