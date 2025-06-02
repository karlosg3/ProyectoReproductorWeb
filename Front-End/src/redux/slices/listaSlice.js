// redux/slices/listaSlice.js
import { createSlice } from '@reduxjs/toolkit';
import {
  getListasByBoard,
  crearLista,
  modificarLista,
  actualizarPosicionLista,
  eliminarLista
} from '../actions/listaActions';

const initialState = {
  listas: [],
  loading: false,
  error: null,
};

const listaSlice = createSlice({
  name: 'listas',
  initialState,
  reducers: {
    clearListasState: (state) => {
      state.listas = [];
      state.error = null;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getListasByBoard.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(getListasByBoard.fulfilled, (state, action) => {
        state.loading = false;
        state.listas = action.payload;
      })
      .addCase(getListasByBoard.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload;
      })

      .addCase(crearLista.fulfilled, (state, action) => {
        state.listas.push(action.payload);
      })
      .addCase(crearLista.rejected, (state, action) => {
        state.error = action.payload;
      })

      .addCase(modificarLista.fulfilled, (state, action) => {
        const idx = state.listas.findIndex(l => l.id === action.payload.id);
        if (idx !== -1) state.listas[idx].nombre = action.payload.nombre;
      })
      .addCase(modificarLista.rejected, (state, action) => {
        state.error = action.payload;
      })

      .addCase(actualizarPosicionLista.fulfilled, (state, action) => {
        const idx = state.listas.findIndex(l => l.id === action.payload.id);
        if (idx !== -1) state.listas[idx].posicion = action.payload.posicion;

        // Reordenar listas localmente si lo deseas (opcional)
        state.listas.sort((a, b) => a.posicion - b.posicion);
      })
      .addCase(actualizarPosicionLista.rejected, (state, action) => {
        state.error = action.payload;
      })

      .addCase(eliminarLista.fulfilled, (state, action) => {
        state.listas = state.listas.filter(l => l.id !== action.meta.arg);
      })
      .addCase(eliminarLista.rejected, (state, action) => {
        state.error = action.payload;
      });
  },
});

export const { clearListasState } = listaSlice.actions;
export default listaSlice.reducer;
