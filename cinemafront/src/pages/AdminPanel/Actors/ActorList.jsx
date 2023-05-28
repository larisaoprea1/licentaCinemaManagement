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
  DeleteActor,
  EditActor,
  GetActor,
  GetActors,
} from "../../../api/ActorsEndpoints";
import { CustomTableCell } from "../../../components/Table/CustomTableCell";
import { CustomTablePagination } from "../../../components/Table/CustomTablePagination";
import { isValidDate } from "../../../utils/isValidDate";

const ActorList = () => {
  const [rows, setRows] = useState([]);
  const [previous, setPrevious] = useState({});
  const [page, setPage] = useState(1);
  const [totalCount, setTotalCount] = useState(1);

  const getActors = () => {
    GetActors(page).then((res) => {
      setRows(res.data.data);
      setTotalCount(res.data.totalRecords);
    });
  };

  useEffect(() => {
    getActors();
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
      firstName: row.firstName,
      lastName: row.lastName,
      information: row.information,
      nationality: row.nationality,
      pictureSrc: row.pictureSrc,
      birthDay: new Date(row.birthDay),
    };

    const isEmpty = Object.values(row).includes("");
    const dateValid = isValidDate(row.birthDay);
    if (isEmpty) {
      toast.error("No empty field allowed!");
    } else if (!dateValid) {
      toast.error("Please enter a valid date");
    } else {
      EditActor(data, row.id).then(() => {
        toast.success("Actor saved successfully!");
        onToggleEditMode(row.id);
      });
    }
  };

  const onRevert = (id) => {
    GetActor(id).then((res) => {
      var newArr = rows;
      const index = newArr.findIndex((obj) => obj.id === id);
      res.data.isEditMode = true;
      newArr[index] = res.data;
      setRows(newArr);
      onToggleEditMode(id);
    });
  };

  const deleteActor = (id) => {
    DeleteActor(id).then(() => {
      toast.success("Actor deleted successfully!");
      getActors();
    });
  };

  return (
    <Box sx={{ mt: 3 }}>
      <Paper>
        <TableContainer component={Paper}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell align="center" sx={{ width: "80px" }}>
                  Actions
                </TableCell>
                <TableCell align="left">First Name</TableCell>
                <TableCell align="left">Last Name</TableCell>
                <TableCell align="left">Information</TableCell>
                <TableCell align="left">Nationality</TableCell>
                <TableCell align="left">Picture src</TableCell>
                <TableCell align="left">Birthday</TableCell>
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
                          onClick={() => deleteActor(row.id)}
                        >
                          <Delete />
                        </IconButton>
                      </>
                    )}
                  </TableCell>
                  <CustomTableCell {...{ row, name: "firstName", onChange }} />
                  <CustomTableCell {...{ row, name: "lastName", onChange }} />
                  <CustomTableCell
                    {...{ row, name: "information", onChange }}
                  />
                  <CustomTableCell
                    {...{ row, name: "nationality", onChange }}
                  />
                  <CustomTableCell {...{ row, name: "pictureSrc", onChange }} />
                  <CustomTableCell {...{ row, name: "birthDay", onChange }} />
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
export default ActorList;
