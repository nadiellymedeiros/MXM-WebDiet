import { Component } from '@angular/core';
import { NavbarComponent } from '../../componentes/navbar/navbar.component';

@Component({
  selector: 'app-dieta',
  standalone: true,
  imports: [NavbarComponent],
  templateUrl: './dieta.component.html',
  styleUrl: './dieta.component.css',
})
export class DietaComponent {}
