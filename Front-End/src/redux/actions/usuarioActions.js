import { createAsyncThunk } from "@reduxjs/toolkit";
import { usuarioService } from "../../services/usuarioService";

export const loginUsuario = createAsyncThunk(
    'usuarios/login',
    async ({ username, password }, { rejectWithValue }) => {
        try {
            const res = await usuarioService.login(username, password);
            if (res.ok) return usuarioService.current();
            return rejectWithValue(res.msg || 'Credenciales incorrectas');
        } catch (e) {
            return rejectWithValue('Error al iniciar sesion');
        }
    }
);

export const registroUsuario = createAsyncThunk(
    'usuario/registro',
    async ({ username, correo, password }, { rejectWithValue}) => {
        try {
            const res = await usuarioService.register(username, correo, password);
            if (res.ok) return usuarioService.current();
            return rejectWithValue(res.msg || 'Registro fallido');
        } catch (e) {
            return rejectWithValue('Error al registrar usuario');
        }
    }
)