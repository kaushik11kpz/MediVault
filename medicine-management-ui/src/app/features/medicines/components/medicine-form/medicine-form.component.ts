import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output, inject } from '@angular/core';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';

import { Medicine } from '../../../../models/medicine';

@Component({
  selector: 'app-medicine-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './medicine-form.component.html',
  styleUrl: './medicine-form.component.scss'
})
export class MedicineFormComponent {

  @Output()
  medicineAdded = new EventEmitter<Medicine>();

  private readonly fb = inject(FormBuilder);

  medicineForm = this.fb.group({
    fullName: ['', Validators.required],
    brand: ['', Validators.required],
    price: [0, [Validators.required, Validators.min(0.01)]],
    quantity: [0, [Validators.required, Validators.min(0)]],
    expiryDate: ['', Validators.required],
    notes: ['']
  });

  onSubmit(): void {

    if (this.medicineForm.invalid) {
      this.medicineForm.markAllAsTouched();
      return;
    }

    const medicine: Medicine = {
      id: 0,
      fullName: this.medicineForm.value.fullName!,
      brand: this.medicineForm.value.brand!,
      price: this.medicineForm.value.price!,
      quantity: this.medicineForm.value.quantity!,
      expiryDate: this.medicineForm.value.expiryDate!,
      notes: this.medicineForm.value.notes ?? ''
    };

    this.medicineAdded.emit(medicine);

    this.medicineForm.reset({
      fullName: '',
      brand: '',
      price: 0,
      quantity: 0,
      expiryDate: '',
      notes: ''
    });

  }

}