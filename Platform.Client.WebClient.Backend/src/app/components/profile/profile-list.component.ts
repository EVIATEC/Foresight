import { Component } from '@angular/core';
import { Http, Request, RequestMethod, Response, RequestOptions, Headers } from '@angular/http';
import { Profile } from './profile.model';
import { Router } from '@angular/router';
import { ConfirmDialogModule, ConfirmationService } from 'primeng/primeng';
import { DragDropModule } from 'primeng/primeng';
import { environment } from 'environments/environment';

@Component({
    providers: [ConfirmationService],
    selector: 'profile-list',
    templateUrl: './profile-list.component.html'
})
export class ProfileListComponent {
    public _profiles : Profile[];

    constructor(private _confirmationService: ConfirmationService, private _http: Http, private _router: Router) {
        this.readProfiles();
    }

    readProfiles() {
        this._http.get(environment.apiUrl + '/content/profiles').subscribe(result => {
            this._profiles = result.json() as Profile[];
        });
    }

    newProfile() {
        this._router.navigateByUrl('/profil/neu');
    }

    onDelete(id: number)
    {
        let headers = new Headers();
        headers.append('Access-Control-Allow-Origin', '*');
        let options = new RequestOptions({ headers: headers });

        this._http.delete(environment.apiUrl + '/content/profiles/' + id.toString(), options).subscribe(success => {
            this.readProfiles();
        });
    }


    onRowSelect(event) {
        this._router.navigateByUrl('/profil/' + event.data.profileId.toString());
    }

    confirm(profileId) {
        this._confirmationService.confirm({
            message: 'Möchten Sie diesen Datensatz wirklich löschen?',
            accept: () => {
                this.onDelete(profileId);
            }
        });
    }
}
