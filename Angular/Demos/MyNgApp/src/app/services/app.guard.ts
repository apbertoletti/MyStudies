import { Injectable } from "@angular/core";
import { CanLoad, CanActivate } from '@angular/router';

@Injectable()
export class AuthGuard implements CanLoad, CanActivate {
    
    user = { admin: false, logged: true }

    canLoad() : boolean {
        return this.user.admin;
    }
    
    canActivate() : boolean {
        return this.user.logged;
    }
}