import { ValidatorFn } from '@angular/forms';

export interface FieldConfig {
    disabled?: boolean,
    name: string,
    options?: string[],
    placeholder?: string,
    type: string,
    validation?: ValidationConfig,
    value?: any
    display: DisplayConfig,
    layout: LayoutConfig,
    api?: ApiConfig
    conditional: ConditionalConfig,
    data?: DataConfig
}

interface DisplayConfig {
    label: string,
    placeholder?: string
}

interface ApiConfig {
    field? : string
}

interface LayoutConfig {

}

interface ConditionalConfig {

}

interface DataConfig {
    defaultValue?: string
}

interface ValidationConfig {
    required: boolean;
}