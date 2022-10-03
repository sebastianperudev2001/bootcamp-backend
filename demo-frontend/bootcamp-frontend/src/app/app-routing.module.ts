import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonModule } from './person/person.module';

const routes: Routes = [
  {path: 'person',
  loadChildren: () => import ('./person/person.module').then((x => x.PersonModule ))
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
