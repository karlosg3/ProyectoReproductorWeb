import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getBoardByName } from '../redux/actions/boardsActions';
import { actualizarPosicionLista} from '../redux/actions/listaActions';
import{cambiarPosicionTarjeta,cambiarTarjetaDeLista} from '../redux/actions/tarjetaActions';
import Board from '../components/Board';
import TaskModal from '../components/TaskModal';
import { DragDropContext } from '@hello-pangea/dnd';
import '../App.css';
import { useParams } from 'react-router-dom';


function BoardPage() {
  const dispatch = useDispatch();
  const { nombre } = useParams(); // Suponiendo que accedes con /board/:nombre

  const { currentBoard, loading, error } = useSelector(state => state.board);
  const [modalState, setModalState] = useState({ isOpen: false, task: null, columnId: null });

  useEffect(() => {
    if (nombre) {
      dispatch(getBoardByName(nombre));
    }
  }, [nombre]);

  if (loading) return <p>Cargando tablero...</p>;
  if (error) return <p>Error: {error}</p>;
  if (!currentBoard) return <p>No hay datos del tablero</p>;

  const onDragEnd = (result) => {
    const { destination, source, draggableId, type } = result;
    if (!destination) return;
    if (destination.droppableId === source.droppableId && destination.index === source.index) return;
  
    if (type === 'column') {
      // Mover columnas (listas)
      const movedListId = draggableId;
      const nuevaPosicion = destination.index;
      dispatch(actualizarPosicionLista({ idLista: movedListId, nuevaPosicion }));
      return;
    }
  
    // Mover tarjetas (dentro o entre listas)
    const tarjetaId = draggableId;
    const idListaOrigen = source.droppableId;
    const idListaDestino = destination.droppableId;
    const nuevaPosicion = destination.index;
  
    // Si se moviÃ³ entre listas
    if (idListaOrigen !== idListaDestino) {
      dispatch(cambiarTarjetaDeLista({ idTarjeta: tarjetaId, idListaDestino }));
    }
  
    dispatch(cambiarPosicionTarjeta({ idTarjeta: tarjetaId, nuevaPosicion }));
  };

  return (
    <DragDropContext onDragEnd={onDragEnd}>
      <Board
        board={currentBoard}
        modalState={modalState}
        setModalState={setModalState}
      />
      <TaskModal
        modalState={modalState}
        setModalState={setModalState}
      />
    </DragDropContext>
  );
}

export default BoardPage;