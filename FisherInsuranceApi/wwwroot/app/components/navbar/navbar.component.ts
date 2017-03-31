import { Component } from '@angular/core';
import { Routes, RouterModule } from "@angular/router";
import { AuthService } from "../../auth.service";
//import { Router } from "../../app.routing";
@Component({
    selector: 'nav-bar',
    templateUrl: './app/components/navbar/navbar.component.html',
    styleUrls: ['./app/components/navbar/navbar.component.css']
})
export class NavBarComponent {
    constructor(public router: Routes, public authService: AuthService) { }
    isActive(data: any[]): boolean {
        return this.router.isActive(
            this.router.createUrlTree(data),
            true);
    }
    logout(): boolean {
        // logs out the user, then redirects him to Welcome View.
        if (this.authService.logout()) {
            this.router.navigate([""]);
        }
        return false;
    }

} 
