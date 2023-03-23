import * as React from "react";
import Box from "@mui/material/Box";
import Drawer from "@mui/material/Drawer";
import ListItem from "@mui/material/ListItem";
import { Grid, MenuItem, Typography } from "@mui/material";
import { styled } from "@mui/material/styles";
import ArrowForwardIosSharpIcon from "@mui/icons-material/ArrowForwardIosSharp";
import MuiAccordion from "@mui/material/Accordion";
import MuiAccordionSummary from "@mui/material/AccordionSummary";
import MuiAccordionDetails from "@mui/material/AccordionDetails";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
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

export default function CustomDrawer(props) {
  const navigate = useNavigate();

  const list = (props) => (
    <Box
      sx={{ height: "calc(100vh - 68.5px)", borderRight: "1px solid purple" }}
    >
      <Accordion>
        <AccordionSummary aria-controls="panel1a-content" id="panel1a-header">
          <Typography>Movies</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Grid container direction="column">
            <MenuItem
              onClick={() => {
                // props.setOpen(false);
                navigate("create-movie");
              }}
            >
              <Typography>Create Movie</Typography>
            </MenuItem>
          </Grid>
        </AccordionDetails>
      </Accordion>
      <Accordion>
        <AccordionSummary aria-controls="panel1a-content" id="panel1a-header">
          <Typography>Genres</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Grid container direction="column">
            <MenuItem
              onClick={() => {
                // props.setOpen(false);
                navigate("create-genre");
              }}
            >
              <Typography>Create Genre</Typography>
            </MenuItem>
            <MenuItem
              onClick={() => {
                // props.setOpen(false);
                navigate("genres-list");
              }}
            >
              <Typography>Genres List</Typography>
            </MenuItem>
          </Grid>
        </AccordionDetails>
      </Accordion>
      <Accordion>
        <AccordionSummary aria-controls="panel1a-content" id="panel1a-header">
          <Typography>Actors</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Grid container direction="column">
            <MenuItem
              onClick={() => {
                // props.setOpen(false);
                navigate("create-actor");
              }}
            >
              <Typography>Create Actor</Typography>
            </MenuItem>
            <MenuItem
              onClick={() => {
                // props.setOpen(false);
                navigate("actors-list");
              }}
            >
              <Typography>Actors List</Typography>
            </MenuItem>
          </Grid>
        </AccordionDetails>
      </Accordion>
      <Accordion>
        <AccordionSummary aria-controls="panel1a-content" id="panel1a-header">
          <Typography>Productions</Typography>
        </AccordionSummary>
        <AccordionDetails>
          <Grid container direction="column">
            <MenuItem
              onClick={() => {
                // props.setOpen(false);
                navigate("create-production");
              }}
            >
              <Typography>Create Production</Typography>
            </MenuItem>
            <MenuItem
              onClick={() => {
                // props.setOpen(false);
                navigate("productions-list");
              }}
            >
              <Typography>Production List</Typography>
            </MenuItem>
          </Grid>
        </AccordionDetails>
      </Accordion>
    </Box>
  );
  return (
    <div>
      <Box sx={{ display: { xs: "none", lg: "block" } }}>{list()}</Box>

      <Box sx={{ display: { xs: "block", lg: "none" } }}>
        <Drawer
          anchor="left"
          open={props.open}
          onClose={props.toggleDrawer(false)}
          onOpen={props.toggleDrawer(true)}
        >
          {list()}
        </Drawer>
      </Box>
    </div>
  );
}
