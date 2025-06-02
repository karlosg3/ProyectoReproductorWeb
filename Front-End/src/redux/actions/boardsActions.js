// redux/actions/boardActions.js
import { createAsyncThunk } from '@reduxjs/toolkit';
import {
  getBoardByNameService,
  createBoardService,
  deleteBoardService,
  updateBoardService,
} from '../../services/boardService';

export const getBoardByName = createAsyncThunk(
  'board/getByName',
  async (name, { rejectWithValue }) => {
    try {
      return await getBoardByNameService(name);
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Error al obtener el board');
    }
  }
);

export const createBoard = createAsyncThunk(
  'board/create',
  async (data, { rejectWithValue }) => {
    try {
      return await createBoardService(data);
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Error al crear el board');
    }
  }
);

export const deleteBoard = createAsyncThunk(
  'board/delete',
  async (id, { rejectWithValue }) => {
    try {
      return await deleteBoardService(id);
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Error al eliminar el board');
    }
  }
);

export const updateBoard = createAsyncThunk(
  'board/update',
  async ({ id, name }, { rejectWithValue }) => {
    try {
      return await updateBoardService({ id, name });
    } catch (err) {
      return rejectWithValue(err.response?.data?.message || 'Error al actualizar el board');
    }
  }
);
