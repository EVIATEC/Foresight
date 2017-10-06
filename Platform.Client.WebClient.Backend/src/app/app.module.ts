import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { RouterModule } from '@angular/router';
import { RouterOutlet } from '@angular/router';
import { AppComponent } from './app.component';

import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { EJAngular2Module } from 'ej-angular2';
import { EventListComponent } from './components/event/event-list.component';
import { EventCreateComponent } from './components/event/event-create.component';
import { EventEditComponent } from './components/event/event-edit.component';
import { FormCreateComponent } from './components/form/form-create.component';
import { FormListComponent } from './components/form/form-list.component';
import { PageListComponent} from './components/page/page-list.component';
import { PageCreateComponent } from './components/page/page-create.component';
import { ProfileListComponent } from './components/profile/profile-list.component';
import { ProfileEditComponent } from './components/profile/profile-edit.component';  
import { FormTestComponent } from './components/form/form-test.component';


import { DropzoneModule } from 'ngx-dropzone-wrapper';


import { NgxDnDModule } from '@swimlane/ngx-dnd';
import { NgxUIModule } from '@swimlane/ngx-ui';

//import { FormContainerComponent } from './dynamic-forms/form-container/form-container.component';
import { FormFieldConfigurationComponent } from './eviatec-components/dynamic-forms/form-field-configuration/form-field-configuration.component';
import { InputTextComponent } from './eviatec-components/basic-components/input-text/input-text.component';
import { InputNumberComponent } from './eviatec-components/basic-components/input-number/input-number.component';
import { DropdownComponent } from './eviatec-components/basic-components/dropdown/dropdown.component';
import { InputPasswordComponent } from './eviatec-components/basic-components/input-password/input-password.component';
import { ButtonComponent } from './eviatec-components/basic-components/button/button.component';
import { FormFieldComponent } from './eviatec-components/dynamic-forms/form-field/form-field.component';
import { StaticTextComponent } from './eviatec-components/basic-components/static-text/static-text.component';
import { FormGeneratorComponent } from './eviatec-components/dynamic-forms/form-generator/form-generator.component';
import { FormFieldContainerComponent } from './eviatec-components/dynamic-forms/form-field-container/form-field-container.component';

import {
    BreadcrumbModule,
    DialogModule,
    TabViewModule,
    MultiSelectModule,
    FileUploadModule,
    ButtonModule,
    GrowlModule,
    CalendarModule,
    DragDropModule,
    ChipsModule,
    EditorModule,
    DataTableModule,
    SharedModule,
    ConfirmDialogModule,
    OverlayPanelModule,
    DropdownModule,
    SpinnerModule
} from 'primeng/primeng';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    EventListComponent,
    EventCreateComponent,
    EventEditComponent,
    FormCreateComponent,
    InputTextComponent,
    InputNumberComponent,
    ButtonComponent,
    FormFieldComponent,
    DropdownComponent,
    InputPasswordComponent,
    //FormContainerComponent,
    FormFieldConfigurationComponent,
    FormListComponent,
    PageListComponent,
    PageCreateComponent,
    FormTestComponent,
    ProfileListComponent,
    ProfileEditComponent,
    StaticTextComponent,
    FormGeneratorComponent,
    FormFieldContainerComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
      HttpModule,
      EJAngular2Module,
      NgxDnDModule,
      NgxUIModule,
      RouterModule.forRoot([
        { path: '', redirectTo: 'home', pathMatch: 'full' },
        { path: 'home', component: HomeComponent },
        { path: 'veranstaltungen', component: EventListComponent },
        { path: 'veranstaltungen/neu', component: EventCreateComponent },
        { path: 'veranstaltungen/:id', component: EventEditComponent },
        { path: 'form', component: FormListComponent},
        { path: 'form/neu', component: FormCreateComponent},
        { path: 'form/:id', component: FormCreateComponent},
        { path: 'page', component: PageListComponent},
        { path: 'page/neu', component: PageCreateComponent},
        { path: 'page/:id', component: PageCreateComponent},
        { path: 'profil', component: ProfileListComponent},
        { path: 'profil/neu', component: ProfileEditComponent},
        { path: 'profil/:id', component: ProfileEditComponent},
        { path: 'form-test/:id', component : FormTestComponent}


      ]),

      BreadcrumbModule,
      DialogModule,
      TabViewModule,
      MultiSelectModule,
      FileUploadModule,
      ButtonModule,
      GrowlModule,
      CalendarModule,
      DragDropModule,
      ChipsModule,
      EditorModule,
      DataTableModule,
      SharedModule,
      ConfirmDialogModule,
      DropzoneModule,
      OverlayPanelModule,
      DropdownModule,
      SpinnerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
