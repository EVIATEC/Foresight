import { Component, Input, ViewContainerRef, forwardRef, OnChanges } from '@angular/core';
import { ControlValueAccessor , NG_VALUE_ACCESSOR} from '@angular/forms';

@Component({
  selector: 'input-text',
  styleUrls: ['./input-text.component.scss'],
  templateUrl: './input-text.component.html',
  providers:[
    { provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => InputTextComponent), multi: true }
  ]
})
export class InputTextComponent implements ControlValueAccessor{

  private _controlValue;
  //@Input('input-text') _controlValue = '';

  @Input('placeholder') _placeholder: string;
  @Input('label') _label: string;
  @Input('suffix') _suffix: string;
  @Input('prefix') _prefix: string;

  propagateChange:any = () => {};
  validateFn:any = () => {};

  get prefix(){
    return this._prefix;
  }
  set prefix(value) {
    this._prefix = value;
  }

  get suffix() {
    return this._suffix;
  }
  set suffix(value){
    this._suffix = value;
  }

  get label(){
    return this._label;
  }
  set label(value){
    this._label = value;
  }

  get placeholder()
  {
    return this._placeholder;
  }
  set placeholder(value)
  {
    this._placeholder = value;
  }

  get textboxValue()
  {
    return this._controlValue;
  }

  set textboxValue(value)
  {
    this._controlValue = value;
    this.propagateChange(value);
  }

  private onChange(event){
    this.propagateChange(this.textboxValue);
  }

  /**
   * Write a new value to the element.
   */
  writeValue(value: any) {
    if (value) {
      this.textboxValue = value;
    }
  }

  /**
   * Set the function to be called 
   * when the control receives a change event.
   */
  registerOnChange(fn: any) {
    this.propagateChange = fn;
  }

  /**
   * Set the function to be called 
   * when the control receives a touch event.
   */
  registerOnTouched(fn: any) {}
}
