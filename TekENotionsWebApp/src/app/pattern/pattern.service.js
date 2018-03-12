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
var http_1 = require("@angular/http");
var Observable_1 = require("rxjs/Observable");
require("rxjs/add/operator/map");
require("rxjs/add/operator/catch");
require("rxjs/add/observable/throw");
var PatternService = (function () {
    function PatternService(http) {
        this.http = http;
        this.url = "/api/patternApi";
    }
    PatternService.prototype.getPatterns = function () {
        return this.http.get(this.url)
            .map(this.extractData)
            .catch(this.handleErrors);
    };
    PatternService.prototype.search = function (searchEntity) {
        var headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        var options = new http_1.RequestOptions({ headers: headers });
        return this.http.post(this.url + "/Search", searchEntity, options)
            .map(this.extractData)
            .catch(this.handleErrors);
    };
    PatternService.prototype.extractData = function (res) {
        var body = res.json();
        return body || {};
    };
    PatternService.prototype.handleErrors = function (error) {
        var errors = [];
        switch (error.status) {
            case 400:
                var err = error.json();
                if (err.message) {
                    errors.push(err.message);
                }
                else {
                    errors.push("An Unknown error occurred.");
                }
                break;
            case 404:
                errors.push("No Pattern Data Is Available.");
                break;
            case 500:
                errors.push(error.json().exceptionMessage);
                break;
            default:
                errors.push("Status: " + error.status
                    + " - Error Message: "
                    + error.statusText);
                break;
        }
        ;
        console.error('An error occurred', errors);
        return Observable_1.Observable.throw(errors);
    };
    return PatternService;
}());
PatternService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http])
], PatternService);
exports.PatternService = PatternService;
//# sourceMappingURL=pattern.service.js.map