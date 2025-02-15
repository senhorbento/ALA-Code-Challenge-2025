import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPage } from './shared/pages/login-page/login-page';
import { ButtonPage } from './shared/pages/button-page/button-page';
import { FooPage } from './shared/pages/foo-page/foo-page';
import { BarPage } from './shared/pages/bar-page/bar-page';
import { AuthGuard } from './core/guard/auth-guard';

const routes: Routes = [
  { path: '', component: LoginPage },
  { path: 'button', component: ButtonPage, canActivate: [AuthGuard], data: { roles: ['admin',  'user'] } },
  { path: 'dropdownbutton/foo', component: FooPage, canActivate: [AuthGuard], data: { roles: ['admin'] } },
  { path: 'dropdownbutton/bar', component: BarPage, canActivate: [AuthGuard], data: { roles: ['admin'] } },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
