// redux/slices/usuarioSlice.js
import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  usuario: null,
  token: null,
  loading: false,
  error: null,
};

export const usuarioSlice = createSlice({
  name: 'user',
  initialState,
  reducers: {
    logoutUsuario: (state) => {
      state.usuario = null;
      state.token = null;
    },
  },
  extraReducers: (builder) => {
    // Aquí se manejan los reducers de los async actions (login, register)
  },
});

export const { logoutUsuario } = usuarioSlice.actions;
export default usuarioSlice.reducer;