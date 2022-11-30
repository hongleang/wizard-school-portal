export interface HouseOption {
    id: number;
    name: string;
};

export interface RegisterHouse {
    id: number;
    name: string;
    value: string;
    motto: string;
    logoUrl: string;
    founderId: number;
}

export interface Characters {
    gender: string;
    houseName: string;
    imageUrl: string;
    name: string;
}

export interface HouseResponse {
    id: number;
    name: string;
    value: string;
    motto: string;
    logoUrl: string;
    founderName: string;
    characters: Characters[]
}