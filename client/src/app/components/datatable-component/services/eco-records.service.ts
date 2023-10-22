import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {GetAllRequestModel} from "../models/get-all-request.model";
import {DeleteRequestModel} from "../models/delete-request.model";

@Injectable({
  providedIn: 'root',
})
export class EcoRecordsService {
  private baseUrl = 'http://localhost:5259/api';

  constructor(private http: HttpClient) {}

  getAllEcoRecords(getAllreq: GetAllRequestModel): Observable<any> {
    return this.http.post(`${this.baseUrl}/url/getAllEcoRecords`, getAllreq);
  }
  deleteEcoRecord(dellreq: string): Observable<any> {
    return this.http.delete(`${this.baseUrl}/EcoRecordAuthorize/deleteEcoRecord/`+dellreq);
  }
  getUrlDetails(id: string ): Observable<any> {
    return this.http.get(`${this.baseUrl}/UrlAuthorize/details/`+id);
  }
}
