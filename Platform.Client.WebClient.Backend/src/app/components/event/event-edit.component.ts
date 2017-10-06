import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Event } from './event.model';
import { Download } from './download.model';
import { Registration } from './registration.model';
import { Router, ActivatedRoute } from '@angular/router';
import { MenuItem } from 'primeng/primeng';
import { CalendarModule } from 'primeng/primeng';
import { ConfirmDialogModule, ConfirmationService } from 'primeng/primeng';

import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';


import { environment } from 'environments/environment';
import {  DropzoneModule, DropzoneConfigInterface } from 'ngx-dropzone-wrapper';


@Component({
    providers: [ConfirmationService],
    selector: 'event-edit',
    templateUrl: './event-edit.component.html'
})
export class EventEditComponent implements OnInit {

    de: any;

    value: Date;

    event: Event;

    private breadItems: MenuItem[];

    private registration: Registration;

    config: DropzoneConfigInterface;

    displayDialog: boolean;

    registrations: Registration[];

    downloads: Download[];

    constructor(private _http: Http,
        private _router: Router,
        private _route: ActivatedRoute,
        private _confirmationService: ConfirmationService) {
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

        // Veranstaltung laden
        let id: number = this._route.snapshot.params['id']
        this.loadEvent(id);

            
        this.config = {
            "url": environment.apiUrl + '/Events/' + id.toString() + '/Downloads',
            "maxFilesize": 50
        };

        // Breadcrump-Navigation
        this.breadItems = [];
        this.breadItems.push({ label: 'Veranstaltungen' });

    }

    myDate : Date =  new Date(2017, 4, 18,10,10);

    loadEvent(id: number)
    {
        this._http.get(environment.apiUrl +'/events/' + id).subscribe(result => {
            this.event = result.json() as Event;
            this.event.eventDate = new Date(this.event.eventDate);

        });

        this._http.get(environment.apiUrl + '/events/' + id + '/registrations').subscribe(result => {
            this.registrations = result.json() as Registration[];
        });

        this.getDownloads(id);
    }

    getDownloads(eventId :number) {

        this._http.get(environment.apiUrl +'/events/' + eventId + '/downloads').subscribe(result => {
            this.downloads = result.json() as Download[];
        });
    }

    submit() {
        let headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' });

        let body = JSON.stringify(this.event);
        let options = new RequestOptions({ headers: headers });

        this._http.put(environment.apiUrl +'/events/' + this.event.eventId, body, options).subscribe(success => {
            this._router.navigateByUrl('/veranstaltungen');
        });
    }

    onRowSelect(event) {
        this.registration = this.cloneObject(event.data);
        this.displayDialog = true;

    }

    cloneObject(registration: Registration): Registration {
        let newRegistration = new Registration();
        for (let prop in registration ) {
            newRegistration[prop] = registration[prop];
        }
        return newRegistration;
    }

    onUploadSuccess(event) {
        this.getDownloads(this.event.eventId);

    }
    onUploadError(event) {
        alert("Upload failed");
    }


    confirm(downloadId) {

        this._confirmationService.confirm({
            message: 'Möchten Sie diesen Datensatz wirklich löschen?',
            accept: () => {
                this.onDelete(downloadId);
            }
        });
    }

    onDelete(id: number) {
        let headers = new Headers();
        headers.append('Access-Control-Allow-Origin', '*');
        let options = new RequestOptions({ headers: headers });

        this._http.delete(environment.apiUrl + '/EventDownloads/' + id.toString(), options).subscribe(success => {
            this.getDownloads(this.event.eventId);
        });
    }


}
