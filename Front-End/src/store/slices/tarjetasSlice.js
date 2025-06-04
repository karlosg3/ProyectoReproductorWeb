// src/store/slices/tarjetasSlice.js
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { ApiService } from '../../services/apiService';
import { DatabaseService } from '../../database-utils';

// 🔄 Cargar tarjetas desde IndexedDB
export const cargarInicialLocal = createAsyncThunk('tarjetas/loadLocal', async () => {
  const local = await DatabaseService.getTasks();
  return local;
});

// 🔄 Cargar tarjetas desde API y sincronizar con IndexedDB
export const fetchTarjetas = createAsyncThunk('tarjetas/fetch', async () => {
  const remote = await ApiService.fetchTasks();
  remote.forEach(task => DatabaseService.updateTask(task)); // sincroniza local
  return remote;
});

// ➕ Crear nueva tarjeta
export const crearTarjeta = createAsyncThunk('tarjetas/create', async (task) => {
  const saved = await ApiService.createTask(task);
  await DatabaseService.createTask(saved);
  return saved;
});

const tarjetaSlice = createSlice({
  name: 'tarjetas',
  initialState: {
    tarjetas: {},
    status: 'idle',
    error: null,
  },
  reducers: {},
  extraReducers: builder => {
    builder
      .addCase(cargarInicialLocal.fulfilled, (state, action) => {
        const map = {};
        action.payload.forEach(t => {
          map[t.id] = t;
        });
        state.tarjetas = map;
      })
      .addCase(fetchTarjetas.fulfilled, (state, action) => {
        const map = {};
        action.payload.forEach(t => {
          map[t.id] = t;
        });
        state.tarjetas = map;
      })
      .addCase(crearTarjeta.fulfilled, (state, action) => {
        state.tarjetas[action.payload.id] = action.payload;
      });
  }
});

export default tarjetaSlice.reducer;