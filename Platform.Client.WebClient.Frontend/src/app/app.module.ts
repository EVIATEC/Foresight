import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import {OrganizationChartModule} from '../../node_modules/primeng/components/organizationchart/organizationchart';

import { HomeComponent } from './components/home/home.component';
import { EventListComponent } from './components/events/event-list.component';
import { EventRegistrationComponent } from './components/events/event-registration.component';
import { EventSuccessComponent } from './components/events/event-success.component';
import { ProfileListComponent } from './components/profile/profile-list.component';
import { DynamicFormModule } from './dynamic-form/dynamic-form.module';
import { PageContentComponent } from './components/content/page-content.component';
import { FeedbackComponent } from './components/feedback/feedback.component';
import { FeedbackSuccessComponent } from './components/feedback/feedback-success.component';
import { ImprovementComponent } from './components/improvements/improvement.component';
import { ImprovementSuccessComponent } from './components/improvements/improvement-success.component';
import { StaffCouncilComponent } from './components/staffcouncil/staffcouncil.component';
import { StaffCouncilSuccessComponent } from './components/staffcouncil/staffcouncil-success.component';
import { OrgChartComponent } from './components/orgchart/orgchart.component';

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
    FeedbackSuccessComponent,
    ImprovementComponent,
    ImprovementSuccessComponent,
    StaffCouncilComponent,
    StaffCouncilSuccessComponent,
    OrgChartComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    DataTableModule,
    SharedModule,
    TooltipModule,
    DynamicFormModule,
    OrganizationChartModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'events', component: EventListComponent },
      { path: 'events/:id', component: EventRegistrationComponent },
      { path: 'events/:id/success', component: EventSuccessComponent },
      { path: 'profile', component: ProfileListComponent },
      { path: 'content/:id', component: PageContentComponent},
      { path: 'feedback', component: FeedbackComponent},
      { path: 'feedback/success', component: FeedbackSuccessComponent},
      { path: 'improvement', component: ImprovementComponent},
      { path: 'improvement/success', component: ImprovementSuccessComponent},
      { path: 'staffcouncil', component: StaffCouncilComponent},
      { path: 'staffcouncil/success', component: StaffCouncilSuccessComponent},
      { path: 'orgchart', component: OrgChartComponent},
      { path: '**', redirectTo: 'home' }
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
