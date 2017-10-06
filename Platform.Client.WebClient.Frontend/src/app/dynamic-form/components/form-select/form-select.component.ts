import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { Field } from '../../models/field.interface';
import { FieldConfig } from '../../models/field-config.interface';

@Component({
    selector: 'form-select',
    styleUrls: ['form-select.component.scss'],
    templateUrl: './form-select.component.html'
})
export class FormSelectComponent implements Field {
    config: FieldConfig;
    group: FormGroup;

    showValidation: boolean = false;


    inputChanged() {
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