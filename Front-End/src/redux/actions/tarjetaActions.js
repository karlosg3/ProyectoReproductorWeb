
import { createAsyncThunk } from '@reduxjs/toolkit';
import {
  getTarjetaByNombreService,
  crearTarjetaService,
  modificarTarjetaService,
  cambiarPosicionTarjetaService,
  cambiarTarjetaDeListaService,
  eliminarTarjetaService
} from '../../services/tarjetaService';

export const getTarjetaByNombre = createAsyncThunk(
  'tarjetas/getByNombre',
  async (nombre, { rejectWithValue }) => {
    try {
      return await getTarjetaByNombreService(nombre);
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Error al buscar tarjeta');
    }
  }
);

export const crearTarjeta = createAsyncThunk(
  'tarjetas/crear',
  async (data, { rejectWithValue }) => {
    try {
      return await crearTarjetaService(data);
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Error al crear tarjeta');
    }
  }
);

export const modificarTarjeta = createAsyncThunk(
  'tarjetas/modificar',
  async ({ idTarjeta, data }, { rejectWithValue }) => {
    try {
      return await modificarTarjetaService(idTarjeta, data);
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Error al modificar tarjeta');
    }
  }
);

export const cambiarPosicionTarjeta = createAsyncThunk(
  'tarjetas/cambiarPosicion',
  async ({ idTarjeta, nuevaPosicion }, { rejectWithValue }) => {
    try {
      return await cambiarPosicionTarjetaService(idTarjeta, nuevaPosicion);
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Error al cambiar posición');
    }
  }
);
export const cambiarTarjetaDeLista = createAsyncThunk(
  'tarjetas/cambiarLista',
  async ({ idTarjeta, idListaDestino }, { rejectWithValue }) => {
    try {
      return await cambiarTarjetaDeListaService(idTarjeta, idListaDestino);
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Error al cambiar de lista');
    }
  }
);

export const eliminarTarjeta = createAsyncThunk(
  'tarjetas/eliminar',
  async (idTarjeta, { rejectWithValue }) => {
    try {
      return await eliminarTarjetaService(idTarjeta);
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Error al eliminar tarjeta');
    }
  }
);
