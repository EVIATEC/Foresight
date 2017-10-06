import { Component, ViewContainerRef } from '@angular/core';
import { FormGroup } from '@angular/forms';

import { Field } from '../../models/field.interface';
import { FieldConfig } from '../../models/field-config.interface';

@Component({
    selector: 'form-input',
    //styleUrls: ['form-input.component.scss'],

    templateUrl: './form-form.component.html'
})
export class FormFormComponent implements Field {
    config: FieldConfig;
    group: FormGroup;

    showValidators()
    { }
}