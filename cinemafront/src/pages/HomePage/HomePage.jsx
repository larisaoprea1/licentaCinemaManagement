import { Button, Container, Divider, Grid, Paper, Typography } from "@mui/material";
import { useEffect, useState } from "react";
import { GetAiringMovies } from "../../api/MoviesEndpoints";
import AiringMovieCard from "../../components/Cards/Movies/AiringMovieCard";

const HomePage = () => {
  const [airingMovies, setAiringMovies] = useState([]);

  const getAiringMovies = () => {
    GetAiringMovies().then((res) => {
      setAiringMovies(res.data);
    });
  };

  useEffect(() => {
    getAiringMovies();
  }, []);

  return (
    <Container maxWidth="xl" sx={{ marginTop: "1rem" }}>
      <Typography sx={{fontSize: "20px"}}>NOW IN CINEMA</Typography>
      <Divider sx={{marginBottom: "10px"}}/>
      <Grid container spacing={2}>
        {airingMovies.map((movie) => {
          return (
            <Grid item xs={12} lg={6}>
              <AiringMovieCard key={movie.id} movie={movie} />
            </Grid>
          );
        })}
      </Grid>
    </Container>
  );
};

export default HomePage;
