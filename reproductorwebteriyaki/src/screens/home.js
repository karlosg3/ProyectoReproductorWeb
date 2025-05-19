import Form, { FormLabel } from 'react-bootstrap';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import React from 'react';
import UserScreen from './User';
import PlaylistScreen from './Playlist';
import AlbumScreen from './Album';
import ArtistaScreen from './Artista';
import BibliotecaScreen from './Biblioteca';
import BusquedaScreen from './Busqueda';
import CancionScreen from './Cancion';
import FavoritasScreen from './Favoritas';
import HistorialScreen from './Historial';
import LogInScreen from './LogIn';
import LyricsScreen from './Lyrics';
import RegistroScreen from './Registro';
import AccesoRapidoScreen from './AccesoRapido';
import './css/home.css';
import Sidebar from '../components/sidebar';

function HomeScreen(){
    return(
        <Router>
            <div className="home-screen">
                <Sidebar />
                <Routes>
                    //Se utilizara un identiifcador para la ruta especifica de los artistas, albums y canciones
                    <Route path="/" element={<AccesoRapidoScreen />} />
                    <Route path="/album" element={<AlbumScreen />} />
                    <Route path="/artista" element={<ArtistaScreen />} />
                    <Route path="/biblioteca" element={<BibliotecaScreen />} />
                    <Route path="/cancion" element={<CancionScreen />} />
                    <Route path="/biblioteca/favoritas" element={<FavoritasScreen />} />
                    <Route path="/biblioteca/historial" element={<HistorialScreen />} />
                    <Route path="/busqueda" element={<BusquedaScreen />} />
                    <Route path="/login" element={<LogInScreen />} />
                    <Route path="/lyrics" element={<LyricsScreen />} />
                    <Route path="/playlist" element={<PlaylistScreen />} />
                    <Route path="/registro" element={<RegistroScreen />} />
                    <Route path="/user" element={<UserScreen />} /> 
                </Routes>
            </div>
        </Router>
    )
}

export default HomeScreen;