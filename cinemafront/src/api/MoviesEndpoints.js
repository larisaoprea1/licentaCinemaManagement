import axiosInstance from "../config/axios"

const API_URL = "/movie";

export const CreateMovieRequest = async (data) =>{
    const response = await axiosInstance.post(`${API_URL}/addmovie`, data)
    return response;
}
