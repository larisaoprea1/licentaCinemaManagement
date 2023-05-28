import { useEffect, useState } from "react";
import { GetWatchedMovies } from "../../api/AuthEndpoints";
import { Box, Grid } from "@mui/material";
import SimpleMovieCard from "../../components/Cards/Movies/SimpleMovieCard";

const WatchedMovies = ({ username }) => {
  const [movies, setMovies] = useState([]);

  const getMovies = () => {
    GetWatchedMovies(username).then((res) => {
      setMovies(res.data);
    });
  };

  useEffect(() => {
    getMovies();
  }, []);

  return (
    <Box>
      <Grid container spacing={2}>
        {movies.map((movie) => {
          return (
            <Grid item xs={12} lg={6} key={movie.id}>
              <SimpleMovieCard movie={movie} />
            </Grid>
          );
        })}
      </Grid>
    </Box>
  );
};

export default WatchedMovies;
