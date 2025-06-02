// redux/services/boardService.js
import api from "./api";

export const getBoardByNameService = async (name) => {
  const response = await api.get(`/api/boards/name/${name}`);
  return response.data;
};

export const createBoardService = async (data) => {
  const response = await api.post('/api/boards/', data); // data: { name: 'Mi Board' }
  return response.data;
};

export const deleteBoardService = async (id) => {
  const response = await api.delete(`/api/boards/${id}`);
  return response.data;
};

export const updateBoardService = async ({ id, name }) => {
  const response = await api.put(`/api/boards/${id}`, { name });
  return response.data;
};
