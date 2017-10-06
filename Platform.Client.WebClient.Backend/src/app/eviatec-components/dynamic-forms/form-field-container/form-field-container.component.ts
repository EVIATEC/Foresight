import { Component, OnInit, Input, ViewContainerRef, forwardRef, OnChanges, Output, EventEmitter, AfterViewInit , AfterContentInit } from '@angular/core';
import { ControlValueAccessor , NG_VALUE_ACCESSOR} from '@angular/forms';
import { Http, Response, RequestOptions, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { environment } from 'environments/environment';
import { Form } from 'app/components/form/form.model';

export enum DataMode {
    formService = 1,
    jsonString = 2
}

@Component({
    selector: 'form-field-container',
    templateUrl: './form-field-container.component.html',
    styleUrls: ['./form-field-container.component.scss'],
    providers:[
      { provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => FormFieldContainerComponent), multi: true }
    ]
 
})
export class FormFieldContainerComponent implements ControlValueAccessor{

 
    propagateChange:any = () => {};

    private _form;
    private _formFields = [];

    private _dataMode : DataMode = DataMode.formService;

    constructor(private _http: Http, private _router: Router) {
        ;
    }

    @Input('formId') _formId: number;

    ngOnInit() { 
        if (typeof this._formId !== "undefined")
        {
            this._http.get(environment.apiUrl + '/forms/' + this._formId.toString()).subscribe(result => {
                this._form = result.json() as Form;
                this._formFields = JSON.parse(this._form.formDefinition);
            });

            this._dataMode = DataMode.formService
        }
        else
        {
            this._dataMode = DataMode.jsonString;
        }
    }        
    
    get formFields()
    {
        return this._formFields;
    }
    set formFields(value)
    { 
        //this._form = value;
        this._formFields = value;
        this.propagateChange(value);
    }
    
    writeValue(value) {
        if (value) {
            this._formFields = value;
        }
    }

    registerOnChange(fn) {
        this.propagateChange = fn;
    }

    registerOnTouched() {}

    submit(form : any) {
        let headers = new Headers({ 'Content-Type': 'application/json; charset=utf-8' });

        var data = {};
        for (var i = 0; i < this._formFields.length; i++)
        {
            var apiField = this._formFields[i].api.propertyName;
            var value = this._formFields[i].data;

            // if there is no api-field than we can go to next field
            if (typeof apiField === "undefined"){
                continue;
            }

            data[apiField] = value;
        }

        let body = JSON.stringify(data);
        alert(body + "\n" + this._form.apiUrl);
        let options = new RequestOptions({ headers: headers });
        
        this._http.post(this._form.apiUrl, body, options).subscribe(success => {
            ;
        });
    }
}