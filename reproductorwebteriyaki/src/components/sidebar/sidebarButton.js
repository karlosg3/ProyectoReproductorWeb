import React from "react";
import { IconContext } from "react-icons";
import { Link } from "react-router-dom";
import { FormLabel } from "react-bootstrap";
import "./sidebarButton.css";

export default function SidebarButton(props){
    return(
        <Link to={props.to}>
            <div className="sidebar-button">
                <IconContext.Provider value={{size: '100%', className:"sidebar-Icon"}}>
                    {props.icon}
                    <FormLabel className="sidebar-text">{props.Text}</FormLabel>
                </IconContext.Provider>
            </div>
        </Link>
    )
}