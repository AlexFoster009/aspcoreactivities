import React from "react";
import {ICar} from "./demo";

// Specifiy an interface telling us this component will
// be using an ICar inside its properties.

interface IProps {
    car: ICar,
    
}

const CarItem: React.FC<IProps> = ({car}) => {
    return (
        <div>
            <h1>{car.color}</h1>
        </div>
    )
}

export default CarItem;