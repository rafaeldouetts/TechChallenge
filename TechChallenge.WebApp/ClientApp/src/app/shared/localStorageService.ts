import { Token } from "../models/Login";

export class localStorageService {

    setToken(token:Token){
        window.localStorage.setItem('token', JSON.stringify(token));
    }

    getToken() : Token
    {
        var token = window.localStorage.getItem('token');

        return JSON.parse(token);
    }
}