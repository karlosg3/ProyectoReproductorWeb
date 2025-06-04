// src/services/apiService.js
import axios from 'axios';

const API_BASE = 'http://localhost:44324'; // Cambia esto por tu URL real

export const ApiService = {
  // Users
  fetchUsers: () => axios.get(`${API_BASE}/users`),
  updateUser: (user) => axios.put(`${API_BASE}/users/${user.id}`, user),

  // Tasks
  fetchTasks: () => axios.get(`${API_BASE}/tasks`),
  createTask: (task) => axios.post(`${API_BASE}/tasks`, task),
  updateTask: (task) => axios.put(`${API_BASE}/tasks/${task.id}`, task),
  deleteTask: (id) => axios.delete(`${API_BASE}/tasks/${id}`),

  // Columns
  fetchColumns: () => axios.get(`${API_BASE}/columns`),
  createColumn: (column) => axios.post(`${API_BASE}/columns`, column),
  updateColumn: (column) => axios.put(`${API_BASE}/columns/${column.id}`, column),
  deleteColumn: (id) => axios.delete(`${API_BASE}/columns/${id}`),

  // Boards
  fetchBoards: () => axios.get(`${API_BASE}/boards`),
  createBoard: (board) => axios.post(`${API_BASE}/boards`, board),
  updateBoard: (board) => axios.put(`${API_BASE}/boards/${board.id}`, board),
  deleteBoard: (id) => axios.delete(`${API_BASE}/boards/${id}`)
};
