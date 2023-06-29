import { Token } from "../models/Login";

export class localStorageService {

    setToken(token:Token){
        window.localStorage.setItem('token', JSON.stringify(token));
    }

    getToken(): Token
    {
        return JSON.parse( window.localStorage.getItem('token'));
    }
}