import { Component, OnInit } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import { Form } from './form.model';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'environments/environment';

@Component({
    providers: [],
    selector: 'form-test',
    templateUrl: './form-test.component.html'
})
export class FormTestComponent implements OnInit {
    
    private _formId : number;

    constructor(private _http: Http,
                private _router: Router,
                private _route: ActivatedRoute) {
        ;
    }

    ngOnInit() {
        this._formId = this._route.snapshot.params['id'];
    }
}
