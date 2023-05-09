import axiosInstance from "../config/axios";

const API_URL = "/room";

export const CreateRoomRequest = async (data) => {
  const response = await axiosInstance.post(`${API_URL}/createroom`, data);
  return response;
};