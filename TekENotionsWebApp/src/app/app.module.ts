import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpModule} from '@angular/http';
import {FormsModule} from '@angular/forms'

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { PatternListComponent } from './pattern/pattern-list.component'
import { PatternService } from './pattern/pattern.service';
import { NeedleService } from './needle/needle.service';
import { FrameworkConfigService } from './fw/services/framework-config.service';
import { MenuService } from './fw/services/menu.service';
import { MenuComponent } from './fw/menus/menu/menu.component';
import { MenuItemComponent } from './fw/menus/menu-item/menu-item.component';


import { FwModule } from './fw/fw.module';
import { TitleBarComponent } from './fw/title-bar/title-bar.component';
import { TopBarComponent } from './fw/top-bar/top-bar.component';
import { StatusBarComponent } from './fw/status-bar/status-bar.component';



@NgModule({
  imports:      [ BrowserModule, AppRoutingModule, HttpModule, FormsModule ],
  declarations: [ AppComponent, PatternListComponent, TitleBarComponent, TopBarComponent, StatusBarComponent, MenuComponent, MenuItemComponent ],
  bootstrap: [AppComponent],
  providers: [PatternService, NeedleService, FrameworkConfigService, MenuService]
})

export class AppModule { }
