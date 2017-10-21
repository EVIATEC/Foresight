import { Component } from '@angular/core';
import { Http, Request, RequestMethod, ResponseContentType, Response, RequestOptions, Headers } from '@angular/http';
import { Improvement } from './improvement.model';
import { Router, ActivatedRoute } from '@angular/router';
import { NgModule } from '@angular/core';
import { NgForm } from '@angular/forms';
 
import { environment } from 'environments/environment';

@Component({
    selector: 'improvement',
    templateUrl: './improvement.component.html'
})

export class ImprovementComponent {

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

        //ToDo: Upload Dateien geht noch nicht!

        this._http.post(environment.apiUrl + '/content/improvementproposals/', body, options).subscribe(success => {
            this._router.navigateByUrl('/improvement/success');
        });

        console.log("Form submitted");
    }
}
