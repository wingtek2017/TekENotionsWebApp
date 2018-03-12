import { Component } from '@angular/core';

import { FrameworkConfigService, FrameworkConfigSettings } from './fw/services/framework-config.service';
import { MenuService } from './fw/services/menu.service';
import { initialMenuItems } from './app.menu';

@Component({
    selector: 'ptc-app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {

    constructor(private frameworkConfigService: FrameworkConfigService, private menuService: MenuService) {

        let config: FrameworkConfigSettings = {
            socialIcons: [

                { imageFile: 'assets/social-fb-bw.png', alt: 'Facebook', link: 'http://www.facebook.com' },
                { imageFile: 'assets/social-google-bw.png', alt: 'Google +', link: 'http://www.google.com' }
            ],
            showLanguageSelector: false,
            showUserControls: true,
            showStatusBar: true,
            showStatusBarBreakpoint: 800
        };

        frameworkConfigService.configure(config);

        menuService.items = initialMenuItems;
       

    }
}
