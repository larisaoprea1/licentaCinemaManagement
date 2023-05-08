import * as React from "react";
import Box from "@mui/material/Box";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import YouTubeIcon from "@mui/icons-material/YouTube";
import { IconButton } from "@mui/material";
import { useNavigate } from "react-router-dom";

const AiringMovieCard = (props) => {
  const navigate = useNavigate();
  return (
    <Card sx={{ display: "flex" }}>
      <CardMedia
        component="img"
        sx={{ width: 151, height: 226 }}
        image={props.movie.poster}
        alt={props.name}
      />
      <Box sx={{ display: "flex", flexDirection: "column" }}>
        <CardContent sx={{ flex: "1 0 auto" }}>
          <Typography
            component="div"
            variant="h5"
            sx={{
              "&:hover": {
                color: "pink",
              },
              cursor: "pointer",
            }}
            onClick={() => navigate(`/movie/${props.movie.id}`)}
          >
            {props.movie.name}
          </Typography>
          <Typography
            variant="subtitle1"
            color="text.secondary"
            component="div"
          >
            Format: {props.movie.format}
          </Typography>
          <Typography
            variant="subtitle1"
            color="text.secondary"
            component="div"
          >
            Genres: 
            {props.movie.genres?.map(
              genre=>{
                return ` ${genre.genreName}`
              }
            )}
          </Typography>
          <Box>
            <IconButton
              size="small"
              target="_blank"
              href={props.movie.trailerLink}
            >
              <YouTubeIcon fontSize="large" sx={{ color: "red" }}></YouTubeIcon>
            </IconButton>
          </Box>
        </CardContent>
      </Box>
    </Card>
  );
};
export default AiringMovieCard;
