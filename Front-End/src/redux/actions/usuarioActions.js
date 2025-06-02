import { createAsyncThunk } from "@reduxjs/toolkit";
import { loginUsuarioService, registroUsuarioService } from "../../services/usuarioService";

export const loginUsuario = createAsyncThunk(
    'usuarios/login',
    async ({ username, password }, { rejectWithValue }) => {
        try {
            const res = await loginUsuarioService.login(username, password);
            if (res.ok) return loginUsuarioService.current();
            return rejectWithValue(res.msg || 'Credenciales incorrectas');
        } catch (e) {
            return rejectWithValue('Error al iniciar sesion');
        }
    }
);

export const registroUsuario = createAsyncThunk(
    'usuario/registro',
    async ({ username, password }, { rejectWithValue}) => {
        try {
            const res = await registroUsuarioService.register(username, password);
            if (res.ok) return registroUsuarioService.current();
            return rejectWithValue(res.msg || 'Registro fallido');
        } catch (e) {
            return rejectWithValue('Error al registrar usuario');
        }
    }
)