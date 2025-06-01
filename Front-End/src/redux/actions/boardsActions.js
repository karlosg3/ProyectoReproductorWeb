import { createAsyncThunk } from "@reduxjs/toolkit";
import { boardService } from "../../services/boardService";

export const getBoard = createAsyncThunk(
    'boards/getBoard',
    async (IdBoard, { rejectWithValue}) => {
        try {
            const res = await boardService.getById(IdBoard);
            if (res.ok) {
                return res.data;
            }
            return rejectWithValue(res.msg || 'No se encontro el tablero');
        } catch (e) {
            return rejectWithValue('Error de red al buscar el tablero');
        }
    }
);

export const newBoard = createAsyncThunk(
    'boards/newBoard',
    async (board, { rejectWithValue }) => {
        try{
            const res = await boardService.newBoard(board);
            if (res.ok) return res.data;
            return rejectWithValue(res.msg || 'Error al crear tablero');
        } catch (e) {
            return rejectWithValue('Error de red al crear tablero');
        }
    }  
);

export const modificarBoard = createAsyncThunk(
    'boards/modificarBoard',
    async (board, { rejectWithValue }) => {
        try {
            const res = await boardService.modificarBoard(board.id, board);
            if (res.ok) return res.data;
            return rejectWithValue(res.msg || 'Error al actualziar tablero');
        } catch (e) {
            return rejectWithValue('Error de red al actualizar el tablero');
        }
    }
);

export const borrarBoard = createAsyncThunk(
    'boards/borrarBoard',
    async (IdBoard, { rejectWithValue }) => {
      try {
        const res = await boardService.delete(IdBoard);
        if (res.ok) return IdBoard;
        return rejectWithValue(res.msg || 'Error al eliminar tablero');
      } catch (e) {
        return rejectWithValue('Error de red al eliminar tablero');
      }
    }
  );