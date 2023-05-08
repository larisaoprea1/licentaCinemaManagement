import { Box, Pagination } from "@mui/material";

function GlobalPagination(props) {
  const handleChange = (event, value) => {
    props.setPage(value);
  };

  return (
    <Box
      justifyContent={"center"}
      display={"flex"}
      sx={{ paddingBottom: "20px" }}
    >
      <Pagination
        count={props.numberOfPages}
        onChange={handleChange}
        color="primary"
      />
    </Box>
  );
}

export default GlobalPagination;