import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration, withEventReplay } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomDirectivesDirective } from './custom-directives.directive';
import { HoverDirective } from './hover.directive';
import { HostbindingDirective } from './hostbinding.directive';

@NgModule({
  declarations: [
    AppComponent,
    CustomDirectivesDirective,
    HoverDirective,
    HostbindingDirective
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideClientHydration(withEventReplay())
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
