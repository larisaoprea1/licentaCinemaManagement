import { Cancel, Delete, DoneOutline, EditOutlined } from "@mui/icons-material";
import {
  IconButton,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableRow,
} from "@mui/material";
import { Box } from "@mui/system";
import { useEffect, useState } from "react";
import { toast } from "react-toastify";
import {
  DeleteProduction,
  EditProduction,
  GetProduction,
  GetProductions,
} from "../../../api/ProductionEndpoints";
import { CustomTableCell } from "../../../components/Table/CustomTableCell";
import { CustomTablePagination } from "../../../components/Table/CustomTablePagination";

const ProductionList = () => {
  const [rows, setRows] = useState([]);
  const [previous, setPrevious] = useState({});
  const [page, setPage] = useState(1);
  const [totalCount, setTotalCount] = useState(1);

  const getProductions = () => {
    GetProductions(page).then((res) => {
      setRows(res.data.data);
      setTotalCount(res.data.totalRecords);
    });
  };

  useEffect(() => {
    getProductions();
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
      productionName: row.productionName,
      description: row.description,
    };

    const isEmpty = Object.values(row).includes("");

    if (isEmpty) {
      toast.error("No empty field allowed!");
    } else {
      EditProduction(data, row.id).then(() => {
        toast.success("Production saved successfully!");
        onToggleEditMode(row.id);
      });
    }
  };

  const onRevert = (id) => {
    GetProduction(id).then((res) => {
      var newArr = rows;
      const index = newArr.findIndex((obj) => obj.id === id);
      res.data.isEditMode = true;
      newArr[index] = res.data;
      setRows(newArr);
      onToggleEditMode(id);
    });
  };

  const deleteProduction = (id) => {
    DeleteProduction(id).then(() => {
      toast.success("Production deleted successfully!");
      getProductions();
    });
  };

  return (
    <Box sx={{ mt: 3 }}>
      <Paper>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell align="center" sx={{ width: "80px" }}>
                Actions
              </TableCell>
              <TableCell align="left">Production Name</TableCell>
              <TableCell align="left">Description</TableCell>
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
                        onClick={() => deleteProduction(row.id)}
                      >
                        <Delete />
                      </IconButton>
                    </>
                  )}
                </TableCell>
                <CustomTableCell
                  {...{ row, name: "productionName", onChange }}
                />
                <CustomTableCell {...{ row, name: "description", onChange }} />
              </TableRow>
            ))}
          </TableBody>
          <CustomTablePagination
            page={page}
            setPage={setPage}
            count={totalCount}
          />
        </Table>
      </Paper>
    </Box>
  );
};
export default ProductionList;
