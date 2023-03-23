import axiosInstance from "../config/axios";

const API_URL = "/production";

export const CreateProductionRequest = async (data) => {
  const response = await axiosInstance.post(
    `${API_URL}/createproduction`,
    data
  );
  return response;
};

export const GetProductions = async (page) => {
  const response = await axiosInstance.get(`${API_URL}/productions/page/${page}/pagesize/10`);
  return response;
};

export const GetPopulateProductions = async () => {
    const response = await axiosInstance.get(`${API_URL}/populateproductions`);
    return response;
  };

  
export const EditProduction = async (data, id) => {
  const response = await axiosInstance.put(
    `${API_URL}/editproduction/${id}`,
    data
  );
  return response;
};

export const GetProduction = async (id) => {
  const response = await axiosInstance.get(`${API_URL}/getproduction/${id}`);
  return response;
};

export const DeleteProduction = async (id) => {
  const response = await axiosInstance.delete(
    `${API_URL}/deleteproduction/${id}`
  );
  return response;
};
