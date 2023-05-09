import axiosInstance from "../config/axios";

const API_URL = "/cinema";

export const CreateCinemaRequest = async (data) => {
  const response = await axiosInstance.post(`${API_URL}/createcinema`, data);
  return response;
};

export const GetCinemas = async (page) => {
  const response = await axiosInstance.get(`${API_URL}/cinemas/page/${page}/pagesize/10`);
  return response;
};

export const GetPopulateCinemas = async () => {
  const response = await axiosInstance.get(`${API_URL}/populatecinemas`);
  return response;
};

export const EditCinema = async (data, id) => {
  const response = await axiosInstance.put(`${API_URL}/editcinema/${id}`, data);
  return response;
};

export const GetCinema = async (id) => {
  const response = await axiosInstance.get(`${API_URL}/getcinema/${id}`);
  return response;
};

export const DeleteCinema = async (id) => {
  const response = await axiosInstance.delete(`${API_URL}/deletecinema/${id}`);
  return response;
};
