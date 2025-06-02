// redux/services/listaService.js
import api from "./api";

export const getListasByBoardService = async (idBoard) => {
  const response = await api.get(`/api/listas/board/${idBoard}`);
  return response.data;
};

export const crearListaService = async ({ idBoard, nombre, posicion }) => {
  const response = await api.post('/api/listas/', { idBoard, nombre, posicion });
  return response.data;
};

export const modificarListaService = async ({ idLista, nombre }) => {
  const response = await api.put(`/api/listas/${idLista}`, { nombre });
  return response.data;
};

export const actualizarPosicionListaService = async ({ idLista, nuevaPosicion }) => {
  const response = await api.patch(`/api/listas/${idLista}/posicion`, { posicion: nuevaPosicion });
  return response.data;
};

export const eliminarListaService = async (idLista) => {
  const response = await api.delete(`/api/listas/${idLista}`);
  return response.data;
};