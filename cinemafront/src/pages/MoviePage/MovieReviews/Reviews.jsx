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
import { useEffect, useState } from "react";
import {
  CreateReview,
  GetReviewsForMovie,
} from "../../../api/ReviewsEndpoints";
import { useForm } from "react-hook-form";
import { useUser } from "../../../context/useUser";
import { toast } from "react-toastify";
import { useParams } from "react-router-dom";

const Reviews = ({ movieId }) => {
  const [reviews, setReviews] = useState([]);
  const [page, setPage] = useState(1);
  const [totalPages, setTotalPages] = useState(0);
  const { user, setUser } = useUser();
  const params = useParams();

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    const dataToSend = {
      content: data.reviewText,
      rating: data.grade,
      userId: user.Id,
      movieId: params.movieId,
    };

    CreateReview(dataToSend).then((res) => {
      toast.success("Review created successfully");
      getReviews();
    });
  };

  const handlePageChange = (newPage) => {
    setPage(newPage);
  };

  useEffect(() => {
    getReviews();
  }, [page]);

  const getReviews = () => {
    GetReviewsForMovie(params.movieId, page).then((res) => {
      setReviews(res.data.data);
      setTotalPages(res.data.totalPages);
    });
  };

  return (
    <Box>
      <Box sx={{ marginBottom: "20px" }}>
        <Typography variant="h6">Reviews</Typography>
      </Box>
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
          <Typography variant="body1" gutterBottom>
            {review.content}
          </Typography>
          <Typography variant="subtitle1" gutterBottom>
            User: {review.user.userName}
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
      <Box sx={{ marginTop: "20px" }}>
        <form onSubmit={handleSubmit(onSubmit)}>
          <TextField
            select
            fullWidth
            id="grade"
            label="Rating"
            defaultValue=""
            inputProps={register("grade", {
              required: "Please enter a grade",
            })}
            error={errors.grade}
            helperText={errors.grade?.message}
            sx={{ marginBottom: "10px", minWidth: "120px" }}
          >
            <MenuItem value="">Select Grade</MenuItem>
            <MenuItem value={10}>10</MenuItem>
            <MenuItem value={9}>9</MenuItem>
            <MenuItem value={8}>8</MenuItem>
            <MenuItem value={7}>7</MenuItem>
            <MenuItem value={6}>6</MenuItem>
            <MenuItem value={5}>5</MenuItem>
            <MenuItem value={4}>4</MenuItem>
            <MenuItem value={3}>3</MenuItem>
            <MenuItem value={2}>2</MenuItem>
            <MenuItem value={1}>1</MenuItem>
          </TextField>

          <TextField
            id="review-textbox"
            label="Write your review"
            multiline
            rows={4}
            variant="outlined"
            {...register("reviewText", { required: true })}
            error={Boolean(errors.reviewText)}
            helperText={errors.reviewText ? "Review is required" : ""}
            fullWidth
            sx={{ marginBottom: "10px" }}
          />

          <Button
            disabled={!user.IsLoggedIn}
            type="submit"
            variant="contained"
            color="primary"
            sx={{ minWidth: "80px" }}
          >
            Send
          </Button>

          {!user.IsLoggedIn && (
            <Typography>You have to be logged in to leave a review!</Typography>
          )}
        </form>
      </Box>
    </Box>
  );
};

export default Reviews;
