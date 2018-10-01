import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'

import { AppComponent } from './app.component';
import { DispComponent } from './disp/disp.component';
import { DispcComponent } from './dispc/dispc.component';

@NgModule({
  declarations: [
    AppComponent,
    DispComponent,
    DispcComponent
  ],
  imports: [
    BrowserModule,FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
