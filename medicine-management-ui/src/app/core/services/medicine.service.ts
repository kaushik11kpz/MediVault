import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Medicine } from '../../models/medicine';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MedicineService {

  private readonly http = inject(HttpClient);

  private readonly apiUrl = `${environment.apiUrl}/Medicines`;

  getAllMedicines(): Observable<Medicine[]> {
    return this.http.get<Medicine[]>(this.apiUrl);
  }

  getMedicineById(id: number): Observable<Medicine> {
    return this.http.get<Medicine>(`${this.apiUrl}/${id}`);
  }

  addMedicine(medicine: Medicine): Observable<Medicine> {
    return this.http.post<Medicine>(this.apiUrl, medicine);
  }

  updateMedicine(medicine: Medicine): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${medicine.id}`, medicine);
  }

  deleteMedicine(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}