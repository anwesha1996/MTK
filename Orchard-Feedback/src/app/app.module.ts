import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'
import { AppComponent } from './app.component';
import { FeedbackComponent } from './feedback/feedback.component';
import { FeedbackFormComponent } from './feedback-form/feedback-form.component';
import { FeedbackCommentsComponent } from './feedback-comments/feedback-comments.component';

@NgModule({
  declarations: [
    AppComponent,
    FeedbackComponent,
    FeedbackFormComponent,
    FeedbackCommentsComponent
  ],
  imports: [
    BrowserModule,FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
