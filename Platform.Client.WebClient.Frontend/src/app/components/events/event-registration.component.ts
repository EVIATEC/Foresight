import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { Validators } from '@angular/forms';

import { Event } from './event.model';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Registration } from './registration.model';
import { FieldConfig } from '../../dynamic-form/models/field-config.interface';
import { DynamicFormComponent } from '../../dynamic-form/containers/dynamic-form/dynamic-form.component';

import { environment } from 'environments/environment';
@Component({
    selector: 'event-registration',
    templateUrl: './event-registration.component.html'
})

export class EventRegistrationComponent implements AfterViewInit, OnInit {
    @ViewChild(DynamicFormComponent) form: DynamicFormComponent;

    private _eventId: number;
    private _event: Event;

    constructor(
        private _http: Http,
        private _router: Router,
        private _route: ActivatedRoute) {
        ;
    }

    ngOnInit() {

        // Veranstaltung laden
        this._eventId = this._route.snapshot.params['id']
        this.loadEvent(this._eventId);
    }

    loadEvent(id: number) {
        this._http.get(environment.apiUrl + '/events/' + id).subscribe(result => {
            this._event = result.json() as Event;
        });
    }

    config: FieldConfig[] = [
        {
            type: 'select',
            name: 'anrede',
            options: ['Herr', 'Frau'],
            validation: { required: true },
            display: {
                label: 'Anrede',
                placeholder: '<Anrede auswählen>'
            },
            api: {},
            conditional: {},
            layout: {}
        },
        {
            type: 'select',
            name: 'titel',
            options: ['Dr.', 'Dr. Dr.'],
            validation: { required: false },
            display: {
                label: 'Titel',
                placeholder: '<Titel auswählen>'
            },
            api: {},
            conditional: {},
            layout: {}
        },
        {
            type: 'input',
            name: 'vorname',
            validation: { required: true },
            display: {
                label: 'Vorname',
                placeholder: 'Bitte Vorname eingeben' },
            api: {},
            conditional: {},
            layout: {},
            data: { }
        },
        {
            type: 'input',
            name: 'nachname',
            validation: { required: true },
            display: {
                label: 'Nachname',
                placeholder: 'Bitte Nachname eingeben'
            },
            api: {},
            conditional: {},
            layout: {},
            data: { }
        },
        {
            type: 'input',
            name: 'strasse',
            validation: { required: false },
            display: {
                label: 'Straße',
                placeholder: 'Bitte Straße eingeben'
            },
            api: {},
            conditional: {},
            layout: {},
            data: {}
        },
        {
            type: 'input',
            name: 'postleitzahl',
            validation: { required: false },
            display: {
                label: 'Postleitzahl',
                placeholder: 'Bitte Postleitzahl eingeben'
            },
            api: {},
            conditional: {},
            layout: {},
            data: {}
        },
        {
            type: 'input',
            name: 'ort',
            validation: { required: false },
            display: {
                label: 'Ort',
                placeholder: 'Bitte Ort eingeben'
            },
            api: {},
            conditional: {},
            layout: {},
            data: {}
        },
        {
            type: 'input',
            name: 'eMail',
            validation: { required: true },
            display: {
                label: 'E-Mail',
                placeholder: 'Bitte E-Mail eingeben'
            },
            api: {},
            conditional: {},
            layout: {},
            data: {}
        },
        {
            name: 'submit',
            type: 'button',
            display: { label: 'Anmelden' },
            api: {},
            conditional: {},
            layout: {}
        }
    ];

    ngAfterViewInit() {
        /*
        let previousValid = this.form.valid;
        this.form.changes.subscribe(() => {
            if (this.form.valid !== previousValid) {
                previousValid = this.form.valid;
                this.form.setDisabled('submit', !previousValid);
            }
        });
        */
        this.form.setDisabled('submit', false);
    }

    submit(value: { [name: string]: any }) {

        if (!this.form.valid) {
            alert("Bitte füllen Sie alle Pflichtfelder aus");
            return false;
        }

        let registration = new Registration();
        registration.firstName = this.form.value.vorname;
        registration.lastName = this.form.value.nachname;
        registration.eventId = this._eventId;
        registration.registrationDate = new Date();
        registration.salutation = this.form.value.anrede;
        registration.title = this.form.value.titel;
        registration.street = this.form.value.strasse;
        registration.zipcode = this.form.value.postleitzahl;
        registration.city = this.form.value.ort;
        registration.eMail = this.form.value.eMail;

        let headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' });

        let body = JSON.stringify(registration);
        let options = new RequestOptions({ headers: headers });

        this._http.post(environment.apiUrl + '/eventregistrations/', body, options).subscribe(success => {
            this._router.navigateByUrl('/events/' + this._eventId.toString() + '/success');
        });

    }
}
