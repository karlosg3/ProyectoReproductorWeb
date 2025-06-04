import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { ApiService } from '../../services/apiService';
import { DatabaseService } from '../../database-utils';

export const fetchBoards = createAsyncThunk('boards/fetch', async () => {
  const remote = await ApiService.fetchBoards();
  remote.forEach(board => DatabaseService.updateBoard(board));
  return remote;
});

export const loadLocalBoards = createAsyncThunk('boards/loadLocal', async () => {
  return await DatabaseService.getAllBoards?.(); // crea esta función si es necesario
});

const boardsSlice = createSlice({
  name: 'boards',
  initialState: {
    entities: {},
    status: 'idle',
    error: null,
  },
  reducers: {},
  extraReducers: builder => {
    builder
      .addCase(fetchBoards.fulfilled, (state, action) => {
        const map = {};
        action.payload.forEach(board => {
          map[board.id] = board;
        });
        state.entities = map;
      })
      .addCase(loadLocalBoards.fulfilled, (state, action) => {
        const map = {};
        action.payload.forEach(board => {
          map[board.id] = board;
        });
        state.entities = map;
      });
  }
});

export default boardsSlice.reducer;