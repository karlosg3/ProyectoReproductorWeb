// redux/services/listaService.js
import axios from 'axios';

const API = axios.create({
  baseURL: '/api/listas', // Ajusta según tu backend
  headers: {
    'Content-Type': 'application/json',
  },
});

export const getListasByBoardService = async (idBoard) => {
  const response = await API.get(`/board/${idBoard}`);
  return response.data;
};

export const crearListaService = async ({ idBoard, nombre, posicion }) => {
  const response = await API.post('/', { idBoard, nombre, posicion });
  return response.data;
};

export const modificarListaService = async ({ idLista, nombre }) => {
  const response = await API.put(`/${idLista}`, { nombre });
  return response.data;
};

export const actualizarPosicionListaService = async ({ idLista, nuevaPosicion }) => {
  const response = await API.patch(`/${idLista}/posicion`, { posicion: nuevaPosicion });
  return response.data;
};

export const eliminarListaService = async (idLista) => {
  const response = await API.delete(`/${idLista}`);
  return response.data;
};
