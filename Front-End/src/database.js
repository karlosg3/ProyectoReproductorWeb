// src/database.js
import Dexie from 'dexie';

const db = new Dexie('KanbanDB');

db.version(1).stores({
    users: 'id, name, mail, password',
    tasks: `
      id,
      name,
      creditType,
      interestRate,
      creditAmount,
      description,
      columnId
    `,
    columns: 'id, title, *taskIds',
    boards: 'id, title, *columnOrder',
    appState: 'id, activeBoardId'
  });

export default db;