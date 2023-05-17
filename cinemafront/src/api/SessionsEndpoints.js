import axiosInstance from "../config/axios";

const API_URL = "/session";

export const CreateSessionRequest = async (data) => {
  const response = await axiosInstance.post(`${API_URL}/createsession`, data);
  return response;
};

export const GetSessionsByMovieId = async (movieId) => {
  const response = await axiosInstance.get(
    `${API_URL}/sessions/movieId/${movieId}`
  );
  return response;
};

export const GetSessionsByRoomId = async (roomId) => {
  const response = await axiosInstance.get(
    `${API_URL}/getsessions/room/${roomId}`
  );
  return response;
};

export const GetSessionsForMovieByCinema = async (movieId, cinemaId) => {
  const response = await axiosInstance.get(
    `${API_URL}/sessions/movieId/${movieId}/cinema/${cinemaId}`
  );
  return response;
};

export const EditSession = async (data, id) => {
  const response = await axiosInstance.put(
    `${API_URL}/editsession/${id}`,
    data
  );
  return response;
};

export const GetSessionById = async (id) => {
  const response = await axiosInstance.get(`${API_URL}/getsession/${id}`);
  return response;
};

export const DeleteSession = async (id) => {
  const response = await axiosInstance.delete(`${API_URL}/deletesession/${id}`);
  return response;
};
