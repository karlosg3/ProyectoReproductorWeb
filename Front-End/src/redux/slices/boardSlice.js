// redux/slices/boardSlice.js
import { createSlice } from '@reduxjs/toolkit';
import { getBoardByName, createBoard, deleteBoard, updateBoard } from '../actions/boardActions';

const initialState = {
  boards: [],
  currentBoard: null,
  loading: false,
  error: null,
};

const boardSlice = createSlice({
  name: 'board',
  initialState,
  reducers: {
    clearBoardState: (state) => {
      state.currentBoard = null;
      state.error = null;
    },
  },
  extraReducers: (builder) => {
    builder
      // GET
      .addCase(getBoardByName.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(getBoardByName.fulfilled, (state, action) => {
        state.loading = false;
        state.currentBoard = action.payload;
      })
      .addCase(getBoardByName.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload;
      })
      // CREATE
      .addCase(createBoard.fulfilled, (state, action) => {
        state.boards.push(action.payload);
      })
      .addCase(createBoard.rejected, (state, action) => {
        state.error = action.payload;
      })
      // DELETE
      .addCase(deleteBoard.fulfilled, (state, action) => {
        state.boards = state.boards.filter(board => board.id !== action.meta.arg);
      })
      .addCase(deleteBoard.rejected, (state, action) => {
        state.error = action.payload;
      })
      // UPDATE
      .addCase(updateBoard.fulfilled, (state, action) => {
        const idx = state.boards.findIndex(board => board.id === action.payload.id);
        if (idx !== -1) {
          state.boards[idx].name = action.payload.name;
        }
        if (state.currentBoard?.id === action.payload.id) {
          state.currentBoard.name = action.payload.name;
        }
      })
      .addCase(updateBoard.rejected, (state, action) => {
        state.error = action.payload;
      });
  },
});

export const { clearBoardState } = boardSlice.actions;
export default boardSlice.reducer;
