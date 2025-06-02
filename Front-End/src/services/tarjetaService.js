// redux/services/tarjetaService.js
import api from "./api";

export const getTarjetaByNombreService = async (nombre) => {
  const response = await api.get(`/api/tarjetas/nombre/${nombre}`);
  return response.data;
};

export const crearTarjetaService = async (data) => {
  // data: { nombre, tipoCredito, tasaInteres, cantidadCredito, descripcion, posicion, idLista }
  const response = await api.post('/api/tarjetas/', data);
  return response.data;
};

export const modificarTarjetaService = async (idTarjeta, data) => {
  // data: todos los campos a modificar
  const response = await api.put(`/api/tarjetas/${idTarjeta}`, data);
  return response.data;
};

export const cambiarPosicionTarjetaService = async (idTarjeta, nuevaPosicion) => {
  const response = await api.patch(`/api/tarjetas/${idTarjeta}/posicion`, { posicion: nuevaPosicion });
  return response.data;
};

export const cambiarTarjetaDeListaService = async (idTarjeta, idListaDestino) => {
  const response = await api.patch(`/api/tarjetas/${idTarjeta}/cambiar-lista`, { idLista: idListaDestino });
  return response.data;
};

export const eliminarTarjetaService = async (idTarjeta) => {
  const response = await api.delete(`/api/tarjetas/${idTarjeta}`);
  return response.data;
};

