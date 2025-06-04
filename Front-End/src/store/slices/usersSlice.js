import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { ApiService } from '../../services/apiService';
import { DatabaseService } from '../../database-utils';

export const fetchUsers = createAsyncThunk('users/fetch', async () => {
  const remote = await ApiService.fetchUsers();
  remote.forEach(user => DatabaseService.updateUser(user));
  return remote;
});

export const loadLocalUsers = createAsyncThunk('users/loadLocal', async () => {
  return await DatabaseService.getUsers();
});

const usersSlice = createSlice({
  name: 'users',
  initialState: {
    entities: {},
    status: 'idle',
    error: null,
  },
  reducers: {},
  extraReducers: builder => {
    builder
      .addCase(fetchUsers.fulfilled, (state, action) => {
        const map = {};
        action.payload.forEach(user => {
          map[user.id] = user;
        });
        state.entities = map;
      })
      .addCase(loadLocalUsers.fulfilled, (state, action) => {
        const map = {};
        action.payload.forEach(user => {
          map[user.id] = user;
        });
        state.entities = map;
      });
  }
});

export default usersSlice.reducer;