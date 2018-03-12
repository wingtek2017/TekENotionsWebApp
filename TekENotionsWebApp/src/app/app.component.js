"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var framework_config_service_1 = require("./fw/services/framework-config.service");
var menu_service_1 = require("./fw/services/menu.service");
var app_menu_1 = require("./app.menu");
var AppComponent = /** @class */ (function () {
    function AppComponent(frameworkConfigService, menuService) {
        this.frameworkConfigService = frameworkConfigService;
        this.menuService = menuService;
        var config = {
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
        menuService.items = app_menu_1.initialMenuItems;
    }
    AppComponent = __decorate([
        core_1.Component({
            selector: 'ptc-app',
            templateUrl: './app.component.html',
            styleUrls: ['./app.component.css']
        }),
        __metadata("design:paramtypes", [framework_config_service_1.FrameworkConfigService, menu_service_1.MenuService])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map