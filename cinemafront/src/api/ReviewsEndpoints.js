import axiosInstance from "../config/axios";

const API_URL = "/review";

// export const CreateProductionRequest = async (data) => {
//   const response = await axiosInstance.post(
//     `${API_URL}/createproduction`,
//     data
//   );
//   return response;
// };

export const CreateReview = async (data) => {
  const response = await axiosInstance.post(`${API_URL}/createreview`, data);
  return response;
};

export const GetReviewsForMovie = async (movieId, page) => {
  const response = await axiosInstance.get(
    `${API_URL}/movie/${movieId}/page/${page}/pagesize/4`
  );
  return response;
};

export const GetUserReviews = async (userId, page) => {
  const response = await axiosInstance.get(
    `${API_URL}/user/${userId}/page/${page}/pagesize/4`
  );
  return response;
};
