import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

import { Medicine } from '../../../../models/medicine';

@Component({
  selector: 'app-medicine-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './medicine-list.component.html',
  styleUrl: './medicine-list.component.scss'
})
export class MedicineListComponent {

  @Input({ required: true })
  medicines: Medicine[] = [];

  isExpiringSoon(expiryDate: string): boolean {

    const expiry = new Date(expiryDate);

    const today = new Date();

    const difference =
      expiry.getTime() - today.getTime();

    const days =
      difference / (1000 * 60 * 60 * 24);

    return days <= 30;

  }

  isLowStock(quantity: number): boolean {

    return quantity < 10;

  }

}