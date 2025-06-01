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

    //Update Board

    //Delete Board
}