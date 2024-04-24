import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { DietaService } from '../../servicos/dietaService/dieta.service';
import { HistoricoComponent } from '../../componentes/historico/historico.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule, HistoricoComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css',
})
export class HomeComponent {
  dieta: any;
  nome: string = '';
  dietaDisponivel: boolean = true;
  historicoDisponivel: boolean = true;

  constructor(private rota: Router, private dietaService: DietaService) {}

  // formularioDieta = new FormGroup({
  //   nome: new FormControl('', [Validators.required, Validators.minLength(8), Validators.pattern(/^[a-zA-Z ]+$/)]),
  //   cpf: new FormControl('', Validators.required),
  //   idade: new FormControl('', Validators.required),
  //   sexo: new FormControl('', Validators.required),
  //   altura: new FormControl('', Validators.required),
  //   peso: new FormControl('', Validators.required),
  // });

  formularioDieta = new FormGroup({
    nome: new FormControl('', [
      Validators.required,
      Validators.minLength(8),
      Validators.pattern(/^[a-zA-Z ]+$/),
    ]),
    cpf: new FormControl('', [
      Validators.required,
      Validators.pattern(/^\d{11}$/),
    ]),
  });

  criarPrompt(): void {
    if (this.formularioDieta.valid) {
      const nome = this.formularioDieta.get('nome')?.value;
      const cpf = this.formularioDieta.get('cpf')?.value;

      if (nome && cpf) {
        this.nome = nome;
        this.dietaService
          .criarPrompt({
            Nome: nome,
            Cpf: cpf,
          })
          .subscribe((dieta) => {
            this.dieta = dieta.resposta;
            this.dietaDisponivel = true;
            this.formularioDieta.reset();

            setTimeout(() => {
              const dietaSection = document.getElementById('dietaSection');
              if (dietaSection) {
                dietaSection.scrollIntoView({ behavior: 'smooth' });
              }
            }, 100);
          });
      }
      // else {
      //   alert('Por favor, preencha todos os campos corretamente.');
      // }
    } else {
      this.formularioDieta.markAllAsTouched();
    }
  }

  openHistorico(): void {
    this.historicoDisponivel = true;
  }

  closeHistorico(): void {
    this.historicoDisponivel = false;
  }
}
