import { FormLabel } from "react-bootstrap";
import "./sidebar.css";
import SidebarButton from './sidebarButton';
import React, { useState } from 'react';

export default function Sidebar() {
    const [userLoggedIn, setUserLoggedIn] = useState(false);

    function handleLogin() {
        // Simulate a login action
        setUserLoggedIn(!userLoggedIn);
    }
    return(
        //Navigation bar
        <nav className='sidebar-container'>
            <ul>
                <li class="active">
                    <SidebarButton to="/"/>
                </li>
                <li>
                    <SidebarButton to="/busqueda"/>
                </li>
                <li>
                    <SidebarButton to="/biblioteca"/>
                </li>
                <li>
                    {userLoggedIn ? (<SidebarButton to="/user"/>) : (<SidebarButton to="/login"/>)}
                </li>
                <li>
                    {userLoggedIn ? (<SidebarButton to="/user"/>) : (<SidebarButton to="/login"/>)}
                </li>
            </ul>
        </nav>
    )
}