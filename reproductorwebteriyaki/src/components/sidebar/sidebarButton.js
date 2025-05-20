import React from "react";
import { IconContext } from "react-icons";
import { Link, useLocation } from "react-router-dom";
import { FormLabel } from "react-bootstrap";
import "./sidebarButton.css";

export default function SidebarButton(props){
    const location = useLocation();
    const isActive = location.pathname === props.to;
    const btnClass = isActive ? "sidebar-button active" : "sidebar-button";
    return(
        <Link to={props.to}>
            <div className={btnClass}>
                <IconContext.Provider value={{size: '100%', className:"sidebar-Icon"}}>
                    {props.icon}
                    <FormLabel className="sidebar-text">{props.Text}</FormLabel>
                </IconContext.Provider>
            </div>
        </Link>
    )
}