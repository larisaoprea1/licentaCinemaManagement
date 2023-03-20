import axiosInstance from "../config/axios";

const API_URL = "/genre";

export const CreateGenreRequest = async (data) =>{
    const response = await axiosInstance.post(`${API_URL}/creategenre`, data)
    return response;
}