export class localStorageService {

    setToken(token:string){
        window.localStorage.setItem('token', token);
    }
}