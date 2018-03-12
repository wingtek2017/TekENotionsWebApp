"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var platform_browser_1 = require("@angular/platform-browser");
var http_1 = require("@angular/http");
var forms_1 = require("@angular/forms");
var app_component_1 = require("./app.component");
var app_routing_module_1 = require("./app-routing.module");
var pattern_list_component_1 = require("./pattern/pattern-list.component");
var pattern_service_1 = require("./pattern/pattern.service");
var needle_service_1 = require("./needle/needle.service");
var framework_config_service_1 = require("./fw/services/framework-config.service");
var menu_service_1 = require("./fw/services/menu.service");
var menu_component_1 = require("./fw/menus/menu/menu.component");
var menu_item_component_1 = require("./fw/menus/menu-item/menu-item.component");
var title_bar_component_1 = require("./fw/title-bar/title-bar.component");
var top_bar_component_1 = require("./fw/top-bar/top-bar.component");
var status_bar_component_1 = require("./fw/status-bar/status-bar.component");
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        core_1.NgModule({
            imports: [platform_browser_1.BrowserModule, app_routing_module_1.AppRoutingModule, http_1.HttpModule, forms_1.FormsModule],
            declarations: [app_component_1.AppComponent, pattern_list_component_1.PatternListComponent, title_bar_component_1.TitleBarComponent, top_bar_component_1.TopBarComponent, status_bar_component_1.StatusBarComponent, menu_component_1.MenuComponent, menu_item_component_1.MenuItemComponent],
            bootstrap: [app_component_1.AppComponent],
            providers: [pattern_service_1.PatternService, needle_service_1.NeedleService, framework_config_service_1.FrameworkConfigService, menu_service_1.MenuService]
        })
    ], AppModule);
    return AppModule;
}());
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map