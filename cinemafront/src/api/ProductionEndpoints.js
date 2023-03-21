import axiosInstance from "../config/axios";

const API_URL = "/production";

export const CreateProductionRequest = async (data) =>{
    const response = await axiosInstance.post(`${API_URL}/createproduction`, data)
    return response;
}