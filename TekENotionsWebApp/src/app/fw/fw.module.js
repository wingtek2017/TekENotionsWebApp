"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var common_1 = require("@angular/common");
var framework_config_service_1 = require("./services/framework-config.service");
var menu_service_1 = require("./services/menu.service");
var framework_body_component_1 = require("./framework-body/framework-body.component");
var content_component_1 = require("./content/content.component");
var title_bar_component_1 = require("./title-bar/title-bar.component");
var top_bar_component_1 = require("./top-bar/top-bar.component");
var status_bar_component_1 = require("./status-bar/status-bar.component");
var FwModule = /** @class */ (function () {
    function FwModule() {
    }
    FwModule = __decorate([
        core_1.NgModule({
            imports: [
                common_1.CommonModule
            ],
            declarations: [
                framework_body_component_1.FrameworkBodyComponent,
                content_component_1.ContentComponent,
                title_bar_component_1.TitleBarComponent,
                top_bar_component_1.TopBarComponent,
                status_bar_component_1.StatusBarComponent
            ],
            providers: [
                framework_config_service_1.FrameworkConfigService,
                menu_service_1.MenuService
            ],
            exports: [
                framework_body_component_1.FrameworkBodyComponent
            ]
        })
    ], FwModule);
    return FwModule;
}());
exports.FwModule = FwModule;
//# sourceMappingURL=fw.module.js.map