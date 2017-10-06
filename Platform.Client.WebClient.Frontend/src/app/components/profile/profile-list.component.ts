import { Component } from '@angular/core';
import { Http, Request, RequestMethod, ResponseContentType, Response, RequestOptions, Headers } from '@angular/http';
import { Profile } from './profile.model';
import { Router } from '@angular/router';
import { NgModule } from '@angular/core';
 
import { environment } from 'environments/environment';

@Component({
    selector: 'profile-list',
    templateUrl: './profile-list.component.html'
})

export class ProfileListComponent {

    public _profiles : Profile[];


    constructor(private _http: Http, private _router: Router) {
        this.readProfiles();
    }

    readProfiles() {
        this._http.get(environment.apiUrl + '/content/profiles').subscribe(result => {
            this._profiles = result.json() as Profile[];
        });
    }
}
