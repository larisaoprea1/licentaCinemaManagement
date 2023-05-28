import axiosInstance from "../config/axios";

const API_URL = "/user";

export const Login = async (data) => {
  const response = await axiosInstance.post(`${API_URL}/login`, data);
  return response;
};

export const Register = async (data) => {
  const response = await axiosInstance.post(`${API_URL}/register`, data);
  return response;
};

export const GetUserByUsername = async (username) => {
  const response = await axiosInstance.get(`${API_URL}/username/${username}`);
  return response;
};

export const GetUserById = async (id) => {
  const response = await axiosInstance.get(`${API_URL}/userId/${id}`);
  return response;
};

export const GetWatchedMovies = async (username) => {
  const response = await axiosInstance.get(
    `${API_URL}/watchedmovies/${username}`
  );
  return response;
};

export const GetUsersPaginated = async (page) => {
  const response = await axiosInstance.get(
    `${API_URL}/page/${page}/pagesize/10`
  );
  return response;
};

export const AddMovieToWatched = async (movieid, userid) => {
  const response = await axiosInstance.post(
    `${API_URL}/movie/${movieid}/user/${userid}`
  );
  return response;
};

export const RemoveMovieFromWatched = async (movieid, userid) => {
  const response = await axiosInstance.delete(
    `${API_URL}/movie/${movieid}/user/${userid}`
  );
  return response;
};

export const EditUser = async (data, id) => {
  const response = await axiosInstance.put(`${API_URL}/edituser/${id}`, data);
  return response;
};

export const DeleteUser = async (id) => {
  const response = await axiosInstance.delete(`${API_URL}/deleteuser/${id}`);
  return response;
};

export const MakeUserAdmin = async (username) => {
  const response = await axiosInstance.post(
    `${API_URL}/assign-role/user/${username}/role/Admin`
  );
  return response;
};

export const RemoveAdmin = async (username) => {
  const response = await axiosInstance.delete(
    `${API_URL}/remove-role/user/${username}/role/Admin`
  );
  return response;
};
