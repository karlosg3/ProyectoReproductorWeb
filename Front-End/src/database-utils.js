// src/database-utils.js
import db from './database';

export const DatabaseService = {
  // Users
  getUsers: () => db.users.toArray(),
  updateUser: (user) => db.users.put(user),
  
  // Tasks
  createTask: (task) => db.tasks.add(task),
  updateTask: (task) => db.tasks.put(task),
  deleteTask: (id) => db.tasks.delete(id),
  
  // Columns
  getAllColumns: () => db.columns.toArray(),
  createColumn: async (columnData) => {
    await db.columns.add(columnData);
    return db.columns.get(columnData.id);
  },
  updateColumn: (column) => db.columns.put(column),
  deleteColumn: async (id) => {
    // Primero eliminamos las tareas asociadas
    await db.tasks.where('columnId').equals(id).delete();
    // Luego eliminamos la columna
    await db.columns.delete(id);
  },
  
  // Boards
  getAllBoards: () => db.boards.toArray(),
  createBoard: async (boardData) => {
    await db.boards.add(boardData);
    return db.boards.get(boardData.id);
  },
  updateBoard: (board) => db.boards.put(board),
  deleteBoard: async (id) => {
    const board = await db.boards.get(id);
    await Promise.all([
      db.tasks.where('columnId').anyOf(board.columnOrder).delete(),
      db.columns.where('id').anyOf(board.columnOrder).delete(),
      db.boards.delete(id)
    ]);
  },
  
  // App State
  getAppState: () => db.appState.get('current'),
  setActiveBoard: (boardId) => 
    db.appState.put({ id: 'current', activeBoardId: boardId })
};