import {
    getAll,
    getById,
    newBoard,
    modificarBoard,
    borrarBoard
} from '../actions/boardsActions';
import { createSlice } from '@reduxjs/toolkit';

export const boardSlice = createSlice({
    name: 'board',
    initialState: null
})