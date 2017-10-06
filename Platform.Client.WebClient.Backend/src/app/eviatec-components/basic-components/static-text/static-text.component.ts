import { Component, Input, ViewContainerRef, forwardRef, OnChanges } from '@angular/core';
import { ControlValueAccessor , NG_VALUE_ACCESSOR} from '@angular/forms';

@Component({
  selector: 'static-text',
  styleUrls: ['./static-text.component.scss'],
  templateUrl: './static-text.component.html',
  providers:[
    { provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => StaticTextComponent), multi: true }
  ]
})
export class StaticTextComponent implements ControlValueAccessor{

  private _value : string;
  //@Input('input-value') _value = '';


  propagateChange:any = () => {};
  validateFn:any = () => {};

  get Value()
  {
    return this._value;
  }

  set Value(value)
  {
    this._value = value;
    this.propagateChange(value);
  }

  writeValue(value) {
    if (value) {
      this._value = value;
    }
  }

  registerOnChange(fn) {
    this.propagateChange = fn;
  }

  registerOnTouched() {}
}
