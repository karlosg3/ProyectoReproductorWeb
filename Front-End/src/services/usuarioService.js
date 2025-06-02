// redux/services/usuarioService.js
import api from "./api";

export const loginUsuarioService = async ({ username, password }) => {
  const response = await api.post('/login', { username, password });
  return response.data;
};

export const registroUsuarioService = async ({ username, password }) => {
  const response = await api.post('/register', { username, password });
  return response.data;
};