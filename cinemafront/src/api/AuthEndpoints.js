import axiosInstance from "../config/axios"

const API_URL = "/user";

export const Login = async (data) =>{
    const response = await axiosInstance.post(`${API_URL}/login`, data)
    return response;
}

export const Register = async (data) =>{
    const response = await axiosInstance.post(`${API_URL}/register`, data)
    return response;
}