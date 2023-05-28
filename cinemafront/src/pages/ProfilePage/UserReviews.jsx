import { useState, useEffect } from "react";
import { useUser } from "../../context/useUser";
import { GetUserReviews } from "../../api/ReviewsEndpoints";
import {
  Box,
  Button,
  FormControl,
  FormHelperText,
  InputLabel,
  MenuItem,
  Select,
  TextField,
  Typography,
} from "@mui/material";
import { Link } from "react-router-dom";

const UserReviews = () => {
  const [reviews, setReviews] = useState([]);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);
  const { user, setUser } = useUser();

  const handlePageChange = (newPage) => {
    setPage(newPage);
  };

  useEffect(() => {
    getReviews();
  }, [page]);

  const getReviews = () => {
    GetUserReviews(user.Id, page).then((res) => {
      setReviews(res.data.data);
      setTotalPages(res.data.totalPages);
    });
  };

  return (
    <>
      {reviews.length == 0 && (
        <Typography>
          This movie has no reviews, be the first one to leave a review!
        </Typography>
      )}
      {reviews.map((review) => (
        <Box
          key={review.id}
          sx={{
            border: "1px solid #ccc",
            borderRadius: "4px",
            padding: "10px",
            marginBottom: "10px",
          }}
        >
          <Link
            to={`/movie/${review.movie?.id}`}
            style={{ textDecoration: "none" }}
          >
            <Typography variant="body1" gutterBottom>
              Movie: {review.movie?.name}
            </Typography>
          </Link>

          <Typography variant="body1" gutterBottom>
            {review.content}
          </Typography>
          <Typography variant="subtitle2" color="textSecondary">
            Created: {new Date(review.createDate).toLocaleString()}
          </Typography>
        </Box>
      ))}
      {totalPages > 1 && (
        <Box
          sx={{ display: "flex", justifyContent: "center", marginTop: "20px" }}
        >
          <Button
            variant="outlined"
            onClick={() => handlePageChange(page - 1)}
            disabled={page === 1}
            sx={{ marginRight: "10px" }}
          >
            Previous
          </Button>
          <Button
            variant="outlined"
            onClick={() => handlePageChange(page + 1)}
            disabled={page === totalPages}
            sx={{ marginLeft: "10px" }}
          >
            Next
          </Button>
        </Box>
      )}
    </>
  );
};

export default UserReviews;
