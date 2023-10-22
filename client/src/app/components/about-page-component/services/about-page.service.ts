import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AboutPageService {
  private baseUrl = 'http://localhost:5259/api'
  constructor(private http: HttpClient) { }

  getAbout(): Observable<any> {
    return this.http.get(`${this.baseUrl}/url/getAbout`);
  }

  setAbout(text:string): Observable<any> {
    return this.http.get(`${this.baseUrl}/urladmin/writeAbout/`+text);
  }
}
