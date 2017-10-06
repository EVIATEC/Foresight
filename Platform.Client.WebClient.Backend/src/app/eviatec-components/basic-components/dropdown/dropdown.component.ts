import { Component, Input, ViewContainerRef, forwardRef, OnChanges } from '@angular/core';
import { ControlValueAccessor , NG_VALUE_ACCESSOR} from '@angular/forms';

@Component({
  selector: 'dropdown',
  styleUrls: ['./dropdown.component.scss'],
  templateUrl: './dropdown.component.html',
  providers:[
    { provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => DropdownComponent), multi: true }
  ]
})
export class DropdownComponent implements ControlValueAccessor, OnChanges{

  private _controlValue = '';
  private _config : any;
  

  @Input('config') set config(value){
    this._config = value; 
  }
  get config(){
    return this._config;
  }
  
  propagateChange:any = () => {};
  validateFn:any = () => {};

  get dropdownOptions ()
  {
    var options = this.config.display.values;
    if (typeof options === "undefined"){
      return [];
    }
    return options.split('|');
  }

  get controlValue()
  {
    return this._controlValue;
  }
  set controlValue(value)
  {
    this._controlValue = value;
  }

  writeValue(value) {
    if (value) {
      this._controlValue = value;
    }

  }

  registerOnChange(fn) {
    this.propagateChange = fn;
  }

  registerOnTouched() {}

  ngOnChanges(inputs) {
   ;
  }

}
