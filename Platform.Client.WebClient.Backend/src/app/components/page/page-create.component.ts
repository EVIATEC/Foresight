import { Component, OnInit, ViewEncapsulation, ViewChild } from '@angular/core';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Page } from './page.model';
import { Router, ActivatedRoute } from '@angular/router';

import { environment } from 'environments/environment';

@Component({
  moduleId: module.id,
  selector: 'page-create',
  templateUrl: './page-create.component.html',
  styleUrls: ['page-create.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class PageCreateComponent implements OnInit {

  _page : Page;
  activeElement = [];
  _configuration;

  constructor(private _http: Http,
              private _router: Router,
              private _route: ActivatedRoute) {
    ;
  }

  deleteElement(model){
    this.configurationDelete(model);
  }

  ngOnInit() {
    let id: number = this._route.snapshot.params['id'];
    
    if (typeof id === "undefined")
    {
      this._page = new Page();
    }
    else
    {
      this._http.get(environment.apiUrl + '/content/pages/' + id).subscribe(result => {
        this._page = result.json() as Page;
        this.targetBuilderTools = JSON.parse(this._page.pageElements);
      });

    }
  }

  // { name: 'Section', children: [], inputType: 'section', icon: 'section', class: 'wide' },

  saveForm()
  {

    this._page.pageElements = JSON.stringify(this.targetBuilderTools);

    let headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' });

    let body = JSON.stringify(this._page);
    let options = new RequestOptions({ headers: headers });

    if (this._page.pageId) {
      this._http.put(environment.apiUrl + '/content/pages/' + this._page.pageId.toString(), body, options).subscribe(success => {
        ;
      });
    }
    else {
      this._http.post(environment.apiUrl + '/content/pages/', body, options).subscribe(success => {
        this._router.navigateByUrl('/page');
      });
    }
  }

  displayDialog: boolean;

  sourceBuilderTools = [
    { name: 'Formular', inputType: 'input-text', icon: 'field-text', class: 'half', config: [], display:[] },
    { name: 'Statischer Text', inputType: 'static-text', icon: 'field-text', class: 'half', display:[] },
    { name: '2 Spaltig', columnLeft:[], columnRight:[], inputType: 'evia-two-column', icon: 'field-numeric', class: 'half', display:[] }
  ];
  targetBuilderTools =[
  ];
    //[];

  droppableItemClass = item => `${item.class} ${item.inputType}`;

  fieldDeleted()  {
    this.displayDialog = false;
  }

  builderDrag(e) {
    const item = e.value;
    item.data = item.inputType === 'number' ?
      (Math.random() * 100) | 0 :
      Math.random().toString(36).substring(20);
  }

  elementDrop(e)   {
    this.log(e);
    this.activeElement = e.value;

    if (typeof this.activeElement["index"] === "undefined"){
      this.activeElement["index"] = 0;
    }

    if (this.activeElement["index"] == 0) {
      let maxIndex = Math.max.apply(Math, this.targetBuilderTools.map(function(o){return o.index;})) ;
      this.activeElement["index"] = parseInt(maxIndex) + 1;
    }
    else
    {
      return;
    }

    this.displayDialog = true;
  }

  log(e) {
    console.log(e.type, e);
 }

  configureElement(model){
    this.activeElement = model;
    this.displayDialog = true;
  }

  configurationDelete(model){
    this.targetBuilderTools = this.targetBuilderTools.filter(function (data) { return data.index != model.index});
    this.displayDialog = false;
  }

  configurationAfterSave(model){
    this.displayDialog = false;
  }
}


class textboxConfiguration
{
  public displayLabel: string;
  public displayPlaceholder: string;
  public displayPrefix: string;
  public displaySuffix: string;

  public validationRequired : boolean;
  public validationMinimumLength : number;
  public validationMaximumLength : number;
  public validationRegexPattern : string;

  public apiPropertyName:string;
}

