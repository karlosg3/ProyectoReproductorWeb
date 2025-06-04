import { configureStore } from "@reduxjs/toolkit";
import usuarioReducer from './slices/usuarioSlice';
import boardReducer from './slices/boardSlice';
import listaReducer from './slices/listaSlice';
import tarjetaReducer from './slices/tarjetaSlice';

const store = configureStore({
    reducer: {
        board: boardReducer,
        usuario: usuarioReducer,
        lista: listaReducer,
        tarjeta: tarjetaReducer
    }
})

export default store;