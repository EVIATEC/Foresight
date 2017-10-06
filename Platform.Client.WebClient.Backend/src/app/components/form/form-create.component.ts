import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core'; 
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Form } from './form.model';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'environments/environment';

@Component({
  moduleId: module.id,
  selector: 'form-create',
  templateUrl: './form-create.component.html',
  styleUrls: ['form-create.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class FormCreateComponent implements OnInit {

  private _form : Form;
  private _formDefinition = [];

  constructor(private _http: Http,
              private _router: Router,
              private _route: ActivatedRoute) {
    ;
  }

  ngOnInit() {
    let id: number = this._route.snapshot.params['id'];
    if (typeof id === "undefined")
    {
      this._form = new Form();
    }
    else
    {
      this._http.get(environment.apiUrl + '/forms/' + id).subscribe(result => {
        this._form = result.json() as Form;
        this._formDefinition = JSON.parse(this._form.formDefinition);
      });
    }
  }

  // { name: 'Section', children: [], inputType: 'section', icon: 'section', class: 'wide' },

  saveForm()
  {
    this._form.formDefinition = JSON.stringify(this._formDefinition);

    let headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' });

    let body = JSON.stringify(this._form);
    let options = new RequestOptions({ headers: headers });

    if (this._form.formId) {
      this._http.put(environment.apiUrl + '/forms/' + this._form.formId.toString(), body, options).subscribe(success => {
        ;
      });
    }
    else {
      this._http.post(environment.apiUrl + '/forms/', body, options).subscribe(success => {
        this._router.navigateByUrl('/form');
      });
    }
  }

}