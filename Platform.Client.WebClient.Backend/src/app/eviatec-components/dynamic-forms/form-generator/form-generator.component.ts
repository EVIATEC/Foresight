import { Component, OnInit, Input, ViewContainerRef, forwardRef, OnChanges, Output, EventEmitter, AfterViewInit , AfterContentInit } from '@angular/core';
import { ControlValueAccessor , NG_VALUE_ACCESSOR} from '@angular/forms';

@Component({
    selector: 'form-generator',
    templateUrl: './form-generator.component.html',
    styleUrls: ['./form-generator.component.scss'],
    providers:[
    { provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() => FormGeneratorComponent), multi: true }
  ]
 
})
export class FormGeneratorComponent implements ControlValueAccessor{

  propagateChange:any = () => {};

  activeElement = [];
  _configuration;

  displayDialog: boolean;

  sourceBuilderTools = [
    { name: 'Text Field', inputType: 'input-text', icon: 'field-text', class: 'half', config: [], display:[] },
    { name: 'Number', inputType: 'number', icon: 'field-text', class: 'half', display:[] },
    { name: 'Password', inputType: 'input-password', icon: 'field-numeric', class: 'half', display:[] },
    { name: 'Text Area', inputType: 'number', icon: 'field-numeric', class: 'half', display:[] },
    { name: 'Check Box', inputType: 'number', icon: 'field-numeric', class: 'half', display:[] },
    { name: 'Dropdown', inputType: 'dropdown', icon: 'field-numeric', class: 'half', display:[] },
    { name: 'Select', inputType: 'number', icon: 'field-numeric', class: 'half', display:[] },
    { name: 'Radio', inputType: 'number', icon: 'field-numeric', class: 'half', display:[] },
    { name: 'Button', inputType: 'button', icon: 'field-numeric', class: 'half', display:[] },
    { name: '2 Spaltig', columnLeft:[], columnRight:[], inputType: 'evia-two-column', icon: 'field-numeric', class: 'half', display:[] }
  ];
  
  private _targetBuilderTools = [];

  get targetBuilderTools()
  {
    return this._targetBuilderTools;
  }
  set targetBuilderTools(value)
  {
      this._targetBuilderTools = value;
      this.propagateChange(value);
  }

  @Input('editMode') _editMode : boolean = false;

  writeValue(value) {
    if (value) {
      this.targetBuilderTools = value;
    }
  }
  
  registerOnChange(fn) {
    this.propagateChange = fn;
  }
  
  registerOnTouched() {}


  deleteElement(model){
    this.configurationDelete(model);
  }

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
    //alert(JSON.stringify(e.value));
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