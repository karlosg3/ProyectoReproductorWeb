// redux/slices/tarjetaSlice.js
import { createSlice } from '@reduxjs/toolkit';
import {
  getTarjetaByNombre,
  crearTarjeta,
  modificarTarjeta,
  cambiarPosicionTarjeta,
  cambiarTarjetaDeLista,
  eliminarTarjeta
} from '../actions/tarjetaActions';

const initialState = {
  tarjetas: [],
  loading: false,
  error: null,
};

const tarjetaSlice = createSlice({
  name: 'tarjetas',
  initialState,
  reducers: {
    clearTarjetasState: (state) => {
      state.tarjetas = [];
      state.error = null;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(getTarjetaByNombre.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(getTarjetaByNombre.fulfilled, (state, action) => {
        state.loading = false;
        // Opcional: puedes manejar tarjeta seleccionada si quieres
      })
      .addCase(getTarjetaByNombre.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload;
      })

      .addCase(crearTarjeta.fulfilled, (state, action) => {
        state.tarjetas.push(action.payload);
      })
      .addCase(crearTarjeta.rejected, (state, action) => {
        state.error = action.payload;
      })

      .addCase(modificarTarjeta.fulfilled, (state, action) => {
        const idx = state.tarjetas.findIndex(t => t.id === action.payload.id);
        if (idx !== -1) {
          state.tarjetas[idx] = action.payload;
        }
      })
      .addCase(modificarTarjeta.rejected, (state, action) => {
        state.error = action.payload;
      })
.addCase(cambiarPosicionTarjeta.fulfilled, (state, action) => {
        const idx = state.tarjetas.findIndex(t => t.id === action.payload.id);
        if (idx !== -1) state.tarjetas[idx].posicion = action.payload.posicion;
        state.tarjetas.sort((a, b) => a.posicion - b.posicion);
      })
      .addCase(cambiarPosicionTarjeta.rejected, (state, action) => {
        state.error = action.payload;
      })

      .addCase(cambiarTarjetaDeLista.fulfilled, (state, action) => {
        const idx = state.tarjetas.findIndex(t => t.id === action.payload.id);
        if (idx !== -1) state.tarjetas[idx].idLista = action.payload.idLista;
      })
      .addCase(cambiarTarjetaDeLista.rejected, (state, action) => {
        state.error = action.payload;
      })

      .addCase(eliminarTarjeta.fulfilled, (state, action) => {
        state.tarjetas = state.tarjetas.filter(t => t.id !== action.meta.arg);
      })
      .addCase(eliminarTarjeta.rejected, (state, action) => {
        state.error = action.payload;
      });
  },
});

export const { clearTarjetasState } = tarjetaSlice.actions;
export default tarjetaSlice.reducer;