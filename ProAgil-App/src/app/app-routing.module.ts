import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { ContatosComponent } from './contatos/contatos.component';
import { DashboardComponent } from './dashboard/dashboard.component';

// configuracoes de rotas, referenciado no app.module e importado os componentes

const routes: Routes = [

  {path: 'evento', component: EventosComponent},
  {path: 'palestrantes', component: PalestrantesComponent},
  {path: 'contatos', component: ContatosComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: '', redirectTo : 'dashboard', pathMatch: 'full'}, // vai para dash se nada por passado
  {path: '**', redirectTo: 'dashboard', pathMatch: 'full'} // vai para dash se algo invalido for passado
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
