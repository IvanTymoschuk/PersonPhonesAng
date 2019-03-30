import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { PhonesService } from './services/phones.service';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { MatButtonModule, MatMenuModule, MatDatepickerModule } from '@angular/material';
import { MatNativeDateModule, MatIconModule, MatCardModule } from '@angular/material';
import { MatSidenavModule, MatFormFieldModule, MatInputModule } from '@angular/material';
import { MatTooltipModule, MatToolbarModule } from '@angular/material';
import { MatPaginatorModule } from '@angular/material/paginator';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PhonesComponent } from './components/phones/phones.component';


@NgModule({
  declarations: [
    AppComponent,
    PhonesComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatMenuModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatPaginatorModule,
    MatCardModule,
    MatSidenavModule,
    MatFormFieldModule,
    MatInputModule,
    MatTooltipModule,
    MatToolbarModule,
    AppRoutingModule
  ],
  providers: [
    HttpClientModule,
    PhonesService,
    MatDatepickerModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
