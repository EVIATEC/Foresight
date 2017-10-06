import { Component, Input, ViewContainerRef, forwardRef, OnChanges } from '@angular/core';
import { ControlValueAccessor , NG_VALUE_ACCESSOR} from '@angular/forms';

@Component({
  selector: 'input-password',
  styleUrls: ['./input-password.component.scss'],
  templateUrl: './input-password.component.html',
  providers:[
    { provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => InputPasswordComponent), multi: true }
  ]
})
export class InputPasswordComponent implements ControlValueAccessor{

  private _textboxValue;
  //@Input('input-text') _textboxValue = '';

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
    return this._textboxValue;
  }

  set textboxValue(value)
  {
    this._textboxValue = value;
    this.propagateChange(value);
  }

  writeValue(value) {
    if (value) {
      this.textboxValue = value;
    }
  }

  registerOnChange(fn) {
    this.propagateChange = fn;
  }

  registerOnTouched() {}
}
