import axiosInstance from "../config/axios";

const API_URL = "/genre";

export const CreateGenreRequest = async (data) => {
  const response = await axiosInstance.post(`${API_URL}/creategenre`, data);
  return response;
};

export const GetGenres = async (page) => {
  const response = await axiosInstance.get(`${API_URL}/genres/page/${page}/pagesize/10`);
  return response;
};

export const GetPopulateGenres = async () => {
  const response = await axiosInstance.get(`${API_URL}/populategenres`);
  return response;
};

export const EditGenre = async (data, id) => {
  const response = await axiosInstance.put(`${API_URL}/editgenre/${id}`, data);
  return response;
};

export const GetGenre = async (id) => {
  const response = await axiosInstance.get(`${API_URL}/getgenre/${id}`);
  return response;
};

export const DeleteGenre = async (id) => {
  const response = await axiosInstance.delete(`${API_URL}/deletegenre/${id}`);
  return response;
};
