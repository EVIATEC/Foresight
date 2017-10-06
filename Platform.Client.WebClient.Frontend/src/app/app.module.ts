import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';

import { HomeComponent } from './components/home/home.component';
import { EventListComponent } from './components/events/event-list.component';
import { EventRegistrationComponent } from './components/events/event-registration.component';
import { EventSuccessComponent } from './components/events/event-success.component';
import { ProfileListComponent } from './components/profile/profile-list.component';
import { DynamicFormModule } from './dynamic-form/dynamic-form.module';
import { PageContentComponent } from './components/content/page-content.component';
import { FeedbackComponent } from './components/feedback/feedback.component';
import { ImprovementComponent } from './components/improvements/improvement.component';

import {
  DataTableModule,
  SharedModule,
  TooltipModule
} from 'primeng/primeng';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    EventListComponent,
    EventRegistrationComponent,
    EventSuccessComponent,
    ProfileListComponent,
    PageContentComponent,
    FeedbackComponent,
    ImprovementComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    DataTableModule,
    SharedModule,
    TooltipModule,
    DynamicFormModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'events', component: EventListComponent },
      { path: 'events/:id', component: EventRegistrationComponent },
      { path: 'events/:id/success', component: EventSuccessComponent },
      { path: 'profile', component: ProfileListComponent },
      { path: 'content/:id', component: PageContentComponent},
      { path: 'feedback', component: FeedbackComponent},
      { path: 'improvement', component: ImprovementComponent},
      { path: '**', redirectTo: 'home' }
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
