// src/initial-data.js
const initialData = {
    users: [
      { id: 'user-1', name: 'Fernando Lopez', avatarColor: '#FF6B6B' },
      { id: 'user-2', name: 'Alejandro Paz', avatarColor: '#3498DB' },
      { id: 'user-3', name: 'Sebastian Ruiz', avatarColor: '#4CAF50' },
      { id: 'user-4', name: 'Ernesto Flores', avatarColor: '#F44336' },
    ],
    tasks: {
      'task-1': { 
        id: 'task-1', 
        name: 'Prospecto de Ejemplo 1',
        creditType: 'Crédito Simple',
        interestRate: '12.5%',
        creditAmount: '1,000,000.00',
        description: 'Cliente referido por el departamento de ventas. Requiere seguimiento urgente.',
        assignedTo: ['user-1', 'user-3'] 
      },
      'task-2': { 
        id: 'task-2', 
        name: 'Prospecto de Ejemplo 2',
        creditType: 'Crédito Revolvente',
        interestRate: '15.0%',
        creditAmount: '500,000.00',
        description: '',
        assignedTo: ['user-2'] 
      },
      'task-3': { 
        id: 'task-3', 
        name: 'Prospecto de Ejemplo 3',
        creditType: 'Crédito Simple',
        interestRate: '2.0%',
        creditAmount: '600,000.00',
        description: '',
        assignedTo: ['user-3', 'user-4'] 
      },
    },
    columns: {
      'column-1': {
        id: 'column-1',
        title: 'Prospectos',
        taskIds: ['task-1'],
      },
      'column-2': {
        id: 'column-2',
        title: 'Perfilamiento',
        taskIds: ['task-3','task-2',],
      },
    },
    columnOrder: ['column-1', 'column-2'],
    boards: {
        'board-001': { id: 'board-001', title: 'Capital', columnOrder: ['column-1', 'column-2'] },
        'board-002': { id: 'board-002', title: 'Creditaria', columnOrder: [] },
    },
    activeBoardId: 'board-001',
  };
  
  export default initialData;