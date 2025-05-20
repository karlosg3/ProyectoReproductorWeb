import { Form, FormLabel } from "react-bootstrap";
import "./sidebar.css";
import SidebarButton from './sidebarButton';
import React, { useState } from 'react';
import { RiHomeLine } from 'react-icons/ri';
import { RiSearch2Line } from "react-icons/ri";
import { RiDashboardHorizontalLine } from "react-icons/ri";
import { RiUser3Line } from "react-icons/ri";
import { RiLoginCircleLine } from "react-icons/ri";
import { RiLogoutCircleLine } from "react-icons/ri";

export default function Sidebar() {
    const [userLoggedIn, setUserLoggedIn] = useState(false);

    function handleLogin() {
        // Simulate a login action
        setUserLoggedIn(!userLoggedIn);
    }
    return(
        //Navigation bar
        <nav className='sidebar-container'>
            <FormLabel className="sidebar-logo">Logotype</FormLabel>
            <ul className="sidebar-top">
                <li class="active">
                    <SidebarButton Text="HOME" to="/" icon={<RiHomeLine />}/>
                </li>
                <li>
                    <SidebarButton Text="SEARCH" to="/busqueda" icon={<RiSearch2Line />}/>
                </li>
                <li>
                    <SidebarButton Text="LIBRARY" to="/biblioteca" icon={<RiDashboardHorizontalLine />}/>
                </li>
                <li>
                    {userLoggedIn ? (<SidebarButton Text="PROFILE" to="/user" icon={<RiUser3Line />}/>) : (<SidebarButton Text="LOG IN" to="/login" icon={<RiLoginCircleLine />}/>)}
                </li>
            </ul>
            <ul className="sidebar-bottom">
                <li>
                    {userLoggedIn ? (<SidebarButton Text="LOG OUT" icon={<RiLogoutCircleLine />} onClick={handleLogin}/>) : (<FormLabel/>)}
                </li>
            </ul>
        </nav>
    )
}