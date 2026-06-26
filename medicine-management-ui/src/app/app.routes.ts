import { Routes } from '@angular/router';
import { MedicinesComponent } from './features/medicines/pages/medicines/medicines.component';

export const routes: Routes = [
  {
    path: '',
    component: MedicinesComponent
  },
  {
    path: '**',
    redirectTo: ''
  }
];