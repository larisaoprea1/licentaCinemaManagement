import axiosInstance from "../config/axios";

const API_URL = "/actor";

export const CreateActorRequest = async (data) => {
  const response = await axiosInstance.post(`${API_URL}/createactor`, data);
  return response;
};

export const GetActors = async (page) => {
  const response = await axiosInstance.get(`${API_URL}/actors/page/${page}/pagesize/10`);
  return response;
};

export const GetPopulateActors = async () => {
    const response = await axiosInstance.get(`${API_URL}/populateactors`);
    return response;
  };
  
export const EditActor = async (data, id) => {
  const response = await axiosInstance.put(
    `${API_URL}/editactor/${id}`,
    data
  );
  return response;
};

export const GetActor = async (id) => {
  const response = await axiosInstance.get(`${API_URL}/getactor/${id}`);
  return response;
};

export const DeleteActor = async (id) => {
  const response = await axiosInstance.delete(
    `${API_URL}/deleteactor/${id}`
  );
  return response;
};
