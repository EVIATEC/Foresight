import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';

import { Validators, FormControl, FormGroup, FormBuilder, NgForm } from '@angular/forms';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Event } from './event.model';
import { Router } from '@angular/router';

import { CalendarModule, Editor } from 'primeng/primeng';

import { environment } from 'environments/environment';


@Component({
    selector: 'event-create',
    templateUrl: './event-create.component.html'
})
export class EventCreateComponent implements OnInit, AfterViewInit {
    de: any;


    value: Date;

    event: Event;

    constructor(private _http: Http, private _router: Router) {
        ;
    }

    @ViewChild(Editor) editorComponent: Editor;

    private quill: any;
  
    ngAfterViewInit()
    {
        this.quill = this.editorComponent.quill;
        
        var toolbar = this.quill.getModule('toolbar');
       
    }

    ngOnInit() {


        this.de = {
            firstDayOfWeek: 1,
            dayNames: ["Sonntag", "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag", "Samstag"],
            dayNamesShort: ["Son", "Mon", "Die", "Mit", "Don", "Fre", "Sam"],
            dayNamesMin: ["So", "Mo", "Di", "Mi", "Do", "Fr", "Sa"],
            monthNames: ["Januar", "Februar", "März", "April", "Mai", "Juni", "Juli", "August", "September", "Oktober", "November", "Dezember"],
            monthNamesShort: ["Jan", "Feb", "Mär", "Apr", "Mai", "Jun", "Jul", "Aug", "Sep", "Okt", "Nov", "Dez"]
        }
        this.event = new Event();
    }
  
    submit(form : any) {
        let headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' });

        let body = JSON.stringify(this.event);
        let options = new RequestOptions({ headers: headers });
        
        this._http.post(environment.apiUrl + '/events/', body, options).subscribe(success => {
            this._router.navigateByUrl('/veranstaltungen');
        });
    }
}