import * as React from "react";
import Box from "@mui/material/Box";
import Card from "@mui/material/Card";
import CardContent from "@mui/material/CardContent";
import CardMedia from "@mui/material/CardMedia";
import Typography from "@mui/material/Typography";
import YouTubeIcon from "@mui/icons-material/YouTube";
import { IconButton } from "@mui/material";
import { useNavigate } from "react-router-dom";

const SimpleMovieCard = (props) => {
  const navigate = useNavigate();
  return (
    <Card sx={{ maxWidth: 250 }}>
      <CardMedia
        component="img"
        sx={{ height: 350 }}
        image={props.movie.poster}
        alt={props.name}
      />
      <CardContent>
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
      </CardContent>
    </Card>
  );
};
export default SimpleMovieCard;
