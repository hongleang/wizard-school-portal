export interface User {
    name: string;
    token: string;
}

export interface UserRegisteration {
    firstName : string;
    lastName : string;
    username: string;
    email: string;
    gender: string;
    password: string;
    dateOfBirth: Date;
    houseId: Number;
}

export interface UserDetails  {
    firstName: string;
    lastName: string;
    username: string;
    houseId: Number;
    species: string;
    gender: string;
}