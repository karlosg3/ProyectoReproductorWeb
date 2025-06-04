import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { ApiService } from '../../services/apiService';
import { DatabaseService } from '../../database-utils';

export const fetchColumns = createAsyncThunk('columns/fetch', async () => {
  const remote = await ApiService.fetchColumns();
  remote.forEach(column => DatabaseService.updateColumn(column));
  return remote;
});

export const loadLocalColumns = createAsyncThunk('columns/loadLocal', async () => {
  return await DatabaseService.getAllColumns?.(); // crea esta función si es necesario
});

const columnsSlice = createSlice({
  name: 'columns',
  initialState: {
    entities: {},
    status: 'idle',
    error: null,
  },
  reducers: {},
  extraReducers: builder => {
    builder
      .addCase(fetchColumns.fulfilled, (state, action) => {
        const map = {};
        action.payload.forEach(col => {
          map[col.id] = col;
        });
        state.entities = map;
      })
      .addCase(loadLocalColumns.fulfilled, (state, action) => {
        const map = {};
        action.payload.forEach(col => {
          map[col.id] = col;
        });
        state.entities = map;
      });
  }
});

export default columnsSlice.reducer;
