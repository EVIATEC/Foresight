import { Component, OnInit, Input, ViewContainerRef, forwardRef, OnChanges, Output, EventEmitter, AfterViewInit , AfterContentInit } from '@angular/core';
import { ControlValueAccessor , NG_VALUE_ACCESSOR} from '@angular/forms';

@Component({
    selector: 'form-field',
    templateUrl: './form-field.component.html',
    styleUrls: ['./form-field.component.scss'],
    providers:[
    { 
      provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() =>  FormFieldComponent), multi: true }
  ]
 
})
export class FormFieldComponent implements ControlValueAccessor{

  private _fieldModel;

  
  activeElement = [];

  displayDialog: boolean;

  @Input('config') _config = [];

  set config (value)
  {
    this._config = value;
    this.propagateChange(value);
  }  

  propagateChange:any = () => {};

  writeValue(value) {
    if (value) {
      ;//this._fieldModel = value;
    }
  }
  
  set fieldModel(value)
  {
    this._fieldModel = value;
    this.propagateChange(value);
  }

  registerOnChange(fn) {
    this.propagateChange = fn;
  }
  
  registerOnTouched() {}

}