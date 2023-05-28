import {
  Cancel,
  Delete,
  DoneOutline,
  EditOutlined,
  RemoveRoadOutlined,
} from "@mui/icons-material";
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
  DeleteUser,
  EditUser,
  GetUserById,
  GetUsersPaginated,
  MakeUserAdmin,
  RemoveAdmin,
} from "../../../api/AuthEndpoints";
import CheckIcon from "@mui/icons-material/Check";
import ClearIcon from "@mui/icons-material/Clear";

const UserList = () => {
  const [rows, setRows] = useState([]);
  const [previous, setPrevious] = useState({});
  const [page, setPage] = useState(1);
  const [totalCount, setTotalCount] = useState(1);

  const getUsers = () => {
    GetUsersPaginated(page).then((res) => {
      setRows(res.data.data);
      setTotalCount(res.data.totalRecords);
    });
  };

  useEffect(() => {
    getUsers();
  }, [page]);

  //table functions
  const onToggleEditMode = (id) => {
    setRows((state) => {
      return rows.map((row) => {
        if (row.user.id === id) {
          return {
            ...row,
            user: {
              ...row.user,
              isEditMode: !row.user.isEditMode,
            },
          };
        }
        return row;
      });
    });
  };

  const onChange = (e, row) => {
    console.log(e);
    console.log(row);
    if (!previous[row.id]) {
      setPrevious((state) => ({ ...state, [row.id]: row }));
    }
    const value = e.target.value;
    const name = e.target.name;
    const { id } = row;
    const newRows = rows.map((rowItem) => {
      if (rowItem.user.id === id) {
        return {
          ...rowItem,
          user: {
            ...rowItem.user,
            [name]: value,
          },
        };
      }
      return rowItem;
    });
    setRows(newRows);
  };

  const onApproveClick = (row) => {
    const data = {
      firstName: row.firstName,
      lastName: row.lastName,
      profileImageSrc: row.profileImageSrc,
      phoneNumber: row.phoneNumber,
      email: row.email,
      userName: row.userName,
    };

    const isEmpty = Object.values(row).includes("");

    if (isEmpty) {
      toast.error("No empty field allowed!");
    } else {
      EditUser(data, row.id).then(() => {
        toast.success("User saved successfully!");
        onToggleEditMode(row.id);
      });
    }
  };

  const onRevert = (id) => {
    GetUserById(id).then((res) => {
      var newArr = rows;
      const index = newArr.findIndex((obj) => obj.id === id);
      res.data.isEditMode = true;
      newArr[index] = res.data;
      setRows(newArr);
      onToggleEditMode(id);
    });
  };

  const deleteUser = (id) => {
    DeleteUser(id).then(() => {
      toast.success("User deleted successfully!");
      getUsers();
    });
  };

  const RemoveRole = (username) => {
    RemoveAdmin(username).then(() => {
      toast.success("Admin Removed");
      getUsers();
    });
  };

  const AddRole = (username) => {
    MakeUserAdmin(username).then(() => {
      toast.success("Admin Added");
      getUsers();
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
                <TableCell align="left">UserName</TableCell>
                <TableCell align="left">Email</TableCell>
                <TableCell align="left">First Name</TableCell>
                <TableCell align="left">Last Name</TableCell>
                <TableCell align="left">Image Source</TableCell>
                <TableCell align="left">Phone Number</TableCell>
                <TableCell align="center">Admin</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {rows.map((row) => (
                <TableRow key={row.user.id}>
                  <TableCell sx={{ width: "80px" }}>
                    {row.user.isEditMode ? (
                      <>
                        <IconButton
                          aria-label="done"
                          onClick={() => {
                            onApproveClick(row.user);
                          }}
                        >
                          <DoneOutline />
                        </IconButton>
                        <IconButton
                          aria-label="revert"
                          onClick={() => onRevert(row.user.id)}
                        >
                          <Cancel />
                        </IconButton>
                      </>
                    ) : (
                      <>
                        <IconButton
                          aria-label="edit"
                          onClick={() => onToggleEditMode(row.user.id)}
                        >
                          <EditOutlined />
                        </IconButton>
                        <IconButton
                          aria-label="edit"
                          onClick={() => deleteUser(row.user.id)}
                        >
                          <Delete />
                        </IconButton>
                      </>
                    )}
                  </TableCell>
                  <TableCell>{row.user.userName}</TableCell>
                  <TableCell>{row.user.email}</TableCell>
                  <CustomTableCell
                    {...{ row: row.user, name: "firstName", onChange }}
                  />
                  <CustomTableCell
                    {...{ row: row.user, name: "lastName", onChange }}
                  />
                  <CustomTableCell
                    {...{ row: row.user, name: "profileImageSrc", onChange }}
                  />
                  <CustomTableCell
                    {...{ row: row.user, name: "phoneNumber", onChange }}
                  />
                  {row.roles.includes("Admin") ? (
                    <TableCell align="center">
                      <IconButton
                        aria-label="edit"
                        onClick={() => {
                          RemoveRole(row.user.userName);
                        }}
                      >
                        <ClearIcon />
                      </IconButton>
                    </TableCell>
                  ) : (
                    <TableCell align="center">
                      <IconButton
                        aria-label="edit"
                        onClick={() => {
                          AddRole(row.user.userName);
                        }}
                      >
                        <CheckIcon />
                      </IconButton>
                    </TableCell>
                  )}
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
export default UserList;
