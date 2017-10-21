import { Component } from '@angular/core';
import { Http, Request, RequestMethod, ResponseContentType, Response, RequestOptions, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { NgModule } from '@angular/core';
import { NgForm } from '@angular/forms';
 
import { environment } from 'environments/environment';

@Component({
    selector: 'staffcouncil',
    templateUrl: './staffcouncil.component.html'
})

export class StaffCouncilComponent {

    constructor(
        private _http: Http,
        private _router: Router,
        private _route: ActivatedRoute) {
        ;
    }
    onSubmit(form: NgForm) {

        console.log("Start submitting");        

        console.log(form.value);        

        let headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' });

        let body = JSON.stringify(form.value);
        let options = new RequestOptions({ headers: headers });

        this._http.post(environment.apiUrl + '/content/staffcouncil/', body, options).subscribe(success => {
            this._router.navigateByUrl('/staffcouncil/success');
        });

        console.log("Form submitted");
    }
}