import axiosInstance from "../config/axios";

const API_URL = "/booking";

export const CreateBookingRequest = async (data) => {
  const response = await axiosInstance.post(`${API_URL}/createbooking`, data);
  return response;
};

export const GetBookingsForUser = async (userId) => {
  const response = await axiosInstance.get(`${API_URL}/bookings/${userId}`);
  return response;
};

export const GetBookingById = async (id) => {
  const response = await axiosInstance.get(`${API_URL}/booking/${id}`);
  return response;
};
