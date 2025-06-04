// src/initial-data.js
import db from './database';

const initialData = {
  users: [],
  tasks: {},
  columns: {},
  columnOrder: [],
  boards: {},
  activeBoardId: null
};

export const loadInitialData = async () => {
  try {
    const [users, tasks, columns, boards, appState] = await Promise.all([
      db.users.toArray(),
      db.tasks.toArray(),
      db.columns.toArray(),
      db.boards.toArray(),
      db.appState.get('current')
    ]);

    // Convertir arrays a objetos con IDs como keys
    const tasksObj = tasks.reduce((obj, task) => ({ ...obj, [task.id]: task }), {});
    const columnsObj = columns.reduce((obj, column) => ({ ...obj, [column.id]: column }), {});
    const boardsObj = boards.reduce((obj, board) => ({ ...obj, [board.id]: board }), {});

    return {
      users,
      tasks: tasksObj,
      columns: columnsObj,
      boards: boardsObj,
      activeBoardId: appState?.activeBoardId || null
    };
  } catch (error) {
    console.error('Error loading data:', error);
    return initialData;
  }
};

export const seedDatabase = async () => {
  const count = await db.boards.count();
  if (count > 0) return; // Ya tiene datos

  const defaultData = {
    users: [
      { id: 'user-1', name: 'Fernando Lopez', avatarColor: '#FF6B6B' },
      { id: 'user-2', name: 'Alejandro Paz', avatarColor: '#3498DB' },
      { id: 'user-3', name: 'Sebastian Ruiz', avatarColor: '#4CAF50' },
      { id: 'user-4', name: 'Ernesto Flores', avatarColor: '#F44336' },
    ],
    tasks: [
      {
        id: 'task-1',
        name: 'Prospecto de Ejemplo 1',
        creditType: 'Crédito Simple',
        interestRate: '12.5%',
        creditAmount: '1,000,000.00',
        description: 'Cliente referido por el departamento de ventas. Requiere seguimiento urgente.',
        assignedTo: ['user-1', 'user-3'],
        columnId: 'column-1'
      },
      {
        id: 'task-2',
        name: 'Prospecto de Ejemplo 2',
        creditType: 'Crédito Revolvente',
        interestRate: '15.0%',
        creditAmount: '500,000.00',
        description: '',
        assignedTo: ['user-2'],
        columnId: 'column-2'
      },
    ],
    columns: [
      { id: 'column-1', title: 'Prospectos', taskIds: ['task-1'] },
      { id: 'column-2', title: 'Perfilamiento', taskIds: ['task-2'] },
    ],
    boards: [
      { id: 'board-001', title: 'CAPITAL', columnOrder: ['column-1', 'column-2'] },
      { id: 'board-002', title: 'CREDITARIA', columnOrder: [] },
    ],
    appState: { id: 'current', activeBoardId: 'board-001' }
  };

  await Promise.all([
    db.users.bulkAdd(defaultData.users),
    db.tasks.bulkAdd(defaultData.tasks),
    db.columns.bulkAdd(defaultData.columns),
    db.boards.bulkAdd(defaultData.boards),
    db.appState.add(defaultData.appState)
  ]);
};

export default initialData;