import { Component } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import { Event } from './event.model';
import { Router } from '@angular/router';

import { ConfirmDialogModule, ConfirmationService } from 'primeng/primeng';

import { environment } from 'environments/environment';

import { DragDropModule } from 'primeng/primeng';

@Component({
    providers: [ConfirmationService],
    selector: 'event-list',
    templateUrl: './event-list.component.html'
})
export class EventListComponent { 
    public events: Event[];



    constructor(private _confirmationService: ConfirmationService, private _http: Http, private _router: Router) {
        this.readEvents();
    }

    readEvents() {        
        this._http.get(environment.apiUrl + '/events').subscribe(result => {
            this.events = result.json() as Event[];
        });
    }
    
    newEvent() {
        this._router.navigateByUrl('/veranstaltungen/neu');
    }

    onDelete(id: number)
    {
        let headers = new Headers();
        headers.append('Access-Control-Allow-Origin', '*');
        let options = new RequestOptions({ headers: headers });

        this._http.delete(environment.apiUrl + '/events/' + id.toString(), options).subscribe(success => {
            this.readEvents();
        });
    }


    onRowSelect(event) {
        this._router.navigateByUrl('/veranstaltungen/' + event.data.eventId.toString());
    }

    confirm(eventId) {
        this._confirmationService.confirm({
            message: 'Möchten Sie diesen Datensatz wirklich löschen?',
            accept: () => {
                this.onDelete(eventId);
            }
        });
    }
}
