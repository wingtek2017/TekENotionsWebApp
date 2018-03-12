import { Component, OnInit } from "@angular/core";

import { Pattern } from "./pattern";
import { PatternService } from "./pattern.service";

import { PatternSearch } from "./patternSearch";
import {Needle} from "../needle/needle";
import { NeedleService } from "../needle/needle.service";

@Component({
    templateUrl: "./pattern-list.component.html",
    styleUrls: ["./pattern-list.component.css"]
})
export class PatternListComponent implements OnInit {
    constructor(private patternService: PatternService,
        private needleService: NeedleService) {
    }

    ngOnInit() {

        this.searchEntity.needleSizeId = 0;

        this.getPatterns();
        this.getSearchNeedles();
    }

    // Public properties
    patterns: Pattern[] = [];
    messages: string[] = [];
    searchNeedles: Needle[] = [];
    searchEntity: PatternSearch = new PatternSearch();

    private getPatterns() {
        this.patternService.getPatterns()
            .subscribe(patterns => this.patterns = patterns,
            errors => this.handleErrors(errors));
    }

    search() {
        this.patternService.search(this.searchEntity)
            .subscribe(patterns => this.patterns = patterns,
            errors => this.handleErrors(errors));
    }

    resetSearch() {
        this.searchEntity.needleSizeId = 0;
        this.searchEntity.patternName = "";
        this.getPatterns();
    }
    private getSearchNeedles() {
        this.needleService.getSearchNeedles()
            .subscribe(needles => this.searchNeedles = needles,
        errors => this.handleErrors(errors))
    }


    private handleErrors(errors: any) {
        this.messages = [];

        for (let msg of errors) {
            this.messages.push(msg);
        }
    }
}