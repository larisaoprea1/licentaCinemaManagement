import axiosInstance from "../config/axios";

const API_URL = "/actor";

export const CreateActorRequest = async (data) =>{
    const response = await axiosInstance.post(`${API_URL}/createactor`, data)
    return response;
}