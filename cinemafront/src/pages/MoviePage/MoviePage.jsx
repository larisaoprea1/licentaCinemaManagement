import {
  Box,
  Button,
  Container,
  Divider,
  Grid,
  IconButton,
  Typography,
} from "@mui/material";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import YouTubeIcon from "@mui/icons-material/YouTube";
import { getMovieById } from "../../api/MoviesEndpoints";
import MovieChip from "../../components/Chips/MovieChip";
import { dateCheck } from "../../utils/dateCheck";
import MovieIcon from "@mui/icons-material/Movie";
import CreateSession from "./MovieSessions/CreateSession";
import CinemaTabs from "./MovieSessions/CinemaTabs";
import Reviews from "./MovieReviews/Reviews";
import { useUser } from "../../context/useUser";
import {
  AddMovieToWatched,
  GetWatchedMovies,
  RemoveMovieFromWatched,
} from "../../api/AuthEndpoints";
import { toast } from "react-toastify";
const MoviePage = () => {
  const [movie, setMovie] = useState({});
  const [open, setOpen] = useState(false);
  const params = useParams();
  const { user, setUser } = useUser();
  const [userMovies, setUserMovies] = useState([]);
  const [isWatched, setIsWatched] = useState(false);

  console.log(isWatched);

  const today = new Date();
  useEffect(() => {
    getMovie();
  }, []);

  useEffect(() => {
    if (user.IsLoggedIn) {
      getUserMovies();
    }
  }, [user]);
  console.log(movie);
  console.log(userMovies);

  useEffect(() => {
    if (movie && userMovies) {
      const foundObject = userMovies.find((item) => item.id === movie.id);
      console.log(foundObject);
      setIsWatched(!!foundObject);
    }
  }, [movie, userMovies]);
  const getMovie = () => {
    getMovieById(params.movieId).then((res) => {
      setMovie(res.data);
    });
  };

  const getUserMovies = () => {
    GetWatchedMovies(user.UserName).then((res) => {
      setUserMovies(res.data);
    });
  };

  const handleWatched = () => {
    if (!isWatched) {
      AddMovieToWatched(movie.id, user.Id).then(() => {
        setIsWatched(true);
        toast.success("Movie added to watched movies!");
      });
    }
    if (isWatched) {
      RemoveMovieFromWatched(movie.id, user.Id).then(() => {
        setIsWatched(false);
        toast.success("Movie removed from watched movies!");
      });
    }
  };
  const handleOpen = () => setOpen(true);
  return (
    <Container maxWidth="xl" sx={{ marginTop: "1rem", marginBottom: "1rem" }}>
      <Box
        sx={{
          display: { sm: "flex", xs: "block" },
          justifyContent: "space-between",
          flexDirection: { xs: "column", sm: "row" },
          alignItems: "center",
          mb: "0.5rem",
        }}
      >
        <Typography sx={{ fontSize: "20px" }}>{movie.name}</Typography>
        {user.IsLoggedIn &&
          (!isWatched ? (
            <Button variant="outlined" onClick={handleWatched}>
              Add to Watched Movies
            </Button>
          ) : (
            <Button variant="contained" onClick={handleWatched}>
              Remove from Watched Movies
            </Button>
          ))}
      </Box>
      <Divider sx={{ marginBottom: "10px" }} />
      <Grid container>
        <Grid item xl={2} xs={12}>
          <Box
            sx={{
              "&:hover": {
                opacity: "0.95",
              },
              width: 230,
              height: 350,
            }}
            component="img"
            className="gameImg"
            src={movie.poster}
          />
          <Box sx={{ display: "flex", justifyContent: "space-between" }}>
            <Typography>{movie.runTime}</Typography>
            {movie.isAdult && (
              <Typography sx={{ mr: "0.2rem" }}>18+</Typography>
            )}
          </Box>
        </Grid>
        <Grid item xl={10} xs={12}>
          <Box>
            <Typography sx={{ fontSize: "16px" }}>
              Format: {movie.format}
            </Typography>
            <Typography sx={{ fontSize: "16px", mt: "0.2rem" }}>
              Release date:{" "}
              {new Date(movie.releaseDate).toLocaleDateString("en-GB", {
                day: "numeric",
                month: "short",
                year: "numeric",
              })}
            </Typography>
            <Typography sx={{ fontSize: "16px", mt: "0.2rem" }}>
              Description: {movie.description}
            </Typography>
            <Box sx={{ mt: "0.2rem" }}>
              <Typography
                sx={{
                  fontSize: "16px",
                  display: "flex",
                  alignItems: "center",
                  mt: "0.2rem",
                }}
              >
                Genres:{" "}
                {movie.genres?.length > 0 ? (
                  movie.genres?.map((genre) => {
                    return <MovieChip id={genre.id} name={genre.genreName} />;
                  })
                ) : (
                  <Typography>No genres available</Typography>
                )}
              </Typography>
              <Typography
                sx={{
                  fontSize: "16px",
                  display: "flex",
                  alignItems: "center",
                  mt: "0.2rem",
                }}
              >
                Actors:{" "}
                {movie.actors?.length > 0 ? (
                  movie.actors?.map((actor) => {
                    return (
                      <MovieChip
                        id={actor.id}
                        name={`${actor.firstName} ${actor.lastName}`}
                      />
                    );
                  })
                ) : (
                  <Typography>No actors available</Typography>
                )}
              </Typography>
              <Typography
                sx={{
                  fontSize: "16px",
                  display: "flex",
                  alignItems: "center",
                  mt: "0.2rem",
                }}
              >
                Productions:
                {movie.productions?.length > 0 ? (
                  movie.productions?.map((production) => {
                    return (
                      <MovieChip
                        id={production.id}
                        name={production.productionName}
                      />
                    );
                  })
                ) : (
                  <Typography>No productions available</Typography>
                )}
              </Typography>
            </Box>
            <Typography sx={{ fontSize: "16px", mt: "0.2rem" }}>
              Director: {movie.director}
            </Typography>

            <Divider sx={{ mt: "0.2rem" }} />

            <Box>
              <Button
                variant="text"
                size="small"
                target="_blank"
                href={movie.trailerLink}
              >
                <YouTubeIcon
                  fontSize="large"
                  sx={{ color: "red", mr: "0.2rem" }}
                ></YouTubeIcon>
                <Typography sx={{ fontSize: "16px", color: "black" }}>
                  Trailer
                </Typography>
              </Button>
              <br></br>
              <Button size="small" target="_blank" href={movie.trailerLink}>
                <MovieIcon
                  fontSize="large"
                  sx={{ color: "black", mr: "0.2rem" }}
                ></MovieIcon>
                <Typography sx={{ fontSize: "16px", color: "black" }}>
                  IMDB
                </Typography>
              </Button>
            </Box>
          </Box>
        </Grid>
        <Grid item md={12}>
          <Divider></Divider>
        </Grid>

        {dateCheck(movie.runDate, movie.endDate, today) && (
          <>
            <Grid item md={12}>
              <Typography sx={{ fontSize: "18px", marginBottom: "10px" }}>
                Movie is in cinema
              </Typography>
              <Box></Box>
            </Grid>
            <Grid
              item
              xs={12}
              display={"flex"}
              justifyContent={"space-between"}
              alignItems={"center"}
            >
              <Typography sx={{ fontSize: "18px", marginBottom: "10px" }}>
                Movie Sessions
              </Typography>
              <Button variant="contained" onClick={handleOpen}>
                {" "}
                Create Session{" "}
              </Button>
            </Grid>
            <Grid item xs={12}>
              <CinemaTabs movieId={movie.id} movie={movie} />
            </Grid>
          </>
        )}

        {!dateCheck(movie.runDate, movie.endDate, today) && (
          <Grid item md={12}>
            <Typography sx={{ fontSize: "18px" }}>
              Movie is not in cinema.
            </Typography>
          </Grid>
        )}

        <Grid item xs={12}>
          <Divider />
        </Grid>

        <Grid item xs={12}>
          <Reviews />
        </Grid>
      </Grid>
      <CreateSession
        open={open}
        setOpen={setOpen}
        movieId={movie.id}
        getMovie={getMovie}
      />
    </Container>
  );
};
export default MoviePage;
