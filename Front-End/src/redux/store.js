import { configureStore } from "@reduxjs/toolkit";
import usuarioReducer from './slices/usuarioSlice';

const store = configureStore({
    reducer: {
        usuario: usuarioReducer
    }
})

export default store;