import * as React from "react";
import Box from "@mui/material/Box";
import Drawer from "@mui/material/Drawer";
import Button from "@mui/material/Button";
import List from "@mui/material/List";
import Divider from "@mui/material/Divider";
import ListItem from "@mui/material/ListItem";

import { Grid, MenuItem, Typography } from "@mui/material";
import { ExpandMore } from "@mui/icons-material";

import { styled } from "@mui/material/styles";
import ArrowForwardIosSharpIcon from "@mui/icons-material/ArrowForwardIosSharp";
import MuiAccordion from "@mui/material/Accordion";
import MuiAccordionSummary from "@mui/material/AccordionSummary";
import MuiAccordionDetails from "@mui/material/AccordionDetails";
import { padding } from "@mui/system";
import { useNavigate } from "react-router-dom";

const Accordion = styled((props) => (
  <MuiAccordion disableGutters elevation={0} square {...props} />
))(({ theme }) => ({
  border: `1px solid ${theme.palette.divider}`,
  "&:not(:last-child)": {
    borderBottom: 0,
  },
  "&:before": {
    display: "none",
  },
}));

const AccordionSummary = styled((props) => (
  <MuiAccordionSummary
    expandIcon={<ArrowForwardIosSharpIcon sx={{ fontSize: "0.9rem" }} />}
    {...props}
  />
))(({ theme }) => ({
  flexDirection: "row-reverse",
  "& .MuiAccordionSummary-expandIconWrapper.Mui-expanded": {
    transform: "rotate(90deg)",
  },
  "& .MuiAccordionSummary-content": {
    marginLeft: theme.spacing(1),
  },
}));

const AccordionDetails = styled(MuiAccordionDetails)(({ theme }) => ({
  padding: theme.spacing(2),
  borderTop: "1px solid rgba(0, 0, 0, .125)",
}));

export default function CustomDrawer() {
  const [open, setOpen] = React.useState(false);
  const navigate = useNavigate()
  const toggleDrawer = (newOpen) => () => {
    setOpen(newOpen);
  };

  const list = () => (
    <Box>
      <Accordion>
        <AccordionSummary
          aria-controls="panel1a-content"
          id="panel1a-header"
          expandIcon={<ExpandMore />}
        >
          <Typography>Movies</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Grid container direction="column">
            <MenuItem>
              <Typography>Create Movie</Typography>
            </MenuItem>
          </Grid>
        </AccordionDetails>
      </Accordion>
      <Accordion>
        <AccordionSummary
          aria-controls="panel1a-content"
          id="panel1a-header"
          expandIcon={<ExpandMore />}
        >
          <Typography>Genres</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Grid container direction="column">
            <MenuItem
              onClick={() => {
                setOpen(false);
                navigate("create-genre")
              }}
            >
              <Typography>Create Genre</Typography>
            </MenuItem>
            <MenuItem
             onClick={() => {
              setOpen(false);
              navigate("genres-list")
            }}>
              <Typography>Genres List</Typography>
            </MenuItem>
          </Grid>
        </AccordionDetails>
      </Accordion>
      <Accordion>
        <AccordionSummary
          aria-controls="panel1a-content"
          id="panel1a-header"
          expandIcon={<ExpandMore />}
        >
          <Typography>Productions</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Grid container direction="column">
            <MenuItem>
              <Typography>Create Production</Typography>
            </MenuItem>
            <ListItem>
              <Typography>Production List</Typography>
            </ListItem>
          </Grid>
        </AccordionDetails>
      </Accordion>
    </Box>
  );

  return (
    <div>
      <React.Fragment>
        <Box
          sx={{
            display: "flex",
            width: "100%",
            justifyContent: "space-between",
            height: "50px",
            alignItems: "center",
          }}
        >
          <Button onClick={toggleDrawer(true)}>Open Menu</Button>
          <Typography>Cinema Management Admin Panel</Typography>
        </Box>
        <Drawer
          anchor="left"
          open={open}
          onClose={toggleDrawer(false)}
          onOpen={toggleDrawer(true)}
        >
          {list()}
        </Drawer>
      </React.Fragment>
    </div>
  );
}
