import { Component, OnInit } from '@angular/core';
import { Http, Request, RequestMethod, ResponseContentType, Response, RequestOptions, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { Page } from './page.model';
import { environment } from 'environments/environment';

@Component({
    selector: 'page-content',
    templateUrl: './page-content.component.html'
})

export class PageContentComponent implements OnInit {

  public _page : Page;
    
  constructor(private _http: Http, 
              private _router: Router,
              private _route: ActivatedRoute) {
    ;
  }

  ngOnInit() {
    let id: number = this._route.snapshot.params['id'];
    
    if (typeof id === "undefined" || isNaN(id)) {
      this._router.navigateByUrl('/');
    }
    else{
      this._http.get(environment.apiUrl + '/content/pages/' + id).subscribe(result => {
        this._page = result.json() as Page;
      });
    }
  }
}
