﻿import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

import { Needle } from "./needle";

@Injectable()
export class NeedleService {
  private url = "/api/needleApi";

  constructor(private http: Http) {
  }

  getSearchNeedles(): Observable<Needle[]> {
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });

    return this.http.post(this.url + "/SearchNeedlesTypes", null, options)
      .map(this.extractData)
      .catch(this.handleErrors);
  }

  private extractData(res: Response) {
    let body = res.json();
    return body || {};
  }

  private handleErrors(error: any): Observable<any> {
    let errors: string[] = [];

    switch (error.status) {
      case 400: // Bad Request
        let err = error.json();
        if (err.message) {
          errors.push(err.message);
        }
        else {
          errors.push("An Unknown error occurred.");
        }
        break;

      case 404: // Not Found
        errors.push("No Category Data Is Available.");
        break;

      case 500: // Internal Error
        errors.push(error.json().exceptionMessage);
        break;

      default:
        errors.push("Status: " + error.status
          + " - Error Message: "
          + error.statusText);
        break;
    };

    console.error('An error occurred', errors);

    return Observable.throw(errors);
  }
}