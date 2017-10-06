import { Component } from '@angular/core';
import { Http, Request, RequestMethod, ResponseContentType, Response, RequestOptions, Headers } from '@angular/http';
import { Event } from './event.model';
import { Download } from './download.model';
import { Router } from '@angular/router';
import { NgModule } from '@angular/core';

import { environment } from 'environments/environment';
import * as FileSaver from 'file-saver';

@Component({
    selector: 'event-list',
    templateUrl: './event-list.component.html'
})

export class EventListComponent {

    public events: Event[];
    public downloads: Download[];

    selectedEvent: Event;

    constructor(private _http: Http, private _router: Router) {
        this.readEvents();
    }

    readEvents() {
        this._http.get(environment.apiUrl + '/events').subscribe(result => {
            this.events = result.json() as Event[];
        });
    }

    readDownload(event)
    {
        this._http.get(environment.apiUrl + '/events/' + event.data.eventId.toString() + '/downloads').subscribe(result => {
            this.downloads = result.json() as Download[];
        });
    }

    register(id) {
        this._router.navigateByUrl('/events/' + id);
    }

    replaceLineBreak(s: string) {
      return s;
        //return s.replace(/\n/g, '<br/>')
    }

    downloadFile(download: Download) {
        this._http.get(environment.apiUrl + '/EventDownloads/' + download.downloadId.toString() + '/file', { responseType: ResponseContentType.Blob })
            .subscribe((response: any) => {
                var fileName = download.name;
                if (download.fileExtension) {
                    fileName += '.' + download.fileExtension;
                }

                FileSaver.saveAs(response.blob(), fileName);
            });

    }
}
