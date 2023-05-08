import {
  Button,
  Container,
  Divider,
  Grid,
  Paper,
  TextField,
  Typography,
} from "@mui/material";
import { useEffect, useState } from "react";
import { GetPaginatedMovies } from "../../api/MoviesEndpoints";
import AiringMovieCard from "../../components/Cards/Movies/AiringMovieCard";
import GlobalPagination from "../../components/Pagination/GlobalPagination";

const Movies = () => {
  const [movies, setMovies] = useState([]);
  const [page, setPage] = useState(1);
  const [numberOfPages, setNumberOfPages] = useState(1);
  const [searchString, setSearchString] = useState("");

  useEffect(() => {
    getMovies();
  }, [page, searchString]);

  const getMovies = () => {
    GetPaginatedMovies(page, searchString).then((res) => {
      setMovies(res.data.data);
      setNumberOfPages(res.data.totalPages);
    });
  };
  return (
    <Container maxWidth="xl" sx={{ marginTop: "1rem" }}>
      <Typography sx={{ fontSize: "20px" }}>MOVIES</Typography>
      <Divider sx={{ marginBottom: "10px" }} />
      <Grid container spacing={2}>
        <Grid item xs={12}>
          <TextField
            label="Search"
            variant="outlined"
            value={searchString}
            onChange={(e) => setSearchString(e.target.value)}
            sx={{ marginBottom: "10px", width: "100%" }}
          />
        </Grid>
        {movies.map((movie) => {
          return (
            <Grid item xs={12} lg={6} key={movie.id}>
              <AiringMovieCard key={movie.id} movie={movie} />
            </Grid>
          );
        })}
        <Grid item xs={12}>
          <GlobalPagination setPage={setPage} numberOfPages={numberOfPages} />
        </Grid>
      </Grid>
    </Container>
  );
};

export default Movies;
