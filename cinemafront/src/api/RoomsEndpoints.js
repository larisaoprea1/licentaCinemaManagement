import axiosInstance from "../config/axios";

const API_URL = "/room";

export const CreateRoomRequest = async (data) => {
  const response = await axiosInstance.post(`${API_URL}/createroom`, data);
  return response;
};

export const GetRoomsByCinemaId = async (cinemaId) => {
  const response = await axiosInstance.get(
    `${API_URL}/roomscinema/id/${cinemaId}`
  );
  return response;
};

export const EditRoom = async (data, id) => {
  const response = await axiosInstance.put(`${API_URL}/editroom/${id}`, data);
  return response;
};

export const GetRoom = async (id) => {
  const response = await axiosInstance.get(`${API_URL}/getroom/${id}`);
  return response;
};

export const DeleteRoom = async (id) => {
  const response = await axiosInstance.delete(`${API_URL}/deleteroom/${id}`);
  return response;
};