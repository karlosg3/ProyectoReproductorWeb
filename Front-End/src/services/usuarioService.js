import api from './api';

export const usuarioService = {
    current() {
        return JSON.parse(localStorage.getItem('user')) ?? null;
    },

    async login(username, password) {
        try {
            const res = await api.post('/api/usuarios/login', {
                Nombre: username,
                Contraseña: password
            });

            if (!res || !res.data) {
                return { ok: false, msg: 'Credenciales invalidas' };
            }

            const user = {
                Id: res.data,
                Nombre: username
            };

            localStorage.setItem('user', JSON.stringify(user));
            return { ok: true, user };
        } catch (error) {
            return { ok: false, msg: 'Credenciales invalidas' };
        }
    },

    async register(username, correo, password) {
        try {
            const res = await api.post('api/usuarios', {
                Nombre: username,
                Correo: correo,
                Contraseña: password,
                Habilitado: true
            });

            if (!res || !res.data) {
                return { ok: false, msg: 'No se pudo registrar el usuario' };
            }

            return await this.login(username, password);
        } catch (error) {
            if (error.response?.status === 409){
                return { ok: false, msg: 'El usuario ya existe' };
            }
            return { ok: false, msg: 'No se pudo registrar el usuario' };
        }
    },

    logout() {
        localStorage.removeItem('user');
    }
};