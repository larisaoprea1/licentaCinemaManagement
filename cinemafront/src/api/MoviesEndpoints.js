import axiosInstance from "../config/axios";

const API_URL = "/movie";

export const CreateMovieRequest = async (data) => {
  const response = await axiosInstance.post(`${API_URL}/addmovie`, data);
  return response;
};

export const GetAiringMovies = async (data) => {
  const response = await axiosInstance.get(`${API_URL}/airingmovies`);
  return response;
};

export const GetPaginatedMovies = async (page, searchString) => {
  const response = await axiosInstance.get(
    `${API_URL}/paginatedmovies/page/${page}/page-size/10`,
    {
      params: {
        searchString: searchString,
      },
    }
  );
  return response;
};

export const getMovieById = async (id) => {
  const response = await axiosInstance.get(`${API_URL}/movieId/${id}`);
  return response;
};
