import * as React from "react";
import PropTypes from "prop-types";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Typography from "@mui/material/Typography";
import Box from "@mui/material/Box";
import { useState } from "react";
import { useEffect } from "react";
import { GetPopulateCinemas } from "../../../api/CinemasEndpoints";
import { GetSessionsForMovieByCinema } from "../../../api/SessionsEndpoints";
import Sessions from "./Sessions";

function TabPanel(props) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`simple-tabpanel-${index}`}
      aria-labelledby={`simple-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          <Typography>{children}</Typography>
        </Box>
      )}
    </div>
  );
}

TabPanel.propTypes = {
  children: PropTypes.node,
  index: PropTypes.number.isRequired,
  value: PropTypes.number.isRequired,
};

function a11yProps(index) {
  return {
    id: `simple-tab-${index}`,
    "aria-controls": `simple-tabpanel-${index}`,
  };
}

export default function CinemaTabs({ movieId }) {
  const [value, setValue] = useState(0);
  const [cinemas, setCinemas] = useState([]);
  const [sessions, setSessions] = useState([]);
  const [selectedCinema, setSelectedCinema] = useState("");

  const getCinemas = () => {
    GetPopulateCinemas().then((res) => {
      setCinemas(res.data);
      if (res.data.length > 0) {
        const firstCinemaId = res.data[0].id;
        setSelectedCinema(firstCinemaId);
      }
    });
  };

  const getSessions = (cinemaId) => {
    GetSessionsForMovieByCinema(movieId, cinemaId).then((res) => {
      setSessions(res.data);
    });
  };

  const handleChange = (event, newValue) => {
    setValue(newValue);
    const selectedCinema = cinemas[newValue].id;
    setSelectedCinema(selectedCinema);
  };

  useEffect(() => {
    getCinemas();
  }, []);

  useEffect(() => {
    if (selectedCinema) {
      getSessions(selectedCinema);
    }
  }, [selectedCinema]);

  return (
    <Box sx={{ width: "100%" }}>
      <Box sx={{ borderBottom: 1, borderColor: "divider" }}>
        <Tabs
          value={value}
          onChange={handleChange}
          aria-label="basic tabs example"
        >
          {cinemas.map((cinema, index) => {
            return (
              <Tab key={index} label={cinema.name} {...a11yProps(index)} />
            );
          })}
        </Tabs>
      </Box>
      {cinemas.map((cinema, index) => {
        return (
          <>
            <TabPanel value={value} index={index} key={cinema.id}>
              {/* <h2>{cinema.name}</h2>
              <p>Cinema Id: {cinema.id}</p>
              <p>Selected Cinema: {selectedCinema}</p>
              <p>Sessions for selected cinema:</p>
              <ul>
                {sessions.map((session) => (
                  <li key={session.id}>{session.sessionStart}</li>
                ))}
              </ul> */}
              <Sessions sessions={sessions}/>
            </TabPanel>
          </>
        );
      })}
    </Box>
  );
}
