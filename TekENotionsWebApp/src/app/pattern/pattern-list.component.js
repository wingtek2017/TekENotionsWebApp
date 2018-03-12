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
var pattern_service_1 = require("./pattern.service");
var patternSearch_1 = require("./patternSearch");
var needle_service_1 = require("../needle/needle.service");
var PatternListComponent = /** @class */ (function () {
    function PatternListComponent(patternService, needleService) {
        this.patternService = patternService;
        this.needleService = needleService;
        // Public properties
        this.patterns = [];
        this.messages = [];
        this.searchNeedles = [];
        this.searchEntity = new patternSearch_1.PatternSearch();
    }
    PatternListComponent.prototype.ngOnInit = function () {
        this.searchEntity.needleSizeId = 0;
        this.getPatterns();
        this.getSearchNeedles();
    };
    PatternListComponent.prototype.getPatterns = function () {
        var _this = this;
        this.patternService.getPatterns()
            .subscribe(function (patterns) { return _this.patterns = patterns; }, function (errors) { return _this.handleErrors(errors); });
    };
    PatternListComponent.prototype.search = function () {
        var _this = this;
        this.patternService.search(this.searchEntity)
            .subscribe(function (patterns) { return _this.patterns = patterns; }, function (errors) { return _this.handleErrors(errors); });
    };
    PatternListComponent.prototype.resetSearch = function () {
        this.searchEntity.needleSizeId = 0;
        this.searchEntity.patternName = "";
        this.getPatterns();
    };
    PatternListComponent.prototype.getSearchNeedles = function () {
        var _this = this;
        this.needleService.getSearchNeedles()
            .subscribe(function (needles) { return _this.searchNeedles = needles; }, function (errors) { return _this.handleErrors(errors); });
    };
    PatternListComponent.prototype.handleErrors = function (errors) {
        this.messages = [];
        for (var _i = 0, errors_1 = errors; _i < errors_1.length; _i++) {
            var msg = errors_1[_i];
            this.messages.push(msg);
        }
    };
    PatternListComponent = __decorate([
        core_1.Component({
            templateUrl: "./pattern-list.component.html",
            styleUrls: ["./pattern-list.component.css"]
        }),
        __metadata("design:paramtypes", [pattern_service_1.PatternService,
            needle_service_1.NeedleService])
    ], PatternListComponent);
    return PatternListComponent;
}());
exports.PatternListComponent = PatternListComponent;
//# sourceMappingURL=pattern-list.component.js.map