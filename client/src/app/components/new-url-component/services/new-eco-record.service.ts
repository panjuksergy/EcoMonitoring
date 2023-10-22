import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CreateEcoRecordlModel} from "../models/create-eco-recordl.model";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class NewEcoRecordService {
  private baseUrl = 'http://localhost:5259/api/EcoRecordAuthorize';

  constructor(private http: HttpClient, ) { }

  public createNewEcoRecord(req: CreateEcoRecordlModel): Observable<any>{
    return this.http.post(`${this.baseUrl}/createEcoRecord`,req);
  }
}
