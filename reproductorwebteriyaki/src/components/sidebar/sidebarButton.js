import React from "react";
import { Link } from "react-router-dom";
import { FormLabel } from "react-bootstrap";

export default function SidebarButton(props){
    return(
        <Link to={props.to}>
            <FormLabel>Text</FormLabel>
        </Link>
    )
}