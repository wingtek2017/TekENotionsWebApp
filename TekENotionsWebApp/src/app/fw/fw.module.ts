import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FrameworkConfigService } from './services/framework-config.service';
import { MenuService} from './services/menu.service';

import { FrameworkBodyComponent } from './framework-body/framework-body.component';
import { ContentComponent} from './content/content.component';
import { TitleBarComponent } from './title-bar/title-bar.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { StatusBarComponent } from './status-bar/status-bar.component';


@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
      FrameworkBodyComponent,
      ContentComponent,
      TitleBarComponent,
      TopBarComponent,
      StatusBarComponent
  ],
  providers: [
      FrameworkConfigService,
      MenuService
  ],
  exports: [
    FrameworkBodyComponent
  ]
})
export class FwModule { }
