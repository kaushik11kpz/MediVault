import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { Medicine } from '../../../../models/medicine';
import { MedicineService } from '../../../../core/services/medicine.service';
import { MedicineFormComponent } from '../../components/medicine-form/medicine-form.component';
import { MedicineListComponent } from '../../components/medicine-list/medicine-list.component';

@Component({
  selector: 'app-medicines',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MedicineFormComponent,
    MedicineListComponent
  ],
  templateUrl: './medicines.component.html',
  styleUrl: './medicines.component.scss'
})
export class MedicinesComponent implements OnInit {

  private readonly medicineService = inject(MedicineService);

  medicines: Medicine[] = [];

  searchText = '';

  ngOnInit(): void {
    this.loadMedicines();
  }

  get filteredMedicines(): Medicine[] {

    if (!this.searchText.trim()) {
      return this.medicines;
    }

    return this.medicines.filter(medicine =>
      medicine.fullName
        .toLowerCase()
        .includes(this.searchText.toLowerCase())
    );

  }

  loadMedicines(): void {

    this.medicineService.getAllMedicines().subscribe({

      next: medicines => {

        this.medicines = medicines;

      },

      error: error => {

        console.error(error);

      }

    });

  }

  onMedicineAdded(medicine: Medicine): void {

    this.medicineService.addMedicine(medicine).subscribe({

      next: () => {

        this.loadMedicines();

      },

      error: error => {

        console.error(error);

      }

    });

  }

}