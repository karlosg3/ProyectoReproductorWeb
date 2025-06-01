import api from './api';

export const boardService = {
    async getAll() {
        try {
            const res = await api.get('/api/boards');
            if (!res || !res.data) {
                return { ok: false, msg: 'No se pudieron obtener los tableros'};
            }

            return { ok: true, data: res.data };
        } catch (error) {
            return { ok: false, msg: 'Error al obtener los tableros' };
        }
    },
    
    //Get Board especifico
    async getById(IdBoard) {
        try {
            const res = await api.get(`/api/boards/${IdBoard}`);
            if (!res || !res.data) {
                return { ok: false, msg: 'No se encontro el tablero'};
            }
            return { ok: true, data: res.data }
        } catch (error) {
            return { ok: true, msg: 'Error al buscar el tablero' };
        }
    },
    //Create Board
    async newBoard(board) {
        try {
            const res = await api.post('/api/boards', board);
            if (!res || !res.data){
                return { ok: false, msg: 'No se pudo crear el tablero'};
            }
            return { ok: true, data: res.data };
        } catch (error) {
            return { ok: false, msg: 'Error al crear el tablero' };
        }
    },
    //Update Board
    async modificarBoard(IdBoard, board) {
        try {
            const res = await api.put(`/api/boards/${IdBoard}`, board);
            if (!res || !res.data) {
                return { ok: false, msg: 'No se pudo actualizar el tablero' };
            }
            return { ok: true, data: res.data };
        } catch (error) {
            return { ok: false, msg: 'Error al actualziar el tablero' };
        }
    },
    //Delete Board
    async borrarBoard(IdBoard) {
        try {
            const res = await api.delete(`/api/boards/${IdBoard}`);
            if (!res) {
                return { ok: false, msg: 'No se pudo eliminar el tablero'};
            }
            return { ok: true };
        } catch (error) {
            return { ok: false, msg: 'Error al eliminar el tablero'};
        }
    }
}