import { Component, Input } from '@angular/core';


@Component({
  selector: 'evia-button',
  styleUrls: ['./button.component.scss'],
  templateUrl: './button.component.html'
})
export class ButtonComponent {

  @Input('label') _label: string;

  set lable (value){
    this._label = value;
  }

  get label()  {
    return this._label;
  }
}
