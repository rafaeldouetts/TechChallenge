
export class Token {
    token:string;
    validTo:Date;
    nome:string;
}

export class ResponseModel {
    success: boolean;
    message:string;
    data:any;
}


export class ResponseTokenModel {
    success: boolean;
    message:string;
    data:Token;
}