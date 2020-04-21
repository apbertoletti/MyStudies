import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class BarService {
    constructor(private http: HttpClient) { }
 
    getDrink(): string{
        return 'Bebidas';
    }

    getFood(): string{
        return 'Comidas';
    }
    
    getSweet(): string{
        return 'Doces';
    }
}