import { Component } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import { Form } from './form.model';
import { Router } from '@angular/router';
import { ConfirmDialogModule, ConfirmationService } from 'primeng/primeng';
import { DragDropModule } from 'primeng/primeng';

import { environment } from 'environments/environment';
@Component({
    providers: [ConfirmationService],
    selector: 'form-list',
    templateUrl: './form-list.component.html'
})
export class FormListComponent {
    public forms: Form[];

    constructor(private _confirmationService: ConfirmationService, private _http: Http, private _router: Router) {
        this.readForms();
    }

    readForms() {
        this._http.get(environment.apiUrl + '/forms').subscribe(result => {
            this.forms = result.json() as Form[];
        });
    }

    newForm() {
        this._router.navigateByUrl('/form/neu');
    }

    onDelete(id: number)
    {
        let headers = new Headers();
        headers.append('Access-Control-Allow-Origin', '*');
        let options = new RequestOptions({ headers: headers });

        this._http.delete(environment.apiUrl + '/forms/' + id.toString(), options).subscribe(success => {
            this.readForms();
        });
    }

    onRowSelect(event) {
        this._router.navigateByUrl('/form/' + event.data.formId.toString());
    }

    confirm(formId) {
        this._confirmationService.confirm({
            message: 'Möchten Sie diesen Datensatz wirklich löschen?',
            accept: () => {
                this.onDelete(formId);
            }
        });
    }
}
