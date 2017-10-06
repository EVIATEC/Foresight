import { Component, OnInit, Input, ViewContainerRef, forwardRef, OnChanges, Output, EventEmitter, AfterViewInit , AfterContentInit } from '@angular/core';
import { ControlValueAccessor , NG_VALUE_ACCESSOR} from '@angular/forms';
import { InputTextDefinition } from './definitions/input-text-definition';
import { InputNumberDefinition } from './definitions/input-number-definition';
import { ButtonDefinition } from './definitions/button-definition';
import { InputPasswordDefinition  } from './definitions/input-password-definition';
import { InputDropdownDefinition } from './definitions/input-dropdown-definition'

@Component({
    selector: 'form-field-configuration',
    templateUrl: './form-field-configuration.component.html',
    styleUrls: ['./form-field-configuration.component.scss'],
  providers:[
    { provide: NG_VALUE_ACCESSOR, useExisting: forwardRef(() =>  FormFieldConfigurationComponent), multi: true }
  ]
})
export class FormFieldConfigurationComponent implements ControlValueAccessor, OnChanges{
  _configuration = new textboxConfiguration();


  private _formFields = {};

  private _formFieldsDisplay = null;
  private _formFieldsValidation = null;
  private _formFieldsApi = null;

  @Input('viewConfiguration') _viewConfiguration;
  @Output() delete = new EventEmitter<any>();
  @Output() afterSave = new EventEmitter<any>();

  /*
  get viewConfiguration () {
    return this._viewConfiguration;
  }*/

  set viewConfiguration(value)  { 
    this._viewConfiguration = value;
    this.loadConfiguration();
  }

  private _activeElement;
  get activeElement(){
    return this._activeElement;
  }
  set activeElement(value) { 
    this._activeElement = value;
    
  }

  propagateChange:any = () => {};
  validateFn:any = () => {};


  writeValue(value) {
    if (value) {
      // reset fields configuration
      this._formFieldsDisplay = null;
      this._formFieldsValidation = null;
      this._formFieldsApi = null;

      this._activeElement = value;
      
      this.loadConfiguration();
    }
  }

  registerOnChange(fn) {
    this.propagateChange = fn;
  }

  registerOnTouched() {}

  ngOnChanges(inputs) {
    ;
  }


  loadConfiguration_View(group, config)
  {
    for (var i in config)
    {
      var field = config[i];

        if (typeof this.activeElement[group] === "undefined") {
          field.data = "";
          continue;
        }          
        
        var name = field.name;
        field.data = this.activeElement[group][name];



      /*
      switch (field.name)
      {
        case "label":

          if (typeof this.activeElement["display"] === "undefined") {
            field.data = "";
          }          
          
          field.data = this.activeElement["display"].label;
          break;

        case "placeholder":
          if (typeof this.activeElement["display"] === "undefined") {
            field.data = "";
          }   

          field.data = this.activeElement["display"].placeholder;
          break;

        case "prefix":
          if (typeof this.activeElement["display"] !== "undefined") {
            field.data = this.activeElement["display"].prefix;
          }   
          break;

        case "suffix":
          if (typeof this.activeElement["display"] === "undefined") {
            field.data = "";
          }   

          field.data = this.activeElement["display"].suffix;
          break;

        case "regularExpression":
          if (typeof this.activeElement["validation"] === "undefined") {
            field.data = "";
          }  

          field.data = this.activeElement["validation"].regexPattern;

          break;

        case "minimumLength":
          if (typeof this.activeElement["validation"] === "undefined") {
            field.data = "";
          }            
          
          field.data = this.activeElement["validation"].minimumLength;

          break;

        case "maximumLength":
          if (typeof this.activeElement["validation"] === "undefined") {
            field.data = "";
          }  

          field.data = this.activeElement["validation"].maximumLength;
          
          break;

        case "propertyName":
          if (typeof this.activeElement["api"] === "undefined") {
            field.data = "";
          }  

          field.data = this.activeElement["api"].propertyName;
          
          break;        
      }
      */
    }
  }

  loadConfiguration() {
    this._formFields = null;    
    this._formFieldsApi = null;
    this._formFieldsDisplay = null;
    this._formFieldsValidation = null;

    switch(this.activeElement["inputType"])
    {
      case 'input-text':
        this._formFields = InputTextDefinition;
        break; 

      case "number":
        this._formFields = InputNumberDefinition;
        break;

      case 'button':
        this._formFields = ButtonDefinition;
        break;

      case "input-password":
        this._formFields = InputPasswordDefinition;
        break;

      case "dropdown": 
        this._formFields = InputDropdownDefinition;
        break;
    }

    if (this._formFields == null)
    {
      return;
    }

    if (typeof this._formFields["displayData"] !== "undefined")
    {
      this._formFieldsDisplay = this._formFields["displayData"];
      this.loadConfiguration_View("display", this._formFieldsDisplay);
    }

    if (typeof this._formFields["api"] !== "undefined")
    {
      this._formFieldsApi = this._formFields["api"];
      this.loadConfiguration_View("api", this._formFieldsApi);
    }
    
    if (typeof this._formFields["validation"] !== "undefined")
    {
      this._formFieldsValidation = this._formFields["validation"];
      this.loadConfiguration_View("validation", this._formFieldsValidation);
    }

    /*

    switch(this.activeElement["inputType"])
    {
      case 'input-text':

        this._configuration = new textboxConfiguration();
         
        if (typeof this.activeElement["validation"] !== "undefined") {
          this._configuration.validationRequired = this.activeElement["validation"].required;
          this._configuration.validationMinimumLength = this.activeElement["validation"].minimumLength;
          this._configuration.validationMaximumLength = this.activeElement["validation"].maximumLength;
          this._configuration.validationRegexPattern = this.activeElement["validation"].regexPattern;
        }

        if (typeof this.activeElement["api"] !== "undefined") {
          this._configuration.apiPropertyName = this.activeElement["api"].propertyName;
        }

        break;
    }
    */
  }

  saveElement_Views(group, config)
  {

    for (var i in config)
    {
      var field = config[i];

      if (this.activeElement[group] == "" || typeof this.activeElement[group] === "undefined")
      {
        var name = field.name;

        // this.activeElement[group] =  { name : field.data }; // der auskommentierte Code geht nicht, weil nicht der Inhalt der Variable im JSON steht sondern der Variablenname

        this.activeElement[group] = {};
        this.activeElement[group][name] = field.data;
      }
      else 
      {
        if (typeof this.activeElement[group][field.name] === "undefined" && typeof field.data === "undefined"){
          continue;          
        }
        
        this.activeElement[group][field.name] = field.data;
      }

      /*
      switch (field.name)
      {

        case "label":
          if (this.activeElement["display"] == "")
          {
            this.activeElement["display"] =  { "label" : field.data };
          }
          else 
          {
            this.activeElement["display"].label = field.data;
          }
            
          break;

        case "placeholder":
          if (this.activeElement["display"] == "")
          {
            this.activeElement["display"] =  { "placeholder" : field.data };
          }
          else 
          {
            this.activeElement["display"]["placeholder"] = field.data;
          }

          break;

        case "prefix":
          if (this.activeElement["display"] == "")
          {
            this.activeElement["display"] =  { "prefix" : field.data };
          }
          else
          {
            this.activeElement["display"].prefix = field.data;
          }

          break;

        case "suffix":
          if (this.activeElement["display"] == "")
          {
            this.activeElement["display"] =  { "suffix" : field.data };
          }
          else 
          {
            this.activeElement["display"].suffix = field.data;
          }
          
          break;

        case "regularExpression":
          if (typeof this.activeElement["validation"] === "undefined")
          {
            this.activeElement.validation = {};
          }

          if (this.activeElement["validation"] == "")
          {
            this.activeElement["validation"] =  { "regexPattern" : field.data };
          }
          else 
          {
            this.activeElement["validation"].regexPattern = field.data;
          }
          
          break;

        case "minimumLength":
          if (typeof this.activeElement["validation"] === "undefined")
          {
            this.activeElement.validation = {};
          }
          
          if (this.activeElement["validation"] == "")
          {
            this.activeElement["validation"] =  { "minimumLength" : field.data };
          }
          else 
          {
            this.activeElement["validation"].minimumLength = field.data;
          }
          
          break;

        case "maximumLength":
          //alert("K");
          if (typeof this.activeElement["validation"] === "undefined")
          {
            this.activeElement.validation = {};
          }

          if (this.activeElement["validation"] == "")
          {
            this.activeElement["validation"] =  { "maximumLength" : field.data };
          }
          else 
          {
            this.activeElement["validation"].maximumLength = field.data;
          }
          
          break;
          
        case "propertyName":
          if (typeof this.activeElement["api"] === "undefined")
          {
            this.activeElement.api = {};
          }

          if (this.activeElement["api"] == "")
          {
            this.activeElement["api"] =  { "propertyName" : field.data };
          }
          else 
          {
            this.activeElement["api"].propertyName = field.data;
          }
          
          break;
      }
      */
    }
  }

  saveElement(){

    if (this._formFieldsDisplay != null)
    {
      this.saveElement_Views("display", this._formFieldsDisplay);
    }
    
    if (this._formFieldsValidation != null)
    {
      this.saveElement_Views("validation", this._formFieldsValidation);
    }
    
    if (this._formFieldsApi != null)
    {
      this.saveElement_Views("api", this._formFieldsApi);
    }
 
    
    //this.activeElement["api"] = {propertyName: this._configuration.apiPropertyName};

    this.afterSave.emit(this._activeElement);

  }

  configureElement(model){
    this.activeElement = model;
    this.loadConfiguration();
    //this.displayDialog = true;
  }

  deleteElement(model){
    this.delete.emit(this._activeElement);
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

