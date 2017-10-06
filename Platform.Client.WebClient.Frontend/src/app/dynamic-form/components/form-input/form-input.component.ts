import { Component, ViewContainerRef, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { Field } from '../../models/field.interface';
import { FieldConfig } from '../../models/field-config.interface';

@Component({
    selector: 'form-input',
    styleUrls: ['form-input.component.scss'],
    templateUrl: './form-input.component.html'
})
export class FormInputComponent implements Field, OnInit {

    ngOnInit() {
        this.inputChanged();
    }

    config: FieldConfig;
    group: FormGroup;

    showValidation: boolean = false;


    inputChanged()
    {
        if (this.config.validation != null &&
            this.config.validation.required) {
            
            if (this.group.controls[this.config.name].value == null) {
                this.showValidation = false; 
                return;
            }

            if (this.group.controls[this.config.name].value.trim() == "") {
                this.showValidation = true;
                return;
            }
        }

        this.showValidation = false; 
    }

    showValidators()
    { this.inputChanged(); }
}