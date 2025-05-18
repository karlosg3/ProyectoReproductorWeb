import Form, { FormLabel } from 'react-bootstrap';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import React from 'react';
import UserScreen from './User';
import PlaylistScreen from './Playlist';
import AlbumScreen from './Album';
import ArtistaScreen from './Artista';
import BibliotecaScreen from './Biblioteca';
import CancionScreen from './Cancion';
import FavoritasScreen from './Favoritas';
import HistorialScreen from './Historial';
import LogInScreen from './LogIn';
import LyricsScreen from './Lyrics';
import RegistroScreen from './Registro';

function HomeScreen(){
    return(
        <Router>
            <Routes>
                //Se utilizara un identiifcador para la ruta especifica de los artistas, albums y canciones
                <Route path="/" element={<FormLabel>Home</FormLabel>} />
                <Route path="/album" element={<AlbumScreen />} />
                <Route path="/artista" element={<ArtistaScreen />} />
                <Route path="/biblioteca" element={<BibliotecaScreen />} />
                <Route path="/cancion" element={<CancionScreen />} />
                <Route path="/biblioteca/favoritas" element={<FavoritasScreen />} />
                <Route path="/biblioteca/historial" element={<HistorialScreen />} />
                <Route path="/login" element={<LogInScreen />} />
                <Route path="/lyrics" element={<LyricsScreen />} />
                <Route path="/playlist" element={<PlaylistScreen />} />
                <Route path="/registro" element={<RegistroScreen />} />
                <Route path="/user" element={<UserScreen />} />
            </Routes>
        </Router>
    )
}

export default HomeScreen;