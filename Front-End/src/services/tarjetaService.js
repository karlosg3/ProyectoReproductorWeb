// redux/services/tarjetaService.js
import axios from 'axios';

const API = axios.create({
  baseURL: '/api/tarjetas',
  headers: {
    'Content-Type': 'application/json',
  },
});

export const getTarjetaByNombreService = async (nombre) => {
  const response = await API.get(`/nombre/${nombre}`);
  return response.data;
};

export const crearTarjetaService = async (data) => {
  // data: { nombre, tipoCredito, tasaInteres, cantidadCredito, descripcion, posicion, idLista }
  const response = await API.post('/', data);
  return response.data;
};

export const modificarTarjetaService = async (idTarjeta, data) => {
  // data: todos los campos a modificar
  const response = await API.put(`/${idTarjeta}`, data);
  return response.data;
};

export const cambiarPosicionTarjetaService = async (idTarjeta, nuevaPosicion) => {
  const response = await API.patch(`/${idTarjeta}/posicion`, { posicion: nuevaPosicion });
  return response.data;
};

export const cambiarTarjetaDeListaService = async (idTarjeta, idListaDestino) => {
  const response = await API.patch(`/${idTarjeta}/cambiar-lista`, { idLista: idListaDestino });
  return response.data;
};

export const eliminarTarjetaService = async (idTarjeta) => {
  const response = await API.delete(`/${idTarjeta}`);
  return response.data;
};

