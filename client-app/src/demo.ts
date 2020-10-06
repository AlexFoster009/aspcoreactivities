let data = 42; 

export interface ICar {
    color: string;
    model: string;
    topSpeed: number;
}

const Car: ICar = {
    color: "red",
    model: "BMW",
    topSpeed: 300
}

const  Car2: ICar = {
    color: "Blue",
    model: "Audi",
    topSpeed: 230
}

const multiply = (x: number, y: number) => {
    return x * y;
}

export const cars = [Car, Car2];