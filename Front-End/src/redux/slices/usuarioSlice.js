import { createSlice } from '@reduxjs/toolkit';
import { loginUsuario, registroUsuario } from '../actions/usuarioActions';

const usuarioSlice = createSlice({
    name: 'user',
    initialState: null,
    reducers: {
        logoutUsuario: () => {
            localStorage.removeItem('user');
            return null;
        }
    },
    extraReducers: (builder) => {
        builder
            .addCase(loginUsuario.fulfilled, (state, action) => action.payload)
            .addCase(registroUsuario.fulfilled, (state, action) => action.payload);
    }
});

export const { logoutUsuario } = usuarioSlice.actions;
export default usuarioSlice.reducer;