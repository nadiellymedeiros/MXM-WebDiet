import { Routes } from '@angular/router';
import { HomeComponent } from './paginas/home/home.component';
import { DietaComponent } from './paginas/dieta/dieta.component';

export const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'dieta', component: DietaComponent },
];
