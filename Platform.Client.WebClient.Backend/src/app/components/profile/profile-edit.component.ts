import { Component, OnInit } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Profile } from './profile.model';
import { Router, ActivatedRoute } from '@angular/router';

import { environment } from 'environments/environment';

@Component({
  moduleId: module.id,
  selector: 'profile-edit',
  templateUrl: './profile-edit.component.html',
  styleUrls: ['profile-edit.component.scss']
})
export class ProfileEditComponent implements OnInit {
  _profile : Profile;

  constructor(private _http: Http, 
              private _router: Router,
              private _route: ActivatedRoute) {
    ;
  }
  
  ngOnInit() {
    let id: number = this._route.snapshot.params['id'];
    if (typeof id === "undefined") {
      this._profile = new Profile();
    }
    else{
      this._http.get(environment.apiUrl + '/content/profiles/' + id).subscribe(result => {
        this._profile = result.json() as Profile;
      });
    }
  }

  submit(form : any) {
    let headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' });

    let body = JSON.stringify(this._profile);
    let options = new RequestOptions({ headers: headers });
    
    
    if (this._profile.profileId) {
      this._http.put(environment.apiUrl + '/content/profiles/' + this._profile.profileId.toString(), body, options).subscribe(success => {
        this._router.navigateByUrl('/profil');
      });
    }
    else {
      this._http.post(environment.apiUrl + '/content/profiles/', body, options).subscribe(success => {
        this._router.navigateByUrl('/profil');
      });
    }
  }
}

 

