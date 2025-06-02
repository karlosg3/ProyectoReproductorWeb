// redux/actions/listaActions.js
import { createAsyncThunk } from '@reduxjs/toolkit';
import {
  getListasByBoardService,
  crearListaService,
  modificarListaService,
  actualizarPosicionListaService,
  eliminarListaService
} from '../services/listaService';

export const getListasByBoard = createAsyncThunk(
  'listas/getByBoard',
  async (idBoard, { rejectWithValue }) => {
    try {
      return await getListasByBoardService(idBoard);
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Error al obtener listas');
    }
  }
);

export const crearLista = createAsyncThunk(
  'listas/crear',
  async ({ idBoard, nombre, posicion }, { rejectWithValue }) => {
    try {
      return await crearListaService({ idBoard, nombre, posicion });
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Error al crear lista');
    }
  }
);

export const modificarLista = createAsyncThunk(
    'listas/modificar',
    async ({ idLista, nombre }, { rejectWithValue }) => {
      try {
        return await modificarListaService({ idLista, nombre });
      } catch (err) {
        return rejectWithValue(err.response?.data?.message || 'Error al modificar lista');
      }
    }
  );
  
  export const actualizarPosicionLista = createAsyncThunk(
    'listas/actualizarPosicion',
    async ({ idLista, nuevaPosicion }, { rejectWithValue }) => {
      try {
        return await actualizarPosicionListaService({ idLista, nuevaPosicion });
      } catch (err) {
        return rejectWithValue(err.response?.data?.message || 'Error al actualizar posición');
      }
    }
  );
  
  export const eliminarLista = createAsyncThunk(
    'listas/eliminar',
    async (idLista, { rejectWithValue }) => {
      try {
        return await eliminarListaService(idLista);
      } catch (err) {
        return rejectWithValue(err.response?.data?.message || 'Error al eliminar lista');
      }
    }
  );