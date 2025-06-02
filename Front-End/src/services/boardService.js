// redux/services/boardService.js
import axios from 'axios';

const API = axios.create({
  baseURL: '/api/boards', // Asegúrate que esto coincida con tu backend
  headers: {
    'Content-Type': 'application/json',
  },
});

export const getBoardByNameService = async (name) => {
  const response = await API.get(`/name/${name}`);
  return response.data;
};

export const createBoardService = async (data) => {
  const response = await API.post('/', data); // data: { name: 'Mi Board' }
  return response.data;
};

export const deleteBoardService = async (id) => {
  const response = await API.delete(`/${id}`);
  return response.data;
};

export const updateBoardService = async ({ id, name }) => {
  const response = await API.put(`/${id}`, { name });
  return response.data;
};
