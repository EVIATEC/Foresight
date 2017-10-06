import { Component } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import { Page } from './page.model';
import { Router } from '@angular/router';
import { ConfirmDialogModule, ConfirmationService } from 'primeng/primeng';
import { DragDropModule } from 'primeng/primeng';

import { environment } from 'environments/environment';
@Component({
    providers: [ConfirmationService],
    selector: 'page-list',
    templateUrl: './page-list.component.html'
})
export class PageListComponent {
    public _pages: Page[];

    constructor(private _confirmationService: ConfirmationService, private _http: Http, private _router: Router) {
        this.readPages();
    }

    readPages() {
        this._http.get(environment.apiUrl + '/content/pages').subscribe(result => {
            this._pages = result.json() as Page[];
        });
    }

    newPage() {
        this._router.navigateByUrl('/page/neu');
    }

    onDelete(id: number)
    {
        let headers = new Headers();
        headers.append('Access-Control-Allow-Origin', '*');
        let options = new RequestOptions({ headers: headers });

        this._http.delete(environment.apiUrl + '/content/pages/' + id.toString(), options).subscribe(success => {
            this.readPages();
        });
    }


    onRowSelect(event) {
        this._router.navigateByUrl('/page/' + event.data.pageId.toString());
    }

    confirm(pageId) {
        this._confirmationService.confirm({
            message: 'Möchten Sie diesen Datensatz wirklich löschen?',
            accept: () => {
                this.onDelete(pageId);
            }
        });
    }
}
